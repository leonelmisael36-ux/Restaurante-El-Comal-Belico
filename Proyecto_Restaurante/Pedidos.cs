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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Restaurante
{
    public partial class Pedidos : Form
    {
        CL_Pedido objPedido = new CL_Pedido();
        CV_Pedido cvPedido = new CV_Pedido();
        B_Pedido busqueda = new B_Pedido();

        public Pedidos()
        {
            InitializeComponent();
        }

        void MostrarPedidos()
        {
            dtgvDetallePedido.DataSource = objPedido.Listar();

            dtgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDetallePedido.ReadOnly = true;
            dtgvDetallePedido.AllowUserToAddRows = false;
            dtgvDetallePedido.AllowUserToDeleteRows = false;
        }

        void Limpiar()
        {
            txtIdCliente.Clear();
            lbl_Id.Text = "";
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pedido obj = new Pedido();

            if (int.TryParse(txtIdCliente.Text, out int idCliente))
                obj.Id_Cliente = idCliente;

            obj.FechaPedido = DateTime.Now;

            string mensaje = "";

            if (cvPedido.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Pedido registrado 😄");
                MostrarPedidos();
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
                MessageBox.Show("Selecciona un pedido");
                return;
            }

            string mensaje = "";

            if (cvPedido.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Pedido eliminado 😄");
                MostrarPedidos();
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
                MessageBox.Show("Selecciona un pedido");
                return;
            }

            Pedido obj = new Pedido();

            obj.Id_Pedido = id;

            if (int.TryParse(txtIdCliente.Text, out int idCliente))
                obj.Id_Cliente = idCliente;

            obj.FechaPedido = DateTime.Now;

            string mensaje = "";

            if (cvPedido.Editar(obj, out mensaje))
            {
                MessageBox.Show("Pedido actualizado 😄");
                MostrarPedidos();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void cmbDetallePedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDetallePedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDetallePedido.Text))
            {
                MessageBox.Show("Selecciona un filtro");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDetallePedido.Text))
            {
                MessageBox.Show("Ingresa un valor");
                return;
            }

            string filtro = cmbDetallePedido.Text;
            string texto = txtDetallePedido.Text.Trim();

            List<Pedido> resultado = new List<Pedido>();

            if (filtro == "ID Pedido")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorId(id);
                else
                {
                    MessageBox.Show("ID inválido");
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
            else if (filtro == "Total")
            {
                if (decimal.TryParse(texto, out decimal total))
                    resultado = busqueda.BuscarPorTotal(total);
                else
                {
                    MessageBox.Show("Total inválido");
                    return;
                }
            }
            else if (filtro == "Cliente")
            {
                if (int.TryParse(texto, out int idCliente))
                    resultado = busqueda.BuscarPorCliente(idCliente);
                else
                {
                    MessageBox.Show("Cliente inválido");
                    return;
                }
            }

            dtgvDetallePedido.DataSource = resultado;
        }

        private void btnReiniciarDetallePedido_Click(object sender, EventArgs e)
        {
            MostrarPedidos();
            cmbDetallePedido.SelectedIndex = -1;
            txtDetallePedido.Clear();
        }

        private void Pedidos_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }

        private void dtgvDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvDetallePedido.Rows[e.RowIndex]
                .Cells["Id_Pedido"].Value.ToString();

            txtIdCliente.Text = dtgvDetallePedido.Rows[e.RowIndex]
                .Cells["Id_Cliente"].Value.ToString();
        }
    }
}
