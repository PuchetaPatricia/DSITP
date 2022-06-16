using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class TipoRecurso
    {
        private string nombre;
        private string descripcion;

        public TipoRecurso(string Nombre, string Descripcion)
        {
            this.nombre = Nombre;
            this.descripcion = Descripcion;
        }

        public string getNombre { get => nombre;}
        public string setNombre {set => nombre = value;}
        public string getDescripcion { get => descripcion;}
        public string setDescripcion { set => descripcion = value;}

    }
}
