using HtmlAgilityPack;
using System;

namespace NetStandardClassLibrary
{
    public class TestClass
    {
        public HtmlDocument TestMethod()
        {
            var url = "http://html-agility-pack.net/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
    }
}
