using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodel;

namespace Queries.Producto
{
    public interface iProductoQueries
    {
        Task<IEnumerable<ProductoViewModel>> GetAll();
        Task<ProductoByIdViewModel> GetById(int id);


    }
}
