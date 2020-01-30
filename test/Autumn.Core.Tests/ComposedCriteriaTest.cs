using NUnit.Framework;

using System.Text.RegularExpressions;

namespace Autumn.Core.Tests {

    [TestFixture]
    public class ComposedCriteriaTest : ComposedCriteria {

        public ComposedCriteriaTest() : base() {
        }

        public ComposedCriteriaTest(ICriteria criteria) : base( criteria ) {
        }

        [Test]
        public void IsSatisfiedWithNoCriteria() {
            var composed_criteria = new ComposedCriteriaTest();

            Assert.That( composed_criteria.IsSatisfied( "foo" ), Is.True );
        }

        [Test]
        public void SatifiedMyUpperCaseCriteria() {
            var composed_criteria = new ComposedCriteriaTest( new MyUpperCaseCriteria() );

            Assert.That( composed_criteria.IsSatisfied( "HELLO" ), Is.True );
            Assert.That( composed_criteria.IsSatisfied( "hello" ), Is.False );
        }

        [Test]
        public void SatifiesTwoCriteria() {
            var composed_criteria = new ComposedCriteriaTest();

            composed_criteria.Add( new MyUpperCaseCriteria() );
            composed_criteria.Add( new MyStringCriteria() );

            Assert.That( composed_criteria.IsSatisfied( "HELLO" ), Is.True );
            Assert.That( composed_criteria.IsSatisfied( "GOODBYE" ), Is.False );

            Assert.That( composed_criteria.Criteria.Count, Is.EqualTo( 2 ) );
        }

        internal class MyUpperCaseCriteria : ICriteria {

            public bool IsSatisfied(object datum) => Regex.Match( datum.ToString(), "[A-Z]" ).Success;
        }

        internal class MyStringCriteria : ICriteria {

            public bool IsSatisfied(object datum) => datum.ToString().ToLower() == "hello";
        }
    }
}