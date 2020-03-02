using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Data
{
    public class Like
    {
        [ForeignKey(nameof(LikedPost))]
        public int LikePostID { get; set; }
        public virtual Post LikedPost { get; set; }
        [ForeignKey(nameof(Liker))]
        public int LikerID { get; set; }
        public virtual User Liker { get; set; }
    }
}
