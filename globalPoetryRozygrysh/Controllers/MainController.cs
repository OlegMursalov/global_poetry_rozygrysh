using globalPoetryRozygrysh.Models;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class MainController : Controller
    {
        public MainController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RapLineModel());
        }
    }
}