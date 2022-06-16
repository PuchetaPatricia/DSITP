namespace PPAI_GRUPO3
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReservarTurno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReservarTurno
            // 
            this.btnReservarTurno.Location = new System.Drawing.Point(248, 100);
            this.btnReservarTurno.Name = "btnReservarTurno";
            this.btnReservarTurno.Size = new System.Drawing.Size(288, 23);
            this.btnReservarTurno.TabIndex = 0;
            this.btnReservarTurno.Text = "Reservar Turno Recurso Tecnologico";
            this.btnReservarTurno.UseVisualStyleBackColor = true;
            this.btnReservarTurno.Click += new System.EventHandler(this.opcionRegistrarReservaTurno);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReservarTurno);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReservarTurno;
    }
}

