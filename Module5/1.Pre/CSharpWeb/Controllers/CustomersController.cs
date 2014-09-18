using System.Linq;
using System.Web.Mvc;
using CSharpWeb.Models;

namespace CSharpWeb.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(int[] ids)
        {
            return RedirectToAction("Index");
        }
    }
}