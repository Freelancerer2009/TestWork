using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ModelsForView
{
    public class EmployeeForView
    {
        public Employee Employee { get; set; }
        public List<Position> PositionList { get; set; }
    }
}