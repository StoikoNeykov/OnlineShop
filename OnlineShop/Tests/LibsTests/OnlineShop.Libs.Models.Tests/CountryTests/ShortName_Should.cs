using NUnit.Framework;
using OnlineShop.Libs.Models.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.CountryTests
{
    [TestFixture]
    public class ShortName_Should
    {
        [TestCase("")]
        [TestCase("321213")]
        [TestCase("ecwqe fcfcdscf")]
        [TestCase("&^DS&A^&MC*@(!*#)")]
        [TestCase("><D>SA<>@>@<#>@<#")]
        public void GetAndSet_Should_Work(string randomString)
        {
            var obj = new Country();

            obj.ShortName = randomString;

            Assert.AreEqual(randomString, obj.ShortName);
        }

        [Test]
        public void Have_MaxLength_Attribute()
        {
            var propertyName = "ShortName";

            var result = typeof(Country)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .SingleOrDefault(x => x.GetType() == typeof(MaxLengthAttribute));

            Assert.IsNotNull(result);
        }

        [Test]
        public void Have_RightValueFor_MaxLength_Attribute()
        {
            var propertyName = "ShortName";

            var result = (MaxLengthAttribute)typeof(Country)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .SingleOrDefault(x => x.GetType() == typeof(MaxLengthAttribute));

            Assert.AreEqual(Validation.Country.ShortNameMaxLength, result.Length);
        }
    }
}
