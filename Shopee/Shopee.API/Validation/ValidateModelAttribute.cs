using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Shopee.Application.DTOs;

namespace Shopee.API.Validation
{
    public class ValidateModelAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var query = from state in context.ModelState.Values
                    from error in state.Errors
                    select error.ErrorMessage;

                var errorList = query.ToList();

                var errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelError => modelError.ErrorMessage);

                context.Result = new BadRequestObjectResult(ApiResponseDto<string>.Failure(errors, "BadRequest"));
            }

            await next();
        }
    }
}
