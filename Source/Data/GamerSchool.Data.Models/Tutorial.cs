namespace GamerSchool.Data.Models
{

    using System.Collections.Generic;

    using Common.Models;

    public class Tutorial : InteractiveEntity
    {
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public TutorialType Type { get; set; }
    }
}
