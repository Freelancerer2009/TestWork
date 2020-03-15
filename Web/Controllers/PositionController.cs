using BLLayer;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PositionController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public PositionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult DetailPosition()
        {
            return PartialView("PartialPositionView");
        }

        [HttpPost]
        public string AddPosition(Position position)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                _unitOfWork.PositionRepository.Add(position);
                _unitOfWork.SaveChanges();
                result = "Должность добавлена";
            }
            return result;
        }
    }
}