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
    public class FeedbackCommentsController : ApiController
    {
        private NandosoAppContext db = new NandosoAppContext();

        // GET: api/FeedbackComments
        public IQueryable<FeedbackComment> GetFeedbackComments()
        {
            return db.FeedbackComments;
        }

        // GET: api/FeedbackComments/5
        [ResponseType(typeof(FeedbackComment))]
        public IHttpActionResult GetFeedbackComment(int id)
        {
            FeedbackComment feedbackComment = db.FeedbackComments.Find(id);
            if (feedbackComment == null)
            {
                return NotFound();
            }

            return Ok(feedbackComment);
        }

        // PUT: api/FeedbackComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedbackComment(int id, FeedbackComment feedbackComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedbackComment.FeedbackCommentID)
            {
                return BadRequest();
            }

            db.Entry(feedbackComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackCommentExists(id))
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

        // POST: api/FeedbackComments
        [ResponseType(typeof(FeedbackComment))]
        public IHttpActionResult PostFeedbackComment(FeedbackComment feedbackComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeedbackComments.Add(feedbackComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedbackComment.FeedbackCommentID }, feedbackComment);
        }

        // DELETE: api/FeedbackComments/5
        [ResponseType(typeof(FeedbackComment))]
        public IHttpActionResult DeleteFeedbackComment(int id)
        {
            FeedbackComment feedbackComment = db.FeedbackComments.Find(id);
            if (feedbackComment == null)
            {
                return NotFound();
            }

            db.FeedbackComments.Remove(feedbackComment);
            db.SaveChanges();

            return Ok(feedbackComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackCommentExists(int id)
        {
            return db.FeedbackComments.Count(e => e.FeedbackCommentID == id) > 0;
        }
    }
}