using Data.Model;
using System;
using BE;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manager.Interface
{
    public interface IEmployeeManager
    {
        bool AddEmployee(tblEmployee employee);
        bool DeleteEmployee(int id);
        List<GetEmployee> GetEmployees();
        tblEmployee GetEmployee(int id);
        bool EditEmployee(tblEmployee employee);
        List<GetEmployee> GetAllEmployees();
        List<GetEmployee> GetMyInfo();
    }
}
