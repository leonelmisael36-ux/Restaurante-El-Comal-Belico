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
    public partial class Registros_Pedidos : Form
    {
        CL_Detalle_Pedido objDetalle = new CL_Detalle_Pedido();
        CV_Detalle_Pedido cvDetalle = new CV_Detalle_Pedido();
        B_Detalle_Pedido busqueda = new B_Detalle_Pedido();
        B_Tipo_Platillo_Union busquedaUnion = new B_Tipo_Platillo_Union();
        CV_Pedido objPedido = new CV_Pedido();
        B_ConsultasAvanzadas busquedaAvanzada = new B_ConsultasAvanzadas();

        public Registros_Pedidos()
        {
            InitializeComponent();
        }

        void MostrarTipo()
        {
            B_Tipo_Platillo_Union datos = new B_Tipo_Platillo_Union();

            dtgvTipo.DataSource = datos.ListarUnido();

            dtgvTipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTipo.ReadOnly = true;
            dtgvTipo.AllowUserToAddRows = false;
            dtgvTipo.AllowUserToDeleteRows = false;
        }
        void MostrarDetalle()
        {
            dtgvPedido.DataSource = objDetalle.Listar();

            dtgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPedido.ReadOnly = true;
            dtgvPedido.AllowUserToAddRows = false;
            dtgvPedido.AllowUserToDeleteRows = false;
            dtgvPedido.MultiSelect = false;
        }

        void Limpiar()
        {
            txtbIdPedido.Clear();
            txtIdTipo.Clear();
            txtCantidad.Clear();
            lbl_Id.Text = "";
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbIdPedido.Text, out int idPedido))
            {
                MessageBox.Show("ID Pedido inválido");
                return;
            }

            if (!int.TryParse(txtIdTipo.Text, out int idTipo))
            {
                MessageBox.Show("ID Tipo inválido");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            Detalle_Pedido obj = new Detalle_Pedido()
            {
                Id_Pedido = idPedido,
                Id_Tipo = idTipo,
                Cantidad = cantidad
            };

            string mensaje = "";

            if (cvDetalle.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Detalle agregado 😄");
                objPedido.ActualizarTotal(idPedido);
                MostrarDetalle();
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
                MessageBox.Show("Selecciona un detalle");
                return;
            }

            Detalle_Pedido obj = new Detalle_Pedido()
            {
                Id_Detalle = id,
                Id_Pedido = int.Parse(txtbIdPedido.Text),
                Id_Tipo = int.Parse(txtIdTipo.Text),
                Cantidad = int.Parse(txtCantidad.Text)
            };

            string mensaje = "";

            if (cvDetalle.Editar(obj, out mensaje))
            {
                MessageBox.Show("Detalle actualizado 😄");

                objPedido.ActualizarTotal(obj.Id_Pedido); 

                MostrarDetalle();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registros_Pedidos_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarDetalle();
            MostrarTipo();

            cmbBuscarPedido.Items.Clear();

            cmbBuscarPedido.Items.Add("ID Detalle");
            cmbBuscarPedido.Items.Add("ID Pedido");
            cmbBuscarPedido.Items.Add("Tipo Platillo");
            cmbBuscarPedido.Items.Add("Fecha");
            cmbBuscarPedido.Items.Add("Detalle Completo");
            cmbBuscarPedido.Items.Add("Pedido Completo");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_Id.Text, out int idDetalle))
            {
                MessageBox.Show("Selecciona un detalle");
                return;
            } 

            int idPedido = Convert.ToInt32(
                dtgvPedido.Rows[dtgvPedido.CurrentRow.Index]
                .Cells["Id_Pedido"].Value
            );

            string mensaje = "";

            if (cvDetalle.Eliminar(idDetalle, out mensaje))
            {
                MessageBox.Show("Eliminado 😄");

                objPedido.ActualizarTotal(idPedido);

                MostrarDetalle();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void cmbBuscarPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbPedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarPedido.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            string filtro = cmbBuscarPedido.Text;

            if (filtro == "Detalle Completo")
            {
                dtgvPedido.DataSource = busquedaAvanzada.DetallePedidoPlatillo();
                return;
            }
            else if (filtro == "Pedido Completo")
            {
                dtgvPedido.DataSource = busquedaAvanzada.PedidoCompleto();
                return;
            }
            else if (filtro == "Ranking Platillos")
            {
                dtgvPedido.DataSource = busquedaAvanzada.RankingPlatillos();
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPedido.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string texto = txbPedido.Text.Trim();

            List<Detalle_Pedido> resultado = new List<Detalle_Pedido>();

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
            else if (filtro == "ID Pedido")
            {
                if (int.TryParse(texto, out int idPedido))
                    resultado = busqueda.BuscarPorPedido(idPedido);
                else
                {
                    MessageBox.Show("ID Pedido inválido");
                    return;
                }
            }
            else if (filtro == "Tipo Platillo")
            {
                if (int.TryParse(texto, out int idTipo))
                    resultado = busqueda.BuscarPorTipo(idTipo);
                else
                {
                    MessageBox.Show("Tipo inválido");
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

            dtgvPedido.DataSource = resultado;
        }

        private void btnReiniciarPedido_Click(object sender, EventArgs e)
        {
            MostrarDetalle();

            txbPedido.Clear();
            cmbBuscarPedido.SelectedIndex = -1;
        }

        private void dtgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarTipo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscarPedido.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPedido.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscarPedido.Text;
            string texto = txbPedido.Text.Trim();

            List<Detalle_Pedido> resultado = new List<Detalle_Pedido>();

            if (filtro == "ID Detalle")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorIdDetalle(id);
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "ID Pedido")
            {
                if (int.TryParse(texto, out int idPedido))
                    resultado = busqueda.BuscarPorPedido(idPedido);
                else
                {
                    MessageBox.Show("El ID Pedido debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Tipo Platillo")
            {
                if (int.TryParse(texto, out int idTipo))
                    resultado = busqueda.BuscarPorTipo(idTipo);
                else
                {
                    MessageBox.Show("El ID Tipo debe ser numérico");
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

            dtgvPedido.DataSource = resultado;
        }

        private void btnReiniciarTipo_Click(object sender, EventArgs e)
        {
            MostrarDetalle();

            txbPedido.Clear();
            cmbBuscarPedido.SelectedIndex = -1;
        }

        private void dtgvTipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvPedido.Rows[e.RowIndex]
                .Cells["Id_Detalle"].Value.ToString();

            txtbIdPedido.Text = dtgvPedido.Rows[e.RowIndex]
                .Cells["Id_Pedido"].Value.ToString();

            txtIdTipo.Text = dtgvPedido.Rows[e.RowIndex]
                .Cells["Id_Tipo"].Value.ToString();

            txtCantidad.Text = dtgvPedido.Rows[e.RowIndex]
                .Cells["Cantidad"].Value.ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Pedidos frm = new Pedidos();
            frm.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
