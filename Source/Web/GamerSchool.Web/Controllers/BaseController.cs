namespace GamerSchool.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using AutoMapper;
    using GamerSchool.Data;
    using GamerSchool.Data.Models;
    using GamerSchool.Services.Web;

    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        protected ApplicationUser UserProfile { get; private set; }

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            var dbContext = new ApplicationDbContext();

            this.UserProfile = dbContext.Users.FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            dbContext.Dispose();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
