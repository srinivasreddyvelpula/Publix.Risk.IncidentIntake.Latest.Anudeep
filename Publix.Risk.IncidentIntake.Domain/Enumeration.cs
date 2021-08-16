using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Publix.Risk.IncidentIntake.Domain
{
    [Serializable]
    [DebuggerDisplay("{DisplayName} - {Value}")]
    public abstract class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
        where TEnumeration : Enumeration<TEnumeration>
    {
        protected Enumeration(int value)
            : base(value)
        {
        }

        protected Enumeration(int value, string description)
            : base(value, description)
        {
        }

        public static TEnumeration? FromInt32(int value)
        {
            return FromValue(value);
        }

        public static bool TryFromInt32(int listItemValue, out TEnumeration? result)
        {
            return TryFromValue(listItemValue, out result);
        }
    }

    [Serializable]
    [DebuggerDisplay("{_value} - {Description}")]
    public abstract class Enumeration<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
        where TEnumeration : Enumeration<TEnumeration, TValue>
        where TValue : IComparable
    {
        private static readonly Lazy<TEnumeration[]> Enumerations = new Lazy<TEnumeration[]>(GetEnumerations);

        readonly string _description;

        readonly TValue _value;
        protected Enumeration(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;

            TEnumeration en = Enumerations.Value.Where(v => v.Value.Equals(value)).FirstOrDefault();
            if (en != null)
            {
                _description = en.Description;
            }
        }

        protected Enumeration(TValue value, string description)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;
            _description = description;
        }

        [JsonIgnore]
        public TValue Value
        {
            get { return _value; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int CompareTo(TEnumeration? other)
        {
            return Value.CompareTo(other != default(TEnumeration) ? other.Value : default(TValue));
        }

        public override sealed string ToString()
        {
            return $"{Value} - {Description}";
        }

        public static TEnumeration[] GetAll()
        {
            return Enumerations.Value;
        }

        private static TEnumeration[] GetEnumerations()
        {
            Type enumerationType = typeof(TEnumeration);
            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToArray();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TEnumeration);
        }

        public bool Equals(TEnumeration? other)
        {
            return other != default(TEnumeration) && ValueEquals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return !Equals(left, right);
        }

        public static TEnumeration? FromValue(TValue value)
        {
            return Parse(value, "value", item => item.Value.Equals(value));
        }

        public static TEnumeration? FromDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return null;
            }
            return Parse(description, "description", item => item.Description == description);
        }

        static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration? result)
        {
            result = GetAll().FirstOrDefault(predicate);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            return result != null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        private static TEnumeration? Parse(object value, string description, Func<TEnumeration, bool> predicate)
        {
            TEnumeration? result;

            if (!TryParse(predicate, out result))
            {
                string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(TEnumeration));
                throw new ArgumentException(message, "value");
            }

            return result;
        }

        public static bool TryFromValue(TValue value, out TEnumeration? result)
        {
            return TryParse(e => e.ValueEquals(value), out result);
        }

        public static bool TryFromDescription(string description, out TEnumeration? result)
        {
            return TryParse(e => e.Description == description, out result);
        }

        protected virtual bool ValueEquals(TValue value)
        {
            return Value.Equals(value);
        }
    }
}
