using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class BitacoraModel
    {

        public void SetNewBitacoraEntry(Bitacora bitacora)
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Bitacora WHERE Id = 0", oleConne);

                dataAdapter.Fill(dataSet, "Bitacora");

                dr = dataSet.Tables["Bitacora"].NewRow();
                dr["IdMovimiento"] = bitacora.IdMovimiento;
                dr["IdElemento"] = bitacora.IdElemento;
                dr["EdoActual"] = bitacora.EdoActual;
                dr["EdoAnterior"] = bitacora.EdoAnterior;
                dr["IdUsuario"] = Usuarios.IdUsuario;
                dr["FechaCambio"] = DateTime.Now;
                dr["FechaCambioInt"] = DateTimeUtilities.DateToInt(DateTime.Now);
                dr["NombreEquipo"] = bitacora.NombreEquipo;

                dataSet.Tables["Bitacora"].Rows.Add(dr);

                dataAdapter.InsertCommand = oleConne.CreateCommand();
                dataAdapter.InsertCommand.CommandText =
                                                       "INSERT INTO Bitacora(IdMovimiento,IdElemento,EdoActual,EdoAnterior,IdUsuario,FechaCambio,FechaCambioInt,NombreEquipo)" +
                                                       " VALUES(@IdMovimiento,@IdElemento,@EdoActual,@EdoAnterior,@IdUsuario,@FechaCambio,@FechaCambioInt,@NombreEquipo)";

                dataAdapter.InsertCommand.Parameters.Add("@IdMovimiento", SqlDbType.Int, 0, "IdMovimiento");
                dataAdapter.InsertCommand.Parameters.Add("@IdElemento", SqlDbType.Int, 0, "IdElemento");
                dataAdapter.InsertCommand.Parameters.Add("@EdoActual", SqlDbType.VarChar, 0, "EdoActual");
                dataAdapter.InsertCommand.Parameters.Add("@EdoAnterior", SqlDbType.VarChar, 0, "EdoAnterior");
                dataAdapter.InsertCommand.Parameters.Add("@IdUsuario", SqlDbType.Int, 0, "IdUsuario");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambio", SqlDbType.Date, 0, "FechaCambio");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambioInt", SqlDbType.Int, 0, "FechaCambioInt");
                dataAdapter.InsertCommand.Parameters.Add("@NombreEquipo", SqlDbType.VarChar, 0, "NombreEquipo");

                dataAdapter.Update(dataSet, "Bitacora");

                dataSet.Dispose();
                dataAdapter.Dispose();

            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, BitacoraModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, BitacoraModel", 0);
            }
            finally
            {

                oleConne.Close();
            }
            

        }
    }
}