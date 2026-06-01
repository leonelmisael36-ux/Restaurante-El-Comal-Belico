namespace Proyecto_Restaurante
{
    partial class Inventario
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
            this.txtbIdIngrediente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.txbBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbBuscar = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtgvCliente = new System.Windows.Forms.DataGridView();
            this.btnReiniciarIngrediente = new System.Windows.Forms.Button();
            this.txtbBsucarIngrediente = new System.Windows.Forms.TextBox();
            this.btnBuscarIngrediente = new System.Windows.Forms.Button();
            this.cmbBuscarIngrediente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lbl_IdInventario = new System.Windows.Forms.Label();
            this.lbl_IdIngrediente = new System.Windows.Forms.Label();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbIdIngrediente
            // 
            this.txtbIdIngrediente.BackColor = System.Drawing.Color.Chocolate;
            this.txtbIdIngrediente.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbIdIngrediente.Location = new System.Drawing.Point(51, 80);
            this.txtbIdIngrediente.Name = "txtbIdIngrediente";
            this.txtbIdIngrediente.Size = new System.Drawing.Size(192, 24);
            this.txtbIdIngrediente.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Id_ingrediente";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.Peru;
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(568, 345);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(155, 30);
            this.btnReiniciar.TabIndex = 74;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // txbBuscar
            // 
            this.txbBuscar.BackColor = System.Drawing.Color.Chocolate;
            this.txbBuscar.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBuscar.Location = new System.Drawing.Point(741, 39);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.Size = new System.Drawing.Size(192, 24);
            this.txbBuscar.TabIndex = 73;
            this.txbBuscar.TextChanged += new System.EventHandler(this.txbBuscar_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Peru;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(399, 343);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(128, 29);
            this.btnBuscar.TabIndex = 72;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbBuscar
            // 
            this.cmbBuscar.BackColor = System.Drawing.Color.Chocolate;
            this.cmbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscar.FormattingEnabled = true;
            this.cmbBuscar.Items.AddRange(new object[] {
            "ID",
            "Ingrediente",
            "Fecha",
            "Stock",
            "Stock",
            "Minimo"});
            this.cmbBuscar.Location = new System.Drawing.Point(541, 36);
            this.cmbBuscar.Name = "cmbBuscar";
            this.cmbBuscar.Size = new System.Drawing.Size(182, 26);
            this.cmbBuscar.TabIndex = 71;
            this.cmbBuscar.SelectedIndexChanged += new System.EventHandler(this.cmbBuscar_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(399, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 21);
            this.label11.TabIndex = 70;
            this.label11.Text = "Buscar Por:";
            // 
            // dtgvCliente
            // 
            this.dtgvCliente.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dtgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCliente.Location = new System.Drawing.Point(404, 78);
            this.dtgvCliente.Name = "dtgvCliente";
            this.dtgvCliente.Size = new System.Drawing.Size(690, 261);
            this.dtgvCliente.TabIndex = 69;
            this.dtgvCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCliente_CellClick);
            this.dtgvCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCliente_CellContentClick);
            // 
            // btnReiniciarIngrediente
            // 
            this.btnReiniciarIngrediente.BackColor = System.Drawing.Color.Peru;
            this.btnReiniciarIngrediente.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarIngrediente.Location = new System.Drawing.Point(580, 712);
            this.btnReiniciarIngrediente.Name = "btnReiniciarIngrediente";
            this.btnReiniciarIngrediente.Size = new System.Drawing.Size(155, 30);
            this.btnReiniciarIngrediente.TabIndex = 80;
            this.btnReiniciarIngrediente.Text = "Reiniciar";
            this.btnReiniciarIngrediente.UseVisualStyleBackColor = false;
            this.btnReiniciarIngrediente.Click += new System.EventHandler(this.btnReiniciarIngrediente_Click);
            // 
            // txtbBsucarIngrediente
            // 
            this.txtbBsucarIngrediente.BackColor = System.Drawing.Color.Chocolate;
            this.txtbBsucarIngrediente.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbBsucarIngrediente.Location = new System.Drawing.Point(741, 415);
            this.txtbBsucarIngrediente.Name = "txtbBsucarIngrediente";
            this.txtbBsucarIngrediente.Size = new System.Drawing.Size(192, 24);
            this.txtbBsucarIngrediente.TabIndex = 79;
            this.txtbBsucarIngrediente.TextChanged += new System.EventHandler(this.txtbBsucarIngrediente_TextChanged);
            // 
            // btnBuscarIngrediente
            // 
            this.btnBuscarIngrediente.BackColor = System.Drawing.Color.Peru;
            this.btnBuscarIngrediente.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarIngrediente.Location = new System.Drawing.Point(411, 710);
            this.btnBuscarIngrediente.Name = "btnBuscarIngrediente";
            this.btnBuscarIngrediente.Size = new System.Drawing.Size(128, 29);
            this.btnBuscarIngrediente.TabIndex = 78;
            this.btnBuscarIngrediente.Text = "Buscar";
            this.btnBuscarIngrediente.UseVisualStyleBackColor = false;
            this.btnBuscarIngrediente.Click += new System.EventHandler(this.btnBuscarIngrediente_Click);
            // 
            // cmbBuscarIngrediente
            // 
            this.cmbBuscarIngrediente.BackColor = System.Drawing.Color.Chocolate;
            this.cmbBuscarIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscarIngrediente.FormattingEnabled = true;
            this.cmbBuscarIngrediente.Items.AddRange(new object[] {
            "ID",
            "Nombre",
            "Unidad"});
            this.cmbBuscarIngrediente.Location = new System.Drawing.Point(541, 412);
            this.cmbBuscarIngrediente.Name = "cmbBuscarIngrediente";
            this.cmbBuscarIngrediente.Size = new System.Drawing.Size(182, 26);
            this.cmbBuscarIngrediente.TabIndex = 77;
            this.cmbBuscarIngrediente.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarIngrediente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 76;
            this.label1.Text = "Buscar Por:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(404, 445);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(690, 261);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Peru;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(51, 362);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 42);
            this.btnEliminar.TabIndex = 83;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Peru;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(51, 425);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(180, 43);
            this.btnEditar.TabIndex = 82;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Peru;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(51, 295);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(180, 42);
            this.btnAgregar.TabIndex = 81;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Peru;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(37, 606);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(163, 48);
            this.btnRegresar.TabIndex = 84;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Peru;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(37, 690);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(163, 49);
            this.btnSalir.TabIndex = 85;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // lbl_IdInventario
            // 
            this.lbl_IdInventario.AutoSize = true;
            this.lbl_IdInventario.Location = new System.Drawing.Point(301, 122);
            this.lbl_IdInventario.Name = "lbl_IdInventario";
            this.lbl_IdInventario.Size = new System.Drawing.Size(35, 13);
            this.lbl_IdInventario.TabIndex = 86;
            this.lbl_IdInventario.Text = "label3";
            this.lbl_IdInventario.Visible = false;
            // 
            // lbl_IdIngrediente
            // 
            this.lbl_IdIngrediente.AutoSize = true;
            this.lbl_IdIngrediente.Location = new System.Drawing.Point(314, 455);
            this.lbl_IdIngrediente.Name = "lbl_IdIngrediente";
            this.lbl_IdIngrediente.Size = new System.Drawing.Size(35, 13);
            this.lbl_IdIngrediente.TabIndex = 87;
            this.lbl_IdIngrediente.Text = "label4";
            this.lbl_IdIngrediente.Visible = false;
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.BackColor = System.Drawing.Color.Chocolate;
            this.txtStockMinimo.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockMinimo.Location = new System.Drawing.Point(51, 154);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(192, 24);
            this.txtStockMinimo.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 88;
            this.label3.Text = "Stock Minimo";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Modern No. 20", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.Chocolate;
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.dtpFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpFecha.Location = new System.Drawing.Point(51, 232);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 91;
            this.label4.Text = "Fecha";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Restaurante.Properties.Resources.ac4195e9_f959_4e67_a731_ef20de244345;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1155, 747);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_IdIngrediente);
            this.Controls.Add(this.lbl_IdInventario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnReiniciarIngrediente);
            this.Controls.Add(this.txtbBsucarIngrediente);
            this.Controls.Add(this.btnBuscarIngrediente);
            this.Controls.Add(this.cmbBuscarIngrediente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.txbBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbBuscar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtgvCliente);
            this.Controls.Add(this.txtbIdIngrediente);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbIdIngrediente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.TextBox txbBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbBuscar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dtgvCliente;
        private System.Windows.Forms.Button btnReiniciarIngrediente;
        private System.Windows.Forms.TextBox txtbBsucarIngrediente;
        private System.Windows.Forms.Button btnBuscarIngrediente;
        private System.Windows.Forms.ComboBox cmbBuscarIngrediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbl_IdInventario;
        private System.Windows.Forms.Label lbl_IdIngrediente;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
    }
}