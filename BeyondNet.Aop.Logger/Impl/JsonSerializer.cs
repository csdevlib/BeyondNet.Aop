using Newtonsoft.Json;

namespace BeyondNet.Aop.Logger
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}

