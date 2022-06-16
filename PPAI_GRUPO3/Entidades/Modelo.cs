using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.Entidades
{
    public class Modelo
    {
        private string nombre;
        private Marca marca;

        public Modelo(string nom, Marca m)
        {
            this.nombre = nom;
            this.marca = m;
        }

        public string obtenerModeloYMarca()
        {
            return ("Modelo: "+ nombre + ", Marca: " + marca.getNombre());
        }
    }
}
