using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class OutController : Controller
    {
        // GET: Out
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetALL()
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            List<Book.Model.T_Stock_Out> list = bll.GetAll();
            return Json(list);
        }
        [Authorize]
        public JsonResult GetList(int pageSize, int pageNumber)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            List<Book.Model.T_Stock_Out> list = bll.GetList(pageNumber, pageSize);
            Book.BLL.T_Stock_Out bll_count = new BLL.T_Stock_Out();
            int count = bll_count.GetCount();
            return Json(new { total = count, rows = list });
            //return Json(list);
        }
        [Authorize]
        public JsonResult GetModel(int headId)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            List<Book.Model.T_Stock_OutItems> list = bll.GetModel(headId);
            return Json(list);
        }
        public JsonResult Delete(string[] HeadIds)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            return Json(bll.Delete(HeadIds));
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public JsonResult AddSave(Book.Model.T_Stock_OutHead Head, Book.Model.T_Stock_OutItems[] Items)
        {
            Book.BLL.T_Stock_Out bll = new BLL.T_Stock_Out();
            Book.Model.T_Stock_Out inStock = new Model.T_Stock_Out();
            inStock.Head = Head;
            inStock.Items = Items.ToList();
            bll.AddSave(inStock);
            return Json(1);
        }
    }
}