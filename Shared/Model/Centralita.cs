using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Centralita
    {
        public bool ABS { get; set; }
        public bool Airbag { get; set; }
        public bool BAS { get; set; }
        public bool GPS { get; set; }
        public bool DireccionAsistida { get; set; }
        public bool TCS { get; set; }
        public bool ESP { get; set; }
    }
}
