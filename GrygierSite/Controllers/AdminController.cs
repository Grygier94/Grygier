using GrygierSite.Models;
using System.Web.Mvc;

namespace GrygierSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

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