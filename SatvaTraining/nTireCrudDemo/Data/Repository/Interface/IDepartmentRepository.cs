using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.Repository.Interface
{
    public interface IDepartmentRepository
    {
        bool AddDepartment(tblDepartment department);
        IQueryable<tblDepartment> GetTblDepartments();
        bool EditDepartment(tblDepartment department);
        tblDepartment GetDepartment(int id);
        bool DeleteDepartment(int id);
        bool Login(string Email, string Password);
    }
}
