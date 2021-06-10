using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Data.Model;
using Data.Repository.Interface;
using BL.Manager.Interface;
namespace BL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepository repository;
        public EmployeeManager(IEmployeeRepository repo)
        {
            repository = repo;
        }
        public bool AddEmployee(tblEmployee employee)
        {
            bool IsAvailable = false;
            var data = GetAllEmployees().ToList();
            foreach (var item in data)
            {
                if (item.Email.ToLower() == employee.Email.ToLower() && item.MobileNumber == employee.MobileNumber)
                {
                    IsAvailable = true;
                    break;
                }
            }
            if (IsAvailable == false)
            {
                return repository.AddEmployee(employee);
            }
            else
            {
                return false;
            }
            
        }

        public bool DeleteEmployee(int id)
        {
            return repository.DeleteEmployee(id);
        }

        public bool EditEmployee(tblEmployee employee)
        {
            return repository.EditEmployee(employee);
        }

        public List<GetEmployee> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        public tblEmployee GetEmployee(int id)
        {
            return repository.GetEmployee(id);
        }

        public List<GetEmployee> GetEmployees()
        {
            return repository.GetEmployees().ToList();
        }

        public List<GetEmployee> GetMyInfo()
        {
            return repository.MyInfo().ToList();
        }
    }
}
