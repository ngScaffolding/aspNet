using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using ngScaffolding.models.Models;
using Microsoft.AspNetCore.Http;
using ngScaffolding.database;
using ngScaffolding.Data;

namespace ngScaffolding.Infrastructure
{
    public class AuditAttribute : ActionFilterAttribute
    {
        private readonly IRepository<ApplicationLog> applicationLogRepository;

        //Our value to handle our AuditingLevel
        public int AuditingLevel { get; set; }
        public bool DontAuditActionParams { get; set; }
        public bool DontAuditRouteData { get; set; }

        public AuditAttribute(IRepository<ApplicationLog> applicationLogRepository)
        {
            this.applicationLogRepository = applicationLogRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (AuditingLevel == 0) AuditingLevel = 2;

            //TODO: Fixup Name here

            ////Stores the Request in an Accessible object
            var request = context.HttpContext.Request;

            var userId = "Anonymous";
            //if (context.HttpContext.Request.RequestContext.Principal != null &&
            //    context.RequestContext.Principal.Identity != null)
            //{
            //    userId = context.RequestContext.Principal.Identity.Name;
            //}

            var desc = "";
            if (context.ActionArguments != null)
            {
                desc = JsonConvert.SerializeObject(context.ActionArguments);
            }

            //Generate an audit
            var audit = new ApplicationLog()
            {
                LogDate = DateTime.Now,
                UserID = userId,
                LogType = "API Request",
                EndPoint = context.HttpContext.Request.QueryString.ToString(),
                HttpCommand = context.HttpContext.Request.Method.ToString(),
                Description = desc
            };

            applicationLogRepository.Insert(audit);

            base.OnActionExecuting(context);
        }

        //This will serialize the Request object based on the level that you determine
        private string SerializeRequest(HttpRequest request)
        {
            switch (AuditingLevel)
            {
                //No Request Data will be serialized
                case 0:
                default:
                    return "";
                //Basic Request Serialization - just stores Data
                case 1:
                    return JsonConvert.SerializeObject(new { request.Cookies, request.Headers });
                //Middle Level - Customize to your Preferences
                case 2:
                    return JsonConvert.SerializeObject(new { request.Cookies, request.Headers, request.Form, request.QueryString, request.Body });
                //Highest Level - Serialize the entire Request object
                case 3:
                    //We can't simply just Encode the entire request string due to circular references as well
                    //as objects that cannot "simply" be serialized such as Streams, References etc.
                    //return Json.Encode(request);
                    return JsonConvert.SerializeObject(new { request.Cookies, request.Headers, request.Form, request.QueryString, request.Body });
            }
        }
    }
}