using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetList(int pageSize, int pageNumber)
        {
            Book.BLL.T_Stock_Report bll = new BLL.T_Stock_Report();
            List<Book.Model.T_Stock_Report> list = bll.GetList(pageNumber, pageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = list });
            //return Json(list);
        }
    }
}