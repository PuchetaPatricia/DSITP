using PPAI_GRUPO3.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_GRUPO3.AccesoABD
{
    public class ABD_TipoRecurso
    {
        //public static List<TipoRecurso> ObtenerTipoRecursosReducida()
        //{
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
        //    SqlConnection cn = new SqlConnection(cadenaConexion);
        //    List < TipoRecurso > tipoRecursos = new List<TipoRecurso >();
        //    try
        //    {
        //        SqlCommand comand = new SqlCommand();
        //        string consulta = "getTipoRecursosNoBorrados";

        //        comand.Parameters.Clear();
        //        comand.CommandType = CommandType.StoredProcedure;
        //        comand.CommandText = consulta;

        //        cn.Open();
        //        comand.Connection = cn;

        //        DataTable tabla = new DataTable();

        //        SqlDataAdapter da = new SqlDataAdapter(comand);
        //        da.Fill(tabla);

        //        for (int i = 0; i<tabla.Rows.Count; i++)
        //        {
        //            TipoRecurso tr = new TipoRecurso((int)tabla.Rows[i][0], tabla.Rows[i][1].ToString(), tabla.Rows[i][2].ToString());
        //            tipoRecursos.Add(tr);
        //        }

        //        return tipoRecursos;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //}
    }
}
