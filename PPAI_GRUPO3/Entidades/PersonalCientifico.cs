using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int nroDocumento;
        private string correoElectronicoInstitucional;
        private string correoElectronicoPersonal;
        private string telefonoCelular;

        public PersonalCientifico(int leg, string nom, string apellido, int nroDoc, string correoInst, string correoPersonal, string telefono)
        {
            this.legajo = leg;
            this.nombre = nom;
            this.apellido = apellido;
            this.correoElectronicoInstitucional = correoInst;
            this.correoElectronicoPersonal = correoPersonal;
            this.telefonoCelular = telefono;
            this.nroDocumento = nroDoc;

        }

        public int getNroDocumento()
        {
            return nroDocumento;
        }

        public string getMail()
        {
            return correoElectronicoPersonal;
        }
    }
}
