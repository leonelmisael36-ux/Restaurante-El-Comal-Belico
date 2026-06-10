using Busqueda;
using CapaLogica;
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
    public partial class Administracion : Form
    {
        CL_Usuario obj = new CL_Usuario();
        B_Usuario busqueda = new B_Usuario();
        CV_Usuario validar = new CV_Usuario();
        public Administracion()
        {
            InitializeComponent();
        }

        void MostrarUsuarios()
        {
            dtgvPedido.DataSource = obj.Listar();

            dtgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPedido.ReadOnly = true;
            dtgvPedido.AllowUserToAddRows = false;
            dtgvPedido.AllowUserToDeleteRows = false;
        }
        void Limpiar()
        {
            txtbNombre.Clear();
            txtAPaterno.Clear();
            txtAmaterno.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();

            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            lbl_Id.Text = "";
        }

        private void txtbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void Administracion_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarUsuarios();

            cmbBuscar.Items.Clear();
            cmbBuscar.Items.Add("ID");
            cmbBuscar.Items.Add("Nombre");
            cmbBuscar.Items.Add("Correo");
            cmbBuscar.Items.Add("Rol");
            cmbBuscar.Items.Add("Estado");

            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Empleado");

            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
        }

        private void txtAmaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario()
            {
                Nombre_usuario = txtbNombre.Text,
                APaterno = txtAPaterno.Text,
                AMaterno = txtAmaterno.Text,
                Correo = txtCorreo.Text,
                Contraseña = txtContraseña.Text,
                Rol = cmbRol.Text,
                EstadoUsuario = cmbEstado.Text
            };

            string mensaje = "";

            if (validar.Registrar(objUsuario, out mensaje))
            {
                MessageBox.Show("Usuario agregado 😄");
                MostrarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_Id.Text, out int id))
            {
                MessageBox.Show("Selecciona un usuario");
                return;
            }

            string mensaje = "";

            if (validar.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Usuario eliminado 😄");
                MostrarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_Id.Text, out int id))
            {
                MessageBox.Show("Selecciona un usuario");
                return;
            }

            Usuario objUsuario = new Usuario()
            {
                Id_Usuario = id,
                Nombre_usuario = txtbNombre.Text,
                APaterno = txtAPaterno.Text,
                AMaterno = txtAmaterno.Text,
                Correo = txtCorreo.Text,
                Contraseña = txtContraseña.Text,
                Rol = cmbRol.Text,
                EstadoUsuario = cmbEstado.Text
            };

            string mensaje = "";

            if (validar.Editar(objUsuario, out mensaje))
            {
                MessageBox.Show("Usuario editado 😄");
                MostrarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Usuario> resultado = new List<Usuario>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorId(id);
            }
            else if (filtro == "Nombre")
            {
                resultado = busqueda.BuscarPorNombre(texto);
            }
            else if (filtro == "Correo")
            {
                resultado = busqueda.BuscarPorCorreo(texto);
            }
            else if (filtro == "Rol")
            {
                resultado = busqueda.BuscarPorRol(texto);
            }
            else if (filtro == "Estado")
            {
                resultado = busqueda.BuscarPorEstado(texto);
            }

            dtgvPedido.DataSource = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
            txbBuscar.Clear();
            cmbBuscar.SelectedIndex = -1;
        }

        private void dtgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvPedido.Rows[e.RowIndex].Cells["Id_Usuario"].Value.ToString();

            txtbNombre.Text = dtgvPedido.Rows[e.RowIndex].Cells["Nombre_usuario"].Value.ToString();
            txtAPaterno.Text = dtgvPedido.Rows[e.RowIndex].Cells["APaterno"].Value.ToString();
            txtAmaterno.Text = dtgvPedido.Rows[e.RowIndex].Cells["AMaterno"].Value.ToString();
            txtCorreo.Text = dtgvPedido.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
            txtContraseña.Text = dtgvPedido.Rows[e.RowIndex].Cells["Contraseña"].Value.ToString();
            cmbRol.Text = dtgvPedido.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
            cmbEstado.Text = dtgvPedido.Rows[e.RowIndex].Cells["EstadoUsuario"].Value.ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Pantalla_Principalcs frm = new Pantalla_Principalcs();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
