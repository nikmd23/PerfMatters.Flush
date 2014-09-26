using System;
using System.Threading;
using System.Web.Mvc;
using CourtesyFlush;

namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        [FlushHead(Title = "Index")]
        public ActionResult Index()
        {
            Thread.Sleep(2000);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = DateTime.Now.Second;
            this.FlushHead();

            Thread.Sleep(2000);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string name)
        {
            return Content("Yey");
        }

        [FlushHead(Title = "I am flushed", FlushAntiForgeryToken = true)]
        public ActionResult Contact()
        {
            return View();
        }
    }
}