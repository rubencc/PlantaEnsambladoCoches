using System;
using Business.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;

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

            this.AssertCentralita(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_motor()
        {
            builder.CrearMotor(110.3098125M, 150, 2000, 4);

            Coche coche = builder.ObtenerCoche();

            this.AssertMotor(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_tanque_de_combustible()
        {
            builder.CrearTanqueCombustible(60);

            Coche coche = builder.ObtenerCoche();

            this.AssertTanqueCombustible(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_transmision()
        {
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            this.AssertTransmision(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_todas_las_partes()
        {
            builder.CrearCentralita(true, true, true, true, true, false, false);
            builder.CrearMotor(110.3098125M, 150, 2000, 4);
            builder.CrearTanqueCombustible(60);
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            this.AssertCentralita(coche);

            this.AssertMotor(coche);

            this.AssertTanqueCombustible(coche);

            this.AssertTransmision(coche);

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
