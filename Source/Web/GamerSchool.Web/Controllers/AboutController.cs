namespace GamerSchool.Web.Controllers
{
    using System.Web.Mvc;

    public class AboutController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
