using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Shared.Model
{
    public abstract class Coche
    {
        public Centralita Centralita { get; set; }
        public Motor Motor { get; set; }
        public TanqueCombustible TanqueCombustible { get; set; }
        public Transmision Transmision { get; set; }

        public String Bastidor { get; set; }
        public String Modelo { get; set; }
        public String Marca { get; set; }
        public String LugarDeEnsamblado { get; set; }
        public DateTime FechaDeEnsamblado { get; set; }

        public override string ToString()
        {
            string s = JsonConvert.SerializeObject(this, Formatting.Indented);
            return s;
        }

        
    }
}