using CapaLogica;
using CapaMo;
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
    public partial class log_in : Form
    {
        CL_Usuario usuario = new CL_Usuario();
        public log_in()
        {
            InitializeComponent();
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Crear_Cuenta frm = new Crear_Cuenta();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            Usuario usuarioLogueado = usuario.Login(correo, contrasena);

            if (usuarioLogueado != null)
            {
                if (usuarioLogueado.EstadoUsuario != "Activo")
                {
                    MessageBox.Show("El usuario está inactivo");
                    return;
                }

                MessageBox.Show("Bienvenido " + usuarioLogueado.Nombre_usuario);

                Sesion.IdUsuario = usuarioLogueado.Id_Usuario;
                Sesion.NombreUsuario = usuarioLogueado.Nombre_usuario;
                Sesion.Rol = usuarioLogueado.Rol;
                Sesion.Estado = usuarioLogueado.EstadoUsuario;

                Pantalla_Principalcs frm = new Pantalla_Principalcs();
                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
