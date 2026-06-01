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
using Clie = CapaMo.Clientes;

namespace Proyecto_Restaurante
{
    public partial class Clientes : Form
    {
        CL_Clientes objCliente = new CL_Clientes();
        CV_Clientes cvCliente = new CV_Clientes();
        B_Clientes busqueda = new B_Clientes();
        public Clientes()
        {
            InitializeComponent();
        }

        void MostrarClientes()
        {
            dtgvCliente.DataSource = objCliente.Listar();

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
            txtbApellido.Clear();
            txtbCalle.Clear();
            txtColonia.Clear();
            txtbNumCasa.Clear();
            txtbCiudad.Clear();
            txtbEstado.Clear();
            txtbCP.Clear();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void txtColonia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbNumCasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCalle_TextChanged(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clie obj = new Clie();

            obj.NombreC = txtbNombre.Text.Trim();
            obj.ApellidoC = txtbApellido.Text.Trim();
            obj.Calle = txtbCalle.Text.Trim();
            obj.Colonia = txtColonia.Text.Trim();
            obj.NumCasa = txtbNumCasa.Text.Trim();
            obj.Ciudad = txtbCiudad.Text.Trim();
            obj.Estado = txtbEstado.Text.Trim();
            obj.CP = txtbCP.Text.Trim();

            string mensaje = "";

            if (cvCliente.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Cliente agregado 😄");
                MostrarClientes();
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
                MessageBox.Show("Selecciona un cliente");
                return;
            }

            string mensaje = "";

            if (cvCliente.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Cliente eliminado 😄");
                MostrarClientes();
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
                MessageBox.Show("Selecciona un cliente");
                return;
            }

            Clie obj = new Clie();

            obj.Id_Cliente = id;
            obj.NombreC = txtbNombre.Text.Trim();
            obj.ApellidoC = txtbApellido.Text.Trim();
            obj.Calle = txtbCalle.Text.Trim();
            obj.Colonia = txtColonia.Text.Trim();
            obj.NumCasa = txtbNumCasa.Text.Trim();
            obj.Ciudad = txtbCiudad.Text.Trim();
            obj.Estado = txtbEstado.Text.Trim();
            obj.CP = txtbCP.Text.Trim();

            string mensaje = "";

            if (cvCliente.Editar(obj, out mensaje))
            {
                MessageBox.Show("Cliente actualizado 😄");
                MostrarClientes();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        private void btnCorreo_Telefono_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarClientes();

            cmbBuscarCliente.SelectedIndex = -1;
            txbCliente.Text = "";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarCliente.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbCliente.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscarCliente.Text;
            string texto = txbCliente.Text.Trim();

            List<Clie> resultado = new List<Clie>();

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
            else if (filtro == "Apellido")
            {
                resultado = busqueda.BuscarPorApellido(texto);
            }
            else if (filtro == "Ciudad")
            {
                resultado = busqueda.BuscarPorCiudad(texto);
            }
            else if (filtro == "Estado")
            {
                resultado = busqueda.BuscarPorEstado(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void txbCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBuscarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Id_Cliente"].Value.ToString();

            txtbNombre.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["NombreC"].Value.ToString();

            txtbApellido.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["ApellidoC"].Value.ToString();

            txtbCalle.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Calle"].Value.ToString();

            txtColonia.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Colonia"].Value.ToString();

            txtbNumCasa.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["NumCasa"].Value.ToString();

            txtbCiudad.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Ciudad"].Value.ToString();

            txtbEstado.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Estado"].Value.ToString();

            txtbCP.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["CP"].Value.ToString();
        }
    }
}
