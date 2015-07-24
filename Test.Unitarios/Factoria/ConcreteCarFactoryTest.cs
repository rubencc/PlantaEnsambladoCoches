using System;
using Business.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Model;
using Test.Unitarios.Mocks;

namespace Test.Unitarios.Factoria
{
    [TestClass]
    public class ConcreteCarFactoryTest
    {
        private ConcreteCarFactory factory;
        private CarBuilderMock carBuilderMock;

        [TestMethod]
        public void Crear_Coche()
        {
            this.carBuilderMock = new CarBuilderMock();
            this.factory = new ConcreteCarFactory(carBuilderMock.GetMock());
            string sku = "ABC";

            this.carBuilderMock.Setup(this.GetCar());

            Coche coche = this.factory.CrearCoche("ABC");

            this.AssertCentralita(coche);
            this.AssertMotor(coche);
            this.AssertTanqueCombustible(coche);
            this.AssertTransmision(coche);

            Assert.AreEqual("Albacete", coche.LugarDeEnsamblado);
            Assert.AreEqual(DateTime.Today, coche.FechaDeEnsamblado);
            Assert.AreEqual(sku, coche.Modelo);
            Assert.AreEqual(sku, coche.Bastidor);

            this.carBuilderMock.Verify(Times.Once());
        }

        [TestMethod]
        public void Crear_Coche_con_centralita_basica()
        {
            this.carBuilderMock = new CarBuilderMock();
            this.factory = new ConcreteCarFactory(carBuilderMock.GetMock());
            string sku = "ABCZZ";

            this.carBuilderMock.Setup(this.GetCar());

            Coche coche = this.factory.CrearCoche(sku);

            this.AssertCentralita(coche);
            this.AssertMotor(coche);
            this.AssertTanqueCombustible(coche);
            this.AssertTransmision(coche);

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

        private void AssertCentralita(Coche coche)
        {
            Assert.IsTrue(coche.Centralita.ABS);
            Assert.IsTrue(coche.Centralita.Airbag);
            Assert.IsTrue(coche.Centralita.BAS);
            Assert.IsTrue(coche.Centralita.DireccionAsistida);
            Assert.IsTrue(coche.Centralita.GPS);
            Assert.IsFalse(coche.Centralita.ESP);
            Assert.IsFalse(coche.Centralita.TCS);
        }

        private void AssertMotor(Coche coche)
        {
            Assert.AreEqual(2000, coche.Motor.Capacidad);
            Assert.AreEqual(4, coche.Motor.Cilindros);
            Assert.AreEqual(150, coche.Motor.PotenciaCV);
            Assert.AreEqual(110.3098125M, coche.Motor.PotenciaKW);
        }

        private void AssertTanqueCombustible(Coche coche)
        {
            Assert.AreEqual(60, coche.TanqueCombustible.Capacidad);
        }

        private void AssertTransmision(Coche coche)
        {
            Assert.AreEqual(6, coche.Transmision.Marchas);
        }
    }
}
