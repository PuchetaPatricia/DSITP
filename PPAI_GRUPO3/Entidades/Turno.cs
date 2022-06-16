using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class Turno
    {
        private DateTime fechaCreacion = DateTime.Now;
        private string diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private List<CambioEstadoTurno> cambioEstados = new List<CambioEstadoTurno>();
        private CambioEstadoTurno actualCambioEstado;

        public Turno(string dia, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurnos)
        {
            this.diaSemana = dia;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstados = cambioEstadoTurnos;
        }

        public bool validarFechaYHoraInicio(DateTime fechaHoraActual)
        {
            int resultado = DateTime.Compare(fechaHoraInicio, fechaHoraActual);
            if (resultado > 0)
            {
                return true;
            }
            return false;
        }

        public string[] mostrarTurnos()
        {
            string nombreEstado="";
            DateTime fhi = getFechaHoraInicio();
            DateTime fhf = getFechaHoraFin();
            //string[] datosTurno = new string[] {};
            foreach(CambioEstadoTurno ce in cambioEstados)
            {
                if (ce.esActual())
                {
                    actualCambioEstado = ce;
                    nombreEstado = actualCambioEstado.mostrarNombreEstado();
                    break;
                }
            }
            string[] datosTurno = new string[] {fhi.ToString(), fhf.ToString(), nombreEstado};
            return datosTurno;
        }

        public DateTime getFechaHoraInicio() { return fechaHoraInicio; }
        public DateTime getFechaHoraFin() { return fechaHoraFin; }

        public bool sosElTurno(string inicio, string fin, string estadoActual)
        {
            string nombreEstado = actualCambioEstado.mostrarNombreEstado();
            if(fechaHoraInicio.ToString().Equals(inicio) && fechaHoraFin.ToString().Equals(fin) && nombreEstado.Equals(estadoActual))
            {
                return true;
            }
            return false;
        }

        public void reservar(DateTime fechaHoraActual, Estado estadoReservado)
        {
            actualCambioEstado.setFechaHasta(fechaHoraActual);
            CambioEstadoTurno nuevoCET = new CambioEstadoTurno(fechaHoraActual, estadoReservado);
        }
    }
}
