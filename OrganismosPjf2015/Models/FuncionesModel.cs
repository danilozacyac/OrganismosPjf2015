using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
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

            const String SqlQuery = "SELECT * FROM Funciones WHERE TipoFuncion = @TipoFuncion OR TipoFuncion = 0 ORDER BY IdFuncion";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(SqlQuery, oleConne);
                cmd.Parameters.AddWithValue("@TipoFuncion", tipoFuncion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommonProperties funcion = new CommonProperties()
                        {
                            IdElemento = Convert.ToInt32(reader["idFuncion"]),
                            Descripcion = reader["Funcion"].ToString()
                        };

                        funciones.Add(funcion);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, FuncionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, FuncionesModel", 0);
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
