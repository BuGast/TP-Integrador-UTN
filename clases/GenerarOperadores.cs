using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.clases
{
    internal class GeneradorOperadores
    {
        public K9 CrearOperadorK9()
        {
            // Lógica para crear un operador de tipo K9
            K9 nuevoOperadorK9 = new K9(); // Todavia sin saber si se define algo del operador, o recibira toda la informacion junto a su creacion.
            return nuevoOperadorK9;
        }

        public UAV CrearOperadorUAV()
        {
            // Lógica para crear un operador de tipo UAV
            UAV nuevoOperadorUAV = new UAV(); // Todavia sin saber si se define algo del operador, o recibira toda la informacion junto a su creacion.        
            return nuevoOperadorUAV;
        }

        public M8 CrearOperadorM8()
        {
            // Lógica para crear un operador de tipo M8
            M8 nuevoOperadorM8 = new M8(); // Todavia sin saber si se define algo del operador, o recibira toda la informacion junto a su creacion.            
            return nuevoOperadorM8;
        }
    }
}
