using PPAI_GRUPO3.solucion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_GRUPO3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void opcionRegistrarReservaTurno(object sender, EventArgs e)
        {
            PantallaRegistrarTurno ventana = new PantallaRegistrarTurno();
            ventana.ShowDialog();
        }
    }
}
