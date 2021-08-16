using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Publix.Risk.IncidentIntake.Domain
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> ToBatch<T>(this IList<T> elements, int size = 50000)
        {
            var list = elements.ToList();
            while (list.Count > 0)
            {
                var chunk = list.Take(size);
                yield return chunk;

                list = list.Skip(size).ToList();
            }
        }


        public static T GetFromName<T>(this List<T> list, string name) where T : Enumeration<T, int>
        {
            var field = typeof(T).GetProperties().FirstOrDefault(p => p.Name == "Name");
            if (field == null)
            {
                field = typeof(T).GetProperties().FirstOrDefault(p => p.Name == "Description");
            }

            if (field == null)
            {
                return null;
            }

            return list.FirstOrDefault(item => (string)field.GetValue(item) == name);
        }


        public static string FixWildcards(this string? input)
        {
            string temp = string.IsNullOrEmpty(input) ? "" : input.Replace("*", "%");

            if (temp.StartsWith("%"))
            {
                temp = temp.Substring(1);
            }

            if (temp.EndsWith("%"))
            {
                temp = temp.Substring(0, temp.Length - 1);
            }

            return temp;
        }


        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            using var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator.Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);

            string sql = "";

            if (command.Parameters.Any())
            {
                sql += "\r\n--Parameters: \r\n";
                foreach (IRelationalParameter p in command.Parameters)
                {
                    sql += $"\tDECLARE {p.InvariantName} [enter DB type here]\r\n\tSET {p.InvariantName} = '[enter value here]'\r\n";
                }
            }

            sql += "\r\n--SQL:\r\n" + command.CommandText;

            return sql;
        }


        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);


        public static string FindValue(this Dictionary<string, string> data, string possibleKey, bool throwIfNotFound = false)
        {
            if (data.ContainsKey(possibleKey))
            {
                return data[possibleKey];
            }

            foreach (string key in data.Keys)
            {
                string tempKey = key.ToLower();
                string possible = possibleKey.ToLower();

                if (tempKey.Equals(possible) || tempKey.StartsWith(possible))
                {
                    return data[key];
                }
            }

            if (throwIfNotFound)
            {
                throw new KeyNotFoundException($"{possibleKey} not found.");
            }

            return null;
        }

        public static string ToStringList(this IList<ValidationFailure> failures)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var failure in failures)
            {
                sb.AppendLine($"{failure.Severity.ToString().ToUpper()} - {failure.ErrorMessage} : {failure.AttemptedValue}");
            }

            return sb.ToString();
        }

        public static ApplicationException ToException(this IList<ValidationFailure> failures)
        {
            var ex = new ApplicationException("Failures occurred during Validation");

            foreach (var fail in failures)
            {
                ((IDictionary<string, object>)ex.Data).Add($"{fail.PropertyName}:{fail.Severity}", fail.ErrorMessage);
            }

            return ex;
        }
    }
}
