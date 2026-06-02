using Busqueda;
using CapaLo;
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
using Inv = CapaMo.Inventario;
using Ing = CapaMo.Ingredientes;

namespace Proyecto_Restaurante
{
    public partial class Inventario : Form
    {
        CL_Inventario objInventario = new CL_Inventario();
        CV_Inventario cvInventario = new CV_Inventario();
        B_Inventario busqueda = new B_Inventario();
        B_Ingredientes busquedaIngredientes = new B_Ingredientes();
        CL_Ingredientes objIngrediente = new CL_Ingredientes();
        public Inventario()
        {
            InitializeComponent();
        }
        void MostrarInventario()
        {
            dtgvCliente.DataSource = objInventario.Listar();

            dtgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCliente.ReadOnly = true;
            dtgvCliente.AllowUserToAddRows = false;
            dtgvCliente.AllowUserToDeleteRows = false;
            dtgvCliente.MultiSelect = false;
        }

        void MostrarIngredientes()
        {
            dataGridView1.DataSource = objIngrediente.Listar();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
        }


        private void Inventario_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarInventario();
            MostrarIngredientes();
        }

        void Limpiar()
        {
            txtStockMinimo.Text = "";
            txtbIdIngrediente.Text = "";
            dtpFecha.Value = DateTime.Now;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbIdIngrediente.Text, out int idIngrediente))
            {
                MessageBox.Show("Id invalido");
                return;
            }

            if (!decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo))
            {
                MessageBox.Show("Stock mínimo inválido");
                return;
            }

            Inv obj = new Inv();

            obj.Id_Ingrediente = idIngrediente;
            obj.StockMinimo = stockMinimo;
            obj.FechaRegistro = dtpFecha.Value;

            string mensaje = "";

            if (cvInventario.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Inventario registrado 😄");
                MostrarInventario();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdInventario.Text, out int id))
            {
                MessageBox.Show("Selecciona un producto");
                return;
            }

            string mensaje = "";

            if (cvInventario.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Producto eliminado 😄");
                MostrarInventario();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdInventario.Text, out int id))
            {
                MessageBox.Show("Selecciona un producto");
                return;
            }

            if (!int.TryParse(txtbIdIngrediente.Text, out int idIngrediente))
            {
                MessageBox.Show("Id ingrediente inválido");
                return;
            }

            if (!decimal.TryParse(txtStockMinimo.Text, out decimal stockMinimo))
            {
                MessageBox.Show("Stock mínimo inválido");
                return;
            }

            Inv obj = new Inv();

            obj.Id_Inventario = id;
            obj.Id_Ingrediente = idIngrediente;
            obj.StockMinimo = stockMinimo;
            obj.FechaRegistro = dtpFecha.Value;

            string mensaje = "";

            if (cvInventario.Editar(obj, out mensaje))
            {
                MessageBox.Show("Producto actualizado 😄");
                MostrarInventario();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscar.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Inv> resultado = new List<Inv>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorId(id);
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Ingrediente")
            {
                if (int.TryParse(texto, out int idIngrediente))
                {
                    resultado = busqueda.BuscarPorIngrediente(idIngrediente);
                }
                else
                {
                    MessageBox.Show("El ID del ingrediente debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Fecha")
            {
                if (DateTime.TryParse(texto, out DateTime fecha))
                {
                    resultado = busqueda.BuscarPorFecha(fecha);
                }
                else
                {
                    MessageBox.Show("Fecha inválida. Usa un formato válido.");
                    return;
                }
            }
            else if (filtro == "Stock")
            {
                if (decimal.TryParse(texto, out decimal stock))
                {
                    resultado = busqueda.BuscarPorStock(stock);
                }
                else
                {
                    MessageBox.Show("El stock debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Stock Minimo")
            {
                if (decimal.TryParse(texto, out decimal stockMinimo))
                {
                    resultado = busqueda.BuscarPorStockMinimo(stockMinimo);
                }
                else
                {
                    MessageBox.Show("El stock mínimo debe ser numérico");
                    return;
                }

                dtgvCliente.DataSource = resultado;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarInventario();
            cmbBuscar.SelectedIndex = -1;
            txbBuscar.Clear();
        }

        private void dtgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_IdInventario.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Id_Inventario"].Value.ToString();

            txtbIdIngrediente.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Id_Ingrediente"].Value.ToString();

            txtStockMinimo.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["StockMinimo"].Value.ToString();
        }

        private void cmbBuscarIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbBsucarIngrediente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReiniciarIngrediente_Click(object sender, EventArgs e)
        {
            MostrarIngredientes();

            cmbBuscarIngrediente.SelectedIndex = -1;
            txtbBsucarIngrediente.Clear();
        }

        private void btnBuscarIngrediente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarIngrediente.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbBsucarIngrediente.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Ing> resultado = new List<Ing>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busquedaIngredientes.BuscarPorId(id);
                else
                {
                    MessageBox.Show("El ID debe ser numérico", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busquedaIngredientes.BuscarPorNombre(texto);
            }
            else if (filtro == "Unidad")
            {
                resultado = busquedaIngredientes.BuscarPorUnidad(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
