using System.Linq;
using System.Web.Mvc;
using CSharpWeb.Models;
using Services;

namespace CSharpWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService service;

        public CustomersController()
        {
            service = new CustomerService();
        }

        public ActionResult Index()
        {
            var customers = service.GetCustomers();
            var model = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Credit = c.Credit,
                IsVip = c.IsVip
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult Post(int[] ids)
        {
            service.UpgradeCustomers(ids);
            return RedirectToAction("Index");
        }
    }
}