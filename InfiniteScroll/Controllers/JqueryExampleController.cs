using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using InfiniteScroll.Dal;

namespace InfiniteScroll.Controllers
{
    public class JqueryExampleController : Controller
    {
        // GET: JqueryExample
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTreks(int pageSize, int currentPage, string countryName, int sortBy)
        {
            Thread.Sleep(500);
            return Json(new PlacesDal().GetFilteredPagedTreks(pageSize, currentPage, countryName, sortBy), JsonRequestBehavior.AllowGet);
        }
    }
}