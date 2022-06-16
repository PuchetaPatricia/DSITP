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
        private List<object> datosRT = new List<object>(); 
        private DataTable dtDatos = new DataTable("dtDatos");

        public GestorReservaDeTurno()
        {
            generarInstanciasObjetos();
        }

        private void generarInstanciasObjetos()
        {
            //aux
            dtDatos.Columns.Add("Numero");
            dtDatos.Columns.Add("NombreCI");
            dtDatos.Columns.Add("Marca y Modelo");
            dtDatos.Columns.Add("Estado");
            //generamos los tipo recursos
            TipoRecurso tipoRecurso1 = new TipoRecurso("Microscopio", "herramienta");
            TipoRecurso tipoRecurso2 = new TipoRecurso("Computadora", "");
            tipoRecursos = new List<TipoRecurso>();
            tipoRecursos.Add(tipoRecurso1);
            tipoRecursos.Add(tipoRecurso2);

            //generamos los estados de los cambios de estado del recurso tecnologico
            Estado e1 = new Estado("En Mantenimiento", "", "Recurso Tecnologico", false, false);
            Estado e2 = new Estado("Disponible", "", "Recurso Tecnologico", true, false);
            Estado e3 = new Estado("Con Inicio de Mantenimiento Correctivo", "", "Recurso Tecnologico", true, false);

            //generamos los cambio de estado de los recursos tecnologicos
            CambioEstadoRT ce1RT1 = new CambioEstadoRT(new DateTime(2022, 3, 15, 7, 0, 0), new DateTime(2022, 3, 15, 8, 0, 0), e1);
            CambioEstadoRT ce2RT1 = new CambioEstadoRT(new DateTime(2022, 3, 15, 8, 0, 0), e1);
            List<CambioEstadoRT> cambioEstadoRT1 = new List<CambioEstadoRT>();
            cambioEstadoRT1.Add(ce1RT1);
            cambioEstadoRT1.Add(ce2RT1);

            CambioEstadoRT ce1RT2 = new CambioEstadoRT(new DateTime(2022, 3, 15, 7, 0, 0), new DateTime(2022, 3, 15, 8, 0, 0), e1);
            CambioEstadoRT ce2RT2 = new CambioEstadoRT(new DateTime(2022, 3, 15, 8, 0, 0), e2);
            List<CambioEstadoRT> cambioEstadoRT2 = new List<CambioEstadoRT>();
            cambioEstadoRT1.Add(ce1RT2);
            cambioEstadoRT1.Add(ce2RT2);

            //generamos los modelos y marcas 
            Marca marca1 = new Marca("Asus");
            Modelo m1 = new Modelo("5000", marca1);

            Marca marca2 = new Marca("Nikon");
            Modelo m2 = new Modelo("E100", marca2);

            //generamos personal cientifico
            PersonalCientifico p1 = new PersonalCientifico(75, "Luisa", "Perez", 222, "75@gmail.com","Luisa@gmial.com", "35233333");
            PersonalCientifico p2 = new PersonalCientifico(71, "Juan", "Perez", 222, "7@gmail.com", "Juan@gmial.com", "35237333");
            PersonalCientifico p3 = new PersonalCientifico(25, "Domingo", "Perez", 222, "5@gmail.com", "Domingo@gmial.com", "35238333");
            PersonalCientifico p4 = new PersonalCientifico(55, "Lucas", "Perez", 222, "55@gmail.com", "Lucas@gmial.com", "35233933");

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

            //generamos los recursos tecnologicos
            RecursoTecnologico rt1 = new RecursoTecnologico(23, new DateTime(2021, 12, 15, 0, 0, 0), new DateTime(2022, 12, 22, 0, 0, 0), 2, 30, tipoRecurso2, cambioEstadoRT1, m1, c1);
            RecursoTecnologico rt2 = new RecursoTecnologico(21, new DateTime(2022, 1, 23, 0, 0, 0), new DateTime(2023, 1, 22, 0, 0, 0), 1, 30, tipoRecurso1, cambioEstadoRT2, m2, c2);
            
            recursosTecnologicos = new List<RecursoTecnologico>();
            recursosTecnologicos.Add(rt1);
            recursosTecnologicos.Add(rt2); 
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

        public void tomarSeleccionTipoRT(string nombreTR)
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

            buscarRTPorTipoRTValido();         
        }

        public void buscarRTPorTipoRTValido()
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
                datosRT.Add(rt.mostrarDatosRT());
                dtDatos.Rows.Add(d[0], d[1], d[2], d[3]);
                //dtDatos.Rows[i][0] = d[0];
                //dtDatos.Rows[i][1] = d[1];
                //dtDatos.Rows[i][2] = d[2];
                //dtDatos.Rows[i][3] = d[3];
            }
           
            
        }

        public void agruparRTporCI()
        {
            DataView dtV = dtDatos.DefaultView;
            dtV.Sort = "NombreCI ASC";
            dtDatos = dtV.ToTable();
        }

    }
}
