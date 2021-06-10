using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface;
using Core.Model;
using Infrastructure.Data;
namespace Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        ManitEmployeeManagementEntities db = new ManitEmployeeManagementEntities();
        public bool AddCompany(tblCompany company)
        {
            var msg = db.AddCompany(company.CompanyName, company.Email, company.Password, company.ContactNo, company.IsActive);
            if (msg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCompany(int id)
        {
            var msg = db.DeleteCompany(id);
            if (msg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<CompanyList_Result> GetCompanies()
        {
            var Data = db.CompanyList().ToList();
            return Data;
        }

        public IEnumerable<GetCompany_Result> GetCompanyById(int id)
        {
            return db.GetCompany(id);
        }

        public bool UpdateCompany(tblCompany company)
        {
            var msg = db.EditCompany(company.Id, company.CompanyName, company.Email, company.Password, company.ContactNo, company.IsActive);
            if (msg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
