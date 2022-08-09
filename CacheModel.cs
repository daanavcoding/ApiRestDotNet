using Microsoft.Extensions.Caching.Memory;
using System;

namespace ApiRestDanielDelViso
{
    public static class CacheModel
    {
        private static readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// Método para añadir objetos a la cache a través de una key.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        public static void Add(string cacheKey, object value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
            _cache.Set(cacheKey, value, cacheExpiryOptions);

        }
        /// <summary>
        /// Método que obtiene los objetos de la caché según la key.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object Get(string cacheKey)
        {
            var result = _cache.Get(cacheKey);
            return (result);
        }

        /// <summary>
        /// Método por si fuera necesario borrar la caché según la key por parámetro.
        /// </summary>
        /// <param name="cacheKey"></param>
        public static void Delete(string cacheKey)
        {
            _cache.Remove(cacheKey);

        }
    }
}
