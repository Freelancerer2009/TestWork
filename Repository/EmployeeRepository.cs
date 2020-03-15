using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(WebDatabaseContext context) : base(context)
        {
        }

        public void AddNewEmployee(Employee employee)
        {
            var person = (from emp in Context.Employees
                        where emp.FirstName.ToUpper().Trim() == employee.FirstName.ToUpper().Trim()
                        && emp.LastName.ToUpper().Trim() == employee.LastName.ToUpper().Trim()
                        && emp.Hired <= employee.Hired
                        orderby emp.Hired descending
                        select emp).FirstOrDefault();

            if(person != null)
            {
                person.Fired = employee.Hired?.AddDays(-1);
            }

            Add(employee);
            Save();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var query = (from t in Context.Employees
                        select t).Include(x=> x.Position);
            return query.ToList();
        }
    }
}
