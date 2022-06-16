using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class CentroInvestigacion
    {
        private string nombre;
        private string sigla;
        private string direccion;
        private string edificio;
        private int piso;
        private string coordenadas;
        private string telefonoContacto;
        private string correoElectronico;
        private int nroResolucionCreacion;
        private DateTime fechaResolucionCreacion;
        private string reglamento;
        private string caracteristicasGenerales;
        private DateTime fechaAlta;
        private int tiempoAntelacionReserva = 10;
        private DateTime fechaBaja;
        private string motivoBaja;
        private List<AsignacionCientificoDelCI> asignacionesCientificos;
        private AsignacionCientificoDelCI asignacionDelCientifico;

        public CentroInvestigacion(string n, List<AsignacionCientificoDelCI> asignacionesCientificos)
        {
            this.nombre = n;
            this.asignacionesCientificos = asignacionesCientificos;
        }

        public string obtenerNombreCI()
        {
            return nombre;
        }

        public bool esCientificoActivo(PersonalCientifico personal)
        {
            foreach(AsignacionCientificoDelCI asignacion in asignacionesCientificos)
            {
                if (asignacion.esCientificoActivo(personal))
                {
                    asignacionDelCientifico = asignacion;
                    return true;
                }
            }
            return false;

        }

        public AsignacionCientificoDelCI reservarTurnoCientifico(Turno turnoSeleccionado)
        {
            asignacionDelCientifico.setTurno(turnoSeleccionado);
            return asignacionDelCientifico;
        }

    }
}
