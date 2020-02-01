using NUnit.Framework;

namespace Autumn.Core.Tests {

    [TestFixture]
    public sealed class MethodArgumentsCriteriaTest {

        [Test]
        public void IsNotSatisfiedWithNull() {
            MethodArgumentsCriteria criteria = new MethodArgumentsCriteria();

            Assert.That( criteria.IsSatisfied( null ), Is.False, "Was satisfied with null." );
        }
    }
}