using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linhkiendientu_aspnetmvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesIndex()
        {
            return View("Categories/Index");
        }
    }
}
