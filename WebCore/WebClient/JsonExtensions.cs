﻿using System.Text.Json;

namespace WebCore.WebClient
{
    public static class JsonExtensions
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static string ToJson(this object entity)
        {
            return JsonSerializer.Serialize(entity, options);
        }
    }
}
