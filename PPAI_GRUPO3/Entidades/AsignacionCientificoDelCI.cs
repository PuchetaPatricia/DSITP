using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class AsignacionCientificoDelCI
    {
        private DateTime fechaDesde;
        private DateTime? fechaHasta = null;
        private PersonalCientifico cientifico;
        List<Turno> turnosAsignados = new List<Turno>();

        public AsignacionCientificoDelCI(DateTime fechaDesde, PersonalCientifico cientifico)
        {
            this.fechaDesde = fechaDesde;
            this.cientifico = cientifico;
        }

        public bool esCientificoActivo(PersonalCientifico personal)
        {
            if(cientifico.getNroDocumento() == personal.getNroDocumento())
            {
                if(fechaHasta == null)
                {
                    return true;
                }
            }
            return false;
        }

        public void setTurno(Turno turnoSeleccionado)
        {
            turnosAsignados.Add(turnoSeleccionado);
        }

        public string obtenerMail()
        {
            return cientifico.getMail();
        }
    }
}
