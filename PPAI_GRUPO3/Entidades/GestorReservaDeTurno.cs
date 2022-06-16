using PPAI_GRUPO3.AccesoABD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class GestorReservaDeTurno
    {
        
        private List<TipoRecurso> tipoRecursos;
        private List<string> nombresTipoRecursos;
        private List<RecursoTecnologico> recursosTecnologicos;
        private List<RecursoTecnologico> recursosTecnologicosDelTR;
        private TipoRecurso tipoRecursoSeleccionado;
        private DataTable dtDatos = new DataTable("dt");
        private PersonalCientifico p4;
        private Usuario usuarioLoguedo;
        private Sesion actualSesion;
        private RecursoTecnologico recursoTecnologicoSeleccionado;
        private DateTime fechaHoraActual;
        DataTable dtTurnos = new DataTable();
        private List<Estado> estados = new List<Estado>();
        private List<Estado> estadosAmbitoTurno = new List<Estado>();
        private Estado estadoReservado;
        private InterfazEmail interfazEmail = new InterfazEmail();

        public GestorReservaDeTurno()
        {
            p4 = new PersonalCientifico(55, "Lucas", "Perez", 222, "55@gmail.com", "Lucas@gmial.com", "35233933");
            usuarioLoguedo = new Usuario("1234", "Lucas", true, p4);
            actualSesion = new Sesion(usuarioLoguedo);
            generarInstanciasObjetos();
        }

        private void generarInstanciasObjetos()
        {
            
            //aux
            dtDatos.Columns.Add("Numero");
            dtDatos.Columns.Add("NombreCI");
            dtDatos.Columns.Add("Marca y Modelo");
            dtDatos.Columns.Add("Estado");
            dtDatos.Columns.Add("Color");
            //generamos los tipo recursos
            TipoRecurso tipoRecurso1 = new TipoRecurso("Microscopio", "herramienta");
            TipoRecurso tipoRecurso2 = new TipoRecurso("Computadora", "");
            TipoRecurso tipoRecurso3 = new TipoRecurso("Balanza", "");
            tipoRecursos = new List<TipoRecurso>();
            tipoRecursos.Add(tipoRecurso1);
            tipoRecursos.Add(tipoRecurso2);
            tipoRecursos.Add(tipoRecurso3);

            //generamos los estados de los cambios de estado del recurso tecnologico y de turnos
            Estado e1 = new Estado("En Mantenimiento", "", "Recurso Tecnologico", true, false);
            Estado e2 = new Estado("Disponible", "", "Recurso Tecnologico", true, false);
            Estado e3 = new Estado("Con Inicio de Mantenimiento Correctivo", "", "Recurso Tecnologico", true, false);

            Estado e4 = new Estado("Con Reserva Pendiente Confirmacion", "", "Turno", true, false);
            Estado e5 = new Estado("Disponible", "", "Turno", true, false);
            Estado e6 = new Estado("Reservado", "", "Turno", true, false);

            estados.Add(e1);
            estados.Add(e2);
            estados.Add(e3);
            estados.Add(e4);
            estados.Add(e5);
            estados.Add(e6);

            //generamos los cambio de estado de los recursos tecnologicos
            CambioEstadoRT ce1RT1 = new CambioEstadoRT(new DateTime(2022, 3, 15, 7, 0, 0), new DateTime(2022, 3, 15, 8, 0, 0), e1);
            CambioEstadoRT ce2RT1 = new CambioEstadoRT(new DateTime(2022, 3, 15, 8, 0, 0), e1);
            List<CambioEstadoRT> cambioEstadoRT1 = new List<CambioEstadoRT>();
            cambioEstadoRT1.Add(ce1RT1);
            cambioEstadoRT1.Add(ce2RT1);

            CambioEstadoRT ce1RT2 = new CambioEstadoRT(new DateTime(2022, 3, 15, 7, 0, 0), new DateTime(2022, 3, 15, 8, 0, 0), e1);
            CambioEstadoRT ce2RT2 = new CambioEstadoRT(new DateTime(2022, 3, 15, 8, 0, 0), e2);
            List<CambioEstadoRT> cambioEstadoRT2 = new List<CambioEstadoRT>();
            cambioEstadoRT2.Add(ce1RT2);
            cambioEstadoRT2.Add(ce2RT2);

            //generamos los modelos y marcas 
            Marca marca1 = new Marca("Asus");
            Modelo m1 = new Modelo("5000", marca1);

            Marca marca2 = new Marca("Nikon");
            Modelo m2 = new Modelo("E100", marca2);

            //generamos personal cientifico
            PersonalCientifico p1 = new PersonalCientifico(75, "Luisa", "Perez", 222, "75@gmail.com","Luisa@gmial.com", "35233333");
            PersonalCientifico p2 = new PersonalCientifico(71, "Juan", "Perez", 222, "7@gmail.com", "Juan@gmial.com", "35237333");
            PersonalCientifico p3 = new PersonalCientifico(25, "Domingo", "Perez", 222, "5@gmail.com", "Domingo@gmial.com", "35238333");
            

            //generamos las asignaciones de los centros de investigacion
            AsignacionCientificoDelCI a1 = new AsignacionCientificoDelCI(new DateTime(2021, 12, 22, 0, 0, 0), p1);
            AsignacionCientificoDelCI a2 = new AsignacionCientificoDelCI(new DateTime(2020, 12, 22, 0, 0, 0), p2);
            AsignacionCientificoDelCI a3 = new AsignacionCientificoDelCI(new DateTime(2021, 2, 22, 0, 0, 0), p3);
            AsignacionCientificoDelCI a4 = new AsignacionCientificoDelCI(new DateTime(2021, 1, 22, 0, 0, 0), p4);

            List<AsignacionCientificoDelCI> ac1= new List<AsignacionCientificoDelCI>();
            ac1.Add(a1);
            ac1.Add(a2);

            List<AsignacionCientificoDelCI> ac2 = new List<AsignacionCientificoDelCI>();
            ac2.Add(a3);
            ac2.Add(a4);

            //generamos centros de investigacion

            CentroInvestigacion c1 = new CentroInvestigacion("FAMAF", ac1);
            CentroInvestigacion c2 = new CentroInvestigacion("UTN", ac2);

            //generamos los cambio de estado de turnos
            CambioEstadoTurno cet1 = new CambioEstadoTurno(new DateTime(2022, 6, 20, 7, 0, 0), e6);
            CambioEstadoTurno cet2 = new CambioEstadoTurno(new DateTime(2022, 6, 20, 8, 0, 0), e5);
            CambioEstadoTurno cet3 = new CambioEstadoTurno(new DateTime(2022, 6, 20, 7, 0, 0), e4);

            CambioEstadoTurno cet4 = new CambioEstadoTurno(new DateTime(2022, 6, 20, 7, 0, 0), e4);
            CambioEstadoTurno cet5 = new CambioEstadoTurno(new DateTime(2022, 5, 20, 8, 0, 0), new DateTime(2022, 5, 20, 9, 0, 0), e5);
            CambioEstadoTurno cet6 = new CambioEstadoTurno(new DateTime(2022, 5, 20, 7, 0, 0), new DateTime(2022, 5, 20, 8, 0, 0), e6);

            List<CambioEstadoTurno> cambioEstadoT1 = new List<CambioEstadoTurno>();
            cambioEstadoT1.Add(cet1);
            cambioEstadoT1.Add(cet5);

            List<CambioEstadoTurno> cambioEstadoT2 = new List<CambioEstadoTurno>();
            cambioEstadoT2.Add(cet2);
            cambioEstadoT2.Add(cet6);

            List<CambioEstadoTurno> cambioEstadoT3 = new List<CambioEstadoTurno>();
            cambioEstadoT3.Add(cet3);

            List<CambioEstadoTurno> cambioEstadoT4 = new List<CambioEstadoTurno>();
            cambioEstadoT4.Add(cet6);

            //generamos los turnos
            Turno turno1 = new Turno("Viernes", new DateTime(2022, 6, 20, 7, 0, 0), new DateTime(2022, 6, 20, 8, 0, 0), cambioEstadoT3);
            Turno turno2 = new Turno("Sabado", new DateTime(2022, 6, 21, 7, 0, 0), new DateTime(2022, 6, 21, 8, 0, 0), cambioEstadoT3);
            Turno turno3 = new Turno("Domingo", new DateTime(2022, 6, 22, 7, 0, 0), new DateTime(2022, 6, 22, 8, 0, 0), cambioEstadoT3);
            Turno turno4 = new Turno("Lunes", new DateTime(2022, 6, 23, 7, 0, 0), new DateTime(2022, 6, 23, 8, 0, 0), cambioEstadoT1);
            Turno turno5 = new Turno("Martes", new DateTime(2022, 6, 24, 7, 0, 0), new DateTime(2022, 6, 24, 8, 0, 0), cambioEstadoT1);
            Turno turno6 = new Turno("Miercoles", new DateTime(2022, 6, 25, 7, 0, 0), new DateTime(2022, 6, 25, 8, 0, 0), cambioEstadoT2);
            Turno turno7 = new Turno("Jueves", new DateTime(2022, 6, 26, 7, 0, 0), new DateTime(2022, 6, 26, 8, 0, 0), cambioEstadoT2);
            Turno turno8 = new Turno("Jueves", new DateTime(2022, 6, 26, 7, 0, 0), new DateTime(2022, 6, 26, 8, 0, 0), cambioEstadoT4);

            List<Turno> turnoList = new List<Turno>();
            turnoList.Add(turno1);
            turnoList.Add(turno2);
            turnoList.Add(turno3);
            turnoList.Add(turno4);
            turnoList.Add(turno5);
            turnoList.Add(turno6);
            turnoList.Add(turno7);
            List<Turno> turnoList2 = new List<Turno>();
            turnoList2.Add(turno8);
            //generamos los recursos tecnologicos
            RecursoTecnologico rt1 = new RecursoTecnologico(23, new DateTime(2021, 12, 15, 0, 0, 0), new DateTime(2022, 12, 22, 0, 0, 0), 2, 30, tipoRecurso2, cambioEstadoRT1, m1, c1,turnoList);
            RecursoTecnologico rt2 = new RecursoTecnologico(21, new DateTime(2022, 1, 23, 0, 0, 0), new DateTime(2023, 1, 22, 0, 0, 0), 1, 30, tipoRecurso1, cambioEstadoRT2, m2, c2,turnoList);
            RecursoTecnologico rt3 = new RecursoTecnologico(24, new DateTime(2022, 1, 23, 0, 0, 0), new DateTime(2023, 1, 22, 0, 0, 0), 1, 30, tipoRecurso3, cambioEstadoRT2, m2, c2, turnoList2);
            recursosTecnologicos = new List<RecursoTecnologico>();
            recursosTecnologicos.Add(rt1);
            recursosTecnologicos.Add(rt2); 
            recursosTecnologicos.Add(rt3);
        }

        public List<string> nuevaReservaTurno()
        {
            obtenerRT();
            return nombresTipoRecursos;
        }

        public void obtenerRT()
        {
            nombresTipoRecursos = new List<string>();
            foreach (TipoRecurso t in tipoRecursos)
            {
                nombresTipoRecursos.Add(t.getNombre);
            }          
        }

        public DataTable tomarSeleccionTipoRT(string nombreTR)
        {
            dtDatos.Rows.Clear();
            if (!nombreTR.Equals("Todos"))
            {
                //asigna el tipo recurso segun lo que se selecciono en la pantalla
                foreach (TipoRecurso t in tipoRecursos)
                {
                    if (t.getNombre.Equals(nombreTR))
                    {
                        tipoRecursoSeleccionado = t;
                        break;
                    }
                }
            }
            else
            {
                //implementar para todos
                tipoRecursoSeleccionado = tipoRecursos[0];
            }
            
            

            return buscarRTPorTipoRTValido();         
        }

        public DataTable buscarRTPorTipoRTValido()
        {
            recursosTecnologicosDelTR = new List<RecursoTecnologico>();
            foreach (RecursoTecnologico r in recursosTecnologicos)
            {
                if (r.esTipoRTSeleccionado(tipoRecursoSeleccionado))
                {
                    if (r.esReservable())
                    {
                        recursosTecnologicosDelTR.Add(r);
                    }
                }
            }

            foreach (RecursoTecnologico rt in recursosTecnologicosDelTR)
            {
                string[] d = rt.mostrarDatosRT();
                dtDatos.Rows.Add(d[0], d[1], d[2], d[3], null);
            }
            agruparRTporCI();
            asignarColorPorEstadoDeRT();
            return dtDatos;
        }

        public void agruparRTporCI()
        {
            DataView dtV = dtDatos.DefaultView;
            dtV.Sort = "NombreCI ASC";
            dtDatos = dtV.ToTable();
        }

        public void asignarColorPorEstadoDeRT()
        {
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (dtDatos.Rows[i][3].Equals("Disponible"))
                {
                    dtDatos.Rows[i][4] = "azul";
                }
                else if(dtDatos.Rows[i][3].Equals("En Mantenimiento"))
                {
                    dtDatos.Rows[i][4] = "verde";
                }
                else
                {
                    dtDatos.Rows[i][4] = "gris";
                }
            }
        }

        public DataTable tomarSeleccionRTAUtilizar(string numeroRTSelec, string nombreCI, string estado)
        {
            foreach (RecursoTecnologico r in recursosTecnologicosDelTR)
            {
                if(r.getNroInventario() == int.Parse(numeroRTSelec)) { recursoTecnologicoSeleccionado = r; break; }
            }
            bool resultado = verificarCIDeUsuario();
            if(resultado)
            {
                obtenerTurnosReservables();
            }
            else
            {
                //obtenerTurnosReservables(int 30);
            }
            return dtTurnos;
        }

        public bool verificarCIDeUsuario()
        {
            PersonalCientifico cientificoLog = actualSesion.verificarCientificoLogueado();
            return recursoTecnologicoSeleccionado.esCientificoDeMiCI(cientificoLog);
            
        }

        public void obtenerTurnosReservables()
        {
            fechaHoraActual = obtenerFechaYHoraActual();
            dtTurnos = recursoTecnologicoSeleccionado.obtenerTurnos(fechaHoraActual);
            dtTurnos = ordenarYAgruparTurnos(dtTurnos);
            determinarDisponibilidadTurnos();
        }

        public void determinarDisponibilidadTurnos()
        {
            for(int i = 0; i<dtTurnos.Rows.Count; i++)
            {
                if (dtTurnos.Rows[i][2].ToString().Equals("Disponible"))
                {
                    dtTurnos.Rows[i][3] = "azul";
                }
                else if (dtTurnos.Rows[i][2].ToString().Equals("Reservado"))
                {
                    dtTurnos.Rows[i][3] = "rojo";
                }
                else
                {
                    dtTurnos.Rows[i][3] = "gris";
                }
            }
        }

        public DataTable ordenarYAgruparTurnos(DataTable dt)
        {
            DataView dtV = dt.DefaultView;
            dtV.Sort = "FechaHoraInicio ASC";
            dt = dtV.ToTable();
            return dt;
        }

        //public void obtenerTurnosReservables(int numero)
        //{
        //    fechaHoraActual = obtenerFechaYHoraActual();
        //    recursoTecnologicoSeleccionado.obtenerTurnos();
        //}

        public DateTime obtenerFechaYHoraActual()
        {
            return DateTime.Now;
        }

        public string[] tomarSeleccionTurno(string inicio, string fin, string estadoActual)
        {
            recursoTecnologicoSeleccionado.seleccionarTurno(inicio, fin, estadoActual);
            string[] datosDelRecurso = recursoTecnologicoSeleccionado.mostrarDatosRT();

            return datosDelRecurso;
        }

        public void tomarConfirmacionReserva()
        {
            registrarReserva();
        }

        public void registrarReserva()
        {
            foreach(Estado e in estados)
            {
                if (e.esAmbitoTurno())
                {
                    estadosAmbitoTurno.Add(e);
                }
            }

            foreach (Estado e in estadosAmbitoTurno)
            {
                if (e.esReservado())
                {
                    estadoReservado = e;
                    break;
                }
            }
            AsignacionCientificoDelCI asignacion = recursoTecnologicoSeleccionado.reservarTurno(fechaHoraActual, estadoReservado);
            obtenerMailCientifico(asignacion);
        }

        public void obtenerMailCientifico(AsignacionCientificoDelCI asignacion)
        {
            string mail = asignacion.obtenerMail();
            generarMail(mail);
        }

        public void generarMail(string mail)
        {
            interfazEmail.enviarMail(mail);
            finCu();
        }

        public void finCu()
        {
        }
    }
}
