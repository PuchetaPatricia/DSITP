namespace PPAI_GRUPO3.solucion
{
    partial class PantallaRegistrarTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoRecurso = new System.Windows.Forms.ComboBox();
            this.chTipoRecurso = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Recurso: ";
            // 
            // cmbTipoRecurso
            // 
            this.cmbTipoRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRecurso.FormattingEnabled = true;
            this.cmbTipoRecurso.Location = new System.Drawing.Point(124, 67);
            this.cmbTipoRecurso.Name = "cmbTipoRecurso";
            this.cmbTipoRecurso.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoRecurso.TabIndex = 1;
            // 
            // chTipoRecurso
            // 
            this.chTipoRecurso.AutoSize = true;
            this.chTipoRecurso.Location = new System.Drawing.Point(271, 70);
            this.chTipoRecurso.Name = "chTipoRecurso";
            this.chTipoRecurso.Size = new System.Drawing.Size(56, 17);
            this.chTipoRecurso.TabIndex = 2;
            this.chTipoRecurso.Text = "Todos";
            this.chTipoRecurso.UseVisualStyleBackColor = true;
            this.chTipoRecurso.CheckedChanged += new System.EventHandler(this.opcionTodos);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(515, 195);
            this.dataGridView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recursos Tecnologicos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(377, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.tomarSeleccionTipoRT);
            // 
            // PantallaRegistrarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chTipoRecurso);
            this.Controls.Add(this.cmbTipoRecurso);
            this.Controls.Add(this.label1);
            this.Name = "PantallaRegistrarTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Turno Recurso Tecnologico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoRecurso;
        private System.Windows.Forms.CheckBox chTipoRecurso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
    }
}