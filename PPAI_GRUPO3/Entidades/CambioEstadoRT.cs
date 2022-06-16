using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    internal class CambioEstadoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime fechaHoraHasta;
        private Estado estado;

        public CambioEstadoRT(DateTime desde, DateTime hasta, Estado est)
        {
            fechaHoraDesde = desde;
            fechaHoraHasta = hasta;
            estado = est;
        }
        public CambioEstadoRT(DateTime desde, Estado est)
        {
            fechaHoraDesde = desde;
            estado = est;
        }

        public bool esActual()
        {
            if (fechaHoraHasta == null)
            {
                return true;
            }
            return false;
        }

        public bool esReservable()
        {
            return estado.esReservable();
        }

        public string getEstado()
        {
            return estado.mostrarNombre();
        }
    }
}
