using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models;

namespace TwentyFourHour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        //Post

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Text = model.Text,
                    AuthorID = model.AuthorID,
                    CommentPostID = model.CommentPostID,
                    ReplyCommentID = model.ReplyCommentID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GETALL

        //GET BY ID
    }
}
