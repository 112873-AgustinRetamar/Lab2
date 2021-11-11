using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AccesoDatos
{
    class HelperDao
    {
		private static HelperDao instancia;
		private string cadenaConexion;
		SqlConnection cnn;
		SqlCommand cmd;

		private HelperDao()
		{
			cadenaConexion = Properties.Resources.cadenaConexion;
			cnn = new SqlConnection(cadenaConexion);
			cmd = new SqlCommand();
		}

		public static HelperDao ObtenerInstancia()
		{
			if (instancia == null)
			{
				instancia = new HelperDao();
			}
			return instancia;
		}

		public DataTable ConsultaSQL(string nombreSP)
		{
			DataTable tabla = new DataTable();
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				tabla.Load(cmd.ExecuteReader());
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open)
					cnn.Close();
			}
			return tabla;
		}

		public DataTable ConsultaVariosSQL(string nombreSp, List<int> datos, List<string> nDatos)
        {
			DataTable tabla = new DataTable();
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSp;

                for (int i = 0; i < nDatos.Count; i++)
                {
					cmd.Parameters.AddWithValue(nDatos[i], datos[i]);
                }

				tabla.Load(cmd.ExecuteReader());
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open)
					cnn.Close();
			}
			return tabla;
		}
	}
}
