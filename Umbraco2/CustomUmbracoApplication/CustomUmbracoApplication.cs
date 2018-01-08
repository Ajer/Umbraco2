using System;
using System.Net.Http.Headers;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Web;

namespace Umbraco2
{
    public class CustomUmbracoApplication : UmbracoApplication
    {
        protected override IBootManager GetBootManager()
        {
            return new CustomWebBootManager(this);
        }

        private void application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}