using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetList(int PageSize, int PageNumber)  //要查找的页数的值
        {
            Book.BLL.T_Base_User bll = new BLL.T_Base_User();
            List<Book.Model.T_Base_User> list = bll.GetList(PageNumber, PageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = list });
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddSave(string LoginName, string PassWord,int RoleId)
        {
            Book.Model.T_Base_User user = new Model.T_Base_User();
            user.LoginName = LoginName;
            user.PassWord = PassWord;
            user.RoleId = RoleId;

            Book.BLL.T_Base_User bll = new BLL.T_Base_User();
            int result = bll.AddSave(user);

            return Redirect("/User/Index");
        }
        [Authorize]
        public JsonResult Delete(string[] Ids)
        {
            Book.BLL.T_Base_User bll = new BLL.T_Base_User();
            return Json(bll.Delete(Ids));
        }
        [Authorize]
        public ActionResult Alter(int Id)
        {
            Book.BLL.T_Base_User bll = new BLL.T_Base_User();
            ViewBag.user = bll.Alter(Id);
            return View();
        }
        [Authorize]
        public ActionResult AlterSave(int Id,string LoginName,string PassWord,int RoleId)
        {

            Book.BLL.T_Base_User bll = new BLL.T_Base_User();
            Book.Model.T_Base_User user = new Model.T_Base_User();
            user.Id = Id;
            user.LoginName = LoginName;
            user.PassWord = PassWord;
            user.RoleId = RoleId;
            bll.AlterSave(user);

            return RedirectToAction("Index");
        }
        [Authorize]
        public JsonResult GetSearch(string query, int mathCount)
        {
            BLL.T_Base_User bll = new BLL.T_Base_User();
            return Json(bll.GetSearch(query, mathCount));
        }
    }
}