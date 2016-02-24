namespace GamerSchool.Web.Areas.Users.ViewModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using GamerSchool.Data.Common;
    using GamerSchool.Data.Models;
    using GamerSchool.Web.Infrastructure.Mapping;

    public class InputCommentViewModelCreate : IMapTo<Comment>
    {
        public InputCommentViewModelCreate()
        {
        }

        public InputCommentViewModelCreate(int articleId)
        {
            this.EntityId = articleId;
        }

        [Required]
        [UIHint("MultiLineText")]
        [MaxLength(ValidationConstants.MaxCommentContentLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int EntityId { get; set; }
    }
}
