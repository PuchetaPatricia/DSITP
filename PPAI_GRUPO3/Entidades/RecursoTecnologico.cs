using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    internal class RecursoTecnologico
    {
        private int numero;
        private DateTime fecha;
        private object imagenes;
        private DateTime periodicidadMantenimiento;
        private int duracionMantenimiento;
        private int fraccionHorarioTurnos;
        //atributos por puntero
        private TipoRecurso tipoRecurso;
        //Todos sus cambio de estado
        private List<CambioEstadoRT> cambiosEstados;
        //Guardamos el cambio de estado actual cuando lo encontremos
        private CambioEstadoRT cambioEstadoActual;

        private Modelo modelo;
        private CentroInvestigacion centro;
        private List<Turno> turnos;
        private DataTable dtDatos = new DataTable("datosTurnos");
        private Turno turnoSeleccionado;



        public RecursoTecnologico(int num, DateTime fecha, DateTime periodicidad, int duracionM, int fraccionHoraria, TipoRecurso recurso, List<CambioEstadoRT> cambiosEstados, Modelo m, CentroInvestigacion centro, List<Turno> turnos)
        {
            numero = num;
            this.fecha = fecha;
            periodicidadMantenimiento = periodicidad;
            duracionMantenimiento = duracionM;
            fraccionHorarioTurnos = fraccionHoraria;
            tipoRecurso = recurso;
            this.cambiosEstados = cambiosEstados;
            this.modelo = m;
            this.centro = centro;
            this.turnos = turnos;
            dtDatos.Columns.Add("FechaHoraInicio");
            dtDatos.Columns.Add("FechaHoraFin");
            dtDatos.Columns.Add("Est");
            dtDatos.Columns.Add("Disponibilida");
        }

        public int getNroInventario() { return numero; }

        public bool esReservable()
        {
            foreach(CambioEstadoRT ce in cambiosEstados)
            {
                if (ce.esActual())
                {
                    cambioEstadoActual = ce;
                    ce.esReservable();
                    return true;
                    break;
                }
            }
            return false;
        }

        public bool esTipoRTSeleccionado(TipoRecurso tr)
        {
            if(tipoRecurso.getNombre == tr.getNombre)
            {
                return true;
            }
            return false;
        }

        public string[] mostrarDatosRT()
        {
            int nro = getNroInventario();
            string nombreCentro = mostrarCentroDeInvestigacion();
            string modeloYMarca = mostrarMarcaYModelo();
            string estado = cambioEstadoActual.getEstado();
            string[] datos = new string[] {nro.ToString(), nombreCentro, modeloYMarca, estado};
            return datos;
        }

        public string mostrarCentroDeInvestigacion()
        {
            return centro.obtenerNombreCI();
        }

        public string mostrarMarcaYModelo()
        {
            return modelo.obtenerModeloYMarca();
        }

        public bool esCientificoDeMiCI(PersonalCientifico personal)
        {
            return centro.esCientificoActivo(personal);
        }

        public DataTable obtenerTurnos(DateTime fechaHoraActual)
        {
            foreach(Turno t in turnos)
            {
                if (t.validarFechaYHoraInicio(fechaHoraActual))
                {
                    string[] d = t.mostrarTurnos();
                    dtDatos.Rows.Add(d[0], d[1], d[2], null);  
                }
            }
            return dtDatos;
        }

        public void seleccionarTurno(string inicio, string fin, string estadoActual)
        {           
            foreach (Turno t in turnos) 
            { 
                if (t.sosElTurno(inicio, fin, estadoActual)) { turnoSeleccionado = t; } 
            }
        }
        public Turno getTurnoSeleccionado()
        {
            return turnoSeleccionado;
        }

        public AsignacionCientificoDelCI reservarTurno(DateTime fechaHoraActual, Estado estadoReservado)
        {
            turnoSeleccionado.reservar(fechaHoraActual, estadoReservado);
            AsignacionCientificoDelCI asignacion =  centro.reservarTurnoCientifico(turnoSeleccionado);
            return asignacion;
        }
    }
}
