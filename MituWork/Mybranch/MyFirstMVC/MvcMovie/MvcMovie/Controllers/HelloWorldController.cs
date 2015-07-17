using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            //// use HttpServerUtility.HtmlEncode to protect the application from malicious
            //// input(namely JavaScript).
            //return HttpUtility.HtmlEncode("Hello" + name + ", NumTimes is: " + numTimes);

            //通过ViewBag对象进行数据的传递---从控制器到视图模板
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            //ViewBag是一个对台对象，意味着 you can put whatever you want in to it;
            // The ViewBag object has no defined properites until you put something inside it.
            // The ASP.NET MVC model binding system automatically maps the named parameters(name and numTimes)
            // from the query string in the address bar to parameters in you method.
            return View();

        }
    }
}