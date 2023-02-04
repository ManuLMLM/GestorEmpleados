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
        int comoeditar = 0;
        int comoborrar = 0;//apoyo para el método eliminar
        public Departamentos()
        {
            InitializeComponent();
            //se les da el parametro de fondo de la imagen en lugar de la ventana
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            //cambio de color a transparente
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        //Método de guardar, editar y eliminar
        private void bGuardar_Click_1(object sender, EventArgs e)
        {
            //Guardar departamento
            if (comoborrar ==0 && comoeditar ==0 && tbNombre.Text != "")
            {
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var lista = new DAL.Departamentos();
                    lista.Departamento = tbNombre.Text;
                    db.Departamentos.Add(lista);

                    db.SaveChanges();
                    RefrescarTabla();
                    Limpieza();
                }
            }
            //Borrar departamento
            else if (comoborrar==1)
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
                    CargarComboBox();
                }
            }
            //Editar departamento
            else if (comoeditar ==1 && tbNombre.Text != "")
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
            //Mensaje de falta de contenido
            else
            {
                MessageBox.Show("El campo Nombre está vacío");
            }
        }
        //Carga de ventana
        private void Departamentos_Load(object sender, EventArgs e)
        {
            TablaContenido.ClearSelection();
            RefrescarTabla();
            TablaContenido.ClearSelection();
            tbNombre.Text = "";
            cmId.Enabled = false;
            TablaContenido.Columns[1].HeaderText = "Nombre de Departamento";
            
            
        }
        //Método para refrescar la tabla de contenido
        private void RefrescarTabla()
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var ver = from d in db.Departamentos select d;
                TablaContenido.DataSource = ver.ToList();
            }
            
        }
        //Método para limpiar todo
        private void Limpieza()
        {
            tbNombre.Text = "";
            cmId.Text = "";
            cmId.Enabled = false;
            
            bGuardar.Image = global::GestorEmpleados.Properties.Resources.BotonGuardar;
            bGuardar.Enabled = true;bGuardar.Visible= true;
            bEditar.Enabled = true; bEditar.Visible = true;
            bEliminar.Enabled = true; bEliminar.Visible = true;
             TablaContenido.ClearSelection(); comoborrar = 0; comoeditar = 0;

        }
        //Botón del ComboBox del ID
        private void cmId_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcombobox();
        }
        //Método para cargar el contenido del ComboBox ID a los campos
        private void loadcombobox()
        {
            int id = int.Parse(cmId.Text);
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var dato = from d in db.Departamentos where d.Id.Equals(id) select d.Departamento;
                foreach (var item in dato)
                {
                    tbNombre.Text = item.ToString();
                }
            }
        }
        //Evento de click a la tabla de contenido que carga los datos a tus campos
        private void TablaContenido_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            int indice = e.RowIndex;
            
            cmId.Enabled = true;
            CargarComboBox();
            if (indice>=0)
            {
            bEditar.Enabled = false; bEditar.Visible = false;
            bEliminar.Enabled = false; bEliminar.Visible = false;
            cmId.Text= TablaContenido.Rows[indice].Cells[0].Value.ToString();
            tbNombre.Text= TablaContenido.Rows[indice].Cells[1].Value.ToString();
            }else TablaContenido.ClearSelection();
            comoeditar = 1; cmId.Enabled = false;
        }
        //Método para cargar el contenido al ComboBox del ID
        public void CargarComboBox()
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var verid = from d in db.Departamentos select d.Id;
                cmId.DataSource = verid.ToList();

            }
        }
        //Evento Botón Editar
        private void bEditar_Click_1(object sender, EventArgs e)
        {
            comoeditar = 1;         
            cmId.Enabled = true;
            CargarComboBox();
            bEditar.Enabled = false; bEditar.Visible = false;
            bEliminar.Enabled = false;bEliminar.Visible = false;
        }
        //Evento Botón Eliminar
        private void bEliminar_Click_1(object sender, EventArgs e)
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var verid = from d in db.Departamentos select d.Id;
                cmId.DataSource = verid.ToList();
                cmId.Enabled = true;
                bEditar.Enabled = false;bEditar.Visible = false;
                bEliminar.Enabled = false;bEliminar.Visible = false;
                bGuardar.Image = global::GestorEmpleados.Properties.Resources.BotonBorrar;
                comoborrar = 1;comoeditar = 1;
            }
        }
        //Evento Botón Cancelar, este reinicia toda la ventana a como estaba al abrirla
        private void bCancelar_Click_1(object sender, EventArgs e)
        {
            RefrescarTabla();
            Limpieza();           
        }
        //Botón para regresar a la ventana principal
        private void bRegresar_Click_1(object sender, EventArgs e)
        {
            Form1 VentanaPrincipal = new Form1();
            this.Close();
            VentanaPrincipal.Show();
        }
    }
}
