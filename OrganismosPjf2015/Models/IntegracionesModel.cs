using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class IntegracionesModel
    {
        private readonly int idOrganismo;

        public IntegracionesModel(int idOrganismo)
        {
            this.idOrganismo = idOrganismo;
        }

        /// <summary>
        /// Establece el consecutivo de la integración de cada uno de los tribunales, así como la fecha en que 
        /// esa integración entro en funciones, para efectos de la Coordinación
        /// </summary>
        public int GetNewIntegracion()
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;
            int idIntegracion = 0;

            try
            {
                idIntegracion = DataBaseUtilities.GetNextIdForUse("Integraciones", "IdIntegracion", oleConne);

                const string SqlQuery = "SELECT * FROM Integraciones WHERE IdIntegracion = 0";
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(SqlQuery, oleConne);

                dataAdapter.Fill(dataSet, "Integraciones");

                dr = dataSet.Tables["Integraciones"].NewRow();
                dr["IdIntegracion"] = idIntegracion;
                dr["IdOrganismo"] = idOrganismo;
                dr["FechaIntegracion"] = DateTime.Now;
                dr["FechaIntegracionInt"] = DateTimeUtilities.DateToInt(DateTime.Now);

                dataSet.Tables["Integraciones"].Rows.Add(dr);

                dataAdapter.InsertCommand = oleConne.CreateCommand();
                dataAdapter.InsertCommand.CommandText =
                                                       "INSERT INTO Integraciones(IdIntegracion,IdOrganismo,FechaIntegracion,FechaIntegracionInt)" +
                                                       " VALUES(@IdIntegracion,@IdOrganismo,@FechaIntegracion,@FechaIntegracionInt)";

                dataAdapter.InsertCommand.Parameters.Add("@IdIntegracion", SqlDbType.Int, 0, "IdIntegracion");
                dataAdapter.InsertCommand.Parameters.Add("@IdOrganismo", SqlDbType.Int, 0, "IdOrganismo");
                dataAdapter.InsertCommand.Parameters.Add("@FechaIntegracion", SqlDbType.Date, 0, "FechaIntegracion");
                dataAdapter.InsertCommand.Parameters.Add("@FechaIntegracionInt", SqlDbType.VarChar, 0, "FechaIntegracionInt");

                dataAdapter.Update(dataSet, "Integraciones");

                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                oleConne.Close();
            }
            return idIntegracion;
        }

        /// <summary>
        /// Almacena la información de la integración actual del organismo
        /// </summary>
        public void SetIntegracionFuncionarios(List<int> listaFuncionarios,int idIntegracion)
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                foreach (int funcionario in listaFuncionarios)
                {
                    const string SqlQuery = "SELECT * FROM HistorialIntegracion WHERE IdIntegracion = 0";
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand(SqlQuery, oleConne);

                    dataAdapter.Fill(dataSet, "HistorialIntegracion");

                    dr = dataSet.Tables["HistorialIntegracion"].NewRow();
                    dr["IdIntegracion"] = idIntegracion;
                    dr["IdFuncionario"] = funcionario;

                    dataSet.Tables["HistorialIntegracion"].Rows.Add(dr);

                    dataAdapter.InsertCommand = oleConne.CreateCommand();
                    dataAdapter.InsertCommand.CommandText =
                                                           "INSERT INTO HistorialIntegracion(IdIntegracion,IdFuncionario)" +
                                                           " VALUES(@IdIntegracion,@IdFuncionario)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdIntegracion", SqlDbType.Int, 0, "IdIntegracion");
                    dataAdapter.InsertCommand.Parameters.Add("@IdFuncionario", SqlDbType.Int, 0, "IdFuncionario");

                    dataAdapter.Update(dataSet, "HistorialIntegracion");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                oleConne.Close();
            }
        }
        
        
        public void SetIntegracionFuncionarios(ObservableCollection<Funcionarios> listaFuncionarios, int idIntegracion)
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                foreach (Funcionarios funcionario in listaFuncionarios)
                {
                    const string SqlQuery = "SELECT * FROM HistorialIntegracion WHERE IdIntegracion = 0";
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand(SqlQuery, oleConne);

                    dataAdapter.Fill(dataSet, "HistorialIntegracion");

                    dr = dataSet.Tables["HistorialIntegracion"].NewRow();
                    dr["IdIntegracion"] = idIntegracion;
                    dr["IdFuncionario"] = funcionario.IdFuncionario;

                    dataSet.Tables["HistorialIntegracion"].Rows.Add(dr);

                    dataAdapter.InsertCommand = oleConne.CreateCommand();
                    dataAdapter.InsertCommand.CommandText =
                                                           "INSERT INTO HistorialIntegracion(IdIntegracion,IdFuncionario)" +
                                                           " VALUES(@IdIntegracion,@IdFuncionario)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdIntegracion", SqlDbType.Int, 0, "IdIntegracion");
                    dataAdapter.InsertCommand.Parameters.Add("@IdFuncionario", SqlDbType.Int, 0, "IdFuncionario");

                    dataAdapter.Update(dataSet, "HistorialIntegracion");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                oleConne.Close();
            }
        }

        /// <summary>
        /// Obtiene el identificador de la última integración del organismo señalado
        /// </summary>
        /// <returns></returns>
        public int GetLastIntegracion()
        {
            int idIntegracion = 0;
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            const String SqlQuery = "SELECT MAX(IdIntegracion) as Ultima FROM Integraciones WHERE IdOrganismo = @IdOrganismo";

            try
            {
                oleConne.Open();

                cmd = new SqlCommand(SqlQuery, oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idIntegracion = reader["Ultima"] as int? ?? 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return idIntegracion;
        }

        /// <summary>
        /// Establece un cambio de presidente para la integración actual del Organismo
        /// </summary>
        /// <param name="idFuncionario">Identificador del Nuevo Presidente</param>
        public void SetNewPresidente(int idFuncionario)
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                int ultimaIntegracionOrganismo = this.GetLastIntegracion();

                const string SqlQuery = "SELECT * FROM HistorialPresidentes WHERE IdIntegracion = 0";
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(SqlQuery, oleConne);

                dataAdapter.Fill(dataSet, "HistorialPresidentes");

                dr = dataSet.Tables["HistorialPresidentes"].NewRow();
                dr["IdIntegracion"] = ultimaIntegracionOrganismo;
                dr["IdFuncionarioPresidente"] = idFuncionario;
                dr["FechaCambio"] = DateTime.Now;
                dr["FechaCambioInt"] = DateTimeUtilities.DateToInt(DateTime.Now);

                dataSet.Tables["HistorialPresidentes"].Rows.Add(dr);

                dataAdapter.InsertCommand = oleConne.CreateCommand();
                dataAdapter.InsertCommand.CommandText =
                                                       "INSERT INTO HistorialPresidentes(IdIntegracion,IdFuncionarioPresidente,FechaCambio,FechaCambioInt)" +
                                                       " VALUES(@IdIntegracion,@IdFuncionarioPresidente,@FechaCambio,@FechaCambioInt)";

                dataAdapter.InsertCommand.Parameters.Add("@IdIntegracion", SqlDbType.Int, 0, "IdIntegracion");
                dataAdapter.InsertCommand.Parameters.Add("@IdFuncionarioPresidente", SqlDbType.Int, 0, "IdFuncionarioPresidente");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambio", SqlDbType.Date, 0, "FechaCambio");
                dataAdapter.InsertCommand.Parameters.Add("@FechaCambioInt", SqlDbType.Int, 0, "FechaCambioInt");

                dataAdapter.Update(dataSet, "HistorialPresidentes");

                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                oleConne.Close();
            }
        }

        /// <summary>
        /// Obtiene al presidente actual del Organismo
        /// </summary>
        /// <returns></returns>
        public int GetLastPresident()
        {
            int presindente = 0;
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            String sqlCadena = "SELECT TOP 1 I.IdIntegracion, H.IdFuncionarioPresidente, H.FechaCambio " +
                               " FROM Integraciones I INNER JOIN HistorialPresidentes H ON I.IdIntegracion = H.IdIntegracion " +
                               " WHERE I.IdOrganismo = @IdOrganismo " +
                               "Order By I.IdIntegracion DESC, H.FechaCambio DESC ";
            
            try
            {
                oleConne.Open();

                cmd = new SqlCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        presindente = reader["IdFuncionarioPresidente"] as int? ?? 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return presindente;
        }

        /// <summary>
        /// Obtiene un listado con el historial de integraciones del Organismo
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Integraciones> GetIntegracionesByOrganismo()
        {
            ObservableCollection<Integraciones> listaIntegraciones = new ObservableCollection<Integraciones>();

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            const String SqlQuery = "SELECT IdIntegracion,FechaIntegracion FROM Integraciones WHERE IdOrganismo = @IdOrganismo";

            FuncionariosModel model = new FuncionariosModel();

            try
            {
                oleConne.Open();

                cmd = new SqlCommand(SqlQuery, oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Integraciones integracion = new Integraciones();

                        integracion.IdIntegracion = reader["IdIntegracion"] as int? ?? 0;
                        integracion.FechaIntegracion = DateTimeUtilities.GetDateFromReader(reader, "FechaIntegracion");
                        integracion.Integrantes = model.GetFuncionariosByIntegracion(integracion.IdIntegracion);
                        integracion.Presidentes = model.GetPresidentesByIntegracion(integracion.IdIntegracion);

                        listaIntegraciones.Add(integracion);
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionesModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return listaIntegraciones;
        }
    }
}