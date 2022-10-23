using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewmodel
{
    public class ProductoViewModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public float precio_unitario { get; set; }

        public string cat_name { get; set; }

        public string prov_name { get; set; }

        public int cantidad { get; set;  }
    }

    public class ProductoByIdViewModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public float precio_unitario { get; set; }

        public string cat_name { get; set; }

        public string prov_name { get; set; }

        public int cantidad { get; set; }
    }
}
