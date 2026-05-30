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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            bool exito = conexion.ProbarConexion();
            if (exito)
            {
                MessageBox.Show("conexion exitosa");
            } else
            {
                MessageBox.Show("error");
            }
                

                    
        }
    }
}
