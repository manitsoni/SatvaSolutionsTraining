using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Data.Model;
namespace BL.Manager.Interface
{
    public interface IDepartmentManager
    {
        bool AddDepartment(Department department);
        IList<Department> GetDepartments();
        bool EditDepartment(Department department);
        tblDepartment GetDepartment(int id);
        bool DeleteDepartment(int id);
        bool Login(string Email, string Password);

    }
}
