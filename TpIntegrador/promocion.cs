using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class promocion
    {
        producto prod;
        int descuento;

        public promocion(producto prod, int descuento)
        {
            this.prod = prod;
            this.descuento = descuento;
        }

        public int Descuento
        {
            get
            {
                return descuento;
            }
        }
    }
}
