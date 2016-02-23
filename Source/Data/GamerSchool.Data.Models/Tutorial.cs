using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerSchool.Data.Models
{
    class Tutorial
    {
    }

    using System.Collections.Generic;

    using H8QMedia.Data.Common.Models;

    public class Article : InteractiveEntity
    {
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public ArticleType Type { get; set; }
    }
}
