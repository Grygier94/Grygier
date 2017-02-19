using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Dashboard()
        {
            return View();
        }


    }
}