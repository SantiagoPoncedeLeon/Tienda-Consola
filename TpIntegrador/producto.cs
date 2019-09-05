using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class producto
    {
        //VARIABLES DE INSTANCIA
        string tipo;
        string marca;
        string talle;
        float precio;
        promocion promocion;

        public producto(string tipo, string marca, string talle, float precio)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.talle = talle;
            this.precio = precio;
        }

        public void AgregarPromo(promocion promo)
        {
            this.promocion = promo;
        }

        //PROPIEDADES
        public string Tipo
        {
            get
            {
                return tipo;
            }
        }
        public string Marca
        {
            get
            {
                return marca;
            }
        }
        public string Talle
        {
            get
            {
                return talle;
            }
        }
        public float Precio
        {
            get
            {
                return precio;
            }
        }
        public int Descuento
        {
            get
            {
                if (promocion == null)
                {
                    return 0;
                }
                else
                    return promocion.Descuento;
            }
        }

    }
}
