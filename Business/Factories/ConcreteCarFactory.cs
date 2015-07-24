using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Business.Builder;
using Shared.Model;

namespace Business.Factories
{
    public class ConcreteCarFactory : CarFactory
    {
        public ConcreteCarFactory(ICarBuilder builder) : base(builder)
        {
        }

        public override Coche CrearCoche(string sku)
        {
            Coche coche = this.EnsamblarCoche();

            if (sku.ToLower().Contains("zz"))

            {
                this.builder.CrearCentralita(true, false, false, false, false, false, false);
            }
            else
            {
                this.builder.CrearCentralita(true, true, true, true, true, true, true);
            }

            this.builder.CrearMotor(110.3098125M, 150, 2000, 4);
            this.builder.CrearTanqueCombustible(60);
            this.builder.CrearTransmision(6);

            coche.Modelo = sku;
            coche.LugarDeEnsamblado = "Albacete";
            coche.FechaDeEnsamblado = DateTime.Today;
            coche.Bastidor = sku;
            coche.Marca = "Newpol";

            return coche;

        }
    }
}
