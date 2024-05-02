using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.EntityLayer.Concrete
{
    public class BlogRayting
    {
        [Key]
        public int BlogRatingId { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRaytingCount { get; set; }
    }
}
