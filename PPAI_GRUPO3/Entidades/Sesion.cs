using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    internal class Sesion
    {
        private DateTime fechaHoraInicio = DateTime.Now;
        private Usuario usuarioLogueado;

        public Sesion(Usuario usu)
        {
            usuarioLogueado = usu;
        }

        public PersonalCientifico verificarCientificoLogueado()
        {
            return usuarioLogueado.obtenerCientifico();
        }
    }
}
