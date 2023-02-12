using GestorEmpleados.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorEmpleados.PL
{
    public partial class VentanaEmpleados : Form
    {
        byte[] ImagenGuardada;
        public VentanaEmpleados()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
        }
        //Botón regresar a Ventana principal
        private void bRegresar_Click_1(object sender, EventArgs e)
        {
            Form1 VentanaPrincipal = new Form1();
            this.Close();
            VentanaPrincipal.Show();
        }
        //Método Guardar
        private void bGuardar_Click(object sender, EventArgs e)
        {

            if (tbNombre.Text!="" && tbApellidoP.Text!= "" && tbApellidoM.Text!=""
                && tbCorreo.Text!="" && ImagenGuardada != null)
            {
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var lista = new DAL.Empleados();
                    var depa = cbDepartamento.Text;
                    var departamento = (from d in db.Departamentos
                                       where d.Departamento == depa
                                       select d.Id).FirstOrDefault();
                        lista.Nombre = tbNombre.Text;
                        lista.ApellidoPaterno=  tbApellidoP.Text;
                        lista.ApellidoMaterno= tbApellidoM.Text;
                        lista.Correo= tbCorreo.Text;
                        lista.Foto= ImagenGuardada;
                        lista.IdDepartamento = departamento;
                    db.Empleados.Add(lista);
                    db.SaveChanges();
                    Limpiar();
                    LlenarTabla();
                    TablaContenido.ClearSelection();
                    MessageBox.Show("Empleado Agregado");
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }
        //´Botón Editar
        private void bEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea editar los datos de este empleado?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(tbId.Text);
                var depa = cbDepartamento.Text;
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var empleado = db.Empleados.Find(id);
                    var depaemple = (from d in db.Departamentos where d.Departamento == depa 
                                     select d.Id).FirstOrDefault();
                    var contenido = db.Empleados.Find(id);
                    MemoryStream memoriafoto = new MemoryStream(contenido.Foto);//Guardar Contenido de la consulta de la foto
                    if (ImagenGuardada == null)
                    {
                        ImagenGuardada = memoriafoto.ToArray();
                    }
                    empleado.Nombre= tbNombre.Text;
                    empleado.ApellidoPaterno = tbApellidoP.Text;
                    empleado.ApellidoMaterno = tbApellidoM.Text;
                    empleado.Correo = tbCorreo.Text;
                    empleado.Foto = ImagenGuardada;
                    empleado.IdDepartamento = depaemple;
                    db.SaveChanges();
                    Limpiar();
                    LlenarTabla();
                    TablaContenido.ClearSelection();
                }

                MessageBox.Show("Se editó el Empleado");
            }
            else
            {

            }
                
        }
        //Botón Eliminar
        private void bEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea eliminar el empleado?","Confirmación",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(tbId.Text);
                using(GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var objeto = db.Empleados.Find(id);
                    db.Empleados.Remove(objeto);
                    db.SaveChanges();
                    Limpiar();
                    LlenarTabla();
                    TablaContenido.ClearSelection();
                }
                MessageBox.Show("Se eliminó el Empleado");
            }
            else
            {

            }
        }
        //Botón Cancelar
        private void bCancelar_Click(object sender, EventArgs e)
        {
            TablaContenido.ClearSelection();
            Limpiar();
        }
        //Método Limpiar
        private void Limpiar()
        {
            tbId.Text = "";
            tbNombre.Text = "";
            tbApellidoP.Text = "";
            tbApellidoM.Text = "";
            tbCorreo.Text = "";
            bGuardar.Enabled = true;
            bExaminar.Enabled = true;
            bGuardar.Visible = true;
            bExaminar.Visible = true;
            ImagenGuardada = null;
            FotoEmpleado.Image=null;//Borrar Imagen del Elemento para la foto
            bEditar.Enabled = false; bEditar.Visible = false;
            bEliminar.Enabled = false; bEliminar.Visible = false;
        }
        //Método de selección del combobox departamento
        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //Método de carga de datos del combobox de departamentos
        private void CargarComboBoxEmpleado()
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var dato = from d in db.Departamentos select d.Departamento;
                cbDepartamento.DataSource = dato.ToList();
            }
        }
        //Método de llenado de datos de la tabla de contenido a los campos
        private void TablaContenido_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            
            cbDepartamento.Enabled = true;
            CargarComboBoxEmpleado();
            if (indice >= 0)
            {
                var id = TablaContenido.Rows[indice].Cells[0].Value;
                using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
                {
                    var contenido = db.Empleados.Find(id);
                    MemoryStream memoriafoto = new MemoryStream(contenido.Foto);//Guardar Contenido de la consulta de la foto
                    Bitmap extrafoto = new Bitmap(memoriafoto);//Mapear la foto
                    FotoEmpleado.Image = extrafoto;
                    
                    cbDepartamento.Text = contenido.Departamentos.Departamento;
                    tbApellidoP.Text = contenido.ApellidoPaterno.ToString();
                    tbApellidoM.Text = contenido.ApellidoMaterno.ToString();
                    tbId.Text = contenido.Id.ToString();
                    tbNombre.Text = contenido.Nombre;
                    tbCorreo.Text=contenido.Correo;
                }
                bEditar.Enabled = true; bEditar.Visible = true;
                bEliminar.Enabled = true; bEliminar.Visible = true;
                bGuardar.Enabled = false; bGuardar.Visible = false;
            }
            else TablaContenido.ClearSelection();
        }
        //Método llenar tabla de contenido
        private void LlenarTabla()
        {
            using (GestionEmpleadosEntities1 db = new GestionEmpleadosEntities1())
            {
                var tabla = from d in db.Empleados join e in db.Departamentos 
                            on d.IdDepartamento equals e.Id
                            select new {d.Id,d.Nombre,
                    apellidocompleto = d.ApellidoPaterno +" " + d.ApellidoMaterno,d.Correo,e.Departamento};
                TablaContenido.DataSource= tabla.ToList();
            }
        }
        //Carga de la ventana principal
        private void VentanaEmpleados_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            TablaContenido.ClearSelection();
            TablaContenido.Columns[1].HeaderText = "Nombre";
            TablaContenido.Columns[2].HeaderText = "Apellidos";
            TablaContenido.Columns[3].HeaderText = "Correo Electronico";
            TablaContenido.Columns[4].HeaderText = "Departamento";
            CargarComboBoxEmpleado();
            bEditar.Enabled = false;
            bEditar.Visible = false;
            bEliminar.Enabled = false;
            bEliminar.Visible = false;
            tbId.Enabled = false;
        }

        private void bExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog escogerimagen = new OpenFileDialog();
            escogerimagen.Title = "Seleccionar una imagen";
            if (escogerimagen.ShowDialog() == DialogResult.OK)//Si ya seleccionó la imagen
            {
                try
                {
                FotoEmpleado.Image = Image.FromStream(escogerimagen.OpenFile());
                MemoryStream memoriafoto = new MemoryStream();
                FotoEmpleado.Image.Save(memoriafoto,System.Drawing.Imaging.ImageFormat.Png);//Formato de la imagen
                ImagenGuardada = memoriafoto.ToArray();//pasar la foto a una variable global
                }
                catch (Exception)
                {
                    MessageBox.Show("Archivo no compatible");
                }
            }
        }
    }
}
