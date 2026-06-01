namespace Proyecto_Restaurante
{
    partial class Pedidos
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnReiniciarDetallePedido = new System.Windows.Forms.Button();
            this.txtDetallePedido = new System.Windows.Forms.TextBox();
            this.btnDetallePedido = new System.Windows.Forms.Button();
            this.cmbDetallePedido = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgvDetallePedido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Peru;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1085, 563);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(212, 57);
            this.btnSalir.TabIndex = 79;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Peru;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(43, 563);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(209, 60);
            this.btnRegresar.TabIndex = 78;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            // 
            // btnReiniciarDetallePedido
            // 
            this.btnReiniciarDetallePedido.BackColor = System.Drawing.Color.Peru;
            this.btnReiniciarDetallePedido.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarDetallePedido.Location = new System.Drawing.Point(1142, 55);
            this.btnReiniciarDetallePedido.Name = "btnReiniciarDetallePedido";
            this.btnReiniciarDetallePedido.Size = new System.Drawing.Size(155, 30);
            this.btnReiniciarDetallePedido.TabIndex = 85;
            this.btnReiniciarDetallePedido.Text = "Reiniciar";
            this.btnReiniciarDetallePedido.UseVisualStyleBackColor = false;
            // 
            // txtDetallePedido
            // 
            this.txtDetallePedido.BackColor = System.Drawing.Color.Chocolate;
            this.txtDetallePedido.Font = new System.Drawing.Font("Modern No. 20", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetallePedido.Location = new System.Drawing.Point(810, 61);
            this.txtDetallePedido.Name = "txtDetallePedido";
            this.txtDetallePedido.Size = new System.Drawing.Size(192, 24);
            this.txtDetallePedido.TabIndex = 84;
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.BackColor = System.Drawing.Color.Peru;
            this.btnDetallePedido.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallePedido.Location = new System.Drawing.Point(1008, 55);
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.Size = new System.Drawing.Size(128, 29);
            this.btnDetallePedido.TabIndex = 83;
            this.btnDetallePedido.Text = "Buscar";
            this.btnDetallePedido.UseVisualStyleBackColor = false;
            // 
            // cmbDetallePedido
            // 
            this.cmbDetallePedido.BackColor = System.Drawing.Color.Chocolate;
            this.cmbDetallePedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetallePedido.FormattingEnabled = true;
            this.cmbDetallePedido.Items.AddRange(new object[] {
            "Id",
            "Descripcion",
            "Disponible",
            "Fecha"});
            this.cmbDetallePedido.Location = new System.Drawing.Point(607, 60);
            this.cmbDetallePedido.Name = "cmbDetallePedido";
            this.cmbDetallePedido.Size = new System.Drawing.Size(182, 26);
            this.cmbDetallePedido.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(488, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 81;
            this.label4.Text = "Buscar Por:";
            // 
            // dtgvDetallePedido
            // 
            this.dtgvDetallePedido.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dtgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetallePedido.Location = new System.Drawing.Point(515, 137);
            this.dtgvDetallePedido.Name = "dtgvDetallePedido";
            this.dtgvDetallePedido.Size = new System.Drawing.Size(766, 205);
            this.dtgvDetallePedido.TabIndex = 80;
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Restaurante.Properties.Resources.Captura_de_pantalla_2026_05_31_123514;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1355, 661);
            this.Controls.Add(this.btnReiniciarDetallePedido);
            this.Controls.Add(this.txtDetallePedido);
            this.Controls.Add(this.btnDetallePedido);
            this.Controls.Add(this.cmbDetallePedido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtgvDetallePedido);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegresar);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetallePedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnReiniciarDetallePedido;
        private System.Windows.Forms.TextBox txtDetallePedido;
        private System.Windows.Forms.Button btnDetallePedido;
        private System.Windows.Forms.ComboBox cmbDetallePedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgvDetallePedido;
    }
}