using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int num = 1)
        {
            ViewBag.Message = "Hello " + name + "!";
            ViewBag.NumTimes = num;
            return View();
        }
       
	}
}