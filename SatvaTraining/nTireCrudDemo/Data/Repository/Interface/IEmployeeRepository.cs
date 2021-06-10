using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Data.Model;
namespace Data.Repository.Interface
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(tblEmployee employee);
        bool DeleteEmployee(int id);
        List<GetEmployee> GetEmployees();
        tblEmployee GetEmployee(int id);
        bool EditEmployee(tblEmployee employee);
        List<GetEmployee> GetAllEmployees();
        List<GetEmployee> MyInfo();
    }
}
