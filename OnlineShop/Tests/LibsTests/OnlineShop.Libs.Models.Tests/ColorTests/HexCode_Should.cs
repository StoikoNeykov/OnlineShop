using NUnit.Framework;
using OnlineShop.Libs.Models.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.ColorTests
{
    [TestFixture]
    public class HexCode_Should
    {
        [TestCase("")]
        [TestCase("42142141xsda")]
        [TestCase("DDSJAd.cfokdsc><")]
        [TestCase("D<><№$№$@№РВ")]
        [TestCase("rewr2ecwrc2")]
        public void GetAndSet_Should_Work(string randomString)
        {
            var obj = new Color();

            obj.HexColor = randomString;

            Assert.AreEqual(randomString, obj.HexColor);
        }

        [Test]
        public void Have_MaxLength_Attribute_WithRightValue()
        {
            var propertyName = "HexColor";

            var result = typeof(Color)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Color.HexColorMaxLength, result.Length);
        }
    }
}
