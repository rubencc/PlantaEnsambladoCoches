using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Builder;
using Shared.Model;

namespace Business.Decorators
{
    public class DecoratorCarBuilder : ICarBuilder
    {
        private readonly ICarBuilder builder;

        public DecoratorCarBuilder(ICarBuilder builder)
        {
            this.builder = builder;
        }

        public Shared.Model.Coche ObtenerCoche()
        {
            CocheGasolina coche = this.builder.ObtenerCoche() as CocheGasolina;

            CocheElectrico hibrido = new CocheElectrico();

            hibrido.Centralita = coche.Centralita;
            hibrido.Motor = coche.Motor;
            hibrido.TanqueCombustible = coche.TanqueCombustible;
            hibrido.Transmision = coche.Transmision;

            hibrido.Bateria = new Bateria()
            {
                Capacidad = 90000
            };

            hibrido.MotorElectrico = new MotorElectrico()
            {
                PotenciaKW = 100
            };

            return hibrido;
        }

        public void CrearCentralita(bool abs, bool airbag, bool bas, bool gps, bool direccionAsistida, bool tcs, bool esp)
        {
            this.builder.CrearCentralita(abs, airbag, bas, gps, direccionAsistida, tcs, esp);
        }

        public void CrearMotor(decimal potenciaKw, int potenciaCv, int capacidad, int cilindros)
        {
            this.builder.CrearMotor(potenciaKw, potenciaCv, capacidad, cilindros);
        }

        public void CrearTanqueCombustible(decimal capacidad)
        {
            this.builder.CrearTanqueCombustible(capacidad);
        }

        public void CrearTransmision(int marchas)
        {
            this.builder.CrearTransmision(marchas);
        }
    }
}
