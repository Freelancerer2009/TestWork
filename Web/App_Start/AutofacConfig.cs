using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using BLLayer;
using Data;
using Data.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<UnitOfWork>().SingleInstance();
            
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var сontainer = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(сontainer));

        }
    }
}