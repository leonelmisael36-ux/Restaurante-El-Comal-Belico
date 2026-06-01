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
    public partial class Cliente_Correo_Telefono : Form
    {
        CL_Telefono_Cliente objTelefono = new CL_Telefono_Cliente();
        CV_Telefono_Cliente cvTelefono = new CV_Telefono_Cliente();
        B_Telefono_Cliente busquedaTelefono = new B_Telefono_Cliente();

        CL_Correo_Clientes objCorreo = new CL_Correo_Clientes();
        CV_Correo_Cliente cvCorreo = new CV_Correo_Cliente();
        B_Correo_Cliente busquedaCorreo = new B_Correo_Cliente();

        private int idTelefonoSeleccionado;
        private int idCorreoSeleccionado;
        public Cliente_Correo_Telefono()
        {
            InitializeComponent();
        }

        void MostrarTelefonos()
        {
            dtgvTelefono.DataSource = objTelefono.Listar();

            dtgvTelefono.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTelefono.ReadOnly = true;
            dtgvTelefono.AllowUserToAddRows = false;
            dtgvTelefono.AllowUserToDeleteRows = false;
        }

        void MostrarCorreos()
        {
            dtgvCorreo.DataSource = objCorreo.Listar();

            dtgvCorreo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCorreo.ReadOnly = true;
            dtgvCorreo.AllowUserToAddRows = false;
            dtgvCorreo.AllowUserToDeleteRows = false;
        }

        private void txtIdCliente_Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cliente_Correo_Telefono_Load(object sender, EventArgs e)
        {
            MostrarTelefonos();
            MostrarCorreos();
        }

        private void mtbTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnAgregar_Telefono_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdCliente_Telefono.Text, out int idCliente))
            {
                MessageBox.Show("ID cliente inválido");
                return;
            }

            Telefono_Cliente obj = new Telefono_Cliente();

            obj.Id_Cliente = idCliente;
            obj.Telefono = new string(
                mtbTelefono.Text.Where(char.IsDigit).ToArray());

            string mensaje = "";

            if (cvTelefono.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Teléfono agregado");
                MostrarTelefonos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Telefono_Click(object sender, EventArgs e)
        {
            Telefono_Cliente obj = new Telefono_Cliente();

            obj.Id_Telefono = idTelefonoSeleccionado;
            obj.Id_Cliente = int.Parse(txtIdCliente_Telefono.Text);

            obj.Telefono = new string(
                mtbTelefono.Text.Where(char.IsDigit).ToArray());

            string mensaje = "";

            if (cvTelefono.Editar(obj, out mensaje))
            {
                MessageBox.Show("Teléfono actualizado");
                MostrarTelefonos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Telefono_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            if (cvTelefono.Eliminar(idTelefonoSeleccionado, out mensaje))
            {
                MessageBox.Show("Teléfono eliminado");
                MostrarTelefonos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void txtIdCliente_Correo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Correo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdCliente_Correo.Text, out int idCliente))
            {
                MessageBox.Show("ID cliente inválido");
                return;
            }

            Correo_Cliente obj = new Correo_Cliente();

            obj.Id_Cliente = idCliente;
            obj.Correo = txtbCorreo.Text.Trim();

            string mensaje = "";

            if (cvCorreo.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Correo agregado");
                MostrarCorreos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Correo_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            if (cvCorreo.Eliminar(idCorreoSeleccionado, out mensaje))
            {
                MessageBox.Show("Correo eliminado");
                MostrarCorreos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Correo_Click(object sender, EventArgs e)
        {
            Correo_Cliente obj = new Correo_Cliente();

            obj.Id_Correo = idCorreoSeleccionado;
            obj.Id_Cliente = int.Parse(txtIdCliente_Correo.Text);
            obj.Correo = txtbCorreo.Text.Trim();

            string mensaje = "";

            if (cvCorreo.Editar(obj, out mensaje))
            {
                MessageBox.Show("Correo actualizado");
                MostrarCorreos();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void cmbBuscarTelefono_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscarTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarTelefono_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarTelefono.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscarTelefono.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string opcion = cmbBuscarTelefono.Text;
            string valor = txbBuscarTelefono.Text.Trim();

            if (opcion == "ID Teléfono")
            {
                if (int.TryParse(valor, out int id))
                    dtgvTelefono.DataSource = busquedaTelefono.BuscarPorId(id);
                else
                    MessageBox.Show("Solo números");
            }
            else if (opcion == "ID Cliente")
            {
                if (int.TryParse(valor, out int idCliente))
                    dtgvTelefono.DataSource = busquedaTelefono.BuscarPorCliente(idCliente);
                else
                    MessageBox.Show("Solo números");
            }
            else if (opcion == "Teléfono")
            {
                dtgvTelefono.DataSource = busquedaTelefono.BuscarPorTelefono(valor);
            }
        }

        private void btnReiniciarTelefono_Click(object sender, EventArgs e)
        {
            MostrarTelefonos();

            cmbBuscarTelefono.SelectedIndex = -1;
            txbBuscarTelefono.Clear();
        }

        private void dtgvTelefono_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBuscarCorreo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscarCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarCorreo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarCorreo.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscarCorreo.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string opcion = cmbBuscarCorreo.Text;
            string valor = txbBuscarCorreo.Text.Trim();

            if (opcion == "ID Correo")
            {
                if (int.TryParse(valor, out int id))
                    dtgvCorreo.DataSource = busquedaCorreo.BuscarPorIdCorreo(id);
                else
                    MessageBox.Show("Solo números");
            }
            else if (opcion == "ID Cliente")
            {
                if (int.TryParse(valor, out int idCliente))
                    dtgvCorreo.DataSource = busquedaCorreo.BuscarPorIdCliente(idCliente);
                else
                    MessageBox.Show("Solo números");
            }
            else if (opcion == "Correo")
            {
                dtgvCorreo.DataSource = busquedaCorreo.BuscarPorCorreo(valor);
            }
        }

        private void btnReiniciarCorreo_Click(object sender, EventArgs e)
        {
            MostrarCorreos();

            cmbBuscarCorreo.SelectedIndex = -1;
            txbBuscarCorreo.Clear();
        }

        private void dtgvCorreo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvTelefono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idTelefonoSeleccionado =
                Convert.ToInt32(dtgvTelefono.Rows[e.RowIndex].Cells["Id_Telefono"].Value);

            txtIdCliente_Telefono.Text =
                dtgvTelefono.Rows[e.RowIndex].Cells["Id_Cliente"].Value.ToString();

            mtbTelefono.Text =
                dtgvTelefono.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
        }

        private void dtgvCorreo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idCorreoSeleccionado =
                Convert.ToInt32(dtgvCorreo.Rows[e.RowIndex].Cells["Id_Correo"].Value);

            txtIdCliente_Correo.Text =
                dtgvCorreo.Rows[e.RowIndex].Cells["Id_Cliente"].Value.ToString();

            txtbCorreo.Text =
                dtgvCorreo.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
