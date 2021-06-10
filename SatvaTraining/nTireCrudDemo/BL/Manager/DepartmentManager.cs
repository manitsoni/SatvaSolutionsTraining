using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Unity;
using Data.Model;
using Data.Repository;
using BL.Manager.Interface;
using BE;
using Common;
using Data.Repository.Interface;
namespace BL.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        private IDepartmentRepository departmentRepository; 
        public DepartmentManager(IDepartmentRepository department)
        {
            departmentRepository = department;
        }
        public string RemoveSymbol(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public bool AddDepartment(Department department)
        {
            bool IsDepartmentAvailable = false;
            
            var data = GetDepartments().ToList();
            foreach (var item in data)
            {
                if (item.CompanyId == SessionProxyUser.CompanyId && RemoveSymbol(item.DepartmentName.ToLower()) == RemoveSymbol(department.DepartmentName.ToLower()))
                {
                    IsDepartmentAvailable = true;
                    break;
                }
            }
            if (IsDepartmentAvailable == false)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, tblDepartment>());
                IMapper mapper = config.CreateMapper();
                tblDepartment dept = mapper.Map<Department, tblDepartment>(department);
                return departmentRepository.AddDepartment(dept);
            }
            else
            {
                return false;
            }
            
        }
        public bool DeleteDepartment(int id)
        {
            return departmentRepository.DeleteDepartment(id);
        }
        public bool EditDepartment(Department department)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, tblDepartment>());
            IMapper mapper = config.CreateMapper();
            tblDepartment dept = mapper.Map<Department, tblDepartment>(department);
            return departmentRepository.EditDepartment(dept);
        }
        public tblDepartment GetDepartment(int id)
        {
            return departmentRepository.GetDepartment(id);
        }
        public IList<Department> GetDepartments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblDepartment, Department>());
            IMapper mapper = config.CreateMapper();
            var dept = departmentRepository.GetTblDepartments().ToList();
            List<Department> departments = dept.Select(x => mapper.Map<tblDepartment, Department>(x)).ToList();
            return departments;
        }
        public bool Login(string Email, string Password)
        {
            return departmentRepository.Login(Email,Password);
        }
    }
}
