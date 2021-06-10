using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Automapper_Ex.Models;
namespace Automapper_Ex.AutomapperProfile
{
    public class AMProfile : Profile
    {
        public AMProfile()
        {
            CreateMap<Company, tblCompany>();
        }
    }
}