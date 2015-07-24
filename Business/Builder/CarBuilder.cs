using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Business.Builder
{
    public class CarBuilder : ICarBuilder
    {
        private Coche coche;
        private Centralita centralita;

        public CarBuilder()
        {
            this.coche = new CocheGasolina();
        }


        public Coche ObtenerCoche()
        {
            //Llamadas a metodos privados o asignacion de partes
            this.coche.Centralita = this.centralita;
            return this.coche;
        }

        public void CrearCentralita(bool abs, bool airbag, bool bas, bool gps, bool direccionAsistida, bool tcs, bool esp)
        {
            this.centralita = new Centralita()
            {
                ABS = abs,
                Airbag = airbag,
                BAS = bas,
                GPS = gps,
                DireccionAsistida = direccionAsistida,
                TCS = tcs,
                ESP = esp
            };

            //this.coche.Centralita = new Centralita()
            //{
            //    ABS = abs, 
            //    Airbag = airbag,
            //    BAS = bas,
            //    GPS = gps,
            //    DireccionAsistida = direccionAsistida,
            //    TCS = tcs,
            //    ESP = esp
            //};
        }

        public void CrearMotor(decimal potenciaKw, int potenciaCv, int capacidad, int cilindros)
        {
            this.coche.Motor = new Motor()
            {
                Capacidad = capacidad,
                Cilindros = cilindros,
                PotenciaCV = potenciaCv,
                PotenciaKW = potenciaKw
            };
        }

        public void CrearTanqueCombustible(decimal capacidad)
        {
            this.coche.TanqueCombustible = new TanqueCombustible()
            {
                Capacidad = capacidad
            };
        }

        public void CrearTransmision(int marchas)
        {
            this.coche.Transmision = new Transmision()
            {
                Marchas = marchas
            };
        }
    }
}
