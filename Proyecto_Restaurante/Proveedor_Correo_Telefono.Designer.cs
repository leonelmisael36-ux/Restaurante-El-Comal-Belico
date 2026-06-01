namespace Proyecto_Restaurante
{
    partial class Proveedor_Correo_Telefono
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
            this.mtbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtbCorreo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdProveedor_Telefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReiniciarCorreo = new System.Windows.Forms.Button();
            this.btnReiniciarTelefono = new System.Windows.Forms.Button();
            this.txbBuscarCorreo = new System.Windows.Forms.TextBox();
            this.btnBuscarCorreo = new System.Windows.Forms.Button();
            this.cmbBuscarCorreo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtgvCorreo = new System.Windows.Forms.DataGridView();
            this.txbBuscarTelefono = new System.Windows.Forms.TextBox();
            this.btnBuscarTelefono = new System.Windows.Forms.Button();
            this.cmbBuscarTelefono = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgvTelefono = new System.Windows.Forms.DataGridView();
            this.lbl_IdTelefono = new System.Windows.Forms.Label();
            this.lbl_IdCorreo = new System.Windows.Forms.Label();
            this.btnEliminar_Telefono = new System.Windows.Forms.Button();
            this.btnEditar_Telefono = new System.Windows.Forms.Button();
            this.btnAgregar_Telefono = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtIdProveedor_Correo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar_Correo = new System.Windows.Forms.Button();
            this.btnEditar_Correo = new System.Windows.Forms.Button();
            this.btnAgregar_Correo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTelefono)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbTelefono
            // 
            this.mtbTelefono.BackColor = System.Drawing.Color.Chocolate;
            this.mtbTelefono.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTelefono.Location = new System.Drawing.Point(40, 153);
            this.mtbTelefono.Mask = "000-000-0000";
            this.mtbTelefono.Name = "mtbTelefono";
            this.mtbTelefono.Size = new System.Drawing.Size(192, 24);
            this.mtbTelefono.TabIndex = 86;
            this.mtbTelefono.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbTelefono_MaskInputRejected);
            // 
            // txtbCorreo
            // 
            this.txtbCorreo.BackColor = System.Drawing.Color.Chocolate;
            this.txtbCorreo.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCorreo.Location = new System.Drawing.Point(40, 450);
            this.txtbCorreo.Name = "txtbCorreo";
            this.txtbCorreo.Size = new System.Drawing.Size(192, 24);
            this.txtbCorreo.TabIndex = 85;
            this.txtbCorreo.TextChanged += new System.EventHandler(this.txtbCorreo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 21);
            this.label9.TabIndex = 84;
            this.label9.Text = "Correo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label10.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 21);
            this.label10.TabIndex = 83;
            this.label10.Text = "Telefono";
            // 
            // txtIdProveedor_Telefono
            // 
            this.txtIdProveedor_Telefono.BackColor = System.Drawing.Color.Chocolate;
            this.txtIdProveedor_Telefono.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProveedor_Telefono.Location = new System.Drawing.Point(40, 71);
            this.txtIdProveedor_Telefono.Name = "txtIdProveedor_Telefono";
            this.txtIdProveedor_Telefono.Size = new System.Drawing.Size(192, 24);
            this.txtIdProveedor_Telefono.TabIndex = 88;
            this.txtIdProveedor_Telefono.TextChanged += new System.EventHandler(this.txtIdProveedor_Telefono_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 87;
            this.label1.Text = "Id_Proveedor";
            // 
            // btnReiniciarCorreo
            // 
            this.btnReiniciarCorreo.BackColor = System.Drawing.Color.Peru;
            this.btnReiniciarCorreo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarCorreo.Location = new System.Drawing.Point(1104, 345);
            this.btnReiniciarCorreo.Name = "btnReiniciarCorreo";
            this.btnReiniciarCorreo.Size = new System.Drawing.Size(155, 30);
            this.btnReiniciarCorreo.TabIndex = 116;
            this.btnReiniciarCorreo.Text = "Reiniciar";
            this.btnReiniciarCorreo.UseVisualStyleBackColor = false;
            this.btnReiniciarCorreo.Click += new System.EventHandler(this.btnReiniciarCorreo_Click);
            // 
            // btnReiniciarTelefono
            // 
            this.btnReiniciarTelefono.BackColor = System.Drawing.Color.Peru;
            this.btnReiniciarTelefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarTelefono.Location = new System.Drawing.Point(1104, 35);
            this.btnReiniciarTelefono.Name = "btnReiniciarTelefono";
            this.btnReiniciarTelefono.Size = new System.Drawing.Size(155, 30);
            this.btnReiniciarTelefono.TabIndex = 115;
            this.btnReiniciarTelefono.Text = "Reiniciar";
            this.btnReiniciarTelefono.UseVisualStyleBackColor = false;
            this.btnReiniciarTelefono.Click += new System.EventHandler(this.btnReiniciarTelefono_Click);
            // 
            // txbBuscarCorreo
            // 
            this.txbBuscarCorreo.BackColor = System.Drawing.Color.Chocolate;
            this.txbBuscarCorreo.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBuscarCorreo.Location = new System.Drawing.Point(693, 352);
            this.txbBuscarCorreo.Name = "txbBuscarCorreo";
            this.txbBuscarCorreo.Size = new System.Drawing.Size(192, 24);
            this.txbBuscarCorreo.TabIndex = 114;
            this.txbBuscarCorreo.TextChanged += new System.EventHandler(this.txbBuscarCorreo_TextChanged);
            // 
            // btnBuscarCorreo
            // 
            this.btnBuscarCorreo.BackColor = System.Drawing.Color.Peru;
            this.btnBuscarCorreo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCorreo.Location = new System.Drawing.Point(935, 346);
            this.btnBuscarCorreo.Name = "btnBuscarCorreo";
            this.btnBuscarCorreo.Size = new System.Drawing.Size(128, 29);
            this.btnBuscarCorreo.TabIndex = 113;
            this.btnBuscarCorreo.Text = "Buscar";
            this.btnBuscarCorreo.UseVisualStyleBackColor = false;
            this.btnBuscarCorreo.Click += new System.EventHandler(this.btnBuscarCorreo_Click);
            // 
            // cmbBuscarCorreo
            // 
            this.cmbBuscarCorreo.BackColor = System.Drawing.Color.Chocolate;
            this.cmbBuscarCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscarCorreo.FormattingEnabled = true;
            this.cmbBuscarCorreo.Items.AddRange(new object[] {
            "ID",
            "ID Proveedor",
            "Correo"});
            this.cmbBuscarCorreo.Location = new System.Drawing.Point(493, 349);
            this.cmbBuscarCorreo.Name = "cmbBuscarCorreo";
            this.cmbBuscarCorreo.Size = new System.Drawing.Size(182, 26);
            this.cmbBuscarCorreo.TabIndex = 112;
            this.cmbBuscarCorreo.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarCorreo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label13.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(339, 355);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 21);
            this.label13.TabIndex = 111;
            this.label13.Text = "Buscar Por:";
            // 
            // dtgvCorreo
            // 
            this.dtgvCorreo.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dtgvCorreo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCorreo.Location = new System.Drawing.Point(412, 381);
            this.dtgvCorreo.Name = "dtgvCorreo";
            this.dtgvCorreo.Size = new System.Drawing.Size(847, 219);
            this.dtgvCorreo.TabIndex = 110;
            this.dtgvCorreo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCorreo_CellClick);
            // 
            // txbBuscarTelefono
            // 
            this.txbBuscarTelefono.BackColor = System.Drawing.Color.Chocolate;
            this.txbBuscarTelefono.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBuscarTelefono.Location = new System.Drawing.Point(693, 38);
            this.txbBuscarTelefono.Name = "txbBuscarTelefono";
            this.txbBuscarTelefono.Size = new System.Drawing.Size(192, 24);
            this.txbBuscarTelefono.TabIndex = 109;
            this.txbBuscarTelefono.TextChanged += new System.EventHandler(this.txbBuscarTelefono_TextChanged);
            // 
            // btnBuscarTelefono
            // 
            this.btnBuscarTelefono.BackColor = System.Drawing.Color.Peru;
            this.btnBuscarTelefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTelefono.Location = new System.Drawing.Point(935, 36);
            this.btnBuscarTelefono.Name = "btnBuscarTelefono";
            this.btnBuscarTelefono.Size = new System.Drawing.Size(128, 29);
            this.btnBuscarTelefono.TabIndex = 108;
            this.btnBuscarTelefono.Text = "Buscar";
            this.btnBuscarTelefono.UseVisualStyleBackColor = false;
            this.btnBuscarTelefono.Click += new System.EventHandler(this.btnBuscarTelefono_Click);
            // 
            // cmbBuscarTelefono
            // 
            this.cmbBuscarTelefono.BackColor = System.Drawing.Color.Chocolate;
            this.cmbBuscarTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscarTelefono.FormattingEnabled = true;
            this.cmbBuscarTelefono.Items.AddRange(new object[] {
            "ID",
            "ID Proveedor",
            "Teléfono"});
            this.cmbBuscarTelefono.Location = new System.Drawing.Point(493, 35);
            this.cmbBuscarTelefono.Name = "cmbBuscarTelefono";
            this.cmbBuscarTelefono.Size = new System.Drawing.Size(182, 26);
            this.cmbBuscarTelefono.TabIndex = 107;
            this.cmbBuscarTelefono.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarTelefono_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(339, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 21);
            this.label12.TabIndex = 106;
            this.label12.Text = "Buscar Por:";
            // 
            // dtgvTelefono
            // 
            this.dtgvTelefono.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dtgvTelefono.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTelefono.Location = new System.Drawing.Point(412, 71);
            this.dtgvTelefono.Name = "dtgvTelefono";
            this.dtgvTelefono.Size = new System.Drawing.Size(847, 219);
            this.dtgvTelefono.TabIndex = 105;
            this.dtgvTelefono.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTelefono_CellClick);
            // 
            // lbl_IdTelefono
            // 
            this.lbl_IdTelefono.AutoSize = true;
            this.lbl_IdTelefono.Location = new System.Drawing.Point(340, 164);
            this.lbl_IdTelefono.Name = "lbl_IdTelefono";
            this.lbl_IdTelefono.Size = new System.Drawing.Size(41, 13);
            this.lbl_IdTelefono.TabIndex = 117;
            this.lbl_IdTelefono.Text = "label15";
            this.lbl_IdTelefono.Visible = false;
            this.lbl_IdTelefono.Click += new System.EventHandler(this.lbl_IdTelefono_Click);
            // 
            // lbl_IdCorreo
            // 
            this.lbl_IdCorreo.AutoSize = true;
            this.lbl_IdCorreo.Location = new System.Drawing.Point(340, 474);
            this.lbl_IdCorreo.Name = "lbl_IdCorreo";
            this.lbl_IdCorreo.Size = new System.Drawing.Size(41, 13);
            this.lbl_IdCorreo.TabIndex = 118;
            this.lbl_IdCorreo.Text = "label15";
            this.lbl_IdCorreo.Visible = false;
            this.lbl_IdCorreo.Click += new System.EventHandler(this.lbl_IdCorreo_Click);
            // 
            // btnEliminar_Telefono
            // 
            this.btnEliminar_Telefono.BackColor = System.Drawing.Color.Peru;
            this.btnEliminar_Telefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_Telefono.Location = new System.Drawing.Point(188, 220);
            this.btnEliminar_Telefono.Name = "btnEliminar_Telefono";
            this.btnEliminar_Telefono.Size = new System.Drawing.Size(142, 38);
            this.btnEliminar_Telefono.TabIndex = 121;
            this.btnEliminar_Telefono.Text = "Eliminar";
            this.btnEliminar_Telefono.UseVisualStyleBackColor = false;
            this.btnEliminar_Telefono.Click += new System.EventHandler(this.btnEliminar_Telefono_Click);
            // 
            // btnEditar_Telefono
            // 
            this.btnEditar_Telefono.BackColor = System.Drawing.Color.Peru;
            this.btnEditar_Telefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_Telefono.Location = new System.Drawing.Point(40, 246);
            this.btnEditar_Telefono.Name = "btnEditar_Telefono";
            this.btnEditar_Telefono.Size = new System.Drawing.Size(142, 44);
            this.btnEditar_Telefono.TabIndex = 120;
            this.btnEditar_Telefono.Text = "Editar";
            this.btnEditar_Telefono.UseVisualStyleBackColor = false;
            this.btnEditar_Telefono.Click += new System.EventHandler(this.btnEditar_Telefono_Click);
            // 
            // btnAgregar_Telefono
            // 
            this.btnAgregar_Telefono.BackColor = System.Drawing.Color.Peru;
            this.btnAgregar_Telefono.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar_Telefono.Location = new System.Drawing.Point(40, 199);
            this.btnAgregar_Telefono.Name = "btnAgregar_Telefono";
            this.btnAgregar_Telefono.Size = new System.Drawing.Size(142, 41);
            this.btnAgregar_Telefono.TabIndex = 119;
            this.btnAgregar_Telefono.Text = "Agregar";
            this.btnAgregar_Telefono.UseVisualStyleBackColor = false;
            this.btnAgregar_Telefono.Click += new System.EventHandler(this.btnAgregar_Telefono_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Peru;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(24, 644);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(171, 51);
            this.btnRegresar.TabIndex = 122;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Peru;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1262, 645);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(181, 50);
            this.btnSalir.TabIndex = 123;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // txtIdProveedor_Correo
            // 
            this.txtIdProveedor_Correo.BackColor = System.Drawing.Color.Chocolate;
            this.txtIdProveedor_Correo.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProveedor_Correo.Location = new System.Drawing.Point(40, 381);
            this.txtIdProveedor_Correo.Name = "txtIdProveedor_Correo";
            this.txtIdProveedor_Correo.Size = new System.Drawing.Size(192, 24);
            this.txtIdProveedor_Correo.TabIndex = 125;
            this.txtIdProveedor_Correo.TextChanged += new System.EventHandler(this.txtIdProveedor_Correo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 124;
            this.label2.Text = "Id_Proveedor";
            // 
            // btnEliminar_Correo
            // 
            this.btnEliminar_Correo.BackColor = System.Drawing.Color.Peru;
            this.btnEliminar_Correo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_Correo.Location = new System.Drawing.Point(188, 518);
            this.btnEliminar_Correo.Name = "btnEliminar_Correo";
            this.btnEliminar_Correo.Size = new System.Drawing.Size(142, 38);
            this.btnEliminar_Correo.TabIndex = 128;
            this.btnEliminar_Correo.Text = "Eliminar";
            this.btnEliminar_Correo.UseVisualStyleBackColor = false;
            this.btnEliminar_Correo.Click += new System.EventHandler(this.btnEliminar_Correo_Click);
            // 
            // btnEditar_Correo
            // 
            this.btnEditar_Correo.BackColor = System.Drawing.Color.Peru;
            this.btnEditar_Correo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar_Correo.Location = new System.Drawing.Point(40, 544);
            this.btnEditar_Correo.Name = "btnEditar_Correo";
            this.btnEditar_Correo.Size = new System.Drawing.Size(142, 44);
            this.btnEditar_Correo.TabIndex = 127;
            this.btnEditar_Correo.Text = "Editar";
            this.btnEditar_Correo.UseVisualStyleBackColor = false;
            this.btnEditar_Correo.Click += new System.EventHandler(this.btnEditar_Correo_Click);
            // 
            // btnAgregar_Correo
            // 
            this.btnAgregar_Correo.BackColor = System.Drawing.Color.Peru;
            this.btnAgregar_Correo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar_Correo.Location = new System.Drawing.Point(40, 497);
            this.btnAgregar_Correo.Name = "btnAgregar_Correo";
            this.btnAgregar_Correo.Size = new System.Drawing.Size(142, 41);
            this.btnAgregar_Correo.TabIndex = 126;
            this.btnAgregar_Correo.Text = "Agregar";
            this.btnAgregar_Correo.UseVisualStyleBackColor = false;
            this.btnAgregar_Correo.Click += new System.EventHandler(this.btnAgregar_Correo_Click);
            // 
            // Proveedor_Correo_Telefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Restaurante.Properties.Resources.ac4195e9_f959_4e67_a731_ef20de244345;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1455, 707);
            this.Controls.Add(this.btnEliminar_Correo);
            this.Controls.Add(this.btnEditar_Correo);
            this.Controls.Add(this.btnAgregar_Correo);
            this.Controls.Add(this.txtIdProveedor_Correo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar_Telefono);
            this.Controls.Add(this.btnEditar_Telefono);
            this.Controls.Add(this.btnAgregar_Telefono);
            this.Controls.Add(this.lbl_IdCorreo);
            this.Controls.Add(this.lbl_IdTelefono);
            this.Controls.Add(this.btnReiniciarCorreo);
            this.Controls.Add(this.btnReiniciarTelefono);
            this.Controls.Add(this.txbBuscarCorreo);
            this.Controls.Add(this.btnBuscarCorreo);
            this.Controls.Add(this.cmbBuscarCorreo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtgvCorreo);
            this.Controls.Add(this.txbBuscarTelefono);
            this.Controls.Add(this.btnBuscarTelefono);
            this.Controls.Add(this.cmbBuscarTelefono);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtgvTelefono);
            this.Controls.Add(this.txtIdProveedor_Telefono);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtbTelefono);
            this.Controls.Add(this.txtbCorreo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Name = "Proveedor_Correo_Telefono";
            this.Text = "Proveedor_Correo_Telefono";
            this.Load += new System.EventHandler(this.Proveedor_Correo_Telefono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTelefono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbTelefono;
        private System.Windows.Forms.TextBox txtbCorreo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdProveedor_Telefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReiniciarCorreo;
        private System.Windows.Forms.Button btnReiniciarTelefono;
        private System.Windows.Forms.TextBox txbBuscarCorreo;
        private System.Windows.Forms.Button btnBuscarCorreo;
        private System.Windows.Forms.ComboBox cmbBuscarCorreo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dtgvCorreo;
        private System.Windows.Forms.TextBox txbBuscarTelefono;
        private System.Windows.Forms.Button btnBuscarTelefono;
        private System.Windows.Forms.ComboBox cmbBuscarTelefono;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgvTelefono;
        private System.Windows.Forms.Label lbl_IdTelefono;
        private System.Windows.Forms.Label lbl_IdCorreo;
        private System.Windows.Forms.Button btnEliminar_Telefono;
        private System.Windows.Forms.Button btnEditar_Telefono;
        private System.Windows.Forms.Button btnAgregar_Telefono;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtIdProveedor_Correo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar_Correo;
        private System.Windows.Forms.Button btnEditar_Correo;
        private System.Windows.Forms.Button btnAgregar_Correo;
    }
}