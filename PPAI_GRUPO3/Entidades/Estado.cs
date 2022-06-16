using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class Estado
    {
        private string nombre;
        private string descripcion;
        private string ambito;
        private bool esReservablee;
        private bool esCancelable;

        public Estado(string Nombre, string Descripcion, string Ambito, bool EsReservable, bool EsCancelable)
        {
            this.nombre = Nombre;
            this.descripcion = Descripcion;
            this.ambito = Ambito;
            this.esReservablee = EsReservable;
            this.esCancelable = EsCancelable;
        }

        public string mostrarNombre()
        {
            return nombre;
        }
        public string getNombre()
        {
            return nombre;
        }
        public bool esReservable()
        {
            return esReservablee;
        }

        public bool esAmbitoTurno()
        {
            if (ambito.Equals("Turno"))
            {
                return true;
            }
            return false;
        }

        public bool esReservado()
        {
            if (nombre.Equals("Reservado"))
            {
                return true;
            }
            return false;
        }
    }
}
