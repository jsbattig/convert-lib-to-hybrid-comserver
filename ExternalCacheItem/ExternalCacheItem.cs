using System.Reflection;
using Ascentis.Infrastructure;

namespace Ascentis.ExternalCache
{
    public class ExternalCacheItem : System.EnterpriseServices.ServicedComponent
    {
        public dynamic Container { get; }

        public ExternalCacheItem()
        {
            Container = new Dynamo();
        }

        public object this[string key]
        {
            get => Container[key];
            set => Container[key] = value;
        }

        public void Assign(object value)
        {
            var type = value.GetType();
            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                Container[prop.Name] = prop.GetValue(value);
        }
    }
}
