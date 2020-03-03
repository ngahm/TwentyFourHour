﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;
using TwentyFourHour.Models;

namespace TwentyFourHour.Services
{
    public class LikeService
    {

        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        //POST

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    LikePostID = model.LikePostID,
                    LikerID = model.LikerID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Like.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET ALL
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Like
                    .Where(e => e.LikerID == _userId)
                    .Select(
                        e=>
                        new LikeListItem
                        {
                            LikerID=e.LikerID,
                            LikePostID=e.LikePostID
                        }

                        );
                return query.ToArray();
            }
        }


        //GET BY ID

        public LikeDetail GetLikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Like
                        .Single(e => e.ID == id && e.LikerID == _userId);
                return
                    new LikeDetail
                    {
                        LikerID = _userId,
                        Liker = entity.Liker,
                        LikePostID = entity.LikePostID,
                        LikedPost = entity.LikedPost,
                    };
            }
        }
    }
}
