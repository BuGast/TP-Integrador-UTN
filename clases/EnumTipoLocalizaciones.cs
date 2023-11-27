// GUSTAVO MARTIN CANTARELLA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.clases;

namespace TP_Integrador.clases
{

    public class TipoLocalizaciones
    {
        public enum TipoLocalizacion
        {
            TerrenoBaldio,
            Planicie,
            Bosque,
            SectorUrbano,
            Vertedero,
            Lago,
            VertederoElectronico,
            SitioReciclaje,
            Cuartel
        }
    }

    public class GeneradorDeLocalizaciones
    {
        private int cuartelesMaximos = 0;
        private int sitioReciclajeMaximo = 0;
        private const int LimiteCuarteles = 3;
        private const int LimiteSitiosReciclaje = 5;

        public TipoLocalizaciones.TipoLocalizacion LocalizacionAleatoria()
        {
            Random random = new Random();
            int terrenoAleatorio = random.Next(0, 100);

            // Probabilidad de terrenos comunes
            if (terrenoAleatorio >= 0 && terrenoAleatorio <= 40)
            {
                return TipoLocalizaciones.TipoLocalizacion.TerrenoBaldio;
            }
            else if (terrenoAleatorio > 40 && terrenoAleatorio <= 60)
            {
                return TipoLocalizaciones.TipoLocalizacion.Planicie;
            }
            else if (terrenoAleatorio > 60 && terrenoAleatorio <= 75)
            {
                return TipoLocalizaciones.TipoLocalizacion.Bosque;
            }
            else if (terrenoAleatorio > 75 && terrenoAleatorio <= 80)
            {
                return TipoLocalizaciones.TipoLocalizacion.SectorUrbano;
            }
            else if (terrenoAleatorio > 80 && terrenoAleatorio <= 85)
            {
                return TipoLocalizaciones.TipoLocalizacion.Vertedero;
            }
            else if (terrenoAleatorio > 85 && terrenoAleatorio <= 90)
            {
                return TipoLocalizaciones.TipoLocalizacion.Lago;
            }
            else if (terrenoAleatorio > 90 && terrenoAleatorio <= 93)
            {
                return TipoLocalizaciones.TipoLocalizacion.VertederoElectronico;
            }            
            //else if (terrenoAleatorio > 93 && terrenoAleatorio <= 100)
            //{
            //    if (sitioReciclajeMaximo < LimiteSitiosReciclaje)
            //    {
            //        sitioReciclajeMaximo++;
            //        return TipoLocalizaciones.TipoLocalizacion.SitioReciclaje;
            //    }
            //    else
            //    {
            //        return TipoLocalizaciones.TipoLocalizacion.Bosque;
            //    }
            //}
            else
            {
                return TipoLocalizaciones.TipoLocalizacion.Planicie;
            }
        }
    }
}
