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
    public partial class Entrega_Inventario : Form
    {
        CL_Detalle_Proveedor objDetalle = new CL_Detalle_Proveedor();
        CV_Detalle_Proveedor cvDetalle = new CV_Detalle_Proveedor();
        B_Detalle_Proveedor busqueda = new B_Detalle_Proveedor();
        public Entrega_Inventario()
        {
            InitializeComponent();
        }

        void MostrarEntrega()
        {
            dtgvEntrega.DataSource = objDetalle.Listar();

            dtgvEntrega.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvEntrega.ReadOnly = true;
            dtgvEntrega.AllowUserToAddRows = false;
            dtgvEntrega.AllowUserToDeleteRows = false;
        }

        void Limpiar()
        {
            txtIdProveedor.Clear();
            txtIdIngrediente.Clear();
            txtCantidad.Clear();
        }
        private void txtIdProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdIngrediente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdProveedor.Text, out int idProveedor))
            {
                MessageBox.Show("Proveedor inválido");
                return;
            }

            if (!int.TryParse(txtIdIngrediente.Text, out int idIngrediente))
            {
                MessageBox.Show("Ingrediente inválido");
                return;
            }

            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad))
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            Detalle_Proveedor obj = new Detalle_Proveedor()
            {
                Id_Proveedor = idProveedor,
                Id_Ingrediente = idIngrediente,
                Cantidad = cantidad,
                Fecha = DateTime.Today
            };

            string mensaje = "";

            if (cvDetalle.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Entrega registrada 😄");
                MostrarEntrega();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dtgvEntrega.CurrentRow.Cells["Id_DetalleProveedor"].Value.ToString(), out int id))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            Detalle_Proveedor obj = new Detalle_Proveedor()
            {
                Id_DetalleProveedor = id,
                Id_Proveedor = int.Parse(txtIdProveedor.Text),
                Id_Ingrediente = int.Parse(txtIdIngrediente.Text),
                Cantidad = decimal.Parse(txtCantidad.Text),
                Fecha = DateTime.Today
            };

            string mensaje = "";

            if (cvDetalle.Editar(obj, out mensaje))
            {
                MessageBox.Show("Actualizado 😄");
                MostrarEntrega();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dtgvEntrega.CurrentRow.Cells["Id_DetalleProveedor"].Value.ToString(), out int id))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            string mensaje = "";

            if (cvDetalle.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Eliminado 😄");
                MostrarEntrega();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void cmbEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEntrega_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = cmbEntrega.Text;
            string texto = txtEntrega.Text.Trim();

            List<Detalle_Proveedor> resultado = new List<Detalle_Proveedor>();

            if (filtro == "ID Detalle")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorIdDetalle(id);
            }
            else if (filtro == "Proveedor")
            {
                if (int.TryParse(texto, out int idProv))
                    resultado = busqueda.BuscarPorIdProveedor(idProv);
            }
            else if (filtro == "Ingrediente")
            {
                if (int.TryParse(texto, out int idIng))
                    resultado = busqueda.BuscarPorIdIngrediente(idIng);
            }
            else if (filtro == "Fecha")
            {
                if (DateTime.TryParse(texto, out DateTime fecha))
                    resultado = busqueda.BuscarPorFecha(fecha);
            }
            else if (filtro == "Cantidad")
            {
                if (decimal.TryParse(texto, out decimal cant))
                    resultado = busqueda.BuscarPorCantidad(cant);
            }

            dtgvEntrega.DataSource = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarEntrega();
            txtEntrega.Clear();
            cmbEntrega.SelectedIndex = -1;
        }

        private void dtgvEntrega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Entrega_Inventario_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarEntrega();

            cmbEntrega.Items.Clear();
            cmbEntrega.Items.Add("ID Detalle");
            cmbEntrega.Items.Add("Proveedor");
            cmbEntrega.Items.Add("Ingrediente");
            cmbEntrega.Items.Add("Fecha");
            cmbEntrega.Items.Add("Cantidad");
        }

        private void dtgvEntrega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dtgvEntrega.Rows[e.RowIndex];

            txtIdProveedor.Text = fila.Cells["Id_Proveedor"].Value.ToString();
            txtIdIngrediente.Text = fila.Cells["Id_Ingrediente"].Value.ToString();
            txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Inventario frm = new Inventario();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
