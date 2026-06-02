using CapaMo;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
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
    public partial class Pantalla_Principalcs : Form
    {
        public Pantalla_Principalcs()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Categorias frm = new Categorias();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventario frm = new Inventario();
            this.Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Entrega_Inventario frm = new Entrega_Inventario();
            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ingredientes frm = new Ingredientes();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pedidos frm = new Pedidos();
            this.Hide();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Platillo frm = new Platillo();
            this.Hide();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TipoPlatillo frm = new TipoPlatillo();
            this.Hide();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Sesion.Rol != "Administrador")
            {
                MessageBox.Show("No tienes permisos para acceder aquí");

            }
            else
            {
                Administracion frm = new Administracion();
                this.Hide();
                frm.Show();
            }
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Sesion.Rol != "Administrador")
            {
                MessageBox.Show("No tienes permisos para acceder aquí");

            }
            else
            {
                Proveedores frm = new Proveedores();
                this.Hide();
                frm.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Pantalla_Principalcs_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";
        }
    }
}
