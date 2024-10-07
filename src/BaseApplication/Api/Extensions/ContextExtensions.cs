using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.Collection.Enum;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Extensions
{
    public static class ContextExtensions
    {
        public static string IPAddress(this HttpContext context)
        {
            if (context is null)
                throw new Exception("Context can't be null");
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                var ipHeader = context?.Request?.Headers["X-Forwarded-For"];
                return ipHeader?.ToString() ?? "";
            }

            else
            {
                //return context?.Connection?.RemoteIpAddress?.MapToIPv4()?.ToString()??"";
                return context?.Connection?.RemoteIpAddress?.ToString() ?? "";
            }
        }

        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        public static List<CollectionResultMessage> AddErrorToCollectionResultMessage(this ValidationResult result)
        {
            var lst = new List<CollectionResultMessage>();

            foreach (var error in result.Errors)
            {
                lst.Add(new CollectionResultMessage(ResultMessageType.Danger, error.ErrorMessage));
            }

            return lst;
        }
    }
}
