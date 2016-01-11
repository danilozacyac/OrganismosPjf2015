using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class FuncionariosModel
    {
        public ObservableCollection<Funcionarios> GetFuncionarios(int tipoOrganismo)
        {
            ObservableCollection<Funcionarios> funcionarios = new ObservableCollection<Funcionarios>();
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());

            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT F.*, R.IdOrg, R.Funcion FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc  ORDER BY Apellidos";

            if (tipoOrganismo == 0)
                sqlCadena = "SELECT F.*, R.IdOrg, R.Funcion FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc  ORDER BY Apellidos";
            else if (tipoOrganismo == 1 || tipoOrganismo == 2)
                sqlCadena = "SELECT F.*, R.IdOrg, R.Funcion FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc WHERE Puesto = 'Mgdo.' OR Puesto = 'Mgda.' ORDER BY Apellidos";
            else if (tipoOrganismo == 3)
                sqlCadena = "SELECT F.*, R.IdOrg, R.Funcion FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc WHERE Puesto = 'Juez' ORDER BY Apellidos";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Funcionarios funcionario = new Funcionarios();
                        funcionario.IdFuncionario = Convert.ToInt32(reader["idFunc"]);
                        funcionario.IdOrganismo = reader["IdOrg"] as int? ?? 0;
                        funcionario.Puesto = reader["Puesto"].ToString();
                        funcionario.Apellidos = reader["Apellidos"].ToString();
                        funcionario.Nombre = reader["Nombre"].ToString();
                        funcionario.Texto = reader["Texto"].ToString();
                        funcionario.Activo = reader["Activo"] as int? ?? 0;

                        if (reader["Funcion"] != System.DBNull.Value)
                            funcionario.EnFunciones = Convert.ToInt16(reader["Funcion"]);
                        else
                            funcionario.EnFunciones = 0;

                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }

        ///// <summary>
        ///// Obtiene un listado de los funcionarios que carecen de adscripción
        ///// </summary>
        ///// <param name="tipoOrganismo"></param>
        ///// <returns></returns>
        //public ObservableCollection<Funcionarios> GetFuncionariosForSelection(int tipoOrganismo)
        //{

        //    ObservableCollection<Funcionarios> funcionarios = new ObservableCollection<Funcionarios>();
        //    OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());

        //    OleDbCommand cmd = null;
        //    OleDbDataReader reader = null;

        //    String sqlCadena = "";

        //    if(tipoOrganismo == 4)
        //        sqlCadena = "SELECT F.*, R.IdOrg FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc WHERE Puesto = 'Mgdo.'  OR Puesto = 'Mgda.' ORDER BY Apellidos";
        //    if (tipoOrganismo == 3)
        //        sqlCadena = "SELECT F.*, R.IdOrg FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc WHERE Puesto = 'Juez' AND  F.IdFunc NOT IN (SELECT IdFunc FROM Rel_Org_Func GROUP BY IdFunc) ORDER BY Apellidos";
        //    else
        //        sqlCadena = "SELECT F.*, R.IdOrg FROM Funcionarios F LEFT JOIN Rel_Org_Func R ON F.IdFunc = R.IdFunc WHERE Puesto = 'Mgdo.'  OR Puesto = 'Mgda.' AND  F.IdFunc NOT IN (SELECT IdFunc FROM Rel_Org_Func GROUP BY IdFunc) ORDER BY Apellidos";
            
        //    try
        //    {
        //        oleConne.Open();

        //        cmd = new OleDbCommand(sqlCadena, oleConne);
        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                Funcionarios funcionario = new Funcionarios();
        //                funcionario.IdFuncionario = Convert.ToInt32(reader["idFunc"]);
        //                funcionario.IdOrganismo = reader["IdOrg"] as int? ?? 0;
        //                funcionario.Puesto = reader["Puesto"].ToString();
        //                funcionario.Apellidos = reader["Apellidos"].ToString();
        //                funcionario.Nombre = reader["Nombre"].ToString();
        //                funcionario.Texto = reader["Texto"].ToString();

        //                funcionarios.Add(funcionario);
        //            }
        //        }
        //    }
        //    catch (OleDbException ex)
        //    {
        //        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        //        MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        //        MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        ErrorUtilities.SetNewErrorMessage(ex, methodName, 0);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        reader.Close();
        //        oleConne.Close();
        //    }

        //    return funcionarios;
        //}

        /// <summary>
        /// Obtiene los funcionarios de la integración actual del tribunal
        /// </summary>
        /// <param name="idOrganismo"></param>
        /// <returns></returns>
        public ObservableCollection<Funcionarios> GetFuncionariosPorOrganismo(int idOrganismo)
        {
            ObservableCollection<Funcionarios> funcionarios = new ObservableCollection<Funcionarios>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT F.*,R.*" +
                               "FROM (Organismos O INNER JOIN Rel_Org_Func R ON O.IdOrg = R.IdOrg) " +
                               "INNER JOIN Funcionarios F ON R.IdFunc = F.IdFunc WHERE O.IdOrg = @IdOrganismo " +
                               " ORDER BY Apellidos";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Funcionarios funcionario = new Funcionarios();
                        funcionario.IdFuncionario = Convert.ToInt32(reader["F.idFunc"]);
                        funcionario.Puesto = reader["Puesto"].ToString();
                        funcionario.Apellidos = reader["Apellidos"].ToString();
                        funcionario.Nombre = reader["Nombre"].ToString();
                        funcionario.Texto = reader["Texto"].ToString();
                        funcionario.Activo = reader["Activo"] as int? ?? 0;
                        funcionario.EnFunciones = Convert.ToInt32(reader["Funcion"]);
                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }

        /// <summary>
        /// Obtiene los funcionarios de la integracion especifica de un tribunal
        /// </summary>
        /// <param name="idIntegracion"></param>
        /// <returns></returns>
        public ObservableCollection<Funcionarios> GetFuncionariosByIntegracion(int idIntegracion)
        {
            ObservableCollection<Funcionarios> funcionarios = new ObservableCollection<Funcionarios>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT F.*, H.IdFuncionario " +
                               " FROM HistorialIntegracion H INNER JOIN Funcionarios F ON H.IdFuncionario = F.IdFunc " +
                               " WHERE IdIntegracion = @IdIntegracion";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdIntegracion", idIntegracion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Funcionarios funcionario = new Funcionarios();
                        funcionario.IdFuncionario = Convert.ToInt32(reader["idFunc"]);
                        funcionario.Puesto = reader["Puesto"].ToString();
                        funcionario.Apellidos = reader["Apellidos"].ToString();
                        funcionario.Nombre = reader["Nombre"].ToString();
                        funcionario.Texto = reader["Texto"].ToString();
                        funcionario.Activo = reader["Activo"] as int? ?? 0;
                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }

        /// <summary>
        /// Obtienen un listado con todos los organismo que ha integrado el funcionario
        /// </summary>
        /// <param name="idFuncionario"></param>
        /// <returns></returns>
        public ObservableCollection<Integraciones> GetHistorialFuncionarios(int idFuncionario)
        {
            ObservableCollection<Integraciones> listaIntegracion = new ObservableCollection<Integraciones>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT H.IdIntegracion, I.FechaIntegracion, O.Organismo " +
                                " FROM (HistorialIntegracion H INNER JOIN Integraciones I ON H.IdIntegracion = I.IdIntegracion) " + 
                                " INNER JOIN Organismos O ON I.IdOrganismo = O.IdOrg " + 
                                " WHERE H.IdFuncionario = @IdFuncionario";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdFuncionario", idFuncionario);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Integraciones integracion = new Integraciones();
                        integracion.IdIntegracion = reader["IdIntegracion"] as int? ?? -1;
                        integracion.FechaIntegracion = DateTimeUtilities.GetDateFromReader(reader, "FechaIntegracion");
                        integracion.Organismo = reader["Organismo"].ToString();

                        listaIntegracion.Add(integracion);
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

            return listaIntegracion;
        }

        public ObservableCollection<Funcionarios> GetPresidentesByIntegracion(int idIntegracion)
        {
            ObservableCollection<Funcionarios> funcionarios = new ObservableCollection<Funcionarios>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT F.*, H.FechaCambio " +
                               " FROM HistorialPresidentes H INNER JOIN Funcionarios F ON H.IdFuncionarioPresidente = F.IdFunc " +
                               " WHERE IdIntegracion = @IdIntegracion";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdIntegracion", idIntegracion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Funcionarios funcionario = new Funcionarios();
                        funcionario.IdFuncionario = Convert.ToInt32(reader["idFunc"]);
                        funcionario.Puesto = reader["Puesto"].ToString();
                        funcionario.Apellidos = reader["Apellidos"].ToString();
                        funcionario.Nombre = reader["Nombre"].ToString();
                        funcionario.Texto = reader["FechaCambio"].ToString();
                        funcionario.Activo = reader["Activo"] as int? ?? 0;
                        funcionarios.Add(funcionario);
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

            return funcionarios;
        }

        public int GetOrganismoPorFuncionario(Funcionarios funcionario)
        {
            int idOrganismo = 0;

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT IdOrg FROM Rel_Org_Func WHERE IdFunc = " + funcionario.IdFuncionario;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    idOrganismo = Convert.ToInt32(reader["IdOrg"]);
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

            return idOrganismo;
        }

        public void AddNewFuncionario(Funcionarios funcionario, Organismos organismo)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            int idFuncionario = DataBaseUtilities.GetNextIdForUse("Funcionarios", "IdFunc", oleConne);
            if (idFuncionario != 0)
            {
                funcionario.IdFuncionario = idFuncionario;
                string sqlCadena = "SELECT * FROM Funcionarios WHERE idFunc = 0";
                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

                dataAdapter.Fill(dataSet, "Funcionario");

                dr = dataSet.Tables["Funcionario"].NewRow();
                dr["idFunc"] = idFuncionario;
                dr["Puesto"] = funcionario.Puesto;
                dr["Apellidos"] = funcionario.Apellidos;
                dr["Nombre"] = funcionario.Nombre;
                dr["Activo"] = funcionario.Activo;
                dr["Texto"] = funcionario.Texto;
                dr["InicialApellido"] = funcionario.Apellidos.Substring(0, 1);

                dataSet.Tables["Funcionario"].Rows.Add(dr);

                dataAdapter.InsertCommand = oleConne.CreateCommand();
                dataAdapter.InsertCommand.CommandText =
                                                       "INSERT INTO Funcionarios(idFunc,Puesto,Apellidos,Nombre,Activo,Texto,InicialApellido)" +
                                                       " VALUES(@idFunc,@Puesto,@Apellidos,@Nombre,@Activo,@Texto,@InicialApellido)";

                dataAdapter.InsertCommand.Parameters.Add("@idFunc", OleDbType.Numeric, 0, "idFunc");
                dataAdapter.InsertCommand.Parameters.Add("@Puesto", OleDbType.VarChar, 0, "Puesto");
                dataAdapter.InsertCommand.Parameters.Add("@Apellidos", OleDbType.VarChar, 0, "Apellidos");
                dataAdapter.InsertCommand.Parameters.Add("@Nombre", OleDbType.VarChar, 0, "Nombre");
                dataAdapter.InsertCommand.Parameters.Add("@Activo", OleDbType.Numeric, 0, "Activo");
                dataAdapter.InsertCommand.Parameters.Add("@Texto", OleDbType.VarChar, 0, "Texto");
                dataAdapter.InsertCommand.Parameters.Add("@InicialApellido", OleDbType.VarChar, 0, "InicialApellido");

                dataAdapter.Update(dataSet, "Funcionario");

                dataSet.Dispose();
                dataAdapter.Dispose();
                oleConne.Close();

                this.InsertaRelacionFuncionario(funcionario);
                organismo.ListaFuncionarios.Add(funcionario);
                //OrganismosSingleton.Instance.AddFuncionarioToOrganismo(organismo, funcionario);
            }
        }

        public void UpdateFuncionario(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM Funcionarios WHERE idFunc = " + funcionario.IdFuncionario;
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

            dataAdapter.Fill(dataSet, "Funcionario");

            dr = dataSet.Tables["Funcionario"].Rows[0];
            dr.BeginEdit();
            dr["idFunc"] = funcionario.IdFuncionario;
            dr["Puesto"] = funcionario.Puesto;
            dr["Apellidos"] = funcionario.Apellidos;
            dr["Nombre"] = funcionario.Nombre;
            dr["Activo"] = funcionario.Activo;
            dr["Texto"] = funcionario.Texto;
            dr["InicialApellido"] = funcionario.Apellidos.Substring(0, 1);
            dr.EndEdit();

            dataAdapter.UpdateCommand = oleConne.CreateCommand();
            dataAdapter.UpdateCommand.CommandText =
                                                   "UPDATE Funcionarios SET Puesto = @Puesto,Apellidos = @Apellidos,Nombre = @Nombre," +
                                                   "Activo = @Activo,Texto = @Texto,InicialApellido = @InicialApellido " +
                                                   " WHERE idFunc = @idFunc";

            dataAdapter.UpdateCommand.Parameters.Add("@Puesto", OleDbType.VarChar, 0, "Puesto");
            dataAdapter.UpdateCommand.Parameters.Add("@Apellidos", OleDbType.VarChar, 0, "Apellidos");
            dataAdapter.UpdateCommand.Parameters.Add("@Nombre", OleDbType.VarChar, 0, "Nombre");
            dataAdapter.UpdateCommand.Parameters.Add("@Activo", OleDbType.Numeric, 0, "Activo");
            dataAdapter.UpdateCommand.Parameters.Add("@Texto", OleDbType.VarChar, 0, "Texto");
            dataAdapter.UpdateCommand.Parameters.Add("@InicialApellido", OleDbType.VarChar, 0, "InicialApellido");
            dataAdapter.UpdateCommand.Parameters.Add("@idFunc", OleDbType.Numeric, 0, "idFunc");

            dataAdapter.Update(dataSet, "Funcionario");

            dataSet.Dispose();
            dataAdapter.Dispose();
            oleConne.Close();

            this.UpdateFuncion(funcionario);
        }

        /// <summary>
        /// Actualiza la función que desempeña un servidor público dentro de su organismo de adscripción
        /// </summary>
        /// <param name="funcionario"></param>
        private void UpdateFuncion(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM Rel_Org_Func WHERE idFunc = " + funcionario.IdFuncionario;
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

            dataAdapter.Fill(dataSet, "Rel_Org_Func");

            if (dataSet.Tables["Rel_Org_Func"].Rows.Count > 0)
            {

                dr = dataSet.Tables["Rel_Org_Func"].Rows[0];
                dr.BeginEdit();
                dr["Funcion"] = funcionario.EnFunciones;
                dr.EndEdit();

                dataAdapter.UpdateCommand = oleConne.CreateCommand();
                dataAdapter.UpdateCommand.CommandText =
                                                       "UPDATE Rel_Org_Func SET Funcion = @Funcion " +
                                                       " WHERE idFunc = @idFunc";

                dataAdapter.UpdateCommand.Parameters.Add("@Funcion", OleDbType.Numeric, 0, "Funcion");
                dataAdapter.UpdateCommand.Parameters.Add("@idFunc", OleDbType.Numeric, 0, "idFunc");

                dataAdapter.Update(dataSet, "Rel_Org_Func");
            }

            dataSet.Dispose();
            dataAdapter.Dispose();
            oleConne.Close();
        }

        public void DeleteFuncionario(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;

            cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM Rel_Org_Func WHERE idFunc = " + funcionario.IdFuncionario;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Funcionarios WHERE idFunc = " + funcionario.IdFuncionario;
                cmd.ExecuteNonQuery();
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
                oleConne.Close();
            }
        }

        public void DeleteTextoInicioNombramiento(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM Funcionarios WHERE idFunc = " + funcionario.IdFuncionario;
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

            dataAdapter.Fill(dataSet, "Funcionario");

            dr = dataSet.Tables["Funcionario"].Rows[0];
            dr.BeginEdit();
            dr["Texto"] = String.Empty;
            dr.EndEdit();

            dataAdapter.UpdateCommand = oleConne.CreateCommand();
            dataAdapter.UpdateCommand.CommandText =
                "UPDATE Funcionarios SET Texto = @Texto";

            dataAdapter.UpdateCommand.Parameters.Add("@Texto", OleDbType.VarChar, 0, "Texto");

            dataAdapter.Update(dataSet, "Funcionario");

            dataSet.Dispose();
            dataAdapter.Dispose();
            oleConne.Close();
        }

        public void DeleteRelacionFuncionario(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;

            cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            String sqlCadena = "DELETE FROM Rel_Org_Func WHERE idOrg = " + funcionario.IdOrganismo +
                               " AND idFunc = " + funcionario.IdFuncionario;

            try
            {
                oleConne.Open();

                cmd.CommandText = sqlCadena;
                cmd.ExecuteNonQuery();
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
                oleConne.Close();
            }
        }

        public void InsertaRelacionFuncionario(Funcionarios funcionario)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM Rel_Org_Func WHERE idFunc = 0";
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

            dataAdapter.Fill(dataSet, "Relacion");

            dr = dataSet.Tables["Relacion"].NewRow();
            dr["idOrg"] = funcionario.IdOrganismo;
            dr["idFunc"] = funcionario.IdFuncionario;
            dr["Funcion"] = 0;
            dr["Tels"] = "";

            dataSet.Tables["Relacion"].Rows.Add(dr);

            dataAdapter.InsertCommand = oleConne.CreateCommand();
            dataAdapter.InsertCommand.CommandText =
                                                   "INSERT INTO Rel_Org_Func(IdOrg,IdFunc,Funcion,Tels)" +
                                                   " VALUES(@IdOrg,@IdFunc,@Funcion,@Tels)";

            dataAdapter.InsertCommand.Parameters.Add("@IdOrg", OleDbType.Numeric, 0, "IdOrg");
            dataAdapter.InsertCommand.Parameters.Add("@IdFunc", OleDbType.Numeric, 0, "IdFunc");
            dataAdapter.InsertCommand.Parameters.Add("@Funcion", OleDbType.Numeric, 0, "Funcion");
            dataAdapter.InsertCommand.Parameters.Add("@Tels", OleDbType.LongVarChar, 0, "Tels");

            dataAdapter.Update(dataSet, "Relacion");

            dataSet.Dispose();
            dataAdapter.Dispose();
            oleConne.Close();
        }

        /// <summary>
        /// Asigna a un tribunal el funcionario respectivo
        /// </summary>
        /// <param name="funcionario">Funcionario que es asignado o reasignado</param>
        /// <param name="idOrganismo">Identificador del organismo al que se asigna</param>
        public void InsertaRelacionFuncionario(Funcionarios funcionario, int idOrganismo)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM Rel_Org_Func WHERE idFunc = 0";
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

            dataAdapter.Fill(dataSet, "Relacion");

            dr = dataSet.Tables["Relacion"].NewRow();
            dr["idOrg"] = idOrganismo;
            dr["idFunc"] = funcionario.IdFuncionario;
            dr["Funcion"] = 0;
            dr["Tels"] = "";

            dataSet.Tables["Relacion"].Rows.Add(dr);

            dataAdapter.InsertCommand = oleConne.CreateCommand();
            dataAdapter.InsertCommand.CommandText =
                                                   "INSERT INTO Rel_Org_Func(IdOrg,IdFunc,Funcion,Tels)" +
                                                   " VALUES(@IdOrg,@IdFunc,@Funcion,@Tels)";

            dataAdapter.InsertCommand.Parameters.Add("@IdOrg", OleDbType.Numeric, 0, "IdOrg");
            dataAdapter.InsertCommand.Parameters.Add("@IdFunc", OleDbType.Numeric, 0, "IdFunc");
            dataAdapter.InsertCommand.Parameters.Add("@Funcion", OleDbType.Numeric, 0, "Funcion");
            dataAdapter.InsertCommand.Parameters.Add("@Tels", OleDbType.LongVarChar, 0, "Tels");

            dataAdapter.Update(dataSet, "Relacion");

            dataSet.Dispose();
            dataAdapter.Dispose();
            oleConne.Close();
        }

        public ObservableCollection<CommonProperties> GetEstadoFuncionarios()
        {
            ObservableCollection<CommonProperties> estados = new ObservableCollection<CommonProperties>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM EstadoFuncionarios ";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CommonProperties estado = new CommonProperties();
                    estado.IdElemento = reader["IdEstado"] as int? ?? 0;
                    estado.Descripcion = reader["Estado"].ToString();

                    estados.Add(estado);
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
            return estados;
        }


        
    }
}