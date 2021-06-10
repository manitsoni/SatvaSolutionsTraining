using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Data.Model;
namespace BL.Manager.Interface
{
    public interface ICompanyManager
    {
        bool Register(Company company);
        bool EditCompany(Company company);
        tblCompany GetCompany(int id);
        IList<Company> GetCompanies();
        bool Delete(int id);
        bool Login(string Username, string Password);
        bool EmployeeLogin(string email, string password);
        bool IsEmployeeVerify(string email, string password);
        bool IsOTPVerify(string email, string password);
    }
}
