using System.Collections.Generic;
using SimpleInjector;

namespace BeeGraph.IoC
{
    public class InstanceProducerComparer : IEqualityComparer<InstanceProducer>
    {
        public static InstanceProducerComparer Instance => new InstanceProducerComparer();

        public bool Equals(InstanceProducer x, InstanceProducer y) =>
            GetHashCode(x) == GetHashCode(y);

        public int GetHashCode(InstanceProducer obj) =>
            obj.ServiceType.GetHashCode();
    }
}