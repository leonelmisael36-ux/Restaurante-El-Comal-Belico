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
using Prov = CapaMo.Provee;
using Pla = CapaMo.Platillo;
using Prove = CapaMo.Proveedor;


namespace Proyecto_Restaurante
{
    public partial class Provee : Form
    {
        CL_Provee objProveedorIngrediente = new CL_Provee();
        CV_Provee cvProveedorIngrediente = new CV_Provee();
        B_Provee busqueda = new B_Provee();
        CL_Platillo objPlatillo = new CL_Platillo();
        B_Platillo busquedaPlatillo = new B_Platillo();
        CL_Proveedor objProveedor = new CL_Proveedor();
        B_Proveedor busquedaProveedor = new B_Proveedor();

        private int proveedorOriginal;
        private int platilloOriginal;
        public Provee()
        {
            InitializeComponent();
        }

        void MostrarProveedorIngrediente()
        {
            dtgvCliente.DataSource = objProveedorIngrediente.Listar();

            dtgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCliente.ReadOnly = true;
            dtgvCliente.AllowUserToAddRows = false;
            dtgvCliente.AllowUserToDeleteRows = false;
            dtgvCliente.MultiSelect = false;
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

        void MostrarProveedores()
        {
            dataGridView2.DataSource = objProveedor.Listar();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.MultiSelect = false;
        }

        void Limpiar()
        {
            lbl_IdProveedor.Text = "";
            lbl_IdPlatillo.Text = "";
            txtbId_Proveedor.Clear();
            txtbId_Platillo.Clear();
        }


        private void txtbId_Proveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbId_Platillo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtbId_Proveedor.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            if (!int.TryParse(txtbId_Platillo.Text, out int idIngrediente))
            {
                MessageBox.Show("ID ingrediente inválido");
                return;
            }

            Prov obj = new Prov();

            obj.Id_Proveedor = idProveedor;
            obj.Id_Platillo = idIngrediente;

            string mensaje = "";

            if (cvProveedorIngrediente.Registrar(obj, out mensaje))
            {
                MessageBox.Show("Registro agregado 😄");
                MostrarProveedorIngrediente();
                Limpiar();
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lbl_IdProveedor.Text, out int id))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            if (!int.TryParse(txtbId_Proveedor.Text, out int idProveedor))
            {
                MessageBox.Show("ID proveedor inválido");
                return;
            }

            if (!int.TryParse(txtbId_Platillo.Text, out int idIngrediente))
            {
                MessageBox.Show("ID ingrediente inválido");
                return;
            }

            Prov obj = new Prov();

            obj.Id_Proveedor = idProveedor;
            obj.Id_Platillo = idIngrediente;

            string mensaje = "";

            if (cvProveedorIngrediente.Editar(obj,
                                proveedorOriginal,
                                platilloOriginal,
                                out mensaje))
            {
                MessageBox.Show("Registro actualizado");
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(txtbId_Proveedor.Text);
            int idPlatillo = int.Parse(txtbId_Platillo.Text);

            if (!int.TryParse(lbl_IdProveedor.Text, out int id))
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            string mensaje = "";


            if (cvProveedorIngrediente.Eliminar(idProveedor,
                                  idPlatillo,
                                  out mensaje))
            {
                MessageBox.Show("Registro eliminado");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbBuscar.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbBuscar.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = cmbBuscar.Text;
            string texto = txbBuscar.Text.Trim();

            List<Prov> resultado = new List<Prov>();

            if (filtro == "ID Proveedor")
            {
                if (int.TryParse(texto, out int idProveedor))
                    resultado = busqueda.BuscarPorProveedor(idProveedor);
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Nombre Proveedor")
            {
                resultado = busqueda.BuscarPorNombreProveedor(texto);
            }
            else if (filtro == "ID Ingrediente")
            {
                if (int.TryParse(texto, out int idIngrediente))
                    resultado = busqueda.BuscarPorPlatillo(idIngrediente);
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Nombre Ingrediente")
            {
                resultado = busqueda.BuscarPorNombrePlatillo(texto);
            }

            dtgvCliente.DataSource = resultado;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            MostrarProveedorIngrediente();
            cmbBuscar.SelectedIndex = -1;
            txbBuscar.Text = "";
        }

        private void Provee_Load_1(object sender, EventArgs e)
        {
            MostrarProveedorIngrediente();
            MostrarPlatillos();
        }

        private void dtgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            proveedorOriginal = Convert.ToInt32(
                dtgvCliente.Rows[e.RowIndex].Cells["Id_Proveedor"].Value);

            platilloOriginal = Convert.ToInt32(
                dtgvCliente.Rows[e.RowIndex].Cells["Id_Platillo"].Value);

            txtbId_Proveedor.Text = proveedorOriginal.ToString();
            txtbId_Platillo.Text = platilloOriginal.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Selecciona un tipo de búsqueda");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa un valor para buscar");
                return;
            }

            string filtro = comboBox1.Text;
            string texto = textBox1.Text.Trim();

            List<Prove> resultado = new List<Prove>();

            if (filtro == "ID")
            {
                if (int.TryParse(texto, out int id))
                {
                    resultado = busquedaProveedor.BuscarPorId(id);
                }
                else
                {
                    MessageBox.Show("El ID debe ser numérico");
                    return;
                }
            }
            else if (filtro == "Nombre")
            {
                resultado = busquedaProveedor.BuscarPorNombre(texto);
            }
            else if (filtro == "Ciudad")
            {
                resultado = busquedaProveedor.BuscarPorCiudad(texto);
            }
            else if (filtro == "Estado")
            {
                resultado = busquedaProveedor.BuscarPorEstado(texto);
            }
            else if (filtro == "Estado Proveedor")
            {
                resultado = busquedaProveedor.BuscarPorEstadoProveedor(texto);
            }

            dataGridView1.DataSource = resultado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarProveedores();

            textBox1.Text = "";
            comboBox2.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarPlatillos();

            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
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
