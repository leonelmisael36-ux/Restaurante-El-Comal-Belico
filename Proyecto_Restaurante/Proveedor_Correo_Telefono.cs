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
    public partial class Proveedor_Correo_Telefono : Form
    {
        CL_Telefono_Proveedor objTelefono = new CL_Telefono_Proveedor();
        CV_Telefono_Proveedor cvTelefono = new CV_Telefono_Proveedor();
        B_Telefono_Proveedor busquedaTelefono = new B_Telefono_Proveedor();

        Cl_Correo_Proveedor objCorreo = new Cl_Correo_Proveedor();
        CV_Correo_Proveedor cvCorreo = new CV_Correo_Proveedor();
        B_Correo_Proveedor busquedaCorreo = new B_Correo_Proveedor();
        public Proveedor_Correo_Telefono()
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

        void LimpiarTelefono()
        {
            lbl_IdTelefono.Text = "";
            txtIdProveedor_Telefono.Clear();
            mtbTelefono.Clear();
        }

        void LimpiarCorreo()
        {
            lbl_IdCorreo.Text = "";
            txtIdProveedor_Correo.Clear();
            txtbCorreo.Clear();
        }
        private void txtIdProveedor_Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void Proveedor_Correo_Telefono_Load(object sender, EventArgs e)
        {
            MostrarTelefonos();
            MostrarCorreos();
        }

        private void mtbTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnAgregar_Telefono_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdProveedor_Telefono.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            Telefono_Proveedor obj = new Telefono_Proveedor();

            string telefonoLimpio = new string(
    mtbTelefono.Text.Where(char.IsDigit).ToArray());

            obj.Telefono = telefonoLimpio;
            obj.Id_Proveedor = idProveedor;

            string mensaje = "";

            if (cvTelefono.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Teléfono agregado");
                MostrarTelefonos();
                LimpiarTelefono();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Telefono_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdTelefono.Text, out int idTelefono))
            {
                MessageBox.Show("Selecciona un teléfono");
                return;
            }

            string mensaje = "";

            if (cvTelefono.Eliminar(idTelefono, out mensaje))
            {
                MessageBox.Show("Teléfono eliminado");
                MostrarTelefonos();
                LimpiarTelefono();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Telefono_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdTelefono.Text, out int idTelefono))
            {
                MessageBox.Show("Selecciona un teléfono");
                return;
            }

            if (!int.TryParse(txtIdProveedor_Telefono.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            Telefono_Proveedor obj = new Telefono_Proveedor();

            string telefonoLimpio = new string(
    mtbTelefono.Text.Where(char.IsDigit).ToArray());

            obj.Telefono = telefonoLimpio;
            obj.Id_TelefonoProveedor = idTelefono;
            obj.Id_Proveedor = idProveedor;

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

        private void txtIdProveedor_Correo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Correo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdCorreo.Text, out int idCorreo))
            {
                MessageBox.Show("Selecciona un correo");
                return;
            }

            string mensaje = "";

            if (cvCorreo.Eliminar(idCorreo, out mensaje))
            {
                MessageBox.Show("Correo eliminado");
                MostrarCorreos();
                LimpiarCorreo();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnAgregar_Correo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdProveedor_Correo.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            Correo_Proveedor obj = new Correo_Proveedor();

            obj.Id_Proveedor = idProveedor;
            obj.Correo = txtbCorreo.Text.Trim();

            string mensaje = "";

            if (cvCorreo.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Correo agregado");
                MostrarCorreos();
                LimpiarCorreo();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Correo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdCorreo.Text, out int idCorreo))
            {
                MessageBox.Show("Selecciona un correo");
                return;
            }

            if (!int.TryParse(txtIdProveedor_Correo.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            Correo_Proveedor obj = new Correo_Proveedor();

            obj.Id_CorreoProveedor = idCorreo;
            obj.Id_Proveedor = idProveedor;
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

        private void lbl_IdCorreo_Click(object sender, EventArgs e)
        {

        }

        private void lbl_IdTelefono_Click(object sender, EventArgs e)
        {

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

            string filtro = cmbBuscarTelefono.Text;
            string texto = txbBuscarTelefono.Text.Trim();

            List<Telefono_Proveedor> resultado = new List<Telefono_Proveedor>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busquedaTelefono.BuscarPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "ID Proveedor")
            {
                if (int.TryParse(texto, out int idProveedor))
                {
                    resultado = busquedaTelefono.BuscarPorProveedor(idProveedor);
                }
                else
                {
                    MessageBox.Show("El ID del proveedor debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Teléfono")
            {
                resultado = busquedaTelefono.BuscarPorTelefono(texto);
            }

            dtgvTelefono.DataSource = resultado;
        }

        private void btnReiniciarTelefono_Click(object sender, EventArgs e)
        {
            MostrarTelefonos();

            cmbBuscarTelefono.SelectedIndex = -1;
            txbBuscarTelefono.Text = "";
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

            string filtro = cmbBuscarCorreo.Text;
            string texto = txbBuscarCorreo.Text.Trim();

            List<Correo_Proveedor> resultado = new List<Correo_Proveedor>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busquedaCorreo.BuscarPorIdCorreo(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "ID Proveedor")
            {
                if (int.TryParse(texto, out int idProveedor))
                {
                    resultado = busquedaCorreo.BuscarPorIdProveedor(idProveedor);
                }
                else
                {
                    MessageBox.Show("El ID del proveedor debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Correo")
            {
                resultado = busquedaCorreo.BuscarPorCorreo(texto);
            }

            dtgvCorreo.DataSource = resultado;
        }

        private void btnReiniciarCorreo_Click(object sender, EventArgs e)
        {
            MostrarCorreos();

            cmbBuscarCorreo.SelectedIndex = -1;
            txbBuscarCorreo.Text = "";
        }

        private void dtgvTelefono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_IdTelefono.Text =
                dtgvTelefono.Rows[e.RowIndex]
                .Cells["Id_TelefonoProveedor"].Value.ToString();

            txtIdProveedor_Telefono.Text =
                dtgvTelefono.Rows[e.RowIndex]
                .Cells["Id_Proveedor"].Value.ToString();

            mtbTelefono.Text =
                dtgvTelefono.Rows[e.RowIndex]
                .Cells["Telefono"].Value.ToString();
        }

        private void dtgvCorreo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_IdCorreo.Text =
                dtgvCorreo.Rows[e.RowIndex]
                .Cells["Id_CorreoProveedor"].Value.ToString();

            txtIdProveedor_Correo.Text =
                dtgvCorreo.Rows[e.RowIndex]
                .Cells["Id_Proveedor"].Value.ToString();

            txtbCorreo.Text =
                dtgvCorreo.Rows[e.RowIndex]
                .Cells["Correo"].Value.ToString();
        }
    }
}
