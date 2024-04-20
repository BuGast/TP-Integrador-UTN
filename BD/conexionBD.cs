﻿// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado intentamos generar una clase que nos permita reutilizar la parte de la conexion..
 * y otras funciones como la ejecucion de las consultas.
*/

using System;
using System.Data;
using System.Data.SqlClient;

namespace TP_Integrador
{

    public class DBHelper
    {
        private readonly string connectionString;

        public DBHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}