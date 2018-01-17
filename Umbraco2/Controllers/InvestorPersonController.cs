using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Umbraco.Core;
using Umbraco.Core.Security;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco2.Models;
using Umbraco2.Models.QueryViewModels;
using IUser = Umbraco.Core.Models.Membership.IUser;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;



namespace Umbraco2.Controllers
{
    
    public class InvestorPersonController: Umbraco.Web.WebApi.UmbracoApiController
    {
        private Umbraco2Entities db = new Umbraco2Entities();

        // GET: api/InvestorPerson
        public JsonResult<List<GetNbrOfQVM>> GetPersons()   // JsonResult<DbSet<z_Person>>
        {
            IUser currentUser = null;

            var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();

            if (userTicket != null)
            {

                currentUser = ApplicationContext.Services.UserService.GetByUsername(userTicket.Name);

                var j = Request.RequestUri;
                var k = System.Web.HttpContext.Current.Request.UrlReferrer;

                if (currentUser == null || !InvestorDashboardPermission(currentUser.Id))
                {
                    var j1 = Request.RequestUri;
                    var k1 = System.Web.HttpContext.Current.Request.UrlReferrer;
                    if (k1 == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    // var j = Request.RequestUri;
                    //var k = System.Web.HttpContext.Current.Request.UrlReferrer;
                    //var h = new JsonSerializerSettings();

                    // HttpContext.Current.Response.ContentType = "application/json";

                    var k1 = System.Web.HttpContext.Current.Request.UrlReferrer;
                    if (k1 == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }

                    var res = new List<GetNbrOfQVM>();

                    foreach (var p in db.z_Person)
                    {
                        GetNbrOfQVM gbnr = new GetNbrOfQVM();
                        gbnr.Id = p.PersonID;
                        gbnr.FirstName = p.FirstName;
                        gbnr.LastName = p.LastName;
                        gbnr.Email = p.Email;

                        gbnr.NbrOf = GetNbrOfInvest(gbnr.Id);

                        res.Add(gbnr);
                    }

                    return Json(res); //Json(db.z_Person);
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }


        // GET: api/InvestorPerson/5
        //[ResponseType(typeof(z_Person))]
        public async Task<JsonResult<z_Person>> GetPerson(int id)
        {
            IUser currentUser = null;

            var userTicket = new System.Web.HttpContextWrapper(System.Web.HttpContext.Current).GetUmbracoAuthTicket();
            if (userTicket != null)
            {
                currentUser = ApplicationContext.Services.UserService.GetByUsername(userTicket.Name);
            }


            if (currentUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            z_Person person = await db.z_Person.FindAsync(id);

            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Json(person);
        }

        // PUT: api/InvestorPerson/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, z_Person person)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/InvestorPerson
        [ResponseType(typeof(z_Person))]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> PostPerson(z_Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.z_Person.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonID }, person);
        }

        // DELETE: api/InvestorPerson/5
        [ResponseType(typeof(z_Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            z_Person person = await db.z_Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.z_Person.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        
        //[Route("api/InvestorPerson/GetNbrOfProjects/{Id}")]
        //[HttpGet]
        //public async Task<JsonResult<int>> GetNbrOfProjects(int Id)  //DbRawSqlQuery<int>
        //{

            // use SqlParameter()
            // var j = db.Database.SqlQuery<int>("Select count(*) from dbo.z_InvestedHistory where PersonID=@pID");
            // return Json(j);

            //var cnt = await (from e in db.z_InvestedHistory

            //    join p in db.z_Person on e.PersonID equals p.PersonID
            //    where p.PersonID == Id

            //    select e.InvestorProjectID).Distinct().ToListAsync();

            //int cnt = (db.z_InvestedHistory
            //    .Join(db.z_Person, e => e.PersonID, p => p.PersonID, (e, p) => new {e, p})
            //    .GroupBy(@t => new {@t.e.InvestorProjectID}, @t => @t.e)).ToList().Count();

        //    return Json(cnt.Count());
        //}


        public int GetNbrOfInvest(int Id)
        {
              var query =   (from e in db.z_InvestedHistory

                join p in db.z_Person on e.PersonID equals p.PersonID
                where p.PersonID == Id

                select e.InvestorProjectID).Distinct().ToList();

            return query.Count();
        }

        // Kontrollerar om umbracoUserId har tillstånd att se InvestorDashboard
        // genom att kontrollera tabell 
        public bool InvestorDashboardPermission(int umbracoUserId)
        {

            var query = (from d in db.z_investeraDashboardPermission
                where d.umbracoUserId == umbracoUserId
                select d.investeraDashBoardUser).Single();

            return query;
        }


        //public async Task<ActionResult> SignIn()
        //{
        //    var c = new System.Web.Mvc.Controller();
        //    IAuthenticationManager authMgr = H.GetOwinContext().Authentication;
        //    StoreUserManager sum = HttpContext.GetOwinContext().GetUserManager<StoreUserManager>();

        //    StoreUser user = await sum.FindAsync("Admin", "secret");
        //    authMgr.SignIn(await sum.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));

        //    return RedirectToAction("Index");
        //}



        //public ActionResult SignOut()
        //{

        //    HttpContext.GetOwinContext().Authentication.SignOut();

        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool PersonExists(int id)
        {
            return db.z_Person.Count(e => e.PersonID == id) > 0;
        }


    }
}