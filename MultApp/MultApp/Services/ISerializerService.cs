using System;
using System.Collections.Generic;

namespace MultApp.Services
{
    public interface ISerializerService
    {
        string Serialize(object data);

        T Deserialize<T>(string payload);
    }
}
