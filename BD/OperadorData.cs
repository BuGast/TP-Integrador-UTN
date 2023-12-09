// Gastón Camú, Alicia Nazar

/* Introduccion
 * Este clase la creamos para manejar el crud de operador.
 * Lo estabamos implementando pero se nos fue el tiempo volando asi que quedo casi terminado :)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    public class OperadorDataAccess
    {
        private readonly DBHelper dbHelper;

        public OperadorDataAccess(string connectionString)
        {
            dbHelper = new DBHelper(connectionString);
        }

        // Método para obtener todos los operadores
        public List<Operador> ObtenerOperadores()
        {
            List<Operador> lista = new List<Operador>();
            string selectQuery = "SELECT * FROM operadores";
            DataTable result = dbHelper.ExecuteQuery(selectQuery);

            foreach (DataRow row in result.Rows)
            {
                Operador operador = CrearOperadorDesdeDataRow(row);
                lista.Add(operador);
            }

            return lista;
        }

        // Método para obtener un operador por ID
        public Operador ObtenerOperadorPorId(string id)
        {
            string selectQuery = $"SELECT * FROM operadores WHERE id = '{id}'";
            DataTable result = dbHelper.ExecuteQuery(selectQuery);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return CrearOperadorDesdeDataRow(row);
            }

            return null; // Operador no encontrado
        }

        // Método para agregar un nuevo operador
        public void AgregarOperador(Operador operador)
        {
            string insertQuery = $"INSERT INTO operadores (id, coordX, coordY, cargaBateria, cargaFisica) " +
                                 $"VALUES ('{operador.getId()}', {operador.getCoordX()}, {operador.getCoordY()}, " +
                                 $"{operador.getBateria().getCargaActual()}, {operador.getCargaFisicaMaxima()})";
            dbHelper.ExecuteNonQuery(insertQuery);
        }

        // Método para actualizar un operador existente
        public void ActualizarOperador(Operador operador)
        {
            string updateQuery = $"UPDATE operadores SET coordX = {operador.getCoordX()}, " +
                                 $"coordY = {operador.getCoordY()}, cargaBateria = {operador.getBateria().getCargaActual()}, " +
                                 $"cargaFisica = {operador.getCargaFisicaMaxima()} WHERE id = '{operador.getId()}'";
            dbHelper.ExecuteNonQuery(updateQuery);
        }

        // Método para eliminar un operador por ID
        public void EliminarOperador(string id)
        {
            string deleteQuery = $"DELETE FROM operadores WHERE id = '{id}'";
            dbHelper.ExecuteNonQuery(deleteQuery);
        }

    }

}
