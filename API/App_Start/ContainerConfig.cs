using API.DAL.Interfaces;
using API.DAL.Repositories;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
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
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}