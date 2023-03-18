using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ReadingLoader.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBibleVerse()
        {
            var util = new ReadingUtil();
            var date = DateTime.Now;
            var result = util.LoadReading(date, ReadingType.Gospel).Result;
            Console.WriteLine(result.Content);
        }

        [TestMethod]
        public void ParseBibleFormat1()
        {
            var util = new ReadingUtil();
            var feed = System.IO.File.ReadAllText("./VerseFormat1.txt");
            var verses = util.ParseVersesFromFeed(feed);
            Assert.AreEqual(4, verses.Count);
        }
    }
}
