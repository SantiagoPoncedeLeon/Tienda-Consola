using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class carro
    {
        float total = 0;
        protected List<productocarro> ListaProductos = new List<productocarro>();

        public void agregarProducto(producto producto, int cantidad)
        {
            int i = 0;
            for (i = 0; i < ListaProductos.Count; i++)
            {
                productocarro p = (productocarro)ListaProductos[i];
                if (p.producto == producto)
                {
                    cantidad = cantidad + p.cantidad;
                    ListaProductos.RemoveAt(i);
                    break;
                }
            }
            ListaProductos.Insert(i,new productocarro(producto, cantidad)); 
            return;
        }

        public void QuitarProducto(int nro, int cantidad)
        {
            productocarro p = ((productocarro)ListaProductos[nro - 1]);
            agregarProducto(p.producto, (-cantidad));

            if (cantidad > p.cantidad)
            {
                ListaProductos.RemoveAt(nro - 1);
            }
            return;
        }

        public struct productocarro
        {
            public producto producto { get; }
            public int cantidad { get; }

            public productocarro(producto p, int c)
            {
                producto = p;
                cantidad = c;
            }
        }

        public struct InfoProducto
        {
            public string tipo { get; }
            public string marca { get; }
            public string talle { get; }
            public float precio { get; }
            public int descuento { get; }
            public int cantidad { get; }

            public InfoProducto(string ti, string m, string ta, float p, int d, int c)
            {
                tipo = ti;
                marca = m;
                talle = ta;
                precio = p;
                descuento = d;
                cantidad = c;
            }

        }

        public InfoProducto[] VerProductos()
        {
            List<InfoProducto> l = new List<InfoProducto>();
            foreach (productocarro p in ListaProductos)
            {
                
                l.Add(new InfoProducto(p.producto.Tipo, p.producto.Marca, p.producto.Talle, p.producto.Precio, p.producto.Descuento, p.cantidad));
            }
            return l.ToArray();
        }

        public producto EncontrarProducto(int numero)
        {
            return (producto)ListaProductos[numero - 1].producto;
        }

        public float VerTotal()
        {
            total = 0;
            foreach (productocarro p in ListaProductos)
            {
                total = total + (p.cantidad * (float)p.producto.Precio * (1 - ((float)p.producto.Descuento/100)));
            }
            return total;
        }

        public void vaciarcarro()
        {
            ListaProductos.Clear();
            return;
        }
    }
}
