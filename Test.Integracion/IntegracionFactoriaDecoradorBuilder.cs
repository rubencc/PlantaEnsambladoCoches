using System;
using Business.Builder;
using Business.Decorators;
using Business.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;
using Test.Common;

namespace Test.Integracion
{
    [TestClass]
    public class IntegracionFactoriaDecoradorBuilder
    {
        private ConcreteCarFactory factory;

        [TestInitialize]
        public void Setup()
        {
            this.factory = new ConcreteCarFactory(new DecoratorCarBuilder(new CarBuilder()));
        }

        //Este test fallara pq la implementacion de la factoria es erronea en la linea 20
        //Se esta llamando al metodo ObtenerCoche antes de haber construidor sus partes. 
        //Este error no aparece en los test unitarios puesto que estamos devolviendo a traves del mock un objeto ya construido.
        [TestMethod]
        public void Integracion_Crear_Coche()
        {
            string sku = "ABC";

            Coche coche = this.factory.CrearCoche("ABC");

            AssertParaCoche.AssertCentralita(coche);
            AssertParaCoche.AssertMotor(coche);
            AssertParaCoche.AssertTanqueCombustible(coche);
            AssertParaCoche.AssertTransmision(coche);
            AssertParaCoche.AssertBateriaYMotorElectrico(coche);

            Assert.AreEqual("Albacete", coche.LugarDeEnsamblado);
            Assert.AreEqual(DateTime.Today, coche.FechaDeEnsamblado);
            Assert.AreEqual(sku, coche.Modelo);
            Assert.AreEqual(sku, coche.Bastidor);

        }

        [TestMethod]
        public void Integracion_Crear_Coche_con_centralita_basica()
        {
            string sku = "ABCZZ";

            Coche coche = this.factory.CrearCoche(sku);

            AssertParaCoche.AssertCentralitaBasica(coche);
            AssertParaCoche.AssertMotor(coche);
            AssertParaCoche.AssertTanqueCombustible(coche);
            AssertParaCoche.AssertTransmision(coche);
            AssertParaCoche.AssertBateriaYMotorElectrico(coche);

            Assert.AreEqual("Albacete", coche.LugarDeEnsamblado);
            Assert.AreEqual(DateTime.Today, coche.FechaDeEnsamblado);
            Assert.AreEqual(sku, coche.Modelo);
            Assert.AreEqual(sku, coche.Bastidor);
        }
    }
}
