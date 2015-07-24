using System;
using Business.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;
using Test.Common;

namespace Test.Unitarios.Builder
{
    [TestClass]
    public class CarBuilderTest
    {

        private CarBuilder builder;

        [TestInitialize]
        public void Setup()
        {
            this.builder = new CarBuilder();
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_centralita()
        {
            builder.CrearCentralita(true, true, true, true, true, false, false);

            Coche coche = builder.ObtenerCoche();

            AssertParaCoche.AssertCentralitaSinESPniTCS(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_motor()
        {
            builder.CrearMotor(110.3098125M, 150, 2000, 4);

            Coche coche = builder.ObtenerCoche();

            AssertParaCoche.AssertMotor(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_tanque_de_combustible()
        {
            builder.CrearTanqueCombustible(60);

            Coche coche = builder.ObtenerCoche();

            AssertParaCoche.AssertTanqueCombustible(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_transmision()
        {
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            AssertParaCoche.AssertTransmision(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_todas_las_partes()
        {
            builder.CrearCentralita(true, true, true, true, true, false, false);
            builder.CrearMotor(110.3098125M, 150, 2000, 4);
            builder.CrearTanqueCombustible(60);
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            AssertParaCoche.AssertCentralitaSinESPniTCS(coche);
            AssertParaCoche.AssertMotor(coche);
            AssertParaCoche.AssertTanqueCombustible(coche);
            AssertParaCoche.AssertTransmision(coche);

        }

        [TestMethod]
        public void Construir_coche_y_evaluar_que_sus_partes_no_sean_nulas()
        {
            builder.CrearCentralita(true, true, true, true, true, false, false);
            builder.CrearMotor(110.3098125M, 150, 2000, 4);
            builder.CrearTanqueCombustible(60);
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            Assert.IsNotNull(coche.Motor);
            Assert.IsNotNull(coche.Centralita);
            Assert.IsNotNull(coche.Transmision);
            Assert.IsNotNull(coche.TanqueCombustible);

        }

        [TestMethod]
        public void Construir_coche_y_evaluar_parte_no_comun()
        {
            builder.CrearCentralita(true, true, true, true, true, false, false);
            builder.CrearMotor(110.3098125M, 150, 2000, 4);
            builder.CrearTanqueCombustible(60);
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            Assert.IsNull(coche.Marca);
            Assert.IsNull(coche.Modelo);
            Assert.IsNull(coche.LugarDeEnsamblado);
            Assert.IsNull(coche.Bastidor);
            Assert.AreEqual(new DateTime(), coche.FechaDeEnsamblado);

        }
    }
}
