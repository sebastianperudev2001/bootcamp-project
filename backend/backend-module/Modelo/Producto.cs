using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Producto
    {
        public string id { get; set; }
        public string name { get; set; }

        public float precio_unitario { get; set; }

        public string categoria    { get; set; }

        public string proveedor { get; set; }

        public int cantidad { get; set; }

    }
}
