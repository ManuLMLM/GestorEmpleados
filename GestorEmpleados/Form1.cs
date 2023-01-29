using GestorEmpleados.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorEmpleados
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Departamentos Ventanadepas = new Departamentos();
            this.Close();//Cerrar Ventana
            Ventanadepas.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//Cerrar aplicación
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Empleados Ventanaempe = new Empleados();
            this.Close();//Cerrar Ventana
            Ventanaempe.Show();
        }
    }
}
