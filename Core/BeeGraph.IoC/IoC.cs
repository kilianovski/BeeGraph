using BeeGraph.Core;
using BeeGraph.Data;
using BeeGraph.Data.Config;
using BeeGraph.Data.Helpers;
using SimpleInjector;

namespace BeeGraph.IoC
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
            container.Register<INodeRelationRepository, NodeRelationRepository>();
            container.Register<IDialogRepository, DialogRepository>();

            container.Register<INodeProvider, NodeProvider>();
            container.Register<IDialogService, DialogService>();            

            return container;
        }
    }
}
