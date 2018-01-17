using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using Umbraco2.Models;

namespace Umbraco2.Controllers
{
    public class MemberSurfaceController : SurfaceController
    {

      
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return CurrentUmbracoPage();
            }

            //System.Web.Helpers.AntiForgery.Validate();

            if (ModelState.IsValid && Membership.ValidateUser(model.Username, model.Password))
            {
                Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return Redirect("/Login"); //return Redirect("/Private_Content");
           
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
            return Redirect("/Login");
        }

     
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.Cookies.Clear();

            FormsAuthentication.SignOut();
            //WebSecurity.Logout();

            return Redirect("/Login");          
        }

    }
}
