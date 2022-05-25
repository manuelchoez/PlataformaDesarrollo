using PlataformaDesarrollo.Cache.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PlataformaDesarrollo.Cache
{
    public class PlataformaCache : IPlataformaCache
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public PlataformaCache(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task Agregar(string key, string value)
        {
           IDatabase db = _connectionMultiplexer.GetDatabase();           
           await db.StringSetAsync(key, value);
        }

        public async Task<string> Obtener(string key)
        {
            IDatabase db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }
    }
}
