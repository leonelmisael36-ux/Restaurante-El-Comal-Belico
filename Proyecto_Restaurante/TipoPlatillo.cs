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
using Pla = CapaMo.Platillo;

namespace Proyecto_Restaurante
{
    public partial class TipoPlatillo : Form
    {
        CL_Tipo_Platillo objTipoPlatillo = new CL_Tipo_Platillo();
        CV_Tipo_Platillo cvTipoPlatillo = new CV_Tipo_Platillo();
        B_Tipo_Platillo busqueda = new B_Tipo_Platillo();
        CL_Platillo objPlatillo = new CL_Platillo();
        B_Platillo busquedaPlatillo = new B_Platillo();
        public TipoPlatillo()
        {
            InitializeComponent();
        }

        void MostrarTipoPlatillo()
        {
            dgvTipo.DataSource = objTipoPlatillo.Listar();

            dgvTipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipo.ReadOnly = true;
            dgvTipo.AllowUserToAddRows = false;
            dgvTipo.AllowUserToDeleteRows = false;
            dgvTipo.MultiSelect = false;
        }

        void MostrarPlatillos()
        {
            dataGridView1.DataSource = objPlatillo.Listar();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
        }

        void Limpiar()
        {
            lbl_Id.Text = "";
            txtbIdIngrediente.Clear();
            cmBoxTamaño.Text = "";
            rtxtboxDescripcion.Clear();
        }

        private void TipoPlatillo_Load(object sender, EventArgs e)
        {
            MostrarTipoPlatillo();
            MostrarPlatillos();
        }

        private void txtbIdIngrediente_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtboxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmBoxTamaño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbIdIngrediente.Text, out int idPlatillo))
            {
                MessageBox.Show("ID de platillo inválido");
                return;
            }

            Tipo_Platillo obj = new Tipo_Platillo();

            obj.Id_Platillo = idPlatillo;
            obj.Tamaño = cmBoxTamaño.Text;
            obj.TipoPreparacion = rtxtboxDescripcion.Text;

            string mensaje = "";

            if (cvTipoPlatillo.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Tipo de platillo agregado 😄");
                MostrarTipoPlatillo();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_Id.Text, out int idTipo))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            if (!int.TryParse(txtbIdIngrediente.Text, out int idPlatillo))
            {
                MessageBox.Show("ID de platillo inválido");
                return;
            }

            Tipo_Platillo obj = new Tipo_Platillo();

            obj.Id_Tipo = idTipo;
            obj.Id_Platillo = idPlatillo;
            obj.Tamaño = cmBoxTamaño.Text;
            obj.TipoPreparacion = rtxtboxDescripcion.Text;

            string mensaje = "";

            if (cvTipoPlatillo.Editar(obj, out mensaje))
            {
                MessageBox.Show("Tipo de platillo actualizado 😄");
                MostrarTipoPlatillo();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarTipoPlatillo();

            cmbBuscar.SelectedIndex = -1;
            txtBuscar.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txtBuscar.Text.Trim();

            List<Tipo_Platillo> resultado = new List<Tipo_Platillo>();

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
            else if (filtro == "Platillo")
            {
                if (int.TryParse(texto, out int idPlatillo))
                {
                    resultado = busqueda.BuscarPorPlatillo(idPlatillo);
                }
                else
                {
                    MessageBox.Show("El ID del platillo debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Tamaño")
            {
                resultado = busqueda.BuscarPorTamano(texto);
            }
            else if (filtro == "Preparación")
            {
                resultado = busqueda.BuscarPorPreparacion(texto);
            }

            dgvTipo.DataSource = resultado;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvTipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            lbl_Id.Text = dgvTipo.Rows[e.RowIndex]
                .Cells["Id_Tipo"].Value.ToString();

            txtbIdIngrediente.Text = dgvTipo.Rows[e.RowIndex]
                .Cells["Id_Platillo"].Value.ToString();

            cmBoxTamaño.Text = dgvTipo.Rows[e.RowIndex]
                .Cells["Tamaño"].Value.ToString();

            rtxtboxDescripcion.Text = dgvTipo.Rows[e.RowIndex]
                .Cells["TipoPreparacion"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
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

            string filtro = comboBox1.Text;
            string texto = textBox1.Text.Trim();

            List<Pla> resultado = new List<Pla>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busquedaPlatillo.BuscarPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busquedaPlatillo.BuscarPorNombre(texto);
            }
            else if (filtro == "Descripción")
            {
                resultado = busquedaPlatillo.BuscarPorDescripcion(texto);
            }
            else if (filtro == "Categoria")
            {
                if (int.TryParse(texto, out int idCat))
                {
                    resultado = busquedaPlatillo.BuscarPorCategoria(idCat);
                }
                else
                {
                    MessageBox.Show("La categoría debe ser numérica (ID)", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (filtro == "Precio")
            {
                if (decimal.TryParse(texto, out decimal precio))
                {
                    resultado = busquedaPlatillo.BuscarPorPrecio(precio);
                }
                else
                {
                    MessageBox.Show("El precio debe ser numérico", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            dataGridView1.DataSource = resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarPlatillos();

            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
        }
    }
}
