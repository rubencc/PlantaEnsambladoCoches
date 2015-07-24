using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Model;

namespace Test.Common
{
    public static class AssertParaCoche
    {
        public static void AssertCentralitaSinESPniTCS(Coche coche)
        {
            Assert.IsTrue(coche.Centralita.ABS);
            Assert.IsTrue(coche.Centralita.Airbag);
            Assert.IsTrue(coche.Centralita.BAS);
            Assert.IsTrue(coche.Centralita.DireccionAsistida);
            Assert.IsTrue(coche.Centralita.GPS);
            Assert.IsFalse(coche.Centralita.ESP);
            Assert.IsFalse(coche.Centralita.TCS);
        }

        public static void AssertCentralita(Coche coche)
        {
            Assert.IsTrue(coche.Centralita.ABS);
            Assert.IsTrue(coche.Centralita.Airbag);
            Assert.IsTrue(coche.Centralita.BAS);
            Assert.IsTrue(coche.Centralita.DireccionAsistida);
            Assert.IsTrue(coche.Centralita.GPS);
            Assert.IsTrue(coche.Centralita.ESP);
            Assert.IsTrue(coche.Centralita.TCS);
        }

        public static void AssertCentralitaBasica(Coche coche)
        {
            Assert.IsTrue(coche.Centralita.ABS);
            Assert.IsFalse(coche.Centralita.Airbag);
            Assert.IsFalse(coche.Centralita.BAS);
            Assert.IsFalse(coche.Centralita.DireccionAsistida);
            Assert.IsFalse(coche.Centralita.GPS);
            Assert.IsFalse(coche.Centralita.ESP);
            Assert.IsFalse(coche.Centralita.TCS);
        }

        public static void AssertMotor(Coche coche)
        {
            Assert.AreEqual(2000, coche.Motor.Capacidad);
            Assert.AreEqual(4, coche.Motor.Cilindros);
            Assert.AreEqual(150, coche.Motor.PotenciaCV);
            Assert.AreEqual(110.3098125M, coche.Motor.PotenciaKW);
        }

        public static void AssertTanqueCombustible(Coche coche)
        {
            Assert.AreEqual(60, coche.TanqueCombustible.Capacidad);
        }

        public static void AssertTransmision(Coche coche)
        {
            Assert.AreEqual(6, coche.Transmision.Marchas);
        }

        public static void AssertBateriaYMotorElectrico(Coche coche)
        {
            CocheElectrico cocheElectrico = coche as CocheElectrico;

            Assert.IsNotNull(cocheElectrico);
            Assert.AreEqual(90000, cocheElectrico.Bateria.Capacidad);
            Assert.AreEqual(100, cocheElectrico.MotorElectrico.PotenciaKW);
        }
    }
}
