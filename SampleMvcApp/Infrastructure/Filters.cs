using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Infrastructure
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        private bool allowLocal = false;

        public CustomAuthorizeFilter(bool allow)
        {
            allowLocal = allow;
        }
        //This function contains the logic on who are authorized to view...
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                if (allowLocal == true)
                    return allowLocal;
            }
            return false;
        }
    }

    //IExceptionFilter is an interface that is implemented by all the Custom Exception Filters. ExceptionFilter is a filter that is triggered when any unhandled exception is raised by the Application...
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        //Called when the unhandled Exception is raised....
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled == false)
            {
                filterContext.Result = new RedirectResult("~/Errors/ErrorView.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}