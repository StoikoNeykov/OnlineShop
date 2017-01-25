using NUnit.Framework;
using OnlineShop.Libs.Models.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.CategoryTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void Have_RightValueFor_MinLength_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Category)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Category.NameMinLenght, result.Length);
        }

        [Test]
        public void Have_RightValueFor_MaxLength_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Category)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Category.NameMaxLenght, result.Length);
        }

        [Test]
        public void Have_RightValueFor_RegularExpression_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Category)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Regexs.EnBgNumSpaceMinus, result.Pattern);
        }
    }
}
