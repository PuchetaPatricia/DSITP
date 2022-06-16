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
        private DateTime fechaHasta;
        private PersonalCientifico cientifico;

        public AsignacionCientificoDelCI(DateTime fechaDesde, PersonalCientifico cientifico)
        {
            this.fechaDesde = fechaDesde;
            this.cientifico = cientifico;
        }
    }
}
