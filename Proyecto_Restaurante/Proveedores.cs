using Busqueda;
using CapaLogica;
using CapaMo;
using CapaValidar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Restaurante
{
    public partial class Proveedores : Form
    {
        CL_Proveedor objProveedor = new CL_Proveedor();
        CV_Proveedor cvProveedor = new CV_Proveedor();
        B_Proveedor busqueda = new B_Proveedor();
        public Proveedores()
        {
            InitializeComponent();
        }

        void MostrarProveedores()
        {
            dtgvCliente.DataSource = objProveedor.Listar();

            dtgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCliente.ReadOnly = true;
            dtgvCliente.AllowUserToAddRows = false;
            dtgvCliente.AllowUserToDeleteRows = false;
            dtgvCliente.MultiSelect = false;
        }

        void Limpiar()
        {
            lbl_Id.Text = "";

            txtbNombre.Clear();
            txtRazon.Clear();
            txtbCalle.Clear();
            txtbNum.Clear();
            txtbColonia.Clear();
            txtbCiudad.Clear();
            txtbEstado.Clear();
            txtbCP.Clear();

            cmbEstado.SelectedIndex = -1;
        }

        private void txtbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRazon_TextChanged(object sender, EventArgs e)
        {

        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        private void txtbCalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbColonia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCP_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor obj = new Proveedor();

            obj.NombreEmpresa = txtbNombre.Text.Trim();
            obj.RazonSocial = txtRazon.Text.Trim();
            obj.CallePr = txtbCalle.Text.Trim();
            obj.NumeroPr = txtbNum.Text.Trim();
            obj.ColoniaPr = txtbColonia.Text.Trim();
            obj.CiudadPr = txtbCiudad.Text.Trim();
            obj.EstadoPr = txtbEstado.Text.Trim();
            obj.CPPr = txtbCP.Text.Trim();
            obj.EstadoProveedor = cmbEstado.Text;

            string mensaje = "";

            if (cvProveedor.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Proveedor agregado 😄");
                MostrarProveedores();
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
                MessageBox.Show("Selecciona un proveedor");
                return;
            }

            Proveedor obj = new Proveedor();

            obj.Id_Proveedor = id;
            obj.NombreEmpresa = txtbNombre.Text.Trim();
            obj.RazonSocial = txtRazon.Text.Trim();
            obj.CallePr = txtbCalle.Text.Trim();
            obj.NumeroPr = txtbNum.Text.Trim();
            obj.ColoniaPr = txtbColonia.Text.Trim();
            obj.CiudadPr = txtbCiudad.Text.Trim();
            obj.EstadoPr = txtbEstado.Text.Trim();
            obj.CPPr = txtbCP.Text.Trim();
            obj.EstadoProveedor = cmbEstado.Text;

            string mensaje = "";

            if (cvProveedor.Editar(obj, out mensaje))
            {
                MessageBox.Show("Proveedor actualizado 😄");
                MostrarProveedores();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dtgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBuscarProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarProveedor.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProveedor.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscarProveedor.Text;
            string texto = txbProveedor.Text.Trim();

            List<Proveedor> resultado = new List<Proveedor>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busqueda.BuscarPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busqueda.BuscarPorNombre(texto);
            }
            else if (filtro == "Ciudad")
            {
                resultado = busqueda.BuscarPorCiudad(texto);
            }
            else if (filtro == "Estado")
            {
                resultado = busqueda.BuscarPorEstado(texto);
            }
            else if (filtro == "Estado Proveedor")
            {
                resultado = busqueda.BuscarPorEstadoProveedor(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void btnReiniciarProveedor_Click(object sender, EventArgs e)
        {
            MostrarProveedores();

            cmbBuscarProveedor.SelectedIndex = -1;
            txbProveedor.Text = "";
        }

        private void dtgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Id_Proveedor"].Value.ToString();

            txtbNombre.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["NombreEmpresa"].Value.ToString();

            txtRazon.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["RazonSocial"].Value.ToString();

            txtbCalle.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["CallePr"].Value.ToString();

            txtbNum.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["NumeroPr"].Value.ToString();

            txtbColonia.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["ColoniaPr"].Value.ToString();

            txtbCiudad.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["CiudadPr"].Value.ToString();

            txtbEstado.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["EstadoPr"].Value.ToString();

            txtbCP.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["CPPr"].Value.ToString();

            cmbEstado.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["EstadoProveedor"].Value.ToString();
        }
    }
}
