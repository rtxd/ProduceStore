﻿using System.Web;
using System.Web.Mvc;

namespace UTS.ProduceStore.WebFrontEnd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
