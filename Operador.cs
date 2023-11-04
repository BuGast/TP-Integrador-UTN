using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador
{
    public abstract class Operador
    {
        string id;
        Bateria bateria;
        string estado;
        double cargaActual;
        double velocidadOptima;
        internal Localizacion localizacionBase;
        Localizacion localizacion;


    }

}
