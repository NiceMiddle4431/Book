using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Provide
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetList(int pageSize, int pageNumber)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            List<Book.Model.T_Base_Customer> list = bll.GetList(pageNumber, pageSize);
            int count = bll.GetCount();
            return Json(new { total = count, rows = list });
            //return Json(list);
        }
        [Authorize]
        public ActionResult Add()
        {

            return View();
        }
        [Authorize]
        public ActionResult AddSave(string CustomerName, string CustomerPwd,
            string CustomerPostbox,string CustomerTel)
        {
            Book.Model.T_Base_Customer user = new Model.T_Base_Customer();
            user.CustomerName = CustomerName;
            user.CustomerPwd = CustomerPwd;
            user.CustomerPostbox = CustomerPostbox;
            user.CustomerTel = CustomerTel;
            Book.BLL.T_Base_Customer userAddSave = new BLL.T_Base_Customer();
            int result = userAddSave.AddSave(user);

            return Redirect("/Customer/Index");
        }
        [Authorize]
        public JsonResult Delete(string[] Ids)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            return Json(bll.Delete(Ids));
        }
        [Authorize]
        public ActionResult Alter(int Id)
        {
            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            ViewBag.user = bll.Alter(Id);
            return View();
        }
        [Authorize]
        public ActionResult AlterSave(int Id, string CustomerName,
            string CustomerPwd, string CustomerPostbox,string CustomerTel)
        {

            Book.BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            Book.Model.T_Base_Customer alterCustomer = new Model.T_Base_Customer();
            alterCustomer.Id = Id;
            alterCustomer.CustomerName = CustomerName;
            alterCustomer.CustomerPwd = CustomerPwd;
            alterCustomer.CustomerPostbox = CustomerPostbox;
            alterCustomer.CustomerTel = CustomerTel;
            bll.AlterSave(alterCustomer);

            return RedirectToAction("Index");
        }
        [Authorize]
        public JsonResult GetSearch(string query, int mathCount)
        {
            BLL.T_Base_Customer bll = new BLL.T_Base_Customer();
            return Json(bll.GetSearch(query, mathCount)) ;
        }

    }
}