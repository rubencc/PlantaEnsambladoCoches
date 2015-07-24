using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Business.Builder;
using Business.Decorators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;

namespace Test.Unitarios.Builder
{
    [TestClass]
    public class CarBuilderTest
    {
        [Ignore]
        [TestMethod]
        public void Construir_coche_y_compararlo_con_el_estandar()
        {
            CarBuilder builder = new CarBuilder();

            builder.CrearCentralita(true, true, true, true, true, false, false);
            builder.CrearMotor(110.3098125M, 150, 2000, 4);
            builder.CrearTanqueCombustible(60);
            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            Coche expected = this.GetCar();

            Assert.AreEqual(expected.ToString(), coche.ToString());

        }

        [TestMethod]
        public void Construir_coche_y_evaluar_centralita()
        {
            CarBuilder builder = new CarBuilder();

            builder.CrearCentralita(true, true, true, true, true, false, false);

            Coche coche = builder.ObtenerCoche();

            this.AssertCentralita(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_motor()
        {
            CarBuilder builder = new CarBuilder();

            builder.CrearMotor(110.3098125M, 150, 2000, 4);

            Coche coche = builder.ObtenerCoche();

            this.AssertMotor(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_tanque_de_combustible()
        {
            CarBuilder builder = new CarBuilder();

            builder.CrearTanqueCombustible(60);

            Coche coche = builder.ObtenerCoche();

            this.AssertTanqueCombustible(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_transmision()
        {
            CarBuilder builder = new CarBuilder();

            builder.CrearTransmision(6);

            Coche coche = builder.ObtenerCoche();

            this.AssertTransmision(coche);
        }

        [TestMethod]
        public void Construir_coche_y_evaluar_todas_las_partes()
        {
            ICarBuilder builder = new DecoratorCarBuilder(new CarBuilder());

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
            CarBuilder builder = new CarBuilder();

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
            CarBuilder builder = new CarBuilder();

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
                    Capacidad = 66.5M
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
