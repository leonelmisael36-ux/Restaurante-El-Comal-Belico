using CapaMo;
using CapaValidar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Restaurante
{
    public partial class Crear_Cuenta : Form
    {
        private CV_Usuario cvUsuario = new CV_Usuario();
        public Crear_Cuenta()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtNombre.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            textBox1.Clear();
            txtContraseña.Clear();

            txtNombre.Focus();
        }

        private void Crear_Cuenta_Load(object sender, EventArgs e)
        {

        }

        private void txtAPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAMaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario()
            {
                Nombre_usuario = txtNombre.Text.Trim(),
                APaterno = txtAPaterno.Text.Trim(),
                AMaterno = txtAMaterno.Text.Trim(),
                Correo = textBox1.Text.Trim(),
                Contraseña = txtContraseña.Text,
                Rol = "Empleado",
                EstadoUsuario = "Activo"
            };

            string mensaje = "";

            if (cvUsuario.Registrar(obj, out mensaje))
            {
                Limpiar();

                MessageBox.Show("Cuenta creada correctamente 😄");

                log_in frm = new log_in();
                frm.Show();

                this.Hide();
            }
            else
            {
                Limpiar();
                MessageBox.Show(mensaje);
            }
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            log_in frm = new log_in();
            this.Hide();
            frm.Show();
        }
    }
}
