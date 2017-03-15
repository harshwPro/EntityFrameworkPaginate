using System.Web.Mvc;
using EntityFrameworkPaginate.Example.Dal;

namespace EntityFrameworkPaginate.Example.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFilteredPaged(int pageSize, int currentPage, string searchText, int sortBy, string jobTitle)
        {
            return Json(new EmployeeDal().GetFilteredEmployees(pageSize, currentPage, searchText, sortBy, jobTitle), JsonRequestBehavior.AllowGet);
        }
    }
}