using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    internal class Usuario
    {
        private string clave;
        private string usuario;
        private bool habilitado;
        private PersonalCientifico personalCientifico;

        public Usuario(string clave, string usuario, bool habilitado, PersonalCientifico personal)
        {
            this.clave = clave;
            this.usuario = usuario;
            this.habilitado = habilitado;
            this.personalCientifico = personal;
        }

        public PersonalCientifico obtenerCientifico()
        {
            return personalCientifico;
        }
    }
}
