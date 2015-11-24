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
using NandosoApp.Models;

namespace NandosoApp.Controllers
{
    public class FeedbackPostsController : ApiController
    {
        private NandosoAppContext db = new NandosoAppContext();

        // GET: api/FeedbackPosts
        public IQueryable<FeedbackPost> GetFeedbackPosts()
        {
            return db.FeedbackPosts;
        }

        // GET: api/FeedbackPosts/5
        [ResponseType(typeof(FeedbackPost))]
        public IHttpActionResult GetFeedbackPost(int id)
        {
            FeedbackPost feedbackPost = db.FeedbackPosts.Find(id);
            if (feedbackPost == null)
            {
                return NotFound();
            }

            return Ok(feedbackPost);
        }

        // PUT: api/FeedbackPosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedbackPost(int id, FeedbackPost feedbackPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedbackPost.FeedbackPostID)
            {
                return BadRequest();
            }

            db.Entry(feedbackPost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackPostExists(id))
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

        // POST: api/FeedbackPosts
        [ResponseType(typeof(FeedbackPost))]
        public IHttpActionResult PostFeedbackPost(FeedbackPost feedbackPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeedbackPosts.Add(feedbackPost);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedbackPost.FeedbackPostID }, feedbackPost);
        }

        // DELETE: api/FeedbackPosts/5
        [ResponseType(typeof(FeedbackPost))]
        public IHttpActionResult DeleteFeedbackPost(int id)
        {
            FeedbackPost feedbackPost = db.FeedbackPosts.Find(id);
            if (feedbackPost == null)
            {
                return NotFound();
            }

            db.FeedbackPosts.Remove(feedbackPost);
            db.SaveChanges();

            return Ok(feedbackPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackPostExists(int id)
        {
            return db.FeedbackPosts.Count(e => e.FeedbackPostID == id) > 0;
        }
    }
}