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
    using GamerSchool.Web.ViewModels.Common;
    using Web.ViewModels.FPS;
    using Web.ViewModels.Tutorial;

    [Authorize]
    public class FPSController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ITutorialService tutorials;

        public FPSController(ITutorialService tutorials)
        {
            this.tutorials = tutorials;
        }

        // GET: Public/design
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.tutorials
                .GetAll()
                .Count(x => x.Type == TutorialType.FPS);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var arts = this.tutorials
                .GetByUserId(this.UserProfile.Id)
                .Where(x => x.Type == TutorialType.FPS)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage)
                .To<TutorialViewModel>()
                .ToList();

            var paginationModel = new PaginationViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Path = "/Users/FPS/Index/"
            };

            var model = new FPSIndexViewModel()
            {
                PaginationModel = paginationModel,
                ArtArticles = arts
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TutorialInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var newArticle = this.Mapper.Map<Tutorial>(model);
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

                newArticle.Type = TutorialType.FPS;
                newArticle.AuthorId = currentUserId;
                newArticle.Images = images;

                var result = this.tutorials.Create(newArticle);

                // TODO: Fix Redirect
                return this.RedirectToAction("Details", "FPS", new { area = "", id = result });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var art = this.tutorials.GetById(id)
            .To<TutorialInputViewModel>()
            .FirstOrDefault();

            return this.View(art);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TutorialInputViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.UserProfile.Id;
                var updatedArticle = this.Mapper.Map<Tutorial>(model);
                var imageUploader = new ImageUplouder();
                var images = new HashSet<Image>();
                string folderPath = this.Server.MapPath(WebConstants.ImagesMainPathMap + currentUserId);

                if (model.Files != null && model.Files.Any())
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

                this.tutorials.Update(model.Id, updatedArticle);

                // TODO: Fix Redirect
                return this.RedirectToAction("Details", "FPS", new { area = "", id = model.Id });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy(int id)
        {
            this.tutorials.Destroy(id, this.UserProfile.Id);

            // TODD: Fix Redirects
            return this.RedirectToAction("Index", "FPS", new { area = "Users", id = 1 });
        }
    }
}