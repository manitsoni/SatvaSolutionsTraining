using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Data.Model;
namespace BL.Manager.Interface
{
    public interface IAppHelperManager
    {
        bool AddCountry(Country country);
        tblCountry GetCountry(int id);
        bool EditCountry(tblCountry country);
        bool DeleteCountry(int id);
        IList<Country> GetCountries();

        //State
        bool AddState(tblState state);
        tblState GetState(int id);
        bool EditState(tblState state);
        IList<State> GetStates();
        bool DeleteState(int id);
        IList<State> GetStateByCountry(int CountryId);

        //City
        bool AddCity(tblCity city);
        tblCity GetCity(int id);
        bool EditCity(tblCity city);
        bool DeleteCity(int id);
        IList<City> GetCities();
        IList<City> GetCityByState(int Stateid);
        IList<City> GetcityByCountry(int Countryid);
        bool VerifyMobileNumber(int EmployeeId);
        bool CheckEmail(string Email);
    }
}
