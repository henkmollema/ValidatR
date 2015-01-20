using System.Web.Mvc;
using Validatr.Example.Models;
using Validatr.Filters;

namespace Validatr.Example.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost, Validate]
        public ActionResult Register(RegisterModel model)
        {
            return Json(new { success = true });
        }
    }
}
