using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class FuncionesModel
    {

        /// <summary>
        /// Obtiene la lista de funciones que puede ejercer un funcionario en su organismo de adscripción
        /// </summary>
        /// <param name="tipoFuncion">Tipo de función que se esta solicitando</param>
        /// <returns></returns>
        public ObservableCollection<CommonProperties> GetFunciones(int tipoFuncion)
        {
            ObservableCollection<CommonProperties> funciones = new ObservableCollection<CommonProperties>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Funciones WHERE TipoFuncion = @TipoFuncion OR TipoFuncion = 0 ORDER BY IdFuncion";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@TipoFuncion", tipoFuncion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommonProperties funcion = new CommonProperties();
                        funcion.IdElemento = Convert.ToInt32(reader["idFuncion"]);
                        funcion.Descripcion = reader["Funcion"].ToString();

                        funciones.Add(funcion);
                    }
                }
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
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return funciones;
        }
    }
}
