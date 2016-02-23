﻿namespace GamerSchool.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using GamerSchool.Data.Common;
    using GamerSchool.Data.Common.Models;

    public abstract class InteractiveEntity : BaseModel<int>
    {
        private ICollection<Comment> comments;
        private ICollection<Like> likes;
        private ICollection<Image> images;

        protected InteractiveEntity()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<Like>();
            this.images = new HashSet<Image>();
        }

        [Required]
        [MinLength(ValidationConstants.MinInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxInteractiveEntityTitleLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.MaxInteractiveEntityDescriptionLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Description { get; set; }


        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
