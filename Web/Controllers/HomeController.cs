using BLLayer;
using Data;
using Data.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult DetailPosition()
        {
            return PartialView("PartialPositionView");
        }

        public ActionResult EmployeeDetail()
        {
            IEnumerable<Position> PositionList = unitOfWork.PositionRepository.GetList();

            List<SelectListItem> items = new List<SelectListItem>();
            items.AddRange(PositionList.Select(x => new SelectListItem { Text = x.PositionName, Value = x.Id.ToString() }));

            ViewBag.PositionList = items;
            return PartialView("PartialEmployeeView");
        }

        [HttpPost]
        public string AddPosition(Position position)
        {
            unitOfWork.PositionRepository.Add(position);
            return "Должность добавлена";
        }

        public void AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeeRepository.AddNewEmployee(employee);
            }
        }

        public ActionResult MainTable()
        {
            IEnumerable<Employee> employees = unitOfWork.EmployeeRepository.GetList();
            return PartialView(employees);
        }
    }
}