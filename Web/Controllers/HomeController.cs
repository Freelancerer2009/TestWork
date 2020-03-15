using BLLayer;
using Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MainTable()
        {
            IEnumerable<Employee> employees = unitOfWork.EmployeeRepository.GetEmployees();
            return PartialView(employees);
        }
    }
}