using NinjasOnlineStore.Core.Contracts;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SQLite;
using NinjasOnlineStore.SqlServer;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Linq;

namespace NinjasOnlineStore.Core.Providers
{
    public class PdfReportWriter : IPdfReportWriter
    {
        private readonly ISqlDatabase sqlServer;
        private readonly ISqLiteDatabase sqLite;
        private readonly IPgDatabase postgreSql;

        public PdfReportWriter(ISqlDatabase sqlServer, ISqLiteDatabase sqLite, IPgDatabase postgreSql)
        {
            this.sqlServer = sqlServer;
            this.sqLite = sqLite;
            this.postgreSql = postgreSql;
        }

        public void GeneratePdfReport(string fileName)
        {
            string destPdfFilePath = $"../../{fileName}";
            string sourcePdfFilePath = $"{Directory.GetCurrentDirectory()}\\{fileName}";

            var folder = Directory.GetFiles("../../");

            if (!folder.Contains(destPdfFilePath))
            {
                PdfDocument document = new PdfDocument();

                int fontTitleHeight = 20;
                int fontCollectionHeight = 14;
                int fontTextHeight = 8;

                ulong spaceBetweenLines = 20;
                int space = 70;

                XFont fontTitle = new XFont("Verdana", fontTitleHeight, XFontStyle.Bold);
                XFont fontCollection = new XFont("Verdana", fontCollectionHeight, XFontStyle.Bold);
                XFont fontText = new XFont("Verdana", fontTextHeight, XFontStyle.Regular);

                PdfPage firstPage = document.AddPage();
                XGraphics firstGfx = XGraphics.FromPdfPage(firstPage);
                firstGfx.DrawString("Ninjas Online Store Report", fontTitle, XBrushes.Black,
                new XRect(0, 0, firstPage.Width, firstPage.Height), XStringFormats.TopCenter);

                firstGfx.DrawString("Jackets", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var jacketsCollection = this.sqlServer.Jackets.ToList();

                foreach (var item in jacketsCollection)
                {
                    firstGfx.DrawString($"Brand: {item.Brand.Name}, Model: {item.Model.Name}, Color: {item.Color.Name}, Type: {item.Kind.Name}, Size: {item.Size.Name}, Price: {item.Price} eur",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }

                spaceBetweenLines = 20;
                PdfPage secondPage = document.AddPage();
                XGraphics secondGfx = XGraphics.FromPdfPage(secondPage);
                secondGfx.DrawString("Pants", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var pantsCollection = this.sqlServer.Pants.ToList();

                foreach (var item in pantsCollection)
                {
                    secondGfx.DrawString($"Brand: {item.Brand.Name}, Model: {item.Model.Name}, Color: {item.Color.Name}, Type: {item.Kind.Name}, Size: {item.Size.Name}, Price: {item.Price} eur",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }

                spaceBetweenLines = 20;
                PdfPage thirdPage = document.AddPage();
                XGraphics thirdGfx = XGraphics.FromPdfPage(thirdPage);
                thirdGfx.DrawString("Shoes", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var shoesCollection = this.sqlServer.Shoes.ToList();

                foreach (var item in shoesCollection)
                {
                    thirdGfx.DrawString($"Brand: {item.Brand.Name}, Model: {item.Model.Name}, Color: {item.Color.Name}, Type: {item.Kind.Name}, Size: {item.Size.Name}, Price: {item.Price} eur",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }

                spaceBetweenLines = 20;
                PdfPage fourthPage = document.AddPage();
                XGraphics fourthGfx = XGraphics.FromPdfPage(fourthPage);
                fourthGfx.DrawString("Swimming Suits", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var swimmingSuitsCollection = this.sqlServer.SwimmingSuits.ToList();

                foreach (var item in swimmingSuitsCollection)
                {
                    fourthGfx.DrawString($"Brand: {item.Brand.Name}, Model: {item.Model.Name}, Color: {item.Color.Name}, Type: {item.Kind.Name}, Size: {item.Size.Name}, Price: {item.Price} eur",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }

                spaceBetweenLines = 20;
                PdfPage fifthPage = document.AddPage();
                XGraphics fifthGfx = XGraphics.FromPdfPage(fifthPage);
                fifthGfx.DrawString("T-Shirts", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var TShirtsCollection = this.sqlServer.TShirts.ToList();

                foreach (var item in TShirtsCollection)
                {
                    fifthGfx.DrawString($"Brand: {item.Brand.Name}, Model: {item.Model.Name}, Color: {item.Color.Name}, Type: {item.Kind.Name}, Size: {item.Size.Name}, Price: {item.Price} eur",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }


                spaceBetweenLines = 20;
                PdfPage sixthPage = document.AddPage();
                XGraphics sixthGfx = XGraphics.FromPdfPage(sixthPage);

                sixthGfx.DrawString("Ninjas Stores", fontCollection, XBrushes.Black,
                new XRect(0, 50, firstPage.Width, 0), XStringFormats.Center);

                var shopsCollection = this.sqLite.Shops.ToList();

                foreach (var item in shopsCollection)
                {
                    sixthGfx.DrawString($"Store: {item.Name}, City: {item.City.Name}",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }

                spaceBetweenLines = 350;
                sixthGfx.DrawString("Ninjas Stores Availability", fontCollection, XBrushes.Black,
                new XRect(0, 220, firstPage.Width, 0), XStringFormats.Center);

                var shopsAvailabilityCollecion = this.postgreSql.Stores.ToList();

                foreach (var item in shopsAvailabilityCollecion)
                {
                    sixthGfx.DrawString($"Store: {item.Name}, Jackets: {item.Jackets}, Pants: {item.Pants}, Shoes: {item.Pants}, Swimming suits: {item.SwimmingSuits}, T-Shirts: {item.TShirts}",
                    fontText, XBrushes.Black, new XRect(0, space, firstPage.Width, spaceBetweenLines), XStringFormats.Center);
                    spaceBetweenLines += 20;
                }


                document.Save(fileName);

                File.Move(sourcePdfFilePath, destPdfFilePath);
            }
        }
    }
}
