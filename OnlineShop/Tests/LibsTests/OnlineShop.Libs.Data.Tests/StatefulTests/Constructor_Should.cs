using NUnit.Framework;
using OnlineShop.Libs.Data;

namespace OnlineShop.Libs.Data.Tests.StatefulTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_WhenEntry_IsNull()
        {
            Assert.That(() => new Stateful<DimmyClass>(null),
                                Throws.ArgumentNullException.With.Message.Contains("Entry"));
        }
        
        private class DimmyClass { }
    }
}
