using HtmlAgilityPack;
using iTextSharp.text;
using System;

namespace NetStandardClassLibrary
{
    public class TestClass
    {
        public void TestMethod()
        {
            var z = new Document();
            var doc = new HtmlWeb();
            var y = doc.Load("http://www.google.fr");
            //var nodes = doc.DocumentNode;
        }
    }
}
