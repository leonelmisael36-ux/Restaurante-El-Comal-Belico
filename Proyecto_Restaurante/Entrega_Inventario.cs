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
        B_Proveedor busquedaPro = new B_Proveedor();
        CL_Proveedor objProveedor = new CL_Proveedor();
        CL_Inventario objInventario = new CL_Inventario();
        B_ConsultasAvanzadas busquedaAvanzada = new B_ConsultasAvanzadas();
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
                objInventario.AumentarStock(idIngrediente, cantidad);

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

        }

        private void cmbEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEntrega_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbEntrega.Text))
            {
                MessageBox.Show("Selecciona un filtro");
                return;
            }

            string filtro = cmbEntrega.Text;

            if (filtro == "Ordenar por Cantidad")
            {
                dtgvEntrega.DataSource = busqueda.OrdenarPorCantidad();
                return;
            }
            else if (filtro == "Entregas + Proveedor")
            {
                dtgvEntrega.DataSource = busquedaAvanzada.ProveedorEntregas();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEntrega.Text))
            {
                MessageBox.Show("Ingresa un valor");
                return;
            }

            string texto = txtEntrega.Text.Trim();

            List<Detalle_Proveedor> resultado = new List<Detalle_Proveedor>();

            if (filtro == "ID Detalle")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorIdDetalle(id);
                else
                {
                    MessageBox.Show("ID inválido");
                    return;
                }
            }
            else if (filtro == "Proveedor")
            {
                if (int.TryParse(texto, out int idProv))
                    resultado = busqueda.BuscarPorIdProveedor(idProv);
                else
                {
                    MessageBox.Show("Proveedor inválido");
                    return;
                }
            }
            else if (filtro == "Ingrediente")
            {
                if (int.TryParse(texto, out int idIng))
                    resultado = busqueda.BuscarPorIdIngrediente(idIng);
                else
                {
                    MessageBox.Show("Ingrediente inválido");
                    return;
                }
            }
            else if (filtro == "Fecha")
            {
                if (DateTime.TryParse(texto, out DateTime fecha))
                    resultado = busqueda.BuscarPorFecha(fecha);
                else
                {
                    MessageBox.Show("Fecha inválida");
                    return;
                }
            }
            else if (filtro == "Cantidad")
            {
                if (decimal.TryParse(texto, out decimal cant))
                    resultado = busqueda.BuscarPorCantidad(cant);
                else
                {
                    MessageBox.Show("Cantidad inválida");
                    return;
                }
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

        void MostrarProveedores()
        {
            dtgvCliente.DataSource = objProveedor.Listar();

            dtgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCliente.ReadOnly = true;
            dtgvCliente.AllowUserToAddRows = false;
            dtgvCliente.AllowUserToDeleteRows = false;
            dtgvCliente.MultiSelect = false;
        }

        private void Entrega_Inventario_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarEntrega();
            MostrarProveedores();

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
            Pantalla_Principalcs frm = new Pantalla_Principalcs();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                    resultado = busquedaPro.BuscarPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busquedaPro.BuscarPorNombre(texto);
            }
            else if (filtro == "Ciudad")
            {
                resultado = busquedaPro.BuscarPorCiudad(texto);
            }
            else if (filtro == "Estado")
            {
                resultado = busquedaPro.BuscarPorEstado(texto);
            }
            else if (filtro == "Estado Proveedor")
            {
                resultado = busquedaPro.BuscarPorEstadoProveedor(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void btnReiniciarProveedor_Click(object sender, EventArgs e)
        {
            MostrarProveedores();

            cmbBuscarProveedor.SelectedIndex = -1;
            txbProveedor.Text = "";
        }

        private void dtgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(dtgvEntrega.CurrentRow.Cells["Id_DetalleProveedor"].Value.ToString(), out int id))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            if (!int.TryParse(dtgvEntrega.CurrentRow.Cells["Id_DetalleProveedor"].Value.ToString(), out int idDetalle))
            {
                MessageBox.Show("ID inválido");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Seguro que deseas eliminar esta entrega?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            int idIngrediente = Convert.ToInt32(dtgvEntrega.CurrentRow.Cells["Id_Ingrediente"].Value);
            decimal cantidad = Convert.ToDecimal(dtgvEntrega.CurrentRow.Cells["Cantidad"].Value);

            bool stockActualizado = objInventario.DisminuirStock(idIngrediente, cantidad);

            bool eliminado = objDetalle.Eliminar(idDetalle);

            if (eliminado)
            {
                MessageBox.Show("Entrega eliminada correctamente 😄");
                MostrarEntrega();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al eliminar la entrega");
            }
        }
    }
}
