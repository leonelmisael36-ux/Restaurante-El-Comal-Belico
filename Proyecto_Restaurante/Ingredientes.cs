using Busqueda;
using CapaLo;
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
using CapaMo;
using Ing = CapaMo.Ingredientes;


namespace Proyecto_Restaurante
{
    public partial class Ingredientes : Form
    {
        CL_Ingredientes objIngrediente = new CL_Ingredientes();
        CV_Ingredientes cvIngrediente = new CV_Ingredientes();
        B_Ingredientes busqueda = new B_Ingredientes();
        

        public Ingredientes()
        {
            InitializeComponent();
        }
        void MostrarIngredientes()
        {
            dtgvCliente.DataSource = objIngrediente.Listar();

            dtgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCliente.ReadOnly = true;
            dtgvCliente.AllowUserToAddRows = false;
            dtgvCliente.AllowUserToDeleteRows = false;
            dtgvCliente.MultiSelect = false;
        }

        private void Ingredientes_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Usuario: {Sesion.NombreUsuario}    Rol: {Sesion.Rol}";

            MostrarIngredientes();
        }

        void Limpiar()
        {
            lbl_Id.Text = "";
            txtbIngrediente.Clear();
            cmBoxUnidad.Text = "";
        }

        private void txtbIngrediente_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmBoxDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ing obj = new Ing();

            obj.Nombre = txtbIngrediente.Text;
            obj.Unidad = cmBoxUnidad.Text;

            string mensaje = "";

            if (cvIngrediente.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Ingrediente agregado 😄");
                MostrarIngredientes();
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
                MessageBox.Show("Selecciona un ingrediente");
                return;
            }

            string mensaje = "";

            if (cvIngrediente.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Ingrediente eliminado 😄");
                MostrarIngredientes();
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
                MessageBox.Show("Selecciona un ingrediente");
                return;
            }

            Ing obj = new Ing();

            obj.Id_Ingrediente = id;
            obj.Nombre = txtbIngrediente.Text;
            obj.Unidad = cmBoxUnidad.Text;

            string mensaje = "";

            if (cvIngrediente.Editar(obj, out mensaje))
            {
                MessageBox.Show("Ingrediente actualizado 😄");
                MostrarIngredientes();
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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda", "Validación");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscar.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar", "Validación");
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Ing> resultado = new List<Ing>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                    resultado = busqueda.BuscarPorId(id);
                else
                {
                    MessageBox.Show("El ID debe ser numérico", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busqueda.BuscarPorNombre(texto);
            }
            else if (filtro == "Unidad")
            {
                resultado = busqueda.BuscarPorUnidad(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarIngredientes();
            cmbBuscar.SelectedIndex = -1;
            txbBuscar.Clear();
        }

        private void dtgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Id_Ingrediente"].Value.ToString();

            txtbIngrediente.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Nombre"].Value.ToString();

            cmBoxUnidad.Text = dtgvCliente.Rows[e.RowIndex]
                .Cells["Unidad"].Value.ToString();
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
