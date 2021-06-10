using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
namespace Core.Interface
{
    public interface ICompanyRepository
    {
        bool AddCompany(tblCompany company);
        IEnumerable<CompanyList_Result> GetCompanies();
        bool UpdateCompany(tblCompany company);
        IEnumerable<GetCompany_Result> GetCompanyById(int id);
        bool DeleteCompany(int id);
    }
}
