using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryAgain.Utils.Extensions;

namespace TryAgain.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void TryParseToTimeSpan_HHMMSSFormat_ValidTimeSpan()
        {
//            var valueToParse = "12:13:12";
//            var expected = new TimeSpan(12, 13, 12);
//
//            var result = valueToParse.TryParseToTimeSpan();
//
//            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryToParseToTimeSpan_InvalidHHMMSSFormat_InvalidTimeSpan()
        {
//            var valueToParse = "25:12:12";
//
//            var result = valueToParse.TryParseToTimeSpan();
//
//            Assert.IsNull(result);
        }
    }
}
