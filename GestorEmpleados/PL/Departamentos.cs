using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorEmpleados.BLL;
using GestorEmpleados.DAL;

namespace GestorEmpleados.PL
{
    public partial class Departamentos : Form
    {
        
        public Departamentos()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text !="" && cmId.Text == "") {
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var lista = new DAL.Departamentos();
                    lista.Departamento = tbNombre.Text;
                        db.Departamentos.Add(lista);
                    
                    db.SaveChanges();
                    RefrescarTabla();

                }
            }
            else if (bGuardar.Text =="Borrar")
            {
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var lista = new DAL.Departamentos();
                    int? id = Convert.ToInt32(cmId.Text);
                    var dato = db.Departamentos.Find(id);
                    db.Departamentos.Remove(dato);
                    db.SaveChanges();
                    RefrescarTabla();
                    Limpieza();
                }
            }
            else if (bEditar.Enabled==false && tbNombre.Text!="")
            {
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var lista = new DAL.Departamentos();
                    int? id = Convert.ToInt32(cmId.Text);
                    //forma para editar un solo elemento
                    var dato = (from d in db.Departamentos where d.Id == id select d).FirstOrDefault();
                    dato.Departamento = tbNombre.Text;
                    //forma para editar muchos elementos
                    //var dato = from d in db.Departamentos where d.Id == id select d;
                    //foreach (DAL.Departamentos item in dato)
                    //{
                    //    item.Departamento = tbNombre.Text;
                    //}
                    db.SaveChanges();
                    RefrescarTabla();
                    Limpieza();

                }        
            }
            else
            {
                MessageBox.Show("El campo Nombre está vacío");
            }
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            cmId.Enabled = false;
        }
        private void RefrescarTabla()
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var ver = from d in db.Departamentos select d;
                TablaContenido.DataSource = ver.ToList();
            }
        }

        private void bRegresar_Click(object sender, EventArgs e)
        {
            Form1 VentanaPrincipal = new Form1();
            this.Close();
            VentanaPrincipal.Show();
        }
        private void Limpieza()
        {
            tbNombre.Text = "";
            cmId.Enabled = false;
            cmId.Text = "";
            bGuardar.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bGuardar.Text = "Guardar";
        }
        private void bCancelar_Click(object sender, EventArgs e)
        {
            RefrescarTabla();
            Limpieza();
        }

        private void cmId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmId.Text);
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var dato = from d in db.Departamentos where d.Id.Equals(id) select d.Departamento;
                foreach (var item in dato)
                {
                    tbNombre.Text = item.ToString();
                    
                }

            }
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var verid = from d in db.Departamentos select d.Id;
                cmId.DataSource = verid.ToList(); 
                
            }
            cmId.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var verid = from d in db.Departamentos select d.Id;
                cmId.DataSource = verid.ToList();
                cmId.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bGuardar.Text = "Borrar";
            }
        }
    }
}
