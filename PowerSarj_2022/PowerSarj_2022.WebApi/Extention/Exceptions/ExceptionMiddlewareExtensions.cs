using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PowerSarj_2022.Entities.Concrete.ErrorModels;
using System.Net;

namespace PowerSarj_2022.WebApi.Extention.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler( x=>
            {
                x.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature != null)
                    {

                        // LOGGER YAZ BURAYA
                        context.Response.StatusCode = contextfeature.Error switch
                        {
                            NotFoundException => 200,
                            _ => 500 ,
                        };

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextfeature.Error.Message,
                        
                        }.ToString()
                        ) ;
                    }


                });
            });
        }
    }
}
