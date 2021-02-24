using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public string SKU { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public ML.Tipo Tipo { get; set; }
        public string NumeroDeSerie { get; set; }
        public DateTime Fecha { get; set; }
        public List<Object> Productos { get; set; }
        public string Accion { get; set; }
        
    }
}
