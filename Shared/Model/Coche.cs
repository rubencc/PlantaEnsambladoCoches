using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public abstract class Coche
    {
        public Centralita Centralita { get; set; }
        public Motor Motor { get; set; }
        public TanqueCombustible TanqueCombustible { get; set; }
        public Transmision Transmision { get; set; }

        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String LugarDeEnsamblado { get; set; }
        public DateTime FechaDeEnsamblado { get; set; }
    }
}
