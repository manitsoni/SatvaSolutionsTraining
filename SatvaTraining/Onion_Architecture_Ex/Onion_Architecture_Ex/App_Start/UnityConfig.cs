using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Core.Interface;
using Infrastructure.Repository;
using Core.Service;
using Infrastructure.Service;
namespace Onion_Architecture_Ex
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<ICompanyService, CompanyService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}