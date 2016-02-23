﻿namespace GamerSchool.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using GamerSchool.Data.Common;
    using GamerSchool.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(ValidationConstants.MinCommentContentLength, ErrorMessage = ValidationConstants.MinLengthErrorMessage)]
        [MaxLength(ValidationConstants.MaxCommentContentLength, ErrorMessage = ValidationConstants.MaxLengthErrorMessage)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int EntityId { get; set; }

        public virtual InteractiveEntity Entity { get; set; }
    }
}
