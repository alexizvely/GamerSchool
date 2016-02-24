namespace GamerSchool.Web.Areas.Users.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data;
    using GamerSchool.Web.Areas.Users.ViewModels.Comment;
    using GamerSchool.Web.Controllers;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Comment;
    using Services.Data.Contracts;

    public class CommentController : BaseController
    {
        private ICommentsService commentsService;

        public CommentController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(InputCommentViewModelCreate model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = this.Mapper.Map<Comment>(model);
                comment.UserId = this.UserProfile.Id;

                comment = this.commentsService.AddNew(comment);

                var viewModel = this.Mapper.Map<CommentViewModel>(comment);
                viewModel.UserName = this.UserProfile.UserName;

                return this.PartialView("~/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid Comment");
        }

        [Authorize]
        public ActionResult Delete(int id, int articleID)
        {
            this.commentsService.DeleteCommentById(id);

            return this.GetPageCommentsPartial(articleID);
        }

        public ActionResult GetPageCommentsPartial(int articleId)
        {
            var comments = this.commentsService
                .AllByEntity(articleId)
                .To<CommentViewModel>();

            return this.PartialView("_EntityCommentsPartial", comments);
        }
    }
}
