using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Umbraco.Web.WebApi;
using Umbraco2.Models;

namespace Umbraco2.Controllers
{
    public class DashboardUserController : UmbracoApiController
    {

        private Umbraco2Entities db = new Umbraco2Entities();

        /// <summary>
        /// Authenoticate Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Login(string user, string password)
        {

            db.Configuration.ProxyCreationEnabled = false;

            var u = db.z_dashboardUser.FirstOrDefault(m => m.UserName == user && m.UserPass == password);

            if (u == null)
            {
                return NotFound();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(email, true);
                FormsAuthentication.RedirectFromLoginPage(email, false);
                member.LastLogedIn = DateTime.Now;
                _db.SaveChanges();

                return Ok();
            }
        }
        /// <summary>
        /// Register New Member
        /// </summary>
        /// <param name="data"></param>
        [HttpPost]
        public void RegisterNewMember(z_dashboardUser data)   // data är validerat och klart att registreras
        {
            var dash_user = new z_dashboardUser();
     
            dash_user.UserName = data.UserName;
            dash_user.UserPass = data.UserPass;
            dash_user.CreatedOn = DateTime.Now;

            _db.Members.Add(member);
            _db.SaveChanges();

        }

    }
}

