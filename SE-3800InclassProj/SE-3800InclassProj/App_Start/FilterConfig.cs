﻿using System.Web;
using System.Web.Mvc;

namespace SE_3800InclassProj
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
