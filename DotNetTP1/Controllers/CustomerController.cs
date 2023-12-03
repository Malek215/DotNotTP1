using DotNetTP1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTP1.Controllers
{
    public class CustomerController : Controller
    {


        public List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1,Name="Melek"},
            new Customer() { Id = 2,Name="Ahmed"},
            new Customer() { Id = 3,Name="Tarek"},

        };


        public ActionResult Index()
        {
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var c = customers.Find((customer) => (customer.Id == id));
            if (c == null)
            {
                return Content("Customer Not Found");
            }
            return View(c);
        }

    }
}