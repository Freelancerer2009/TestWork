using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data
{
    using Data.Migrations;
    using Data.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WebDatabaseContext : DbContext
    {
        public WebDatabaseContext() : base("name=Database")
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }

    class MyContextInitializer : DropCreateDatabaseAlways<WebDatabaseContext>
    {
        protected override void Seed(WebDatabaseContext context)
        {
            IList<Position> Positions = new List<Position>();

            Positions.Add(new Position { PositionName = "Junior Dev" });
            Positions.Add(new Position { PositionName = "Middle Dev" });
            Positions.Add(new Position { PositionName = "Senior Dev" });
            Positions.Add(new Position { PositionName = "Junior QA" });
            Positions.Add(new Position { PositionName = "DevOps" });
            Positions.Add(new Position { PositionName = "Middle QA" });

            context.Positions.AddRange(Positions);
            context.SaveChanges();

            IList<Employee> Employees = new List<Employee>();

            Employees.Add(new Employee { FirstName = "Иван", LastName = "Маслов", PositionId = 2, Salary = 1500, Hired = new DateTime(2015, 01, 05) });
            Employees.Add(new Employee { FirstName = "Александр", LastName = "Прыгуков", PositionId = 3, Salary = 600, Hired = new DateTime(2016, 12, 22) });
            Employees.Add(new Employee { FirstName = "Анастасия", LastName = "Капустина", PositionId = 5, Salary = 1800, Hired = new DateTime(2018, 05, 15) });

            context.Employees.AddRange(Employees);

            base.Seed(context);
        }
    }

}

