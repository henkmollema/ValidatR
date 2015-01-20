using System.Web.Mvc;
using Newtonsoft.Json;
using Validatr.Configuration;

namespace Validatr.Filters
{
    /// <summary>
    /// Replaces the response of the current action with a JSON 
    /// representation of the model state when it's invalid.
    /// </summary>
    public class ValidateActionFilterAttribute : ActionFilterAttribute
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
