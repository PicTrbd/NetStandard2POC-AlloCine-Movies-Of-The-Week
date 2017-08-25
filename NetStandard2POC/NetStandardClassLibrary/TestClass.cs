using System;
using System.Diagnostics;
using System.Net.Http;
using HtmlAgilityPack;
using iTextSharp.text;

namespace NetStandardClassLibrary
{
    public class TestClass
    {
        public async void TestMethod()
        {
            var doc = new Document();
            var url = "http://www.brainjar.com/java/host/test.html";

            var client = new HttpClient();

            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content)
                {
                    // read answer in non-blocking way
                    var result = await content.ReadAsStringAsync();
                    var document = new HtmlDocument();
                    document.LoadHtml(result);
                    var nodes = document.DocumentNode.OuterHtml;
                    Debug.WriteLine(nodes);
                }
            }   
        }
    }
}
