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
        private PersonMySqlRepository _personMySqlRepository;

        public PoetryController()
        {
            _textMySqlRepository = new TextMySqlRepository();
            _personMySqlRepository = new PersonMySqlRepository();
        }

        [HttpPost]
        public FileStreamResult GetPdf()
        {
            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            string ARIALUNI_TFF = Path.Combine(@"C:\Users\Олег\source\repos\globalPoetryRozygrysh\globalPoetryRozygrysh\Content\font\", "ARIALUNI.TTF");
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font f = new Font(bf, 12, Font.NORMAL);
            document.Add(new Paragraph(DateTime.Now.ToString(), f));
            document.Add(new Paragraph("GLOBAL POETRY РОЗЫГРЫШ, ТЕКСТЫ..", f));

            string errMessage = null;
            foreach (var vk_id in _personMySqlRepository.GetAllVkIds(out errMessage))
            {
                document.Add(new Paragraph($"----- https://vk.com/{vk_id}", f));
                var texts = _textMySqlRepository.Get(vk_id, out errMessage);
                for (int i = 0; i < texts.Count; i++)
                {
                    if (!string.IsNullOrEmpty(texts[i].value))
                    {
                        document.Add(new Paragraph($"{i + 1}: {texts[i].value}", f));
                    }
                    else
                    {
                        document.Add(new Paragraph($"{i + 1}: <не заполнено>", f));
                    }
                }
            }
            
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