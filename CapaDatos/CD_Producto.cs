using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    class CD_Producto
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "LeerProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.Execute.Reader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, double precio, int cantidad, int estado)
        {
            //Procedimientos para insertar datos

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar Productos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();

            comando.Parameter.Clear();
        }

        public void Actualizar(string nombre, string desc, double precio, int cantidad, int estado, int idproducto)
        {
            //Procedimiento para actualizar datos 

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Actualizar Productos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Borrar(int idproducto)
        {
            //Procedimiento para eliminar
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idprod", idproducto);

            comando.ExcecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
