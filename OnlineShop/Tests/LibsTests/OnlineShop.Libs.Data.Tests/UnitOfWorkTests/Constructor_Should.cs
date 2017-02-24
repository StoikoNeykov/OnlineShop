using NUnit.Framework;

namespace OnlineShop.Libs.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_NullReferenceException_WithProperMessage_WhenDbContext_IsNull()
        {
            // Act & Assert
            Assert.That(() => new UnitOfWork(null),
                                Throws.ArgumentNullException.With.Message.Contains("DbContext"));
        }
    }
}
