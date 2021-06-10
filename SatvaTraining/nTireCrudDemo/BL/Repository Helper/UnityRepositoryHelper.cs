using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using Data.Repository;
using Data.Repository.Interface;
namespace BL.Repository_Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICompanyRepository, CompanyRepository>();
            Container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            Container.RegisterType<IAppHelperRepository, AppHelperRepository>();
            Container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
