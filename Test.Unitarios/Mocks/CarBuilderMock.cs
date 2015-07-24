using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Builder;
using Moq;
using Shared.Model;

namespace Test.Unitarios.Mocks
{
    public class CarBuilderMock
    {
        private Mock<ICarBuilder> objectMock;

        public CarBuilderMock()
        {
            this.objectMock = new Mock<ICarBuilder>();
        }

        public ICarBuilder GetMock()
        {
            return this.objectMock.Object;
        }

        public void Setup(Coche coche)
        {
            this.objectMock.Setup(mock => mock.ObtenerCoche()).Returns(coche);
        }

        public void Verify(Times times)
        {
            this.objectMock.Verify(mock => mock.CrearCentralita(It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(),It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>()));
            this.objectMock.Verify(mock => mock.CrearMotor(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
            this.objectMock.Verify(mock => mock.CrearTanqueCombustible(It.IsAny<decimal>()));
            this.objectMock.Verify(mock => mock.CrearTransmision(It.IsAny<int>()));
            this.objectMock.Verify(mock => mock.ObtenerCoche(), times);
        }

        public void VerifyCEntralitaBasica(Times times)
        {
            this.objectMock.Verify(mock => mock.CrearCentralita(true, false, false, false, false, false, false));
            this.objectMock.Verify(mock => mock.CrearMotor(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
            this.objectMock.Verify(mock => mock.CrearTanqueCombustible(It.IsAny<decimal>()));
            this.objectMock.Verify(mock => mock.CrearTransmision(It.IsAny<int>()));
            this.objectMock.Verify(mock => mock.ObtenerCoche(), times);
        }
    }
}
