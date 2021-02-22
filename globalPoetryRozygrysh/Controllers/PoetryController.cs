using globalPoetryRozygrysh.Repositories.MySql;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class PoetryController : Controller
    {
        private TextMySqlRepository _textMySqlRepository;

        public PoetryController()
        {
            _textMySqlRepository = new TextMySqlRepository();
        }

        [HttpGet]
        public ActionResult Index(string vk_id)
        {
            return View();
        }
    }
}