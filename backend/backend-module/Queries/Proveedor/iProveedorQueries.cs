using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodel;

namespace Queries.Proveedor
{
    public interface iProveedorQueries
    {
         Task<IEnumerable<ProveedorViewModel>> GetAll();

    }
}
