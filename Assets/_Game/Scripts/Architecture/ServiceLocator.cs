using System;
using System.Collections.Generic;

namespace HentaiGame
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service), "Сервис не может быть null.");
            }

            services[typeof(T)] = service;
        }

        public static T Get<T>()
        {
            if (services.TryGetValue(typeof(T), out var service))
            {
                return (T)service;
            }

            throw new KeyNotFoundException($"Сервис типа {typeof(T).Name} не зарегистрирован.");
        }

        public static bool IsRegistered<T>()
        {
            return services.ContainsKey(typeof(T));
        }

        public static void Unregister<T>()
        {
            services.Remove(typeof(T));
        }

        public static void Clear()
        {
            services.Clear();
        }
    }
}
