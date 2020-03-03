using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFourHour.Models;
using TwentyFourHour.Services;

namespace TwentyFourHour.WebAPI.Controllers
{
    public class CommentController : ApiController
    {

        //POST COMMENT ()

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        //GET COMMENT ()
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var notes = commentService.GetComment();
            return Ok(notes);
        }

        //GET COMMENT BY ID
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var note = commentService.GetCommentById(id);
            return Ok(note);
        }



        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
    }
}
