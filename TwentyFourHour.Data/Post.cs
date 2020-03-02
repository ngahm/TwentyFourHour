using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFourHour.Data
{
    public class Post
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorID { get; set; }
        public virtual User Author { get; set; }
    }
}
