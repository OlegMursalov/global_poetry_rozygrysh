using globalPoetryRozygrysh.Models;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class RzgrController : Controller
    {
        public RzgrController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RapLineModel());
        }
    }
}