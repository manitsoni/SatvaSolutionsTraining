using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Common;
using Data.Model;
using Data.Repository.Interface;
namespace Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public bool AddEmployee(tblEmployee employee)
        {
            db.tblEmployees.Add(employee);
            return db.SaveChanges() > 0;
        }

        public bool DeleteEmployee(int id)
        {
            tblEmployee employee = db.tblEmployees.Find(id);
            db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public bool EditEmployee(tblEmployee employee)
        {
            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public List<GetEmployee> GetAllEmployees()
        {
            var Employee = (from emp in db.tblEmployees
                            join cu in db.tblCountries on emp.Country equals cu.Id
                            join st in db.tblStates on emp.State equals st.Id
                            join ct in db.tblCities on emp.City equals ct.Id
                            join cmp in db.tblCompanies on emp.CompanyId equals cmp.Id
                            join dp in db.tblDepartments on emp.DepartmentId equals dp.Id
                            where emp.IsActive == true 
                            select new GetEmployee
                            {
                                IsActive = emp.IsActive,
                                Id = emp.Id,
                                AddressLine1 = emp.AddressLine1,
                                AddressLine2 = emp.AddressLine2,
                                City = ct.Id,
                                Cityname = ct.CityName,
                                Area = emp.Area,
                                Comment = emp.Comment,
                                CompanyId = emp.CompanyId,
                                Companyname = cmp.CompanyName,
                                Country = emp.Country,
                                Countryname = cu.CountryName,
                                CreatedDate = emp.CreatedDate.ToString(),
                                DepartmentId = emp.DepartmentId,
                                Departmentname = dp.DepartmentName,
                                Email = emp.Email,
                                FirstName = emp.FirstName,
                                IsContactVerify = emp.IsContactVerify,
                                IsEmailVerify = emp.IsEmailVerify,
                                IsTrainee = emp.IsTrainee,
                                JoiningDate = emp.JoiningDate.ToString(),
                                LastName = emp.LastName,
                                MiddleName = emp.MiddleName,
                                MobileNumber = emp.MobileNumber,
                                Photo = emp.Photo,
                                Resume = emp.Resume,
                                State = emp.State,
                                Statename = st.StateName,
                                TelephoneNo = emp.TelethoneNo,
                                UpdatedDate = emp.UpdatedDate.ToString()
                            }).ToList();
            return Employee;
        }

        public tblEmployee GetEmployee(int id)
        {
            tblEmployee employee = db.tblEmployees.Find(id);
            return employee;
        }

        public List<GetEmployee> GetEmployees()
        {
            var Employee = (from emp in db.tblEmployees
                            join cu in db.tblCountries on emp.Country equals cu.Id
                            join st in db.tblStates on emp.State equals st.Id
                            join ct in db.tblCities on emp.City equals ct.Id
                            join cmp in db.tblCompanies on emp.CompanyId equals cmp.Id
                            join dp in db.tblDepartments on emp.DepartmentId equals dp.Id
                            where emp.IsActive == true && emp.CompanyId == SessionProxyUser.CompanyId
                            select new GetEmployee
                            {
                                IsActive = emp.IsActive,
                                Id = emp.Id,
                                AddressLine1 = emp.AddressLine1,
                                AddressLine2 = emp.AddressLine2,
                                City = ct.Id,
                                Cityname = ct.CityName,
                                Area = emp.Area,
                                Comment = emp.Comment,
                                CompanyId = emp.CompanyId,
                                Companyname = cmp.CompanyName,
                                Country = emp.Country,
                                Countryname = cu.CountryName,
                                CreatedDate = emp.CreatedDate.ToString(),
                                DepartmentId = emp.DepartmentId,
                                Departmentname = dp.DepartmentName,
                                Email = emp.Email,
                                FirstName = emp.FirstName,
                                IsContactVerify = emp.IsContactVerify,
                                IsEmailVerify = emp.IsEmailVerify,
                                IsTrainee = emp.IsTrainee,
                                JoiningDate=  emp.JoiningDate.ToString(),
                                LastName = emp.LastName,
                                MiddleName = emp.MiddleName,
                                MobileNumber = emp.MobileNumber,
                                Photo = emp.Photo,
                                Resume = emp.Resume,
                                State = emp.State,
                                Statename = st.StateName,
                                TelephoneNo = emp.TelethoneNo,
                                UpdatedDate = emp.UpdatedDate.ToString()
                            }).ToList();
            return Employee;
        }

        public List<GetEmployee> MyInfo()
        {
            var Employee = (from emp in db.tblEmployees
                            join cu in db.tblCountries on emp.Country equals cu.Id
                            join st in db.tblStates on emp.State equals st.Id
                            join ct in db.tblCities on emp.City equals ct.Id
                            join cmp in db.tblCompanies on emp.CompanyId equals cmp.Id
                            join dp in db.tblDepartments on emp.DepartmentId equals dp.Id
                            where emp.IsActive == true && emp.Id == SessionProxyUser.UserID
                            select new GetEmployee
                            {
                                IsActive = emp.IsActive,
                                Id = emp.Id,
                                AddressLine1 = emp.AddressLine1,
                                AddressLine2 = emp.AddressLine2,
                                City = ct.Id,
                                Cityname = ct.CityName,
                                Area = emp.Area,
                                Comment = emp.Comment,
                                CompanyId = emp.CompanyId,
                                Companyname = cmp.CompanyName,
                                Country = emp.Country,
                                Countryname = cu.CountryName,
                                CreatedDate = emp.CreatedDate.ToString(),
                                DepartmentId = emp.DepartmentId,
                                Departmentname = dp.DepartmentName,
                                Email = emp.Email,
                                FirstName = emp.FirstName,
                                IsContactVerify = emp.IsContactVerify,
                                IsEmailVerify = emp.IsEmailVerify,
                                IsTrainee = emp.IsTrainee,
                                JoiningDate = emp.JoiningDate.ToString(),
                                LastName = emp.LastName,
                                MiddleName = emp.MiddleName,
                                MobileNumber = emp.MobileNumber,
                                Photo = emp.Photo,
                                Pincode = emp.PinCode,
                                Resume = emp.Resume,
                                State = emp.State,
                                Statename = st.StateName,
                                TelephoneNo = emp.TelethoneNo,
                                UpdatedDate = emp.UpdatedDate.ToString()
                            }).ToList();
            return Employee;
        }
    }
}
