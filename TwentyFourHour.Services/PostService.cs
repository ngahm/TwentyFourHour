using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models;

namespace TwentyFourHour.Services
{
    public class PostService
    {

        //CREATE POST
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new PostService()
            {
                OwnerId = _userId,
                Title = model.Title,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItems> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx.Comments
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new CommentListItem
                    {
                        
                    })
            }
        }


        //GET POSTS



        //GET POST BY ID
    }
}
