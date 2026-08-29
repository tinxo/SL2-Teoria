namespace Proyecto1
{
    partial class FrmDiscos
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
            btnGuardar = new Button();
            cbxTipoDisco = new ComboBox();
            nupAnioPublicacion = new NumericUpDown();
            txtNombreDisco = new TextBox();
            txtNombreArtista = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label9 = new Label();
            nupCantidadCanciones = new NumericUpDown();
            label1 = new Label();
            nupDuracionTotal = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nupAnioPublicacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupCantidadCanciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupDuracionTotal).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(421, 368);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(169, 35);
            btnGuardar.TabIndex = 42;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cbxTipoDisco
            // 
            cbxTipoDisco.FormattingEnabled = true;
            cbxTipoDisco.Items.AddRange(new object[] { "En vivo", "Estudio", "Antología", "Otros" });
            cbxTipoDisco.Location = new Point(254, 316);
            cbxTipoDisco.Name = "cbxTipoDisco";
            cbxTipoDisco.Size = new Size(336, 33);
            cbxTipoDisco.TabIndex = 40;
            // 
            // nupAnioPublicacion
            // 
            nupAnioPublicacion.Location = new Point(254, 195);
            nupAnioPublicacion.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
            nupAnioPublicacion.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            nupAnioPublicacion.Name = "nupAnioPublicacion";
            nupAnioPublicacion.Size = new Size(138, 31);
            nupAnioPublicacion.TabIndex = 39;
            nupAnioPublicacion.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // txtNombreDisco
            // 
            txtNombreDisco.Location = new Point(254, 149);
            txtNombreDisco.Name = "txtNombreDisco";
            txtNombreDisco.Size = new Size(336, 31);
            txtNombreDisco.TabIndex = 38;
            // 
            // txtNombreArtista
            // 
            txtNombreArtista.Enabled = false;
            txtNombreArtista.Location = new Point(254, 104);
            txtNombreArtista.Name = "txtNombreArtista";
            txtNombreArtista.Size = new Size(336, 31);
            txtNombreArtista.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 319);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 35;
            label6.Text = "Tipo de disco:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 197);
            label5.Name = "label5";
            label5.Size = new Size(169, 25);
            label5.TabIndex = 34;
            label5.Text = "Año de publicación:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 152);
            label4.Name = "label4";
            label4.Size = new Size(82, 25);
            label4.TabIndex = 33;
            label4.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 107);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 32;
            label3.Text = "Autor (artista):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 54);
            label2.Name = "label2";
            label2.Size = new Size(219, 25);
            label2.TabIndex = 31;
            label2.Text = "Carga de datos de Discos:";
            label2.Click += label2_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 17);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(136, 28);
            label9.TabIndex = 30;
            label9.Text = "Escuchify 1.1";
            // 
            // nupCantidadCanciones
            // 
            nupCantidadCanciones.Location = new Point(254, 235);
            nupCantidadCanciones.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nupCantidadCanciones.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nupCantidadCanciones.Name = "nupCantidadCanciones";
            nupCantidadCanciones.Size = new Size(138, 31);
            nupCantidadCanciones.TabIndex = 46;
            nupCantidadCanciones.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 237);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 45;
            label1.Text = "Cantidad canciones:";
            // 
            // nupDuracionTotal
            // 
            nupDuracionTotal.Location = new Point(254, 279);
            nupDuracionTotal.Maximum = new decimal(new int[] { 5400, 0, 0, 0 });
            nupDuracionTotal.Minimum = new decimal(new int[] { 600, 0, 0, 0 });
            nupDuracionTotal.Name = "nupDuracionTotal";
            nupDuracionTotal.Size = new Size(138, 31);
            nupDuracionTotal.TabIndex = 48;
            nupDuracionTotal.Value = new decimal(new int[] { 1500, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(70, 281);
            label7.Name = "label7";
            label7.Size = new Size(128, 25);
            label7.TabIndex = 47;
            label7.Text = "Duración total:";
            // 
            // FrmDiscos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 424);
            Controls.Add(nupDuracionTotal);
            Controls.Add(label7);
            Controls.Add(nupCantidadCanciones);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(cbxTipoDisco);
            Controls.Add(nupAnioPublicacion);
            Controls.Add(txtNombreDisco);
            Controls.Add(txtNombreArtista);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label9);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmDiscos";
            Text = "FrmDiscos";
            ((System.ComponentModel.ISupportInitialize)nupAnioPublicacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupCantidadCanciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupDuracionTotal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGuardar;
        private ComboBox cbxTipoDisco;
        private NumericUpDown nupAnioPublicacion;
        private TextBox txtNombreDisco;
        private TextBox txtNombreArtista;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
        private NumericUpDown nupCantidadCanciones;
        private Label label1;
        private NumericUpDown nupDuracionTotal;
        private Label label7;
    }
}