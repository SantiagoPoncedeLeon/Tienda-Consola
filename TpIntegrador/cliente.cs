using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIntegrador
{
    class cliente
    {
        int dni;
        string nombre;
        string apellido;
        DateTime nacimiento;
        float total;

        public cliente(int dni, string nombre, string apellido, DateTime nacimiento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
        }

        public int DNI
        {
            get
            {
                return dni;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }
        }
        public DateTime Nacimiento
        {
            get
            {
                return nacimiento;
            }
        }
        public float TotalGastado
        {
            get
            {
                return total;
            }
        }

        public void ActualizarTotalGastado(float total)
        {
            this.total = this.total + total;
        }
    }
}
