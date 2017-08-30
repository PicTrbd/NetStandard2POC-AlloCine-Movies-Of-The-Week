using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStandardClassLibrary.Models;

namespace NetStandardClassLibrary.MovieHtmlParser
{
    public interface IMovieHtmlParser
    {
        Task<List<MovieInformation>> RetrieveMoviesOfTheWeek();
    }

    public class MovieHtmlParser : IMovieHtmlParser
    {
        private const string MoviesOfTheWeekUrl = "http://www.allocine.fr/film/sorties-semaine/";

        private readonly HttpClient _httpClient = new HttpClient();
        private readonly HtmlDocument _moviesOfTheWeekPage = new HtmlDocument();
        private readonly List<MovieInformation> _movies = new List<MovieInformation>();

        public async Task<List<MovieInformation>> RetrieveMoviesOfTheWeek()
        {
            await RetrieveMoviesOfTheWeekPageAsync();
            var moviesNodes = _moviesOfTheWeekPage.DocumentNode
                .SelectNodes("//div[contains(@class, 'card card-entity card-entity-list cf hred')]");

            foreach (var movie in moviesNodes)
            {
                MovieInformation extractedMovieInformation;
                var movieInformationNode = movie.Descendants().Where(a => a.Attributes.Contains("class"));
                if ((extractedMovieInformation = ExtractMovieInformationFromNode(movieInformationNode.ToList())) != null)
                    _movies.Add(extractedMovieInformation);
            }
            return _movies;
        }

        private async Task RetrieveMoviesOfTheWeekPageAsync()
        {
            using (var response = await _httpClient.GetAsync(MoviesOfTheWeekUrl))
            {
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    _moviesOfTheWeekPage.LoadHtml(result);
                }
            }
        }

        private static MovieInformation ExtractMovieInformationFromNode(IReadOnlyCollection<HtmlNode> movieInformationNode)
        {
            var movieInformation = new MovieInformation();

            var titleNode = movieInformationNode.First(x => x.Attributes["class"].Value.Contains("meta-title-link"));
            movieInformation.Title = (titleNode == null ? "" : titleNode.InnerText.Replace("&amp;", "&").Replace("&#039;", "'"));

            var directorNode = movieInformationNode.First(x => x.Attributes["class"].Value.Contains("meta-body-direction"))
                    .SelectNodes(".//a[contains(@class, 'blue-link')]");
            movieInformation.Director = (directorNode == null ? "Inconnu" : directorNode.First().InnerText);

            var linkNode = movieInformationNode.First(x => x.Attributes["class"].Value.Contains("meta-title-link"))
                .Attributes.First(y => y.Name == "href");
            movieInformation.Link = (linkNode == null ? "" : "www.allocine.fr" + linkNode.Value);

            var synopsisNode = movieInformationNode.First(x => x.Attributes["class"].Value.Contains("synopsis"));
            movieInformation.Synopsis = (synopsisNode == null ? "" : synopsisNode.InnerText.Replace(Environment.NewLine, "").Trim());
            
            var pictureNode = movieInformationNode.First(x => x.Attributes["class"].Value.Contains("thumbnail-img"))
                    .Attributes.First(y => y.Name == "data-src");
            movieInformation.Picture = (pictureNode == null ? "" : pictureNode.Value);

            return movieInformation;
        }
    }
}

