using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Publix.Risk.IncidentIntake.API.Pipelines
{
#pragma warning disable IDE1006 // Naming Styles
    internal class ErrorDetail
    {
        public ErrorDetail(string propertyName, string message)
        {
            this.propertyName = propertyName;
            this.message = message;
        }

        public string propertyName { get; }
        public string message { get; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public class ValidationExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                var error = new
                {
                    errors = validationException.Errors.Select(x => new ErrorDetail(x.PropertyName, x.ErrorMessage))
                };

                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(error);

                context.ExceptionHandled = true;
            }

            if (context.Exception is DbUpdateException dbUpdateException)
            {
                var errorMessage = dbUpdateException.Message;
                //Used Message because in test SQLite Error and in runtime SQL Server Error
                if (dbUpdateException.InnerException != null &&
                    (dbUpdateException.InnerException.Message.Contains("UNIQUE constraint failed") ||
                     dbUpdateException.InnerException.Message.Contains("duplicate key")))
                {
                    errorMessage = "Duplicate record";
                }

                var error = new
                {
                    message = errorMessage
                };

                context.HttpContext.Response.StatusCode = 406;
                context.Result = new JsonResult(error);

                context.ExceptionHandled = true;
            }
        }
    }
}
