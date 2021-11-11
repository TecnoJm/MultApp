using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MultApp.Services
{
    public class SerializerService : ISerializerService
    {
        public T Deserialize<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload);
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
