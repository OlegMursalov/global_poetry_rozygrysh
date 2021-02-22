using globalPoetryRozygrysh.Helper;
using globalPoetryRozygrysh.Repositories.MySql;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
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

        [HttpPost]
        public FileStreamResult GetPdf()
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph(DateTime.Now.ToString()));
            document.Add(new Paragraph("GLOBAL POETRY РОЗЫГРЫШ, ТЕКСТЫ.."));
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }

        [HttpGet]
        public ActionResult Index(string vk_id, string token, bool? success = null)
        {
            if (string.IsNullOrEmpty(vk_id) || string.IsNullOrEmpty(token))
            {
                return Redirect($"/Auth/Index");
            }

            if (!AuthTokenHelper.Check(vk_id, token))
            {
                return Redirect($"/Auth/Index");
            }

            ViewBag.vk_id = vk_id;
            ViewBag.token = token;
            if (success != null && success.Value)
            {
                ViewBag.tooltipText = "Тексты успешно сохранены";
            }

            string errMessage = null;
            var texts = _textMySqlRepository.Get(vk_id, out errMessage);
            return View(texts);
        }

        [HttpPost]
        public ActionResult Process(string vk_id, string token, string[] lyrics)
        {
            string errMessage = null;
            _textMySqlRepository.SaveAll(vk_id, lyrics, out errMessage);
            return Redirect($"/Poetry/Index?vk_id={vk_id}&token={token}&success=true");
        }
    }
}