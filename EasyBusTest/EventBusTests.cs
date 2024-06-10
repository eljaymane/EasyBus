using EasyBus;
using EasyBus.CustomAttributes;
using NuGet.Frameworks;

namespace EasyBusTest
{
    [TestClass]
    public class EventBusTests
    {
        private EventBus eventBus;
        private int _CallNumbers;

        [TestInitialize]
        public void Initialize()
        {
            eventBus = new();
            _CallNumbers = 0;
        }
        [TestMethod]
        public void Should_Call_Method_When_Event_IsPublished()
        {
            eventBus.Publish(new TestEvent());
        }

        [TestMethod]
        public void Should_Call_Method_With_Args_When_Event_Is_Published()
        {
            eventBus.Publish(new TestEvent("Called you maybe"));
        }


        [Subscribe(typeof(TestEvent))]
        public void callMeMaybe()
        {
            Console.WriteLine("Called you baby");
            _CallNumbers++;
        }

        [Subscribe(typeof(TestEvent))]
        public void callMeMaybeArgs(TestEvent @event)
        {
            Console.WriteLine(@event.Message);
        }
    }
}