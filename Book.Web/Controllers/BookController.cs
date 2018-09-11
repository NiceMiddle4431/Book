using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public JsonResult GetList(int PageSize,int PageNumber,string Query)  //要查找的页数的值
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            List<Book.Model.T_Base_Book> list = bll.GetList(PageNumber, PageSize, Query);
            int count = bll.GetCount(Query);
            return Json(new { total = count,rows=list });
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddSave(string BookName,string Author,
            string ISBN,string PressName,int Version,decimal Price)
        {
            //图片保存
            var file = Request.Files["ImgFile"];
            string path = Server.MapPath("\\upLoad\\");
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            file.SaveAs(path + fileName);


            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            book.BookName = BookName;
            book.Author = Author;
            book.ISBN = ISBN;
            book.PressName = PressName;
            book.Version = Version;
            book.Price = Price;
            book.Img = fileName;

            Book.BLL.T_Base_Book bookAddSave = new BLL.T_Base_Book();
            int result = bookAddSave.AddSave(book);
            
            return Redirect("/Book/Index");
        }
        [Authorize]
        public JsonResult Delete(string[] Ids)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            return Json(bll.Delete(Ids));
        }
        [Authorize]
        public ActionResult Alter(int Id)
        {
            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            ViewBag.book = bll.Alter(Id);
            return View();
        }
        [Authorize]
        public ActionResult AlterSave(int Id,string BookName,
            string Author,string ISBN,string PressName,int Version,decimal Price)
        {

            //图片保存
            var file = Request.Files["ImgFile"];
            string path = Server.MapPath("\\upLoad\\");
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            file.SaveAs(path + fileName);

            Book.BLL.T_Base_Book bll = new BLL.T_Base_Book();
            Book.Model.T_Base_Book book = new Model.T_Base_Book();
            book.id = Id;
            book.BookName = BookName;
            book.Author = Author;
            book.ISBN = ISBN;
            book.PressName = PressName;
            book.Version = Version;
            book.Price = Price;
            book.Img = fileName;
            bll.AlterSave(book);

            return RedirectToAction("Index");
        }
        [Authorize]
        public JsonResult GetSearch(string query,int mathCount)
        {
            BLL.T_Base_Book bll = new BLL.T_Base_Book();
            return Json(bll.GetSearch(query,mathCount));
        }
    }
}