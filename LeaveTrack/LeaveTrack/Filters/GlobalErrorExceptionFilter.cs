using LeaveTrack.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeaveTrack.Filters
{
    public class GlobalErrorExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var deneme = context.HttpContext.Request.ContentType;

            if(context.Exception is NotFoundException notFoundExp)
            {
                context.Result = new NotFoundObjectResult(new JsonResponse<string?>
                {
                    IsSuccess = false,
                    Message = notFoundExp.Message
                });
            }
            else if(context.Exception is BusinessException businessExp)
            {
                context.Result = new BadRequestObjectResult(new JsonResponse<string?>
                {
                    IsSuccess = false,
                    Message = businessExp.Message
                });
            }
            else
            {
                context.Result = new ObjectResult(new
                {
                    IsSuccess = false,
                    Message = "Beklenmeyen bir hata oluştu."
                }){ StatusCode = 500 };
            }

            context.ExceptionHandled = true;
        }
    }
}
