using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Book.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            Book.BLL.Home bll = new BLL.Home();
            Book.Model.Home home = bll.GetCount();
            ViewBag.home = home;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Check(string LoginName,string Password)
        {
            Book.BLL.Home bll = new BLL.Home();
            Book.Model.T_Base_User user = bll.Check(LoginName, Password);


            //记录票据
            FormsAuthentication.SetAuthCookie(LoginName, true);//简单授权
            var authTicket = new FormsAuthenticationTicket(
                user.RoleId,        //角色
                LoginName,          //登录名
                DateTime.Now,       //当前时间
                DateTime.Now.AddMinutes(5),//保存时间
                true,// 如果为 true，则创建持久 Cookie（跨浏览器会话保存的 Cookie）；否则为 false。
                ""      //存储在票证中的用户特定的数据
                );
            HttpCookie authCookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(authTicket));

            Response.Cookies.Add(authCookie);
            return RedirectToAction("/Index");
        }
    }
}