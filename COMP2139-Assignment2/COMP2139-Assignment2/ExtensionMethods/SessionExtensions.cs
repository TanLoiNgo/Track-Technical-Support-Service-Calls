using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace COMP2139_Assignment1.ExtensionMethods
{
    public static class SessionExtensions
    {
        public static void setObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value ==  null? default(T):
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
