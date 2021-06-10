using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data.Model;
using Data.Repository.Interface;
namespace Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        PasswordDecrypt passwordDec = new PasswordDecrypt();
        public bool AddCompany(tblCompany company)
        {
            db.tblCompanies.Add(company);
            return db.SaveChanges() > 0;
        }

        public bool DeleteCompany(int id)
        {
            tblCompany comp = db.tblCompanies.Find(id);
            db.tblCompanies.Remove(comp);
            return db.SaveChanges() > 0;
        }

        public bool EditCompany(tblCompany company)
        {
            db.Entry(company).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool EmployeeLogin(string email, string password)
        {
            var data = db.tblEmployees.Where(m => m.Email == email).FirstOrDefault();
            if (data !=null)
            {
                string pass = passwordDec.Decrypt(data.Password);

                if (pass == password)
                {

                    SessionProxyUser.IsUserLogin = false;
                    SessionProxyUser.UserID = data.Id;
                    SessionProxyUser.CompanyId = Convert.ToInt32(data.CompanyId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public IQueryable<tblCompany> GetCompanies()
        {
            return db.tblCompanies;
        }
        public tblCompany GetCompany(int id)
        {
            tblCompany comp = null;
            comp = db.tblCompanies.Find(id);
            return comp;
        }

        public bool IsEmailVerify(string email, string password)
        {
            var data = db.tblEmployees.Where(m => m.Email == email && m.IsEmailVerify == false).FirstOrDefault();
            if (data !=null)
            {
                string pass = passwordDec.Decrypt(data.Password);
                if (pass == password)
                {
                    SessionProxyUser.IsUserLogin = true;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        public bool IsOTPVerify(string email, string password)
        {
            var data = db.tblEmployees.Where(m => m.Email == email && m.IsEmailVerify == true && m.IsContactVerify == false).FirstOrDefault();
            if (data != null)
            {
                string pass = passwordDec.Decrypt(data.Password);
                if (pass == password)
                {
                    SessionProxyUser.IsUserLogin = true;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        public bool Login(string email, string password)
        {
            var data = db.tblCompanies.Where(m => m.Email == email).FirstOrDefault();
            if (data != null)
            {
                string pass = passwordDec.Decrypt(data.Password);
                if (pass == password)
                {
                    SessionProxyUser.IsUserLogin = true;
                    SessionProxyUser.CompanyId = data.Id;
                    SessionProxyUser.CompanyName = data.CompanyName;
                    return true;

                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }
        }
    }
}
