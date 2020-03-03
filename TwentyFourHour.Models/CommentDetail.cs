﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourHour.Data;

namespace TwentyFourHour.Models
{
    public class CommentDetail
    {
        public int CommentID { get; set; }

        public string Text { get; set; }

        public Guid AuthorID { get; set; }
        public virtual User Author { get; set; }

        public int CommentPostID { get; set; }
        public virtual Post CommentPost { get; set; }
    }
}
