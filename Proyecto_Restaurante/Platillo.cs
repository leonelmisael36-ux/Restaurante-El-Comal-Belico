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
using Pla = CapaMo.Platillo;

namespace Proyecto_Restaurante
{
    public partial class Platillo : Form
    {
        CL_Platillo objPlatillo = new CL_Platillo();
        CV_Platillo cvPlatillo = new CV_Platillo();
        B_Platillo busqueda = new B_Platillo();
        public Platillo()
        {
            InitializeComponent();
        }

        void MostrarPlatillos()
        {
            dtgvPlatillo.DataSource = objPlatillo.Listar();

            dtgvPlatillo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvPlatillo.ReadOnly = true;
            dtgvPlatillo.AllowUserToAddRows = false;
            dtgvPlatillo.AllowUserToDeleteRows = false;
            dtgvPlatillo.MultiSelect = false;
        }

        void Limpiar()
        {
            lbl_Id.Text = "";
            txtbNombre.Clear();
            rtxtboxDescripcion.Clear();
            nudPrecioVenta.Value = 0;
            txtbIdcategoria.Clear();
        }



        private void nudPrecioVenta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtbIdcategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtboxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Platillo_Load(object sender, EventArgs e)
        {
            nudPrecioVenta.DecimalPlaces = 2;
            nudPrecioVenta.Minimum = 0;
            nudPrecioVenta.Maximum = 100000;

            MostrarPlatillos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Pla obj = new Pla();

            obj.Nombre_Platillo = txtbNombre.Text;
            obj.Descripcion = rtxtboxDescripcion.Text;
            obj.Precio_Venta = nudPrecioVenta.Value;
            obj.Id_Categoria = Convert.ToInt32(txtbIdcategoria.Text);

            string mensaje = "";

            if (cvPlatillo.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Platillo agregado 😄");
                MostrarPlatillos();
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
                MessageBox.Show("Selecciona un platillo");
                return;
            }

            Pla obj = new Pla();

            obj.Id_Platillo = id;
            obj.Nombre_Platillo = txtbNombre.Text;
            obj.Descripcion = rtxtboxDescripcion.Text;
            obj.Precio_Venta = nudPrecioVenta.Value;
            obj.Id_Categoria = Convert.ToInt32(txtbIdcategoria.Text);

            string mensaje = "";

            if (cvPlatillo.Editar(obj, out mensaje))
            {
                MessageBox.Show("Platillo actualizado 😄");
                MostrarPlatillos();
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
                MessageBox.Show("Selecciona un platillo");
                return;
            }

            string mensaje = "";

            if (cvPlatillo.Eliminar(id, out mensaje))
            {
                MessageBox.Show("Platillo eliminado 😄");
                MostrarPlatillos();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarPlatillos();

            cmbBuscar.SelectedIndex = -1;
            txbBuscar.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscar.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Pla> resultado = new List<Pla>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busqueda.BuscarPorId(id);
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
                resultado = busqueda.BuscarPorNombre(texto);
            }
            else if (filtro == "Descripción")
            {
                resultado = busqueda.BuscarPorDescripcion(texto);
            }
            else if (filtro == "Categoria")
            {
                if (int.TryParse(texto, out int idCat))
                {
                    resultado = busqueda.BuscarPorCategoria(idCat);
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
                    resultado = busqueda.BuscarPorPrecio(precio);
                }
                else
                {
                    MessageBox.Show("El precio debe ser numérico", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            dtgvPlatillo.DataSource = resultado;
        }
    }
}
