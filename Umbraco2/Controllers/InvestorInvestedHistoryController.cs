using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco2.Models;

namespace Umbraco2.Controllers
{
    public class InvestorInvestedHistoryController : ApiController
    {
        private Umbraco2Entities db = new Umbraco2Entities();

        // GET: api/InvestorInvestedHistory
        public IQueryable<z_InvestedHistory> GetInvestedHistory()
        {
        
            return db.z_InvestedHistory;
        }

        // GET: api/InvestorInvestedHistory/5
        //[ResponseType(typeof(z_InvestedHistory))]
        public async Task<IHttpActionResult> GetInvestedHistory(int id)
        {
            z_InvestedHistory investedHistory = await db.z_InvestedHistory.FindAsync(id);
            if (investedHistory == null)
            {
                return NotFound();
            }

            return Ok(investedHistory);
        }

        // PUT: api/InvestorInvestedHistory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvestedHistory(int id, z_InvestedHistory investedHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (id != investedHistory.InvestedHistoryID)
            {
                return BadRequest();
            }

            db.Entry(investedHistory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestedHistoryExists(id))
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

        // POST: api/InvestorInvestedHistory
        [ResponseType(typeof(z_InvestedHistory))]
        public async Task<IHttpActionResult> Postz_InvestedHistory(z_InvestedHistory investedHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.z_InvestedHistory.Add(investedHistory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = investedHistory.InvestedHistoryID }, investedHistory);
        }

        // DELETE: api/InvestorInvestedHistory/5
        //[ResponseType(typeof(z_InvestedHistory))]
        public async Task<IHttpActionResult> DeleteInvestedHistory(int id)
        {
            z_InvestedHistory investedHistory = await db.z_InvestedHistory.FindAsync(id);
            if (investedHistory == null)
            {
                return NotFound();
            }

            db.z_InvestedHistory.Remove(investedHistory);
            await db.SaveChangesAsync();

            return Ok(investedHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestedHistoryExists(int id)
        {
            return db.z_InvestedHistory.Count(e => e.InvestedHistoryID == id) > 0;
        }
    }
}