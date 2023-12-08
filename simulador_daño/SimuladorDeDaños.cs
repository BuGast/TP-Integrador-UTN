using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Integrador.operador;

namespace TP_Integrador.simulador_daño
{
    public class SimuladorDeDaños
    {
        public bool MotorComprometido { get; set; }
        public bool ServoAtascado { get; set; }
        public bool BateriaPerforada { get; set; }
        public bool PuertoBateriaDesconectado { get; set; }
        public bool PinturaRayada { get; set; }

        // Lo inicializo sin daños
        public SimuladorDeDaños()
        {
            MotorComprometido = false;
            ServoAtascado = false;
            BateriaPerforada = false;
            PuertoBateriaDesconectado = false;
            PinturaRayada = false;
        }
        public void SimularMotorComprometido(Operador operador)
        {
            if (!MotorComprometido)
            {
                Console.WriteLine("Motor comprometido. Velocidad promedio reducida a la mitad.");
                int velocidadReducida = Convert.ToInt32(operador.getVelocidadOptima()) / 2;
                operador.setVelocidadOptima(velocidadReducida);
                MotorComprometido = true;
                operador.setEstadoDañado(MotorComprometido);
            }
        }
        public void SimularServoAtascado(Operador operador)
        {
            if (!ServoAtascado)
            {
                Console.WriteLine("Servo atascado. No puede realizar operaciones de carga y descarga física.");
                ServoAtascado = true;
                operador.setEstadoDañado(ServoAtascado);
            }
        }
        public void SimularBateriaPerforada(Operador operador)
        {
            if (!BateriaPerforada)
            {
                Console.WriteLine("Batería perforada. Pierde batería un 500% más rápido en cada operación.");
                BateriaPerforada = true;
                operador.setEstadoDañado(BateriaPerforada);
            }
        }

        public void SimularPuertoBateriaDesconectado(Operador operador)
        {
            if (!PuertoBateriaDesconectado)
            {
                Console.WriteLine("Puerto de batería desconectado. No puede realizar operaciones de carga, recarga o transferencia de batería.");
                PuertoBateriaDesconectado = true;
                operador.setEstadoDañado(PuertoBateriaDesconectado);
            }
        }

        public void SimularPinturaRayada(Operador operador)
        {
            if (!PinturaRayada)
            {
                Console.WriteLine("Pintura rayada. No tiene efecto.");
                PinturaRayada = true;
                operador.setEstadoDañado(PinturaRayada);
            }
        }
    }
}
