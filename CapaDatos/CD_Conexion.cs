using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private sqlConecction Conexion = new sqlconecction("Server=DESKTOP-MCMQE06\\SQLEXPRESS;" +

            "DataBase= BarDB"

            "Integrated Security= SSPI");

        public sqlConecction AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public sqlConecction CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Open();
            return Conexion;
        }

    }
}
