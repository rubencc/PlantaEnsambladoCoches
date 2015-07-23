using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Business.Factories
{
    public interface ICarFactory
    {
        Coche CrearCoche(string sku);
    }
}
