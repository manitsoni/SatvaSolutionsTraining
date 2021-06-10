using RepositoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryDemo.Models;
namespace RepositoryDemo.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        ManitEmployeeManagementEntities db = null;
        public CompanyRepository()
        {
            db = new ManitEmployeeManagementEntities();
        }
        public bool Add(tblCompany obj)
        {
            db.tblCompanies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            tblCompany company = db.tblCompanies.Find(id);
            db.tblCompanies.Remove(company);
            return db.SaveChanges() > 0;
        }

        public IEnumerable<tblCompany> GetCompanies()
        {
            return db.tblCompanies;
        }

        public tblCompany GetCompanyById(int id)
        {
            return db.tblCompanies.Find(id);
        }

        public bool Update(tblCompany obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}