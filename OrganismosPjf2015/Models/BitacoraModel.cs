using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class BitacoraModel
    {

        public void SetNewBitacoraEntry(Bitacora bitacora)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Bitacora WHERE Id = 0";
                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

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

                dataAdapter.InsertCommand.Parameters.Add("@IdMovimiento", OleDbType.Numeric, 0, "IdMovimiento");
                dataAdapter.InsertCommand.Parameters.Add("@IdElemento", OleDbType.Numeric, 0, "IdElemento");
                dataAdapter.InsertCommand.Parameters.Add("@EdoActual", OleDbType.VarChar, 0, "EdoActual");
                dataAdapter.InsertCommand.Parameters.Add("@EdoAnterior", OleDbType.VarChar, 0, "EdoAnterior");
                dataAdapter.InsertCommand.Parameters.Add("@IdUsuario", OleDbType.Numeric, 0, "IdUsuario");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambio", OleDbType.Date, 0, "FechaCambio");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambioInt", OleDbType.Numeric, 0, "FechaCambioInt");
                dataAdapter.InsertCommand.Parameters.Add("@NombreEquipo", OleDbType.VarChar, 0, "NombreEquipo");

                dataAdapter.Update(dataSet, "Bitacora");

                dataSet.Dispose();
                dataAdapter.Dispose();

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
            }
            finally
            {

                oleConne.Close();
            }
            

        }
    }
}