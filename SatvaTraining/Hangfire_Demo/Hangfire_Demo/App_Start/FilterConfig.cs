﻿using System.Web;
using System.Web.Mvc;

namespace Hangfire_Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
