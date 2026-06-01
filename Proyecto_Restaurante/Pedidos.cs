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
        CL_Detalle_Pedido clDetalle = new CL_Detalle_Pedido();
        CV_Detalle_Pedido cvDetalle = new CV_Detalle_Pedido();

        CL_Pedido clPedido = new CL_Pedido();
        CV_Pedido cvPedido = new CV_Pedido();
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {

        }

        private void txtbIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void cmbBuscarPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbPedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {

        }

        private void cmbDetallePedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDetallePedido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {

        }

        private void btnReiniciarDetallePedido_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
