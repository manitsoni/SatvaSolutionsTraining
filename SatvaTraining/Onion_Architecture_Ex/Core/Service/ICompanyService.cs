using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ViewModel;
namespace Core.Service
{
    public interface ICompanyService
    {
        bool AddCompany(CompanyViewModel company);
        IList<CompanyViewModel> GetCompanies();
        IList<CompanyViewModel> GetCompanyById(int id);
        bool UpdateCompany(CompanyViewModel company);
        bool DeleteCompany(int id);
    }
}
