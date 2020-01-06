using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WebCore.WebClient
{
    public static class JsonExtensions
    {
        public static string ToJson(this object entity)
        {
            return JsonSerializer.Serialize(entity);
        }
    }
}
