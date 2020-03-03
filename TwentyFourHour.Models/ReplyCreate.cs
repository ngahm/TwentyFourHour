using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class ReplyCreate:CommentCreate
    {
        //Note this inherits from CommentCreate
        [Required]
        public int ReplyCommentID { get; set; }

    }
}
