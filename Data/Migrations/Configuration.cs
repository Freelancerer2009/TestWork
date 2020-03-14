﻿namespace Data.Migrations
{
    using Data.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.WebDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.WebDatabaseContext context)
        {
            //IList<Position> Positions = new List<Position>();

            //Positions.Add(new Position { PositionName = "Junior Dev" });
            //Positions.Add(new Position { PositionName = "Middle Dev" });
            //Positions.Add(new Position { PositionName = "Senior Dev" });
            //Positions.Add(new Position { PositionName = "Junior QA" });
            //Positions.Add(new Position { PositionName = "DevOps" });
            //Positions.Add(new Position { PositionName = "Middle QA" });

            //context.Positions.AddRange(Positions);

            //IList<Employee> Employees = new List<Employee>();

            //Employees.Add(new Employee { FirstName = "Маслов Иван", Salary = 1500, Hired = new DateTime(2015, 01, 05) });
            //Employees.Add(new Employee { FirstName = "Прыгуков Александр", Salary = 600, Hired = new DateTime(2016, 12, 22) });
            //Employees.Add(new Employee { FirstName = "Капстина Анастасия", Salary = 1800, Hired = new DateTime(2018, 05, 15) });

            //context.Employees.AddRange(Employees);

            //base.Seed(context);
        }
    }
}