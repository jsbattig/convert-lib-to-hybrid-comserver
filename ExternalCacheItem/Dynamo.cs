using System.Collections.Generic;
using System.Dynamic;

namespace Ascentis.Infrastructure
{
    public class Dynamo : DynamicObject
    {
        public IDictionary<string, object> Dictionary { get; set; }

        public Dynamo()
        {
            Dictionary = new Dictionary<string, object>();
        }

        public int Count => Dictionary.Keys.Count;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!Dictionary.ContainsKey(binder.Name))
                return base.TryGetMember(binder, out result); //means result = null and return = false

            result = Dictionary[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!Dictionary.ContainsKey(binder.Name))
                Dictionary.Add(binder.Name, value);
            else
                Dictionary[binder.Name] = value;

            return true;
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            if (!Dictionary.ContainsKey(binder.Name))
                return base.TryDeleteMember(binder);

            Dictionary.Remove(binder.Name);
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            foreach (string name in Dictionary.Keys)
                yield return name;
        }

        public object this[string key] { get { return Dictionary[key]; } set { Dictionary[key] = value; } }
    }
}