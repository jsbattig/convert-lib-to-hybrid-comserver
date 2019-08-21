using Ascentis.Infrastructure;

namespace Ascentis.ExternalCache
{
    public class ExternalCacheItem : System.EnterpriseServices.ServicedComponent
    {
        public Dynamo Container { get; }

        public ExternalCacheItem()
        {
            Container = new Dynamo();
        }
    }
}
