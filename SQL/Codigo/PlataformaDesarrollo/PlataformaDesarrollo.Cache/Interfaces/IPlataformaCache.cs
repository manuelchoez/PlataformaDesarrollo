using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaDesarrollo.Cache.Interfaces
{
    public interface IPlataformaCache
    {
        Task Agregar(string key, string value);
        Task<string> Obtener(string key);
    }
}
