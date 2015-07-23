using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;

namespace Test.Unitarios
{
    [TestClass]
    public class CocheTest
    {
        [TestMethod]
        public void Metodo_ToString()
        {
            Coche coche = this.GetCar();

            string specs = coche.ToString();

            Assert.AreNotEqual(String.Empty, specs);
        }

        private Coche GetCar()
        {
            Coche coche = new CocheGasolina()
            {
                Centralita = new Centralita()
                {
                    ABS = true,
                    Airbag = true,
                    BAS = true,
                    DireccionAsistida = true,
                    ESP = true,
                    GPS = true,
                    TCS = true
                },
                Bastidor = "123456",
                FechaDeEnsamblado = new DateTime(2015, 1, 1),
                LugarDeEnsamblado = "Albacete",
                Marca = "Matel",
                Modelo = "Autoloco",
                Motor = new Motor()
                {
                    Capacidad = 2000,
                    PotenciaCV = 150,
                    PotenciaKW = 110.3098125M,
                    Cilindros = 4

                },
                TanqueCombustible = new TanqueCombustible()
                {
                    Capacidad = 66.5M
                },
                Transmision = new Transmision()
                {
                    Marchas = 6
                }
            };

            return coche;


        }
    }
}
