using System;
using Business.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Model;
using Test.Common;
using Test.Unitarios.Mocks;

namespace Test.Unitarios.Factoria
{
    [TestClass]
    public class ConcreteCarFactoryTest
    {
        private ConcreteCarFactory factory;
        private CarBuilderMock carBuilderMock;

        [TestInitialize]
        public void Setup()
        {
            this.carBuilderMock = new CarBuilderMock();
            this.factory = new ConcreteCarFactory(carBuilderMock.GetMock());
        }

        [TestMethod]
        public void Crear_Coche()
        {           
            string sku = "ABC";

            this.carBuilderMock.Setup(this.GetCar());

            Coche coche = this.factory.CrearCoche("ABC");

            AssertParaCoche.AssertCentralitaSinESPniTCS(coche);
            AssertParaCoche.AssertMotor(coche);
            AssertParaCoche.AssertTanqueCombustible(coche);
            AssertParaCoche.AssertTransmision(coche);

            Assert.AreEqual("Albacete", coche.LugarDeEnsamblado);
            Assert.AreEqual(DateTime.Today, coche.FechaDeEnsamblado);
            Assert.AreEqual(sku, coche.Modelo);
            Assert.AreEqual(sku, coche.Bastidor);

            this.carBuilderMock.Verify(Times.Once());
        }

        [TestMethod]
        public void Crear_Coche_con_centralita_basica()
        {
            string sku = "ABCZZ";

            this.carBuilderMock.Setup(this.GetCar());

            Coche coche = this.factory.CrearCoche(sku);

            AssertParaCoche.AssertCentralitaSinESPniTCS(coche);
            AssertParaCoche.AssertMotor(coche);
            AssertParaCoche.AssertTanqueCombustible(coche);
            AssertParaCoche.AssertTransmision(coche);

            Assert.AreEqual("Albacete", coche.LugarDeEnsamblado);
            Assert.AreEqual(DateTime.Today, coche.FechaDeEnsamblado);
            Assert.AreEqual(sku, coche.Modelo);
            Assert.AreEqual(sku, coche.Bastidor);

            this.carBuilderMock.VerifyCEntralitaBasica(Times.Once());
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
                    ESP = false,
                    GPS = true,
                    TCS = false
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
                    Capacidad = 60M
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
