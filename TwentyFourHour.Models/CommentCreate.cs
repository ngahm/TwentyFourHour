﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class CommentCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int CommentID { get; set; }
    }
}
