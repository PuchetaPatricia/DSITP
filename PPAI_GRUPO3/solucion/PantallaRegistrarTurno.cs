using PPAI_GRUPO3.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_GRUPO3.solucion
{
    public partial class PantallaRegistrarTurno : Form
    {
        private GestorReservaDeTurno gestorReservaDeTurno = new GestorReservaDeTurno();
        public PantallaRegistrarTurno()
        {
            InitializeComponent();
            opcionRegistrarReservaTurno();
        }

        public void opcionRegistrarReservaTurno()
        {
            habilitarPantalla();
        }

        public void habilitarPantalla()
        {
            List<string> nombresTipoRecursos = gestorReservaDeTurno.nuevaReservaTurno();
            mostrarYSolicitarTipoRT(nombresTipoRecursos);
        }

        public void mostrarYSolicitarTipoRT(List<string> nombresTipoRecursos)
        {
            cmbTipoRecurso.DataSource = nombresTipoRecursos;
        }

        private void opcionTodos(object sender, EventArgs e)
        {
            if (chTipoRecurso.Checked)
            {
                cmbTipoRecurso.SelectedIndex = -1;
                cmbTipoRecurso.Enabled = false;
            }
            else
            {
                cmbTipoRecurso.Enabled = true;
            }
        }

        private void tomarSeleccionTipoRT(object sender, EventArgs e)
        {
            gestorReservaDeTurno.tomarSeleccionTipoRT(cmbTipoRecurso.SelectedItem.ToString());
        }
    }
}
