using System.Linq;
using BeeGraph.Data;
using BeeGraph.Data.Config;
using SimpleInjector;

namespace BeeGraph.Tests.Infrastructure
{
    internal static class TestContainer
    {
        public static Container Container;

        static TestContainer()
        {
            Container = InitContainer();
        }

        private static Container InitContainer()
        {
            var container = new Container();

            container.Register<IConnectionStringProvider, TestDataBaseConnectionStringProvider>();

            RegisterDefaultBindings(container);
            container.Verify();
            return container;
        }

        private static void RegisterDefaultBindings(Container container)
        {
            var defaultBindings = IoC.IoC.Container.GetCurrentRegistrations().Except(container.GetCurrentRegistrations(), InstanceProducerComparer.Instance).ToList();
            defaultBindings.ForEach(b => Register(b, container));
        }

        private static void Register(InstanceProducer instanceProducer, Container container)
        {
            container.Register(instanceProducer.ServiceType, instanceProducer.Registration.ImplementationType);
        }
    }
}
