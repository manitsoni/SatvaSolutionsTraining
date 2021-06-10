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
    public class AppHelperRepository : IAppHelperRepository
    {
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public bool AddCity(tblCity city)
        {
            db.tblCities.Add(city);
            return db.SaveChanges() > 0;
        }

        public bool AddCountry(tblCountry country)
        {
            db.tblCountries.Add(country);
            return db.SaveChanges() > 0;
        }

        public bool AddState(tblState state)
        {
            db.tblStates.Add(state);
            return db.SaveChanges() > 0;
        }

        public bool CheckEmail(string Email)
        {
            var data = db.tblEmployees.Where(m => m.Email == Email).FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCity(int id)
        {
            tblCity city = db.tblCities.Find(id);
            db.Entry(city).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public bool DeleteCountry(int id)
        {
            tblCountry country = db.tblCountries.Find(id);
            db.Entry(country).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public bool DeleteState(int id)
        {
            tblState state = db.tblStates.Find(id);
            db.Entry(state).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public bool EditCity(tblCity city)
        {
            db.Entry(city).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool EditCountry(tblCountry country)
        {
            db.Entry(country).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool EditState(tblState state)
        {
            db.Entry(state).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public IList<City> GetCities()
        {
            var City = (from ct in db.tblCities
                        join cu in db.tblCountries on ct.CountryId equals cu.Id
                        join st in db.tblStates on ct.StateId equals st.Id
                        select new City
                        {
                            CityName = ct.CityName,
                            CountryId = cu.Id,
                            Id = ct.Id,
                            CountryName = cu.CountryName,
                            StateId = st.Id,
                            StateName = st.StateName
                        }).OrderBy(m => m.CityName).ToList();
            return City;
        }

        public tblCity GetCity(int id)
        {
            tblCity city = db.tblCities.Find(id);
            return city;
        }

        public IList<City> GetcityByCountry(int Countryid)
        {
            var City = (from ct in db.tblCities
                        join cu in db.tblCountries on ct.CountryId equals cu.Id
                        join st in db.tblStates on ct.StateId equals st.Id
                        where ct.CountryId == Countryid
                        select new City
                        {
                            CityName = ct.CityName,
                            CountryId = cu.Id,
                            Id = ct.Id,
                            CountryName = cu.CountryName,
                            StateId = st.Id,
                            StateName = st.StateName
                        }).OrderBy(m => m.CityName).ToList();
            return City;
        }

        public IList<City> GetCityByState(int Stateid)
        {
            var City = (from ct in db.tblCities
                        join cu in db.tblCountries on ct.CountryId equals cu.Id
                        join st in db.tblStates on ct.StateId equals st.Id
                        where ct.StateId == Stateid
                        select new City
                        {
                            CityName = ct.CityName,
                            CountryId = cu.Id,
                            Id = ct.Id,
                            CountryName = cu.CountryName,
                            StateId = st.Id,
                            StateName = st.StateName
                        }).OrderBy(m => m.CityName).ToList();
            return City;
        }

        public IQueryable<tblCountry> GetCountries()
        {
            return db.tblCountries;
        }

        public tblCountry GetCountry(int id)
        {
            try
            {
                tblCountry country = db.tblCountries.Where(m=>m.Id == id).FirstOrDefault();
                return country;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public IQueryable<tblDepartment> GetDepartments()
        {
            var department = db.tblDepartments.Where(m => m.CompanyId == SessionProxyUser.CompanyId);
            return department;
        }

        public tblState GetState(int id)
        {
            tblState state = db.tblStates.Find(id);
            return state;
        }
        public IList<State> GetStateByCountry(int CountryId)
        {
            var State = (from st in db.tblStates
                         join cu in db.tblCountries on st.CountryId equals cu.Id
                         where st.CountryId == CountryId
                         select new State
                         {
                             StateName = st.StateName,
                             Id = st.Id,
                             CountryId = cu.Id,
                             CountryName = cu.CountryName
                         }).OrderBy(m => m.StateName).ToList();
            return State;
        }
        public IList<State> GetStates()
        {
            var State = (from st in db.tblStates
                         join cu in db.tblCountries on st.CountryId equals cu.Id
                         select new State
                         {
                             StateName = st.StateName,
                             Id = st.Id,
                             CountryId = cu.Id,
                             CountryName = cu.CountryName
                         }).OrderBy(m => m.StateName).ToList();
            return State;
        }

        public bool VerifyMobileNumber(int EMployeeId)
        {
            tblEmployee emp = db.tblEmployees.Find(EMployeeId);
            emp.IsContactVerify = true;
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            SessionProxyUser.IsEmployeeVerified = true;
            return db.SaveChanges() > 0;
        }
    }
}
