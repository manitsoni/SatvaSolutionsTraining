using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using BL.Manager;
using BL.Repository_Helper;
using BL.Manager.Interface;
namespace nTireCrudDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICompanyManager, CompanyManager>();
            container.RegisterType<IDepartmentManager, DepartmentManager>();
            container.RegisterType<IAppHelperManager, AppHelperManager>();
            container.RegisterType<IEmployeeManager, EmployeeManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}