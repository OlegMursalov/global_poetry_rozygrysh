using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace globalPoetryRozygrysh.Helper
{
    public static class PdfHelper
    {
        public static MemoryStream SimpleGenerate(string title, List<string> list)
        {
            MemoryStream workStream = new MemoryStream();
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = title;

            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            var xRect = new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point);
            graph.DrawString("GLOBAL POETRY РОЗЫГРЫШ (тексты)", new XFont("Verdana", 10, XFontStyle.Italic), XBrushes.Black, xRect, XStringFormats.Center);

            foreach (var block in list.ChunkBy(40))
            {
                var i = 25;
                pdfPage = pdf.AddPage();
                graph = XGraphics.FromPdfPage(pdfPage);

                foreach (var item in block)
                {
                    xRect = new XRect(50, i, pdfPage.Width.Point, pdfPage.Height.Point);
                    graph.DrawString(item, new XFont("Verdana", 10, XFontStyle.Italic), XBrushes.Black, xRect, XStringFormats.TopLeft);
                    i += 20;
                }
            }

            pdf.Save(workStream);
            return workStream;
        }

        private static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}