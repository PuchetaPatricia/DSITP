using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class CambioEstadoTurno
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta = null;
        private Estado estado;

        public CambioEstadoTurno(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }

        public CambioEstadoTurno(DateTime fechaHoraDesde, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.estado = estado;
        }

        public bool esActual()
        {
            if (fechaHoraHasta == null)
            {
                return true;
            }
            return false;
        }

        public string mostrarNombreEstado()
        {
            return estado.getNombre();
        }

        public void setFechaHasta(DateTime fecha)
        {
            fechaHoraHasta = fecha;
        }
    }
}
