using BLLayer;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public EmployeeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult EmployeeDetail()
        {
            IEnumerable<Position> PositionList = _unitOfWork.PositionRepository.GetList();

            List<SelectListItem> items = new List<SelectListItem>();
            items.AddRange(PositionList.Select(x => new SelectListItem { Text = x.PositionName, Value = x.Id.ToString() }));

            ViewBag.PositionList = items;
            return PartialView("PartialEmployeeView");
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepository.AddNewEmployee(employee);
            }
        }
    }
}