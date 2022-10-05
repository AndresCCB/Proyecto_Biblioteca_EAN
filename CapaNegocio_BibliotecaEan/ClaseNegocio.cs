using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos_BibliotecaEan;
using CapaEntidad_BibliotecaEan;

namespace CapaNegocio_BibliotecaEan
{
    public class ClaseNegocio
    {
        ClaseDatos datos = new ClaseDatos();

        public DataTable N_listar_libros()
        {
            return datos.D_Listar_libros();
        }

        public DataTable N_buscar_libros_titulo(ClaseEntidad entidad)
        {
            return datos.D_buscar_libros_titulo(entidad);
        }
        public DataTable N_buscar_libros_autor(ClaseEntidad entidad)
        {
            return datos.D_buscar_libros_autor(entidad);
        }
        public DataTable N_buscar_libros_codigo(ClaseEntidad entidad)
        {
            return datos.D_buscar_libros_codigo(entidad);
        }

        public String N_mantenimiento_libros(ClaseEntidad entidad)
        {
            return datos.D_mantenimiento_libros(entidad);
        }
    }
}
