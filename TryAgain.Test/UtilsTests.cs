using NUnit.Framework;
using System;
using NUnit.Framework.Internal;
using TryAgain.Utils.Extensions;

namespace TryAgain.Test
{
    [TestFixture]
    public class UtilsTests
    {
        [Test]
        [Category("UnitTest")]
        public void TryParseToTimeSpan_HHMMFormat_ValidTimeSpan()
        {
            var valueToParse = "12:13";
            var expected = new TimeSpan(12, 13, 0);

            var result = valueToParse.TryParseToTimeSpan();

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("UnitTest")]
        public void TryParseToTimeSpan_HHMMSSFormat_ValidTimeSpan()
        {
            var valueToParse = "12:13:11";
            var expected = new TimeSpan(12, 13, 11);

            var result = valueToParse.TryParseToTimeSpan();

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("UnitTest")]
        public void TryParseToTimeSpan_TooBigHoursNumber_NullValue()
        {
            var valueToParse = "25:12:12";

            var result = valueToParse.TryParseToTimeSpan();

            Assert.IsNull(result);
        }

        [Test]
        [Category("UnitTest")]
        public void TryParseToTimeSpan_InvalidFormatOfHoursNumber_NullValue()
        {
            var valueToParse = "2:01";

            var result = valueToParse.TryParseToTimeSpan();

            Assert.IsNull(result);
        }

        [Test]
        [Category("UnitTest")]
        public void TryParseToTimeSpan_MinusMinutesNumber_NullValue()
        {
            var valueToParse = "11:-01";

            var result = valueToParse.TryParseToTimeSpan();

            Assert.IsNull(result);
        }

        [Test]
        [Category("UnitTest")]
        public void GetHoursAndMinutes_HoursMinutesValue_ValidStringValue()
        {
            var valueToParse = new TimeSpan(00, 11, 00);
            var expected = "00:11";

            var result = valueToParse.GetHoursAndMinutes();

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Category("UnitTest")]
        public void GetHoursAndMinutes_DaysHoursSecondsValue_ValidStringValue()
        {
            var valueToParse = new TimeSpan(1, 23, 0, 22);
            var expected = "23:00";

            var result = valueToParse.GetHoursAndMinutes();

            Assert.AreEqual(expected, result);
        }
    }
}
