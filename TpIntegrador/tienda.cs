using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TpIntegrador
{

    class tienda
    {
        protected List<producto> ListaProductos = new List<producto>();
        protected List<promocion> ListaPromociones = new List<promocion>();
        protected List<cliente> ListaClientes = new List<cliente>();
        protected List<tarjeta> ListaTarjetas = new List<tarjeta>();
        protected List<carro> ListaCarro = new List<carro>();
        float totalvendido = 0;

        public void agregarProducto(string tipo, string marca, string talle, float precio)
        {
            ListaProductos.Add(new producto(tipo, marca, talle, precio));
            return;
        }
        public carro agregarCarro()
        {
            return new carro();
        }
        public struct InfoProducto
        {
            public string tipo { get; }
            public string marca { get; }
            public string talle { get; }
            public float precio { get; }
            public int descuento { get; }

            public InfoProducto(string ti, string m, string ta, float p, int d)
            {
                tipo = ti;
                marca = m;
                talle = ta;
                precio = p;
                descuento = d;
            }

        }

        public InfoProducto[] VerProductos()
        {
            List<InfoProducto> l = new List<InfoProducto>();
            for (int i = 0; i < ListaProductos.Count; i++)
            {
                producto p = (producto)ListaProductos[i];
                l.Add(new InfoProducto(p.Tipo, p.Marca, p.Talle, p.Precio, p.Descuento));
            }
            return l.ToArray();
        }

        public producto EncontrarProducto(int numero)
        {
            return (producto)ListaProductos[numero - 1];
        }

        public promocion agregarPromocion(producto prod, int descuento)
        {
            promocion promocion = new promocion(prod, descuento);
            ListaPromociones.Add(promocion);
            prod.AgregarPromo(promocion);
            return promocion;
        }


        public cliente agregarCliente(int dni, string nombre, string apellido, DateTime nacimiento)
        {
            cliente cliente = new cliente(dni, nombre, apellido, nacimiento);
            ListaClientes.Add(cliente);
            return cliente;
        }

        public cliente EncontrarCliente(int documento)
        {
            cliente client = null;
            foreach (cliente cli in ListaClientes)
            {
                if (cli.DNI == documento)
                {
                    client = cli;
                }
                else
                {
                    client = null;
                }
            }
            return client;
        }

        public struct InfoCliente
        {
            public string nombre { get; }
            public string apellido { get; }
            public int dni { get; }
            public DateTime nacimiento { get; }
            public float total { get; }

            public InfoCliente(string n, string a, int d, DateTime na, float t)
            {
                nombre = n;
                apellido = a;
                dni = d;
                nacimiento = na;
                total = t;
            }

        }

        public InfoCliente[] VerClientes()
        {
            List<InfoCliente> l = new List<InfoCliente>();
            foreach (cliente c in ListaClientes)
            { 
                l.Add(new InfoCliente(c.Nombre,c.Apellido, c.DNI, c.Nacimiento, c.TotalGastado));
            }
            return l.ToArray();
        }


        public tarjeta agregarTarjeta(string nombre, string banco)
        {
            tarjeta tarjeta = new tarjeta(nombre, banco);
            ListaTarjetas.Add(tarjeta);
            return tarjeta;
        }

        public void QuitarTarjeta(tarjeta tarjeta)
        {
            ListaTarjetas.Remove(tarjeta);
            return;
        }

        public struct InfoTarjeta
        {
            public string nombre { get; }
            public string banco { get; }
            public int formasdepago { get; }

            public InfoTarjeta(string n, string b, int f)
            {
                nombre = n;
                banco = b;
                formasdepago = f;
            }
        }

        public InfoTarjeta[] VerTarjetas()
        {
            List<InfoTarjeta> l = new List<InfoTarjeta>();
            foreach (tarjeta t in ListaTarjetas)
            {
                l.Add(new InfoTarjeta(t.Nombre, t.Banco, t.FormasdePago));
            }

            return l.ToArray();
        }

        public tarjeta EncontrarTarjeta(int numero)
        {
            return (tarjeta)ListaTarjetas[numero - 1];
        }

        public void ActualizarTotalGastado(float total)
        {
            totalvendido = totalvendido + total;
        }

        public float TotalVendido
        {
            get
            {
                return totalvendido;
            }
        }

    }
}
