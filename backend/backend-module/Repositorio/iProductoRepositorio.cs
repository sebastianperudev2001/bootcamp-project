using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface iProductoRepositorio
    {
        Task<int> Create(Producto producto);
        Task<int> Delete(int id);
        Task<int> Update(Producto producto);
    }
}
