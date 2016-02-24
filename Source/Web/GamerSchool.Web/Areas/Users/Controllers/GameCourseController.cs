namespace GamerSchool.Web.Areas.Users.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using GamerSchool.Common;
    using GamerSchool.Common.Extensions;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;
    using GamerSchool.Web.Controllers;
    using GamerSchool.Web.Infrastructure.Constants;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.Infrastructure.UploadHelpers;
    using GamerSchool.Web.ViewModels.GameCourse;

    [Authorize(Roles = ApplicationRoles.Trainer)]
    public class GameCourseController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly IGameCoursesService courses;
        private readonly IUsersService users;

        public GameCourseController(IGameCoursesService courses, IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCourseInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<GameCourse>(model);
                var imageUploader = new ImageUplouder();
                var images = new HashSet<Image>();
                string folderPath = this.Server.MapPath(WebConstants.ImagesMainPathMap + currentUserId);

                if (model.Files != null && model.Files.Count() > 0)
                {
                    foreach (var file in model.Files)
                    {
                        if (file != null
                            && (file.ContentType == WebConstants.ContentTypeJpg || file.ContentType == WebConstants.ContentTypePng)
                            && file.ContentLength < WebConstants.MaxImageFileSize)
                        {
                            images.Add(imageUploader.UploadImage(file, folderPath, currentUserId));
                        }
                    }
                }

                var trainer = this.users.UserById(currentUserId).FirstOrDefault();

                newArticle.Coaches.Add(trainer);

                var result = this.courses.Create(newArticle);

                return this.RedirectToAction("Course", "Academy", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.courses.GetById(id)
            .To<GameCourseInputModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameCourseInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<GameCourse>(model);
                var imageUploader = new ImageUplouder();
                var images = new HashSet<Image>();
                string folderPath = this.Server.MapPath(WebConstants.ImagesMainPathMap + currentUserId);

                if (model.Files != null && model.Files.Count() > 0)
                {
                    foreach (var file in model.Files)
                    {
                        if (file != null
                            && (file.ContentType == WebConstants.ContentTypeJpg || file.ContentType == WebConstants.ContentTypePng)
                            && file.ContentLength < WebConstants.MaxImageFileSize)
                        {
                            images.Add(imageUploader.UploadImage(file, folderPath, currentUserId));
                        }
                    }
                }

                images.ForEach(x => updatedArticle.Images.Add(x));

                this.courses.Update(model.Id, updatedArticle);

                return this.RedirectToAction("Course", "Academy", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.courses.Destroy(id, this.UserProfile.Id);

            return this.RedirectToAction("Index", "Academy", new { area = "Users", id = 1 });
        }
    }
}
