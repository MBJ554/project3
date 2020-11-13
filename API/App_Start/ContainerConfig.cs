using API.DAL.Repositories;
using API.DAL.Interfaces;
using API.Models;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace API
{
    public class ContainerConfig
    {
        public static void RegisterContainers()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ClinicRepository>().As<IClinicRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<PractitionerRepository>().As<IPractitionerRepository>();
            builder.RegisterType<RehabProgramRepository>().As<IRehabProgramRepository>();
            builder.RegisterType<ExerciseLineRepository>().As<IExerciseLineRepository>();
            builder.RegisterType<ExerciseRepository>().As<IExerciseRepository>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}