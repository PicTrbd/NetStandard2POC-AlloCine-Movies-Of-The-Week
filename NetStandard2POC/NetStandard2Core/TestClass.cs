using HtmlAgilityPack;
using System;

namespace NetStandard2Core
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
