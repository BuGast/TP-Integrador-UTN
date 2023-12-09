// Gastón Camú, Alicia Nazar

/* Introduccion
 * En este apartado realizamos la creacion del operador tomando en cuenta los valores de m8.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador;

namespace TP_Integrador
{
    public class M8 : Operador
    {
        public M8(string id, int coordX, int coordY, int cargaBateria, int cargaFisica)
            : base(id, coordX, coordY, cargaBateria, cargaFisica)
        {


        }
    }

}
