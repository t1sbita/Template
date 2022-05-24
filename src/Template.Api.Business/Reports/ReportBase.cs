using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Template.Api.Core.Util;
using System;

namespace Template.Api.Business.Reports
{
    public class ReportBase
    {
        public Document CreateDocument(PdfDocument pdfDocument, bool immediateFlush = false)
        {
            pdfDocument
                .SetTagged()
                .GetCatalog()
                .SetLang(new PdfString("pt-br"));

            Document document = new Document(pdfDocument, PageSize.A4, immediateFlush);
            document.SetMargins(35, 20, 20, 20);

            return document;
        }

        public void MountHeader(Document document)
        {

            byte[] logoSefaz = ResourceFactory.Create().ExtractResource("image.png");
            Image logo = new Image(ImageDataFactory.Create(logoSefaz));
            logo.ScaleAbsolute(60, 60);

            Paragraph textHeader = new Paragraph().Add($"Header\n");
                                                    
            textHeader.SetFontSize(11);
            textHeader.SetTextAlignment(TextAlignment.LEFT);
            textHeader.SetMargins(0, 10, 0, 10);

            Paragraph dateTime = new Paragraph($"\nData/Hora de extração: \n" +
                                                        $"\b{DateTime.Now}");
            dateTime.SetFontSize(8);
            dateTime.SetTextAlignment(TextAlignment.RIGHT);
            dateTime.SetMargins(10, 0, 0, 10);

            Table table = new Table(3).UseAllAvailableWidth();

            table.AddCell(new Cell().Add(logo).SetBorder(Border.NO_BORDER));
            table.AddCell(new Cell().Add(textHeader).SetBorder(Border.NO_BORDER));
            table.AddCell(new Cell().Add(dateTime).SetBorder(Border.NO_BORDER));


            document.Add(table.SetHorizontalAlignment(HorizontalAlignment.CENTER));
        }

        public void AddNumberation(PdfDocument pdfDocument, Document document)
        {
            int numberOfPages = pdfDocument.GetNumberOfPages();
            for (int i = 1; i <= numberOfPages; i++)
            {
                Rectangle pageSize = pdfDocument.GetPage(i).GetPageSize();
                var width = pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();

                float x = width - 40;
                float y = pageSize.GetTop() - 20;

                Paragraph header = new Paragraph($"página {i} de {numberOfPages}").SetFontSize(8);

                document.ShowTextAligned(header, x, y, i, TextAlignment.JUSTIFIED, VerticalAlignment.BOTTOM, 0);
            }
        }

        public void AddTitle(Document document, string title, Color color = null)
        {
            Paragraph table = new Paragraph(title)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(color ?? ColorConstants.BLACK)
                .SetBold();
            document.Add(table);
        }

        public void AddLineSeparator(Document document, float parameter, Color color = null)
        {
            SolidLine line = new SolidLine(parameter);
            line.SetColor(color ?? ColorConstants.BLUE);

            LineSeparator ls = new LineSeparator(line);
            ls.SetMarginTop(parameter);
            ls.SetMarginBottom(parameter);

            document.Add(ls);
        }
    }
}
