using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Models
{
    public class LikeCreate
    {
        [Required]
        public int LikePostID { get; set; }
       [Required]
        public int LikerID { get; set; }

    }
}
