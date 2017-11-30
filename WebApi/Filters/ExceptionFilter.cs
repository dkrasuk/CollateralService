using Logger;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace WebApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// OnExceptionAsync
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var service = ServiceLocator.Current.GetInstance<ILogger>(); //DependencyResolver.Current.GetService<ILogger>();

            if (actionExecutedContext.Exception is DbUpdateException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.Conflict, GetErrorMessage(actionExecutedContext.Exception));
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                 HttpStatusCode.InternalServerError, GetErrorMessage(actionExecutedContext.Exception));
            }
            service.Error(actionExecutedContext.Exception.ToString());
            return Task.FromResult(0);

        }

        private static string GetErrorMessage(Exception ex)
        {
            var innerExceptionMessage = string.Empty;

            if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            {
                innerExceptionMessage = GetErrorMessage(ex.InnerException);
            }

            return $"{ex.Message}\n{innerExceptionMessage}";
        }
    }
}