using Newtonsoft.Json;

namespace BeyondNet.Aop.Logger
{
    public class SensitiveDataJsonSerializer<TAttribute> : ISerializer
        where TAttribute : Attribute
    {
        public string Serialize(object value)
        {
            var settings = new JsonSerializerSettings() { ContractResolver = new SensitiveDataResolver<TAttribute>() };
            return JsonConvert.SerializeObject(value, settings);
        }
    }
}