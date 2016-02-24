﻿namespace GamerSchool.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Data.Contracts;
    using GamerSchool.Web.Infrastructure.Mapping;
    using GamerSchool.Web.ViewModels.Common;
    using ViewModels.FPS;
    using ViewModels.Tutorial;

    public class FPSController : BaseController
    {
        private const int ItemsPerPage = 6;
        private readonly ITutorialService tutorials;

        public FPSController(ITutorialService tutorials)
        {
            this.tutorials = tutorials;
        }

        // GET: Public/Design
        public ActionResult Index(int page = 1)
        {
            var allItemsCount = this.tutorials.GetAll().Count(x => x.Type == TutorialType.FPS);
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);

            var arts = this.tutorials
                .GetAll()
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
                Path = "/Design?page="
            };

            var model = new FPSIndexViewModel()
            {
                PaginationModel = paginationModel,
                ArtArticles = arts
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var art = this.tutorials.GetById(id)
                .To<TutorialViewModel>()
                .FirstOrDefault();

            return this.View(art);
        }
    }
}