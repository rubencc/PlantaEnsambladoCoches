using Business.Builder;
using Shared.Model;

namespace Business.Factories
{
    public abstract class CarFactory : ICarFactory
    {
        protected readonly ICarBuilder builder;

        protected CarFactory(ICarBuilder builder)
        {
            this.builder = builder;
        }

        public abstract Coche CrearCoche(string sku);

        protected Coche EnsamblarCoche()
        {
            return this.builder.ObtenerCoche();
        }
    }
}
