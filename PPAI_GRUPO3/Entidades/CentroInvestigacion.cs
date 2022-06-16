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
        private string tiempoAntelacionReserva;
        private DateTime fechaBaja;
        private string motivoBaja;
        private List<AsignacionCientificoDelCI> asignacionesCientificos;

        public CentroInvestigacion(string n, List<AsignacionCientificoDelCI> asignacionesCientificos)
        {
            this.nombre = n;
            this.asignacionesCientificos = asignacionesCientificos;
        }

        public string obtenerNombreCI()
        {
            return nombre;
        }

    }
}
