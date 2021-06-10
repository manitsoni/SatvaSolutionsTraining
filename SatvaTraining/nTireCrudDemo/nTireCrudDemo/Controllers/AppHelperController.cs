using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Common;
using BE;
using Data.Model;
using BL.Manager.Interface;
using Data.Repository.Interface;
using Newtonsoft.Json;
namespace nTireCrudDemo.Controllers
{
    public class AppHelperController : Controller
    {
        IsSuperUserLogin Userlogin = new IsSuperUserLogin();
        private IAppHelperManager Repository;
        EmployeeManagementEntities db = new EmployeeManagementEntities();
        public AppHelperController(IAppHelperManager repository)
        {
           
            Repository = repository;
        }
        // GET: AppHelper
        public ActionResult Index()
        {
            if (Userlogin.IsUserLogin())
            {
                ViewBag.clist = new SelectList("");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            } 
        }
        #region Country
        public JsonResult AddCountry(string Id, string CountryName)
        {
            if (Id == "")
            {
                Country country = new Country();
                country.CountryName = CountryName;
                return Json(Repository.AddCountry(country), JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblCountry country = new tblCountry();
                country.Id = Convert.ToInt32(Id);
                country.CountryName = CountryName;
                return Json(Repository.EditCountry(country), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCountry()
        {
           
            var data = Repository.GetCountries();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCForDD()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = Repository.GetCountries().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSForDD(string cid)
        {
            if (cid == "")
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Repository.GetStateByCountry(Convert.ToInt32(cid)), JsonRequestBehavior.AllowGet);
            }
           
        }
        public JsonResult GetCountryById(string id)
        {
            try
            {
                var data = Repository.GetCountry(Convert.ToInt32(id));
                tblCountry ctr = new tblCountry();
                ctr.Id = data.Id;
                ctr.CountryName = data.CountryName;
                return Json(ctr, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex,JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult DeleteCountry(string Id)
        {
            return Json(Repository.DeleteCountry(Convert.ToInt32(Id)), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region State
        public JsonResult AddState(string Id,string CoyntryId,string Statename)
        {
            if (Id == "")
            {
                tblState state = new tblState();
                state.StateName = Statename;
                state.CountryId = Convert.ToInt32(CoyntryId);
                return Json(Repository.AddState(state), JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblState state = new tblState();
                state.StateName = Statename;
                state.CountryId = Convert.ToInt32(CoyntryId);
                state.Id = Convert.ToInt32(Id);
                return Json(Repository.EditState(state), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetState()
        {
            return Json(Repository.GetStates(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStateById(string Id)
        {
            var data = Repository.GetState(Convert.ToInt32(Id));
            tblState state = new tblState();
            state.Id = data.Id;
            state.StateName = data.StateName;
            state.CountryId = data.CountryId;
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteState(string Id)
        {
            return Json(Repository.DeleteState(Convert.ToInt32(Id)), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region City
        public JsonResult GetCity()
        {
           
            return Json(Repository.GetCities(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddCity(string id,string cid,string sid,string CityName)
        {
            if (sid == "")
            {
                sid = "0";
            }
            if (id == "")
            {
                tblCity city = new tblCity();
                city.CityName = CityName;
                city.CountryId = Convert.ToInt32(cid);
                city.StateId = Convert.ToInt32(sid);
                return Json(Repository.AddCity(city), JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblCity city = new tblCity();
                city.CityName = CityName;
                city.CountryId = Convert.ToInt32(cid);
                city.StateId = Convert.ToInt32(sid);
                city.Id = Convert.ToInt32(id);
                return Json(Repository.EditCity(city), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCityById(string Id)
        {
            var data = Repository.GetCity(Convert.ToInt32(Id));
            tblCity city = new tblCity();
            city.Id = data.Id;
            city.CityName = data.CityName;
            city.CountryId = data.CountryId;
            city.StateId = data.StateId;
            return Json(city, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCity(string Id)
        {
            return Json(Repository.DeleteCity(Convert.ToInt32(Id)), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Helper
        public JsonResult GetStateByCountry(string cid)
        {
            try
            {
                var data = Repository.GetStateByCountry(Convert.ToInt32(cid));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public JsonResult GetCityByState(string sid)
        {
            try
            {
                var data = Repository.GetCityByState(Convert.ToInt32(sid));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public JsonResult GetCityByCountry(string cid)
        {
            try
            {
                var data = Repository.GetcityByCountry(Convert.ToInt32(cid));
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public JsonResult CheckEmail(string Email)
        {
            bool e = Repository.CheckEmail(Email);
            return Json(Repository.CheckEmail(Email), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}