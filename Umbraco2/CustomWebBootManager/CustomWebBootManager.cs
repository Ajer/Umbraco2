using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Web;

namespace Umbraco2
{
    public class CustomWebBootManager : WebBootManager
    {
        public CustomWebBootManager(UmbracoApplicationBase application) : base(application)
        {
            //Hook into boot manager
        }

        public override IBootManager Complete(Action<ApplicationContext> afterComplete)
        {
            //RouteTable.Routes.MapRoute(
            //        "Emner",
            //        "emner/",
            //        new
            //        {
            //            controller = "Emner",
            //            action = "Emner"
            //        });

            //RouteTable.Routes.MapRoute(
            //        "EmneAbonnenter",
            //        "emneabonnenter/",
            //        new
            //        {
            //            controller = "EmneAbonnenter",
            //            action = "EmneAbonnenter"
            //        });

            //RouteTable.Routes.MapRoute(
            //        "CalendarEvents",
            //        "calendarevents/",
            //        new
            //        {
            //            controller = "CalendarEvents",
            //            action = "CalendarEvents"
            //        });

            return base.Complete(afterComplete);
        }
    }
}