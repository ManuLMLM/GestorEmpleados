namespace GestorEmpleados.PL
{
    partial class Departamentos
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.TablaContenido = new System.Windows.Forms.DataGridView();
            this.cmId = new System.Windows.Forms.ComboBox();
            this.bEditar = new System.Windows.Forms.PictureBox();
            this.bGuardar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bEliminar = new System.Windows.Forms.PictureBox();
            this.bCancelar = new System.Windows.Forms.PictureBox();
            this.bRegresar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TablaContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bRegresar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre:";
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNombre.Location = new System.Drawing.Point(176, 38);
            this.tbNombre.MaxLength = 50;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(273, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // TablaContenido
            // 
            this.TablaContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablaContenido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablaContenido.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablaContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaContenido.Location = new System.Drawing.Point(12, 121);
            this.TablaContenido.MultiSelect = false;
            this.TablaContenido.Name = "TablaContenido";
            this.TablaContenido.ReadOnly = true;
            this.TablaContenido.Size = new System.Drawing.Size(459, 167);
            this.TablaContenido.TabIndex = 9;
            this.TablaContenido.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TablaContenido_CellMouseClick);
            // 
            // cmId
            // 
            this.cmId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmId.FormattingEnabled = true;
            this.cmId.Location = new System.Drawing.Point(32, 38);
            this.cmId.Name = "cmId";
            this.cmId.Size = new System.Drawing.Size(99, 21);
            this.cmId.TabIndex = 11;
            this.cmId.SelectedIndexChanged += new System.EventHandler(this.cmId_SelectedIndexChanged);
            // 
            // bEditar
            // 
            this.bEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEditar.Image = global::GestorEmpleados.Properties.Resources.BotonEditar;
            this.bEditar.Location = new System.Drawing.Point(236, 80);
            this.bEditar.Name = "bEditar";
            this.bEditar.Size = new System.Drawing.Size(35, 35);
            this.bEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bEditar.TabIndex = 13;
            this.bEditar.TabStop = false;
            this.bEditar.Click += new System.EventHandler(this.bEditar_Click_1);
            // 
            // bGuardar
            // 
            this.bGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bGuardar.Image = global::GestorEmpleados.Properties.Resources.BotonGuardar;
            this.bGuardar.Location = new System.Drawing.Point(176, 80);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(35, 35);
            this.bGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bGuardar.TabIndex = 12;
            this.bGuardar.TabStop = false;
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GestorEmpleados.Properties.Resources.Trabajos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bEliminar
            // 
            this.bEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEliminar.Image = global::GestorEmpleados.Properties.Resources.BotonBorrar;
            this.bEliminar.Location = new System.Drawing.Point(296, 80);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(35, 35);
            this.bEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bEliminar.TabIndex = 14;
            this.bEliminar.TabStop = false;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click_1);
            // 
            // bCancelar
            // 
            this.bCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelar.Image = global::GestorEmpleados.Properties.Resources.BotonCancel;
            this.bCancelar.Location = new System.Drawing.Point(356, 80);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(35, 35);
            this.bCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bCancelar.TabIndex = 15;
            this.bCancelar.TabStop = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click_1);
            // 
            // bRegresar
            // 
            this.bRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRegresar.Image = global::GestorEmpleados.Properties.Resources.BotonHome;
            this.bRegresar.Location = new System.Drawing.Point(448, 294);
            this.bRegresar.Name = "bRegresar";
            this.bRegresar.Size = new System.Drawing.Size(35, 35);
            this.bRegresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bRegresar.TabIndex = 16;
            this.bRegresar.TabStop = false;
            this.bRegresar.Click += new System.EventHandler(this.bRegresar_Click_1);
            // 
            // Departamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 330);
            this.ControlBox = false;
            this.Controls.Add(this.bRegresar);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bEditar);
            this.Controls.Add(this.bGuardar);
            this.Controls.Add(this.cmId);
            this.Controls.Add(this.TablaContenido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Departamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departamentos";
            this.Load += new System.EventHandler(this.Departamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bRegresar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.DataGridView TablaContenido;
        private System.Windows.Forms.ComboBox cmId;
        private System.Windows.Forms.PictureBox bGuardar;
        private System.Windows.Forms.PictureBox bEditar;
        private System.Windows.Forms.PictureBox bEliminar;
        private System.Windows.Forms.PictureBox bCancelar;
        private System.Windows.Forms.PictureBox bRegresar;
    }
}