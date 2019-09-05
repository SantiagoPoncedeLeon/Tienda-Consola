using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class tarjeta
    {
        string nombre;
        string banco;
        float total= 0;
        List<FormadePago> ListaFormasdePago = new List<FormadePago>();

        struct FormadePago
        {
            //public int num { get; }
            public int numcuotas { get; }
            public int interes { get; }
            public bool beneficio { get; }

             public FormadePago ( int n, int i, bool b)
            {
                numcuotas = n;
                interes = i;
                beneficio = b;
            }
        }

        public tarjeta(string nombre, string banco)
        {
            this.nombre = nombre;
            this.banco = banco;
        }

        public void AgregarFormaPago(int numcuotas, int interes)
        {
            this.ListaFormasdePago.Add(new FormadePago(numcuotas,interes, false));
        }

        //PROPIEDADES
        public string Nombre
        {
            get
            {
                return nombre;
            }
        }
        public string Banco
        {
            get
            {
                return banco;
            }
        }
        public int FormasdePago
        {
            get
            {
                return ListaFormasdePago.Count;
            }
        }
        public float Total
        {
            get
            {
                return total;
            }
        }

        //Lista de Formas de Pago

        public struct InfoFormadePago
        {
            public int numcuotas { get; }
            public int interes { get; }
            public bool beneficio { get; }

            public InfoFormadePago( int n, int i, bool b)
            {
                numcuotas = n;
                interes = i;
                beneficio = b;
            }
        }

        public InfoFormadePago[] VerFormasdePago()
        {
            List<InfoFormadePago> l = new List<InfoFormadePago>();
            foreach (FormadePago f in this.ListaFormasdePago)
            {
                l.Add(new InfoFormadePago( f.numcuotas, f.interes, f.beneficio));
            }

            return l.ToArray();
        }

        public void AgregarBeneficio(int numCuotas, int Beneficio)
        {
            for (int i = 0; i < ListaFormasdePago.Count; i++)
            {
                if (((FormadePago)ListaFormasdePago[i]).numcuotas == numCuotas)
                {
                    ListaFormasdePago.RemoveAt(i);
                    this.ListaFormasdePago.Insert(i,new FormadePago(numCuotas, Beneficio, true));
                    break;
                }
            }
            return;
        }

        public int EncontrarFormadePago(int numCuotas)
        {
            for (int i = 0; i < ListaFormasdePago.Count; i++)
            {
                if (((FormadePago)ListaFormasdePago[i]).numcuotas == numCuotas)
                {
                    return ((FormadePago)ListaFormasdePago[i]).interes;
                }
            }
            return -1;
        }

        public void ActualizarTotalGastado(float total)
        {
            this.total = this.total + total;
        }
    }
}
