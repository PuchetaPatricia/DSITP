using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class Marca
    {
        private string nombre;
        private Modelo modelos;

        public Marca(string nom)
        {
            this.nombre = nom;
        }

        public string getNombre()
        {
            return nombre;
        }
    }
}
