using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class InController : Controller
    {
        // GET: In
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetALL()
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_In> list = bll.GetAll();
            return Json(list);
        }
        [Authorize]
        public JsonResult GetList(int pageSize, int pageNumber)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_In> list = bll.GetList(pageNumber, pageSize);
            Book.BLL.T_Stock_In bll_count = new BLL.T_Stock_In();
            int count = bll_count.GetCount();
            return Json(new { total = count, rows = list });
            //return Json(list);
        }
        [Authorize]
        public JsonResult GetModel(int headId)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            List<Book.Model.T_Stock_InItems> list = bll.GetModel(headId);
            return Json(list);
        }
        public JsonResult Delete(string[] HeadIds)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            return Json(bll.Delete(HeadIds));
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public JsonResult AddSave(Book.Model.T_Stock_InHead Head,Book.Model.T_Stock_InItems[] Items)
        {
            Book.BLL.T_Stock_In bll = new BLL.T_Stock_In();
            Book.Model.T_Stock_In inStock = new Model.T_Stock_In();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bll.AddSave(inStock);
            return Json(1);
        }
    }
}