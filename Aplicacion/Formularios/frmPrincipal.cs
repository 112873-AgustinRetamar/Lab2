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
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            CargarMaterias();             
        }        

        private void BorrarListas()
        {
            datos.Clear();
            nDatos.Clear();            
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
            consulta = 1;
            BorrarListas();
        }
        private void btnConsulta2_Click(object sender, EventArgs e)
        {
            consulta = 2;
            BorrarListas();
            lblInt1.Text = "Desde (años)";
            lblInt2.Text = "Hasta (años)";            
        }
        private void btnConsulta3_Click(object sender, EventArgs e)
        {
            consulta = 3;
            BorrarListas();            
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {
            consulta = 4;
            BorrarListas();            
        }
        private void btnConsulta5_Click(object sender, EventArgs e)
        {
            consulta = 5;
            BorrarListas();            
        }
        private void btnConsulta6_Click(object sender, EventArgs e)
        {
            consulta = 6;
            BorrarListas();
            lblInt1.Text = "Desde (legajo)";
            lblInt2.Text = "Desde (legajo)";            
        }
        private void btnConsulta7_Click(object sender, EventArgs e)
        {
            consulta = 7;
            BorrarListas();
            lblInt1.Text = "Legajo";            
        }

        private void btnConsulta8_Click(object sender, EventArgs e)
        {
            consulta = 8;
            BorrarListas();            
        }
        #endregion

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
                    datos.Add(int.Parse(txtInt1.Text));
                    datos.Add(int.Parse(txtInt2.Text));
                    nDatos.Add("@edad1");
                    nDatos.Add("@edad2");
                    dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_ALUMNOS_RANGO_EDAD", datos, nDatos);
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
                    datos.Add(int.Parse(txtInt1.Text));
                    datos.Add(int.Parse(txtInt2.Text));
                    nDatos.Add("@lMin");
                    nDatos.Add("@lMax");
                    dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_MATRICULAS_POR_RANGO_LEGAJO", datos, nDatos);
                    break;
                case 7:
                    datos.Add(int.Parse(txtInt1.Text));
                    nDatos.Add("@legajo");
                    dgvGrilla.DataSource = HelperDao.ObtenerInstancia().ConsultaVariosSQL("SP_INSCIP_MATERIAS_ALUMNO", datos, nDatos);
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
    }
}
