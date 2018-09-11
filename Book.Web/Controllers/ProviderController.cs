using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provide
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetList(int PageSize, int PageNumber)  //要查找的页数的值
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            List<Book.Model.T_Base_Provider> list = bll.GetList(PageNumber, PageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = list });
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddSave(string ProviderName, string ProviderTel, string Memo)
        {
            Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
            provider.ProviderName = ProviderName;
            provider.ProviderTel = ProviderTel;
            provider.Memo = Memo;

            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            int result = bll.AddSave(provider);

            return Redirect("/Provider/Index");
        }
        [Authorize]
        public JsonResult Delete(string[] Ids)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            return Json(bll.Delete(Ids));
        }
        [Authorize]
        public ActionResult Alter(int Id)
        {
            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            ViewBag.provider = bll.Alter(Id);
            return View();
        }
        [Authorize]
        public ActionResult AlterSave(int Id, string ProviderName, string ProviderTel, string Memo)
        {

            Book.BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            Book.Model.T_Base_Provider provider = new Model.T_Base_Provider();
            provider.Id = Id;
            provider.ProviderName = ProviderName;
            provider.ProviderTel = ProviderTel;
            provider.Memo = Memo;
            bll.AlterSave(provider);

            return RedirectToAction("Index");
        }
        [Authorize]
        public JsonResult GetSearch(string query, int mathCount)
        {
            BLL.T_Base_Provider bll = new BLL.T_Base_Provider();
            return Json(bll.GetSearch(query, mathCount));
        }
    }
}