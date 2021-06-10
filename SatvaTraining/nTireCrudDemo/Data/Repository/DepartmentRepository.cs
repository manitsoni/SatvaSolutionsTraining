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
    public class DepartmentRepository : IDepartmentRepository
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public bool AddDepartment(tblDepartment department)
        {
            db.tblDepartments.Add(department);
            return db.SaveChanges() > 0;
        }
        public bool DeleteDepartment(int id)
        {
            tblDepartment dept = db.tblDepartments.Find(id);
            db.tblDepartments.Remove(dept);
            return db.SaveChanges() > 0;
        }
        public bool EditDepartment(tblDepartment department)
        {
            db.Entry(department).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public tblDepartment GetDepartment(int id)
        {
            tblDepartment department = db.tblDepartments.Find(id);
            return department;
        }
        public IQueryable<tblDepartment> GetTblDepartments()
        {
            return db.tblDepartments.Where(m=>m.CompanyId == SessionProxyUser.CompanyId);
        }
        public bool Login(string Email, string Password)
        {
            //int IsAvailable = Convert.ToInt32(db.(Email, Password).First());
            //if (IsAvailable == 1)
            //{
            //    var data = db.tblCompanies.Where(m => m.Email == Email && m.Password == Password).FirstOrDefault();
            //    SessionProxyUser.IsUserLogin = true;
            //    SessionProxyUser.CompanyId = data.Id;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
    }
}
