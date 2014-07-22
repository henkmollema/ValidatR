using System.Web.Mvc;
using Newtonsoft.Json;
using Validatr.Configuration;

namespace Validatr.Filters
{
    /// <summary>
    /// Represents an action filter that serialzes the model state of the current context and sends it in response to the client.
    /// </summary>
    public class ValidatrActionFilterAttribute : ActionFilterAttribute
    {
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid)
            {
                return;
            }

            var serializedModelState = JsonConvert.SerializeObject(
                filterContext.Controller.ViewData.ModelState,
                ValidatrConfig.JsonSerializerSettings);

            var result = new ContentResult
                             {
                                 Content = serializedModelState,
                                 ContentType = ValidatrConfig.ContentType
                             };

            filterContext.HttpContext.Response.StatusCode = (int)ValidatrConfig.HttpStatusCode;
            filterContext.Result = result;
        }
    }
}
