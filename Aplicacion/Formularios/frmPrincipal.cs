using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.AccesoDatos;

namespace Aplicacion
{
    public partial class frmPrincipal : Form
    {
        List<int> datos = new List<int>();
        List<string> nDatos = new List<string>();
        int consulta;
        int posX = 238;
        int posY = 79;
        int posLX = 246;
        int posLY = 67;
                
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            CargarMaterias();            
            lblCarreras.Location = lblMateria.Location = new Point(posLX, posLY);
            gbCarrera.Location = gbMateria.Location = new Point(posX, posY);
            OcultarObjetos();
        }        

        private void BorrarListas()
        {
            datos.Clear();
            nDatos.Clear();            
        }

        private void ResetObjetos()
        {
            cboCarreras.SelectedIndex = cboMaterias.SelectedIndex = -1;
            txtInt1.Text = txtInt2.Text = string.Empty;
        }

        private void OcultarObjetos()
        {
            lblCarreras.Visible = lblInt1.Visible = lblInt2.Visible = lblMateria.Visible = gbCarrera.Visible = gbInt1.Visible = gbInt2.Visible = gbMateria.Visible = false;
        }

        #region Carga de Combos
        private void CargarCarreras()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_CARRRERAS");
            cboCarreras.DataSource = tabla;
            cboCarreras.DisplayMember = tabla.Columns[1].ColumnName;
            cboCarreras.ValueMember = tabla.Columns[0].ColumnName;
            cboCarreras.SelectedIndex = -1;
        }

        private void CargarMaterias()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_MATERIAS");
            cboMaterias.DataSource = tabla;
            cboMaterias.DisplayMember = tabla.Columns[1].ColumnName;
            cboMaterias.ValueMember = tabla.Columns[0].ColumnName;
            cboMaterias.SelectedIndex = -1;
        }
        #endregion

        #region Botones de Consulta
        private void btnConsulta1_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Promedio de las notas parciales de los alumnos del corriente año de la materia\nseleccionada.";
            OcultarObjetos();
            lblMateria.Visible = gbMateria.Visible = true;
            consulta = 1;
            BorrarListas();
            ResetObjetos();
        }
        private void btnConsulta2_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de alumnos están dentro de un rango de edad determinado.";
            OcultarObjetos();
            lblInt1.Visible = lblInt2.Visible = gbInt1.Visible = gbInt2.Visible = true;
            consulta = 2;
            BorrarListas();
            lblInt1.Text = "Desde (años)";
            lblInt2.Text = "Hasta (años)";
            ResetObjetos();
        }
        private void btnConsulta3_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de alumnos que están inscripto en una materia seleccionada.";
            OcultarObjetos();
            lblCarreras.Visible = gbCarrera.Visible = true;
            consulta = 3;
            BorrarListas();
            ResetObjetos();
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Cantidad de inasistencias de los alumnos que cursan la materia seleccionada en el\ncorriente año.";
            OcultarObjetos();
            lblMateria.Visible = gbMateria.Visible = true;
            consulta = 4;
            BorrarListas();
            ResetObjetos();
        }
        private void btnConsulta5_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de alumnos que aprobaron finales en el corriente año de una materia\nseleccionada.";
            OcultarObjetos();
            lblMateria.Visible = gbMateria.Visible = true;
            consulta = 5;
            BorrarListas();
            ResetObjetos();
        }
        private void btnConsulta6_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de los alumnos que se hayan matriculado este año incluyendo solo a aquellos\ncuyo legajo oscile entre números de legajos ingresados.";
            consulta = 6;
            OcultarObjetos();
            lblInt1.Visible = lblInt2.Visible = gbInt1.Visible = gbInt2.Visible = true;
            BorrarListas();
            lblInt1.Text = "Desde (legajo)";
            lblInt2.Text = "Desde (legajo)";
            ResetObjetos();
        }
        private void btnConsulta7_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de las materias a las que está inscrito un alumno";
            consulta = 7;
            OcultarObjetos();
            lblInt1.Visible = gbInt1.Enabled = true;
            BorrarListas();
            lblInt1.Text = "Legajo";
            ResetObjetos();
        }

        private void btnConsulta8_Click(object sender, EventArgs e)
        {
            lblDescConsulta.Text = "Listado de docentes que dan una materia";
            OcultarObjetos();
            lblMateria.Visible = gbMateria.Visible = true;
            consulta = 8;
            BorrarListas();
            ResetObjetos();
        }
        #endregion

        #region Verificaciones
        private bool VerificarCombo(ComboBox combo)
        {
            string mensaje;

            if (combo.Name.Equals("cboMaterias"))
                mensaje = "una materia";
            else
                mensaje = "una carrera";

            if (combo.SelectedIndex > -1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Por favor seleccione "+mensaje+" para realizar la consulta...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool VerificarTextbox(TextBox textBox)
        {
            string mensaje;
            switch (consulta)
            {
                case 2:
                    if (textBox.Name.Equals("txtInt1"))
                        mensaje = "la edad desde";
                    else
                        mensaje = "la edad hasta";
                    break;
                case 6:
                    if (textBox.Name.Equals("txtInt1"))
                        mensaje = "el legajo desde";
                    else
                        mensaje = "el legajo hasta";
                    break;
                case 7:
                    mensaje = "un legajo";
                    break;
                default:
                    mensaje = "error";
                    break;
            }
            if (textBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Por favor ingrese " + mensaje + " para realizar la consulta...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            try
            {
                int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese solo numeros por favor...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }            
            return true;                 
        }
        #endregion

        private void btnEject_Click(object sender, EventArgs e)
        {
            BorrarListas();
            switch (consulta)
            {
                case 1:
                    if (VerificarCombo(cboMaterias)) 
                    {
                        datos.Add((int)cboMaterias.SelectedValue);
                        nDatos.Add("@idMateria");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_PROMEDIO_AÑO_MATERIA", datos, nDatos);
                    }                    
                    break;
                case 2:
                    if(VerificarTextbox(txtInt1) && VerificarTextbox(txtInt2))
                    {
                        datos.Add(int.Parse(txtInt1.Text));
                        datos.Add(int.Parse(txtInt2.Text));
                        nDatos.Add("@edad1");
                        nDatos.Add("@edad2");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALUMNOS_RANGO_EDAD", datos, nDatos);
                    }                    
                    break;
                case 3:
                    if (VerificarCombo(cboCarreras))
                    {
                        datos.Add(int.Parse(cboCarreras.SelectedValue.ToString()));
                        nDatos.Add("@idCarrera");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALUMNOS_CARRERAS", datos, nDatos);
                    }                    
                    break;
                case 4:
                    if (VerificarCombo(cboMaterias))
                    {
                        datos.Add((int)cboMaterias.SelectedValue);
                        nDatos.Add("@idMateria");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALMUNOS_INASISTENCIAS_POR_MATERIA", datos, nDatos);
                    }                    
                    break;
                case 5:
                    if (VerificarCombo(cboMaterias))
                    {
                        datos.Add((int)cboMaterias.SelectedValue);
                        nDatos.Add("@idMateria");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_FINALES_APROBADOS", datos, nDatos);
                    }                    
                    break;
                case 6:
                    if (VerificarTextbox(txtInt1) && VerificarTextbox(txtInt2))
                    {
                        datos.Add(int.Parse(txtInt1.Text));
                        datos.Add(int.Parse(txtInt2.Text));
                        nDatos.Add("@lMin");
                        nDatos.Add("@lMax");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_MATRICULAS_POR_RANGO_LEGAJO", datos, nDatos);
                    }                    
                    break;
                case 7:
                    if (VerificarTextbox(txtInt1))
                    {
                        datos.Add(int.Parse(txtInt1.Text));
                        nDatos.Add("@legajo");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_INSCIP_MATERIAS_ALUMNO", datos, nDatos);
                    }                    
                    break;
                case 8:
                    if (VerificarCombo(cboMaterias))
                    {
                        datos.Add((int)cboMaterias.SelectedValue);
                        nDatos.Add("@idMateria");
                        dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_DOCENTES_POR_MATERIA", datos, nDatos);
                    }                    
                    break;
                default:
                    MessageBox.Show("Seleccione una consulta a ejecutar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
