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
using static CapaMo.ConexChuy;

namespace Proyecto_Restaurante
{
    public partial class Categorias : Form
    {
        CL_Categoria objCategoria = new CL_Categoria();

        CV_Categoria cvCategoria = new CV_Categoria();

        B_Categoria busqueda = new B_Categoria();

        public Categorias()
        {
            InitializeComponent();
        }

        void MostrarCategorias()
        {
            dgvCategoria.DataSource = objCategoria.Listar();

            dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategoria.ReadOnly = true;
            dgvCategoria.AllowUserToAddRows = false;
            dgvCategoria.AllowUserToDeleteRows = false;
            dgvCategoria.AllowUserToResizeRows = false;
            dgvCategoria.MultiSelect = false;
        }

        void Limpiar()
        {
            lbl_Id.Text = "";
            rtxtboxDescripcion.Clear();
            cmBoxDisponible.Text = "Activo";
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            MostrarCategorias();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria obj = new Categoria();

            obj.Descripcion = rtxtboxDescripcion.Text;
            obj.Disponible = cmBoxDisponible.Text == "Activo";

            string mensaje = "";

            if (cvCategoria.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Categoría agregada correctamente 😄");

                MostrarCategorias();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una categoría 😄");
                return;
            }

            if (!int.TryParse(lbl_Id.Text, out int id))
            {
                MessageBox.Show("ID inválido 😄");
                return;
            }

            Categoria obj = new Categoria();

            obj.Id_Categoria = id;
            obj.Descripcion = rtxtboxDescripcion.Text;

            obj.Disponible = cmBoxDisponible.SelectedIndex == 0;

            string mensaje = "";

            if (cvCategoria.Editar(obj, out mensaje))
            {
                MessageBox.Show("Categoría actualizada 😄");

                MostrarCategorias();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dgvCategoria.Rows[e.RowIndex]
                .Cells["Id_Categoria"].Value.ToString();

            rtxtboxDescripcion.Text = dgvCategoria.Rows[e.RowIndex]
                .Cells["Descripcion"].Value.ToString();

            cmBoxDisponible.Text = Convert.ToInt32(
                dgvCategoria.Rows[e.RowIndex].Cells["Disponible"].Value
            ) == 1 ? "ACTIVO" : "INACTIVO";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = textBox1.Text.Trim();

            List<Categoria> resultado = new List<Categoria>();

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
            else if (filtro == "Descripción")
            {
                resultado = busqueda.BuscarPorDescripcion(texto);
            }
            else if (filtro == "Estado")
            {
                
                string input = texto.ToLower().Trim();

                if (input == "activo")
                    resultado = busqueda.BuscarPorEstado(true);
                else if (input == "inactivo")
                    resultado = busqueda.BuscarPorEstado(false);
                else
                {
                    MessageBox.Show("Escribe 'Activo' o 'Inactivo'", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (filtro == "Fecha")
            {
                if (DateTime.TryParse(texto, out DateTime fecha))
                    resultado = busqueda.BuscarPorFecha(fecha);
                else
                {
                    MessageBox.Show("Formato de fecha inválido (ej: 2026-05-31)", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            dgvCategoria.DataSource = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            CL_Categoria datos = new CL_Categoria();
            dgvCategoria.DataSource = datos.Listar();
        }
    }
}
