using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad_BibliotecaEan
{
    public class ClaseEntidad
    {
        public int codigo { get; set; }
        public String titulo { get; set; }
        public String autor { get; set; }
        public String editorial { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string accion { get; set; }
    }
}
