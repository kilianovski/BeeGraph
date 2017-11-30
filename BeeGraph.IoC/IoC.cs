using BeeGraph.Data.Config;
using BeeGraph.Data.Helpers;
using SimpleInjector;

namespace BeeGraph.Data
{
    public static class IoC
    {
        public static Container Container;

        static IoC()
        {
            Container = InitContainer();
        }

        private static Container InitContainer()
        {
            var container = new Container();
                
            container.Register<IConnectionStringProvider, HardcodedConnectionStringProvider>();
            container.Register<IStoredProcedureHelper, StoredProcedureHelper>();

            
            container.Register<IEdgeRepository, EdgeSpRepository>();
            container.Register<INodeRepository, NodeSpRepository>();

            return container;
        }
    }
}
