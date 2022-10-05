using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad_BibliotecaEan;
using System.Configuration;

namespace CapaDatos_BibliotecaEan
{
    public class ClaseDatos
    {
        /*Conexion a la Base de Datos*/
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_Listar_libros()
        {
            SqlCommand cmd = new SqlCommand("listar_libros", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_libros_titulo(ClaseEntidad entidad)
        {
            SqlCommand cmd = new SqlCommand("buscar_libros_titulo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", entidad.titulo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_libros_autor(ClaseEntidad entidad)
        {
            SqlCommand cmd = new SqlCommand("buscar_libros_autor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@autor", entidad.autor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_buscar_libros_codigo(ClaseEntidad entidad)
        {
            SqlCommand cmd = new SqlCommand("buscar_libros_codigo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", entidad.codigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_mantenimiento_libros(ClaseEntidad entidad)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("mantenimiento_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", entidad.codigo);
            cmd.Parameters.AddWithValue("@titulo", entidad.titulo);
            cmd.Parameters.AddWithValue("@autor", entidad.autor);
            cmd.Parameters.AddWithValue("@editorial", entidad.editorial);
            cmd.Parameters.AddWithValue("@precio", entidad.precio);
            cmd.Parameters.AddWithValue("@cantidad", entidad.cantidad);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = entidad.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
