using System;
using Shared.Model;

namespace Business.Builder
{
    public interface ICarBuilder
    {
        Coche EnsamblarCoche();
        void CrearCentralita(bool abs, bool airbag, bool bas, bool gps, bool direccionAsistida, bool tcs, bool esp);
        void CrearMotor(int potenciaKw, int potenciaCv, int capacidad, int cilindros);
        void CrearTanqueCombustible(Decimal capacidad);
        void CrearTransmision(int marchas);
    }
}
