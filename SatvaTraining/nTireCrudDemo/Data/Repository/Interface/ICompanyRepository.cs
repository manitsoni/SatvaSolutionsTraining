using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.Repository.Interface
{
    public interface ICompanyRepository
    {
        bool AddCompany(tblCompany company);
        bool EditCompany(tblCompany company);
        tblCompany GetCompany(int id);
        IQueryable<tblCompany> GetCompanies();
        bool DeleteCompany(int id);
        bool Login(string email, string password);
        bool EmployeeLogin(string email, string password);
        bool IsEmailVerify(string email, string password);
        bool IsOTPVerify(string email, string password);
    }
}
