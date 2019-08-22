using Ascentis.Infrastructure;
using System.Collections.Generic;

namespace Ascentis.ExternalCache
{
    public class ExternalCacheItem : System.EnterpriseServices.ServicedComponent
    {
        public dynamic Container { get; }

        public ExternalCacheItem()
        {
            Container = new Dynamo();
        }
        public object this[string key] { get { return Container[key]; } set { Container[key] = value; } }
    }
}
