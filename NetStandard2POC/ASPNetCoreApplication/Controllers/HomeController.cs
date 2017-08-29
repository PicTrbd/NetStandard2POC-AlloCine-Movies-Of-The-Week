using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using NetStandardClassLibrary.Models;
using NetStandardClassLibrary.MovieHtmlParser;
using Newtonsoft.Json;

namespace ASPNetCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var htmlParser = new MovieHtmlParser();
            var movies = await htmlParser.RetrieveMoviesOfTheWeek();

            return View(movies);
        }

        public void DownloadPdf(string moviesJson)
        {
            var movies = JsonConvert.DeserializeObject<List<MovieInformation>>(moviesJson);

            using (var memoryStream = new MemoryStream())
            {
                using (var document = new Document(PageSize.A4, 50, 50, 25, 25))
                {
                    var writer = PdfWriter.GetInstance(document, memoryStream);
                    writer.CloseStream = false;

                    document.Open();

                    var introFont = new Font(Font.FontFamily.HELVETICA, 25f);
                    var introParagraph = new Paragraph("Sorties en salle de la semaine", introFont);
                    document.Add(introParagraph);

                    foreach (var movie in movies)
                    {
                        document.Add(new Paragraph(Environment.NewLine));
                        var movieTitleFont = new Font(Font.FontFamily.HELVETICA, 14f, Font.BOLD, new BaseColor(26, 57, 102));
                        var movieTitleChunk = new Chunk('\t' + $" - {movie.Title}", movieTitleFont);
                        document.Add(movieTitleChunk);

                        var placeholderWordFont = new Font(Font.FontFamily.HELVETICA, 12f);
                        var placeholderWordChunk = new Chunk(" de ", placeholderWordFont);
                        document.Add(placeholderWordChunk);

                        var directorNameFont = new Font(Font.FontFamily.HELVETICA, 13f, Font.BOLD);
                        var directorNamePhrase = new Phrase($"{movie.Director}", directorNameFont);
                        document.Add(directorNamePhrase);
                    }
                    document.Close();
                }

                var docArray = memoryStream.ToArray();
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Body.WriteAsync(docArray, 0, docArray.Length);
            }
        }
    }
}
