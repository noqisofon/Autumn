using NUnit.Framework;

namespace Autumn.Core.Tests {

    [TestFixture]
    public class ControlFlowFactoryTest {

        [Test]
        public void CreateControlFlow() {
            IControlFlow control_flow = ControlFlowFactory.CreateControlFlow();

            Assert.That( control_flow, Is.Not.Null,
                         "The ControlFlowFactory factory class is returning a " +
                         "null IControlFlow instance (it, obviously, must not)" );
        }

        [Test]
        public void CreateControlFlowReturnsDisinctInstance() {
            IControlFlow control_flow1  = ControlFlowFactory.CreateControlFlow();
            IControlFlow control_flow2  = ControlFlowFactory.CreateControlFlow();

            Assert.That( ReferenceEquals( control_flow1, control_flow2 ), Is.False,
                         "The ControlFlowFactory factory class is not returning distinct IControlFlow instances (its always" +
                         "the same instance)" );
        }

        [Test]
        public void DefaultControlFlowUnderThisTest() {
            IControlFlow control_flow = ControlFlowFactory.CreateControlFlow();

            bool is_under = control_flow.Under( GetType() );

            Assert.That( is_under, Is.True,
                         "The IControlFlow implementation created by the ControlFlowFactory factory class " +
                         "would appear to have a faulty Under(Type) implementation: [{0}]",
                         control_flow.GetType() );
        }

        [Test]
        public void DefaultControlFlowIsNotUnderThisTestAndSomeRandomMethodName() {
            IControlFlow control_flow = ControlFlowFactory.CreateControlFlow();

            bool is_under = control_flow.Under( GetType(), "PlayingYouALikeTheFoolYouAre" );

            Assert.That( is_under, Is.False,
                         "The IControlFlow implementation created by the ControlFlowFactory factory class " +
                         "would appear to have a faulty Under(Type, string) implementation: [{0}]",
                         control_flow.GetType() );
        }

        [Test]
        public void DefaultControlFlowUnderToken() {
            IControlFlow control_flow = ControlFlowFactory.CreateControlFlow();

            bool is_under = control_flow.UnderToken( "ControlFlow" );

            Assert.That( is_under, Is.True,
                         "The IControlFlow implementation created by the ControlFlowFactory factory class " +
                         "would appear to have a faulty UnderToken(string) implementation: [{0}]",
                         control_flow.GetType() );
        }
    }
}