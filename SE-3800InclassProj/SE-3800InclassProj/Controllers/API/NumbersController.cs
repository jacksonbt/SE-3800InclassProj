using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SE_3800InclassProj.Models;

namespace SE_3800InclassProj.Controllers.API
{
    [RoutePrefix("api/Numbers")]
    public class NumbersController : ApiController
    {
        private Projectdb db = new Projectdb();

        // GET: api/Numbers
        public IQueryable<Number> GetNumbers()
        {
            return db.Numbers;
        }

        [Route("Max")]
        public Number GetMaxNumber()
        {
            return db.Numbers.First(num => num.number == db.Numbers.Max(num1 => num1.number));
        }

        // GET: api/Numbers/5
        [ResponseType(typeof(Number))]
        public IHttpActionResult GetNumber(int id)
        {
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return NotFound();
            }

            return Ok(number);
        }

        // PUT: api/Numbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNumber(int id, Number number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != number.numberId)
            {
                return BadRequest();
            }

            db.Entry(number).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberExists(id))
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

        // POST: api/Numbers
        [ResponseType(typeof(Number))]
        public IHttpActionResult PostNumber(int num)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var number = new Number()
            {
                number = num
            };

            number = db.Numbers.Add(number);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = number.numberId }, number);
        }

        // DELETE: api/Numbers/5
        [ResponseType(typeof(Number))]
        public IHttpActionResult DeleteNumber(int id)
        {
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return NotFound();
            }

            db.Numbers.Remove(number);
            db.SaveChanges();

            return Ok(number);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NumberExists(int id)
        {
            return db.Numbers.Count(e => e.numberId == id) > 0;
        }
    }
}