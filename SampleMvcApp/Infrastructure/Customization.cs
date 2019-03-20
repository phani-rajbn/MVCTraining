using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web;
//MVC is an Open Source Technology where developers can customize their MVC pipeline by implementing certain interfaces and define how their Apps can be delivered. These customizations remove many of the low level functionalities which might not be used in the Application Exection and might be unnessasary burden to the speed of the application. 
//MVC starts by creating an instance of a ControllerFactory whose job is to create the instance of the controllers specified by the URL Routers.  We could customize by creating our own ControllerFactory specifically designed to cater the needs of our Application only.  
namespace SampleMvcApp.Infrastructure
{
    using SampleMvcApp.Controllers;
    [CustomExceptionFilter]
    public class CustomControllerFactory : IControllerFactory
    {
        [CustomExceptionFilter]
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "Ajax":
                    return new AjaxController();
                case "MvcPipeLine":
                    return new MvcPipeLineController();
                default:
                    throw new Exception("Unknown Controller");
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Disabled;
            //Sessions wont work in this Application..
        }

        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
            {
                IDisposable dispose = controller as IDisposable;
                dispose.Dispose();
            }
        }
    }

    //Customizing the controller.
    public class CustomController : IController, IDisposable
    {
        private IActionInvoker _functionInvoker;
        public CustomController()
        {
            ControllerContext = new ControllerContext();
            _functionInvoker = new CustomInvoker(this);
        }
        public void Dispose()
        {
            
        }

        public ControllerContext ControllerContext { get; set; }
        public void Execute(RequestContext requestContext)
        {
            ControllerContext.HttpContext = requestContext.HttpContext;
            ControllerContext.RequestContext = requestContext;
            ControllerContext.RouteData = requestContext.RouteData;
            _functionInvoker.InvokeAction(ControllerContext, requestContext.RouteData.Values["action"].ToString());
           // string info = string.Format("The Controller by Name {0} has been requested to call an Action called {1}", requestContext.RouteData.Values["controller"], requestContext.RouteData.Values["action"]);
            //requestContext.HttpContext.Response.Write(info);
        }
    }

    public class CustomInvoker : ControllerActionInvoker
    {
        private IController controller;
        public CustomInvoker(IController controller)
        {
            this.controller = controller;
            
        }
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            MvcPipeLineController controller = this.controller as MvcPipeLineController;
            if (actionName == "Index")
            {
                controllerContext.HttpContext.Response.Write("Index Method is called");
                var res = controller.Index();
                InvokeActionResult(controllerContext, res);
            }else if(actionName == "AllEmployees")
            {
                controllerContext.HttpContext.Response.Write("AllEmployees Method is called");
                var content = controller.AllEmployees();
                InvokeActionResult(controllerContext, content);
            }
            else
            {
                throw new Exception("Invalid Action Name");
            }
            return true;
        }
    }

    public class MyViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            throw new NotImplementedException();
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return null;
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            ((IDisposable)view).Dispose();
        }
    }
}