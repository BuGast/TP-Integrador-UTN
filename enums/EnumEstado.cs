// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado guardamos los datos de los diferentes estados que puede tener un operador.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    internal enum Estado
    {
        Ocupado,
        EnEspera //listo para cualquier acción,STANDBY, No acepta comandos generales
    }
}
