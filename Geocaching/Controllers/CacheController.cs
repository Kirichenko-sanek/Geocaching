using System.Web.Mvc;
using Geocaching.Filters;

namespace Geocaching.Controllers
{
    [Culture]
    public class CacheController : Controller
    {
        //private readonly 

        [AllowAnonymous]
        public ActionResult CachePage()
        {
            return View();
        }


    }
}