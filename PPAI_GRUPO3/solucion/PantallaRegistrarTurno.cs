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
        private List<Button> buttons;
        private int[] meses = new int[] {1,2,3,4,5,6,7,8,9,10,11,12};
        private int[] años = new int[] { 2022, 2023 };
        private string[] notificaciones = new string[] { "Mail", "Whatsapp" , "Mail y Whatsapp" };
        private DataTable dtTurnos;
        public PantallaRegistrarTurno()
        {
            InitializeComponent();
            buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31};
            cargarComboMeses();
            cargarComboAños();
            cargarComboNotificacion();
            opcionRegistrarReservaTurno();
        }

        public void cargarComboMeses()
        {
            cmbMes.DataSource = meses;
        }

        public void cargarComboAños()
        {
            cmbAño.DataSource = años;
        }

        public void cargarComboNotificacion()
        {
            cmbNotificacion.DataSource = notificaciones;
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

            DataTable dt = new DataTable();
            if (chTipoRecurso.Checked)
            {
                dt = gestorReservaDeTurno.tomarSeleccionTipoRT("Todos");
            }
            else
            {
                dt = gestorReservaDeTurno.tomarSeleccionTipoRT(cmbTipoRecurso.SelectedItem.ToString());
            }
            
            mostrarYSolicitarSeleccionRTAUtilizar(dt);
        }

        public void mostrarYSolicitarSeleccionRTAUtilizar(DataTable dtDatos)
        {
            grillaRT.DataSource = dtDatos;

        }

        private void cancelar(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grillaRT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grillaRT.Columns[e.ColumnIndex].Name == "Color")  //Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("azul"))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Blue;
                    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                }
                else if (e.Value.ToString().Contains("verde"))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Green;
                    e.CellStyle.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Gray;
                    e.CellStyle.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void grillaRT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DataGridViewRow filaSeleccionada = grillaRT.Rows[indice];
            txtNumeroRT.Text = filaSeleccionada.Cells["Numero"].Value.ToString();
            txtCI.Text = filaSeleccionada.Cells["NombreCI"].Value.ToString();
            txtEstado.Text = filaSeleccionada.Cells["Estado"].Value.ToString();
            lblModeloYMarca.Text = filaSeleccionada.Cells["ModeloYMarca"].Value.ToString();


        }

        private void tomarSeleccionRTAUtilizar(object sender, EventArgs e)
        {
            dtTurnos = gestorReservaDeTurno.tomarSeleccionRTAUtilizar(txtNumeroRT.Text, txtCI.Text, txtEstado.Text);
            mostrarYSolicitarSeleccionTurnos();
        }

        public void mostrarYSolicitarSeleccionTurnos()
        {
            MessageBox.Show("Seleccione mes y año para verificar disponibilidad");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            foreach (Button b in buttons) { b.BackColor = DefaultBackColor; };
            if (cmbAño.SelectedIndex == -1 || cmbMes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccionar año y mes para ver disponibilidad de fechas");
            }
            else
            {
                int contador = 0;
                foreach(Button b in buttons)
                {
                    for(int i = 0; i<dtTurnos.Rows.Count; i++)
                    {
                        DateTime fecha = DateTime.Parse(dtTurnos.Rows[i][0].ToString());
                        string dia = fecha.Day.ToString();
                        string mes = fecha.Month.ToString();
                        string año = fecha.Year.ToString();
                        if (b.Text.Equals(dia) && mes.Equals(cmbMes.SelectedValue.ToString()) && año.Equals(cmbAño.SelectedValue.ToString())) { contador++; };
                    }
                    if(contador == 0)
                    {
                        b.BackColor = System.Drawing.Color.Red;
                        b.Enabled = false;
                    }
                    else
                    {
                        b.Enabled = true;
                        b.BackColor = System.Drawing.Color.Blue;
                    }
                    contador = 0;
                }
                

            }
        }

        private void seleccionDia(object sender, EventArgs e)
        {
            grillaTurnos.Rows.Clear();
            Button boton = sender as Button;
            string año = cmbAño.SelectedValue.ToString();
            string mes = cmbMes.SelectedValue.ToString();
            string dia = boton.Text;
            txtDia.Text = boton.Text + "/" + mes + "/" + año;

            for (int i = 0; i < dtTurnos.Rows.Count; i++)
            {
                DateTime fecha = DateTime.Parse(dtTurnos.Rows[i][0].ToString());
                string d = fecha.Day.ToString();
                string m = fecha.Month.ToString();
                string a = fecha.Year.ToString();
                if (dia.Equals(d) && mes.Equals(m) && año.Equals(a))
                {
                    grillaTurnos.Rows.Add(dtTurnos.Rows[i][0], dtTurnos.Rows[i][1], dtTurnos.Rows[i][2], dtTurnos.Rows[i][3]);
                }
            }
        }

        private void grillaTurnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grillaTurnos.Columns[e.ColumnIndex].Name == "Disponibilidad")  //Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("azul"))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Blue;
                    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                }
                else if (e.Value.ToString().Contains("rojo"))
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Gray;
                    e.CellStyle.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        private void grillaTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            DataGridViewRow filaSeleccionada = grillaTurnos.Rows[indice];
            txtFechaInicio.Text = filaSeleccionada.Cells["FechaHoraInicio"].Value.ToString();
            txtFechaFin.Text = filaSeleccionada.Cells["FechaHoraFin"].Value.ToString();
            txtEstadoTurno.Text = filaSeleccionada.Cells["Est"].Value.ToString();
            txtFechaFin.Visible = false;
            txtFechaInicio.Visible = false;
            txtEstadoTurno.Visible = false;
        }

        private void tomarSeleccionTurno(object sender, EventArgs e)
        {
            if (txtEstadoTurno.Equals("Discponible"))
            {
                string[] recurso = gestorReservaDeTurno.tomarSeleccionTurno(txtFechaInicio.Text, txtFechaFin.Text, txtEstadoTurno.Text);
                txtFechaFin.Visible = true;
                txtFechaInicio.Visible = true;
                txtEstadoTurno.Visible = true;
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                String mensajeCarga = ("|Numero Recurso Tecnologico: " + recurso[0] + "\n|Centro de investigacion: " + recurso[1] + "\n|" + recurso[2] + "\n|Estado Recurso Tecnologico: " + recurso[3] + "\nTURNO:\n|Fecha Hora Inicio: " + txtFechaInicio.Text + "\n|Fecha Hora fin: " + txtFechaInicio.Text + "\n|Estado Turno: " + txtEstadoTurno.Text);

                string titulo = "Información del Turno";

                DialogResult result = MessageBox.Show(mensajeCarga, titulo, buttons);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un turno disponible");
            }
        }

        private void tomarConfirmacionReserva(object sender, EventArgs e)
        {
            gestorReservaDeTurno.tomarConfirmacionReserva();
            MessageBox.Show("Turno reservado.");
            this.Hide();
        }


    }
}
