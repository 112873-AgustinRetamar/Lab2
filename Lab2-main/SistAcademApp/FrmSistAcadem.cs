using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

//NUEVO
namespace WindowsFormsApp1
{
    public partial class FrmSistAcadem : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-M6ASG0I\SQLEXPRESS;Initial Catalog=SistemaAcademico;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        string consulta;

        public FrmSistAcadem()
        {
            InitializeComponent();

        }

        private void frmITV_Load(object sender, EventArgs e)
        {
            btnMostrar.Enabled = false;
            btnLimpiar.Enabled = false;
                       
        }

        private void cargarDetalle(string detalle)
        {
            lstDescripcion.Items.Clear();
            lstDescripcion.Items.Add(detalle);
            btnMostrar.Enabled = true;
        }

        private DataTable consultarTabla(string consulta)
        {
            DataTable tabla = new DataTable();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

   

        //Botones
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable tabla = consultarTabla(consulta);
            dgvReporte.DataSource = tabla;
            dgvReporte.ClearSelection();
            btnLimpiar.Enabled = true;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult limpiar = MessageBox.Show("Desea limpiar el informe?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (limpiar == DialogResult.Yes)
            {
                dgvReporte.DataSource = "";
                consulta = "";
                cargarDetalle("");
                btnMostrar.Enabled = false;
                btnLimpiar.Enabled = false;
            }
            else if (limpiar == DialogResult.No)
            {
                return;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("Desea terminar el programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (salir == DialogResult.Yes)
            {
                this.Close();
            }
            else if (salir == DialogResult.No)
            {
                return;
            }
        }


        //CONSULTAS HECHAS CON VISTAS
        //Consulta 1- ESTE HAY QUE CAMBIAR PARA QUE SEA UNA VISTA
        //no lo hice porque le agregué un group by a la consulta, 1ero queria que la vieran
        private void tsmVista1_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("1- Promedio de las notas parciales de los alumnos del corriente año:");
            consulta = "select a.legajo Legajo, a.ape_alumno + ' ' + a.nom_alumno as 'Alumno', avg(nota) Nota" +
                " from examenes e join alumnos a on a.legajo = e.legajo" +
                " where year(fecha) = year(getdate()) and id_tipo = 1" +
                " group by a.legajo, a.ape_alumno, a.nom_alumno";
        }
        //Consulta 3
        private void tsmVista2_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("3- Consultar alumnos que estudien Ingeniera Civil:");
            consulta = "select * from alumnos_civil";
        }

        //CONSULTAS 'NORMALES'
        //Consulta 4--Esta la tenemos que arreglar
        private void tsmConsulta1_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("4- Consultar alumnos con inasistencias en este año de la materia de química.");
            consulta = "select a.legajo Legajo, a.nom_alumno + a.ape_alumno as 'Alumno'" +
                " from examenes e join alumnos a on a.legajo = e.legajo" +
                " join materias m on m.id_materia = e.id_materia" +
                " where id_tipo = 3 and nota = 0 and year(fecha)= year(getdate())" +
                " and m.nom_materia like 'Quimica'" +
                " order by Alumno";
        }
        //Consulta 6
        private void tsmConsulta2_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("6- Emitir un listado de los alumnos que se hayan matriculado este año \n" +
                " matriculado este año incluyendo solo a aquellos cuyo legajo oscile" +
                " entre 110000 y 115000.");
            consulta = "select legajo 'Legajo', nom_alumno + ape_alumno as 'Alumno'" +
                " from alumnos " +
                "where legajo in(select m.legajo" +
                               " from alumnos a join matriculas m" +
                               " on a.legajo = m.legajo" +
                               " where year(fecha)= year(getdate()))" +
                               " and legajo between 110000 and 115000";
        }

        //Consulta 7 --A ESTE LE MANDÉ UN SELECT AL AZAR, HAY QUE ARRREGLAR LA CONSULTA
        private void tsmConsulta3_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("7- Consultar las materias a las que está inscrito un alumno" 
                );
            consulta = "select a.legajo as 'Legajo', a.nom_alumno+' '+a.ape_alumno as 'Nombre', mate.nom_materia as 'Materia' from matriculasXmaterias mxm join materias mate on mate.id_materia= mxm.id_materia join matriculas matr on mxm.id_matricula= matr.id_matricula join alumnos a on matr.legajo= a.legajo order by 1";
        }


        //Consulta 8
        private void tsmConsulta4_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("8- Listado de docentes y alumnos de la utn:");
            consulta = "select legajo as 'Legajo', nom_alumno+' '+ape_alumno as 'Nombre'," +
                " 'Alumno' as 'Tipo'" +
                " from alumnos" +
                " union" +
                " select legajo, nom_docente + ' ' + ape_docente, 'Docente'" +
                " from docentes" +
                " order by 3";
        }

        //PROCEDIMIENTOS ALMACENADOS
        //Consulta 2-Falta terminar, muestra algo al azar
        private void tsmSP1_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("2- Consultar alumnos entre 21 y 25 años:");
            consulta = "exec alumnos_edad 21,25";
        }

        //Consulta 5-falta terminar, muestra algo al azar
        private void tsmSP2_Click_1(object sender, EventArgs e)
        {
            dgvReporte.DataSource = "";
            cargarDetalle("5- Consultar lista de alumnos que aprobaron finales" +
                " en el corriente año de una materia ingresada");
            consulta = "select * from alumnos_civil";
        }
    }   
        
}
