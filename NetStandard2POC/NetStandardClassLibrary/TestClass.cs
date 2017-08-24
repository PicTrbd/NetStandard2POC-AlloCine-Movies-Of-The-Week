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
            var doc = new HtmlWeb().Load("http://html-agility-pack.net/");
            var nodes = doc.DocumentNode;
        }
    }
}
