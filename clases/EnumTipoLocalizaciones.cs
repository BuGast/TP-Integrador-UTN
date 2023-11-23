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
            Cuartel,
            TerrenoBaldio,
            Planicie,
            Bosque,
            SectorUrbano,
            Vertedero,
            Lago,
            VertederoElectronico,
            SitioReciclaje
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
            int terrenoAleatorio = random.Next(100);

            // Probabilidad de terrenos comunes
            if (terrenoAleatorio >= 0 && terrenoAleatorio <= 25)
            {
                return TipoLocalizaciones.TipoLocalizacion.TerrenoBaldio;
            }
            else if (terrenoAleatorio > 25 && terrenoAleatorio <= 40)
            {
                return TipoLocalizaciones.TipoLocalizacion.Planicie;
            }
            else if (terrenoAleatorio > 40 && terrenoAleatorio <= 60)
            {
                return TipoLocalizaciones.TipoLocalizacion.Bosque;
            }
            else if (terrenoAleatorio > 60 && terrenoAleatorio <= 75)
            {
                return TipoLocalizaciones.TipoLocalizacion.SectorUrbano;
            }
            else if (terrenoAleatorio > 75 && terrenoAleatorio <= 100)
            {
                // Aca añadimos los sitios con efecto especial, y limitamos los cuarteles y sitios de reciclaje.
                int terrenoAleatorio2 = random.Next(100);

                if (terrenoAleatorio2 >= 0 && terrenoAleatorio2 <= 25)
                {
                    return TipoLocalizaciones.TipoLocalizacion.Vertedero;
                }
                else if (terrenoAleatorio2 > 25 && terrenoAleatorio2 <= 40)
                {
                    return TipoLocalizaciones.TipoLocalizacion.VertederoElectronico;
                }
                else if (terrenoAleatorio2 > 40 && terrenoAleatorio2 <= 50)
                {
                    return TipoLocalizaciones.TipoLocalizacion.Lago;
                }
                else if (terrenoAleatorio2 > 50 && terrenoAleatorio2 < 65)
                {
                    if (cuartelesMaximos < LimiteCuarteles)
                    {
                        cuartelesMaximos++;
                        return TipoLocalizaciones.TipoLocalizacion.Cuartel;
                    }
                    else
                    {
                        return TipoLocalizaciones.TipoLocalizacion.Planicie;
                    }
                }
                else if (terrenoAleatorio2 > 65 && terrenoAleatorio2 < 80)
                {
                    if (sitioReciclajeMaximo < LimiteSitiosReciclaje)
                    {
                        sitioReciclajeMaximo++;
                        return TipoLocalizaciones.TipoLocalizacion.SitioReciclaje;
                    }
                    else
                    {
                        return TipoLocalizaciones.TipoLocalizacion.Bosque;
                    }
                }
                else
                {
                    // En caso de algún error, lanzar una excepción o manejar de otra manera.
                    throw new InvalidOperationException("Error en la generación de localizaciones aleatorias.");
                }
            }

            // En caso de algún error, lanzar una excepción o manejar de otra manera.
            throw new InvalidOperationException("Error en la generación de localizaciones aleatorias.");
        }
    }
}
