﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class Post
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
    }
}
