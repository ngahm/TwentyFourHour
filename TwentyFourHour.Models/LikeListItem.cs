﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class LikeListItem
    { 
        public int LikePostID { get; set; }
       
        public Guid LikerID { get; set; }
    }
}
