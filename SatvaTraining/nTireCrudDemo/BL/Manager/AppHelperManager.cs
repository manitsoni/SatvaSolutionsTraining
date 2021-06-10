using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using AutoMapper;
using Data.Model;
using BL.Manager.Interface;
using Data.Repository.Interface;
namespace BL.Manager
{
    public class AppHelperManager : IAppHelperManager
    {
        private IAppHelperRepository Repository;
        public AppHelperManager(IAppHelperRepository appHelperRepository)
        {
            Repository = appHelperRepository;
        }
        public bool AddCity(tblCity city)
        {
            bool IsAvailable = false;
            var data = GetCities().ToList();
            foreach (var item in data)
            {
                if (item.CityName == city.CityName || city.CityName == "")
                {
                    IsAvailable = true;
                    break;
                }
            }
            if (IsAvailable == false)
            {
                return Repository.AddCity(city);
            }
            else
            {
                return false;
            }  
        }

        public bool AddCountry(Country country)
        {
            bool IsAvailable = false;
            var data = GetCountries().ToList();
            foreach (var item in data)
            {
                if (item.CountryName == country.CountryName  || country.CountryName == "")
                {
                    IsAvailable = true;
                    break;
                }
            }
            if (IsAvailable == false)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Country, tblCountry>());
                IMapper mapper = config.CreateMapper();
                tblCountry cu = mapper.Map<Country, tblCountry>(country);
                return Repository.AddCountry(cu);
            }
            else
            {
                return false;
            }
           
        }
        
        public bool AddState(tblState state)
        {
            bool IsAvailable = false;
            var data = GetStates().ToList();
            foreach (var item in data)
            {
                if (item.StateName == state.StateName || state.StateName == "")
                {
                    IsAvailable = true;
                    break;
                }
            }
            if (IsAvailable == false)
            {
                return Repository.AddState(state);
            }
            else
            {
                return false;
            }
            
        }

        public bool CheckEmail(string Email)
        {
            return Repository.CheckEmail(Email);
        }

        public bool DeleteCity(int id)
        {
            return Repository.DeleteCity(id);
        }

        public bool DeleteCountry(int id)
        {
            return Repository.DeleteCountry(id);
        }

        public bool DeleteState(int id)
        {
            return Repository.DeleteState(id);
        }

        public bool EditCity(tblCity city)
        {
            return Repository.EditCity(city);
        }

        public bool EditCountry(tblCountry country)
        {
            return Repository.EditCountry(country);
        }

        public bool EditState(tblState state)
        {
            return Repository.EditState(state);
        }

        public IList<City> GetCities()
        {
            return Repository.GetCities();
        }

        public tblCity GetCity(int id)
        {
            return Repository.GetCity(id);
        }

        public IList<City> GetcityByCountry(int Countryid)
        {
            return Repository.GetcityByCountry(Countryid).ToList();
        }
        public IList<City> GetCityByState(int Stateid)
        {
            return Repository.GetCityByState(Stateid);
        }

        public IList<Country> GetCountries()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblCountry, Country>());
            IMapper mapper = config.CreateMapper();
            var data = Repository.GetCountries().ToList();
            List<Country> countries = data.Select(x => mapper.Map<tblCountry, Country>(x)).ToList();
            return countries;
        }

        public tblCountry GetCountry(int id)
        {
            try
            {
                return Repository.GetCountry(id);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public tblState GetState(int id)
        {
            return Repository.GetState(id);
        }

        public IList<State> GetStateByCountry(int CountryId)
        {
            return Repository.GetStateByCountry(CountryId);
        }

        public IList<State> GetStates()
        {
            return Repository.GetStates();
        }

        public bool VerifyMobileNumber(int EmployeeId)
        {
            return Repository.VerifyMobileNumber(EmployeeId);
        }
    }
}
