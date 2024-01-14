using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_pokemon_review.Middleware
{
    /// <summary>
    /// Custom Response Format for ResponseType
    /// </summary>
    public class CustomResponseFormatAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(context.Result is ObjectResult objectResult)
            {
                var customData = new
                {
                    StatusCode = objectResult.StatusCode,
                    Data = objectResult.Value
                };
                context.Result = new ObjectResult(customData)
                {
                    StatusCode = objectResult.StatusCode
                };
            }

            base.OnResultExecuting(context);
        }
    }
}