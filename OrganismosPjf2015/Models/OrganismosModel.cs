using System;
using System.Collections.Generic;
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
    public class OrganismosModel
    {
        private readonly Organismos organismo;

        public OrganismosModel()
        {
        }

        public OrganismosModel(Organismos organismo)
        {
            this.organismo = organismo;
        }

        public ObservableCollection<Organismos> GetOrganismos(int tipoOrganismo)
        {
            ObservableCollection<Organismos> organismos = new ObservableCollection<Organismos>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN (Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado) " +
                               " ON O.Ciudad = C.IdCiudad WHERE TpoOrg = " + tipoOrganismo + " ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        Organismos organismoAdd = new Organismos();
                        organismoAdd.IdOrganismo = reader["IdOrg"] as int? ?? -1;
                        organismoAdd.TipoOrganismo = reader["TpoOrg"] as int? ?? -1;
                        organismoAdd.Circuito = reader["Circuito"] as int? ?? -1;
                        organismoAdd.Ordinal = reader["Ordinal"] as int? ?? -1;
                        organismoAdd.Materia = reader["Materia"] as int? ?? -1;
                        organismoAdd.Organismo = reader["Organismo"].ToString();
                        organismoAdd.Direccion = reader["Direccion"].ToString();
                        organismoAdd.Telefonos = reader["Tels"].ToString();
                        organismoAdd.Ciudad = reader["O.Ciudad"] as int? ?? -1;
                        organismoAdd.Integrantes = reader["Integrantes"] as int? ?? -1;
                        organismoAdd.OrdenImpresion = reader["OrdenImpr"] as int? ?? -1;
                        organismoAdd.ListaFuncionarios = new ObservableCollection<Funcionarios>();
                        organismoAdd.IdFuncionarioPresidente = new IntegracionesModel(organismoAdd.IdOrganismo).GetLastPresident();

                        foreach (Funcionarios func in new FuncionariosModel().GetFuncionariosPorOrganismo(organismoAdd.IdOrganismo))
                            organismoAdd.ListaFuncionarios.Add(func);

                        organismoAdd.Integrantes = organismoAdd.ListaFuncionarios.Count;

                        organismos.Add(organismoAdd);
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

            return organismos;
        }

        public Organismos GetOrganismoPorId(int idOrganismo)
        {
            Organismos organismo = new Organismos();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN (Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado) ON O.Ciudad = C.IdCiudad WHERE IdOrg = " + idOrganismo + " ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        organismo.IdOrganismo = reader["IdOrg"] as int? ?? -1;
                        organismo.TipoOrganismo = reader["TpoOrg"] as int? ?? -1;
                        organismo.Circuito = reader["Circuito"] as int? ?? -1;
                        organismo.Ordinal = reader["Ordinal"] as int? ?? -1;
                        organismo.Materia = reader["Materia"] as int? ?? -1;
                        organismo.Organismo = reader["Organismo"].ToString();
                        organismo.Direccion = reader["Direccion"].ToString();
                        organismo.Telefonos = reader["Tels"].ToString();
                        organismo.Ciudad = reader["O.Ciudad"] as int? ?? -1;
                        organismo.Integrantes = reader["Integrantes"] as int? ?? -1;
                        organismo.OrdenImpresion = reader["OrdenImpr"] as int? ?? -1;
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

            return organismo;
        }

        public void AddNuevoOrganismo()
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;
            try
            {
                int idOrg = DataBaseUtilities.GetNextIdForUse("Organismos", "IdOrg", oleConne);
                if (idOrg != 0)
                {

                    organismo.IdOrganismo = idOrg;
                    string sqlCadena = "SELECT * FROM Organismos WHERE idOrg = 0";
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

                    dataAdapter.Fill(dataSet, "Organismo");

                    dr = dataSet.Tables["Organismo"].NewRow();
                    dr["idOrg"] = idOrg;
                    dr["TpoOrg"] = organismo.TipoOrganismo;
                    dr["Circuito"] = organismo.Circuito;
                    dr["Ordinal"] = organismo.Ordinal;
                    dr["Materia"] = organismo.Materia;
                    dr["Organismo"] = organismo.Organismo;
                    dr["Direccion"] = organismo.Direccion;
                    dr["Tels"] = organismo.Telefonos;
                    dr["Ciudad"] = organismo.Ciudad;
                    dr["Integrantes"] = organismo.Integrantes;
                    dr["OrdenImpr"] = organismo.OrdenImpresion;

                    dataSet.Tables["Organismo"].Rows.Add(dr);

                    //dataAdapter.UpdateCommand = connectionEpsOle.CreateCommand();
                    dataAdapter.InsertCommand = oleConne.CreateCommand();
                    dataAdapter.InsertCommand.CommandText =
                                                           "INSERT INTO Organismos(idOrg,TpoOrg,Circuito,Ordinal,Materia,Organismo,Direccion," +
                                                           "Tels,Ciudad,Integrantes,OrdenImpr)" +
                                                           " VALUES(@idOrg,@TpoOrg,@Circuito,@Ordinal,@Materia,@Organismo,@Direccion," +
                                                           "@Tels,@Ciudad,@Integrantes,@OrdenImpr)";

                    dataAdapter.InsertCommand.Parameters.Add("@idOrg", OleDbType.Numeric, 0, "idOrg");
                    dataAdapter.InsertCommand.Parameters.Add("@TpoOrg", OleDbType.Numeric, 0, "TpoOrg");
                    dataAdapter.InsertCommand.Parameters.Add("@Circuito", OleDbType.Numeric, 0, "Circuito");
                    dataAdapter.InsertCommand.Parameters.Add("@Ordinal", OleDbType.Numeric, 0, "Ordinal");
                    dataAdapter.InsertCommand.Parameters.Add("@Materia", OleDbType.Numeric, 0, "Materia");
                    dataAdapter.InsertCommand.Parameters.Add("@Organismo", OleDbType.LongVarChar, 0, "Organismo");
                    dataAdapter.InsertCommand.Parameters.Add("@Direccion", OleDbType.LongVarChar, 0, "Direccion");
                    dataAdapter.InsertCommand.Parameters.Add("@Tels", OleDbType.LongVarChar, 0, "Tels");
                    dataAdapter.InsertCommand.Parameters.Add("@Ciudad", OleDbType.Numeric, 0, "Ciudad");
                    dataAdapter.InsertCommand.Parameters.Add("@Integrantes", OleDbType.Numeric, 0, "Integrantes");
                    dataAdapter.InsertCommand.Parameters.Add("@OrdenImpr", OleDbType.Numeric, 0, "OrdenImpr");

                    dataAdapter.Update(dataSet, "Organismo");

                    dataSet.Dispose();
                    dataAdapter.Dispose();

                    Bitacora bitacora = new Bitacora();
                    bitacora.IdMovimiento = 1;
                    bitacora.IdElemento = organismo.IdOrganismo;
                    bitacora.EdoActual = organismo.Organismo;
                    bitacora.EdoAnterior = " ";
                    bitacora.NombreEquipo = Environment.MachineName;
                    new BitacoraModel().SetNewBitacoraEntry(bitacora);

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
                oleConne.Close();
            }
            
        }// fin InsertarRegistro

        public void UpdateOrganismo()
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Organismos WHERE idOrg = " + organismo.IdOrganismo;
                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

                dataAdapter.Fill(dataSet, "Organismo");

                dr = dataSet.Tables["Organismo"].Rows[0];
                dr.BeginEdit();
                dr["TpoOrg"] = organismo.TipoOrganismo;
                dr["Circuito"] = organismo.Circuito;
                dr["Ordinal"] = organismo.Ordinal;
                dr["Materia"] = organismo.Materia;
                dr["Organismo"] = organismo.Organismo;
                dr["Direccion"] = organismo.Direccion;
                dr["Tels"] = organismo.Telefonos;
                dr["Ciudad"] = organismo.Ciudad;
                dr["Integrantes"] = organismo.Integrantes;
                dr["OrdenImpr"] = organismo.OrdenImpresion;
                dr.EndEdit();

                dataAdapter.UpdateCommand = oleConne.CreateCommand();
                dataAdapter.UpdateCommand.CommandText = "UPDATE Organismos SET TpoOrg = @TpoOrg, Circuito = @Circuito,Ordinal = @Ordinal,Materia = @Materia," +
                                                        "Organismo = @Organismo,Direccion = @Direccion, Tels = @Tels,Ciudad = @Ciudad," +
                                                        "Integrantes = @Integrantes,OrdenImpr = @OrdenImpr" +
                                                        " WHERE idOrg = @idOrg";

                dataAdapter.UpdateCommand.Parameters.Add("@TpoOrg", OleDbType.Numeric, 0, "TpoOrg");
                dataAdapter.UpdateCommand.Parameters.Add("@Circuito", OleDbType.Numeric, 0, "Circuito");
                dataAdapter.UpdateCommand.Parameters.Add("@Ordinal", OleDbType.Numeric, 0, "Ordinal");
                dataAdapter.UpdateCommand.Parameters.Add("@Materia", OleDbType.Numeric, 0, "Materia");
                dataAdapter.UpdateCommand.Parameters.Add("@Organismo", OleDbType.LongVarChar, 0, "Organismo");
                dataAdapter.UpdateCommand.Parameters.Add("@Direccion", OleDbType.LongVarChar, 0, "Direccion");
                dataAdapter.UpdateCommand.Parameters.Add("@Tels", OleDbType.LongVarChar, 0, "Tels");
                dataAdapter.UpdateCommand.Parameters.Add("@Ciudad", OleDbType.Numeric, 0, "Ciudad");
                dataAdapter.UpdateCommand.Parameters.Add("@Integrantes", OleDbType.Numeric, 0, "Integrantes");
                dataAdapter.UpdateCommand.Parameters.Add("@OrdenImpr", OleDbType.Numeric, 0, "OrdenImpr");
                dataAdapter.UpdateCommand.Parameters.Add("@idOrg", OleDbType.Numeric, 0, "idOrg");

                dataAdapter.Update(dataSet, "Organismo");

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

        public void DeleteOrganismo(Organismos organismo)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;

            cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM Rel_Org_Func WHERE idOrg = " + organismo.IdOrganismo;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Organismos WHERE idOrg = " + organismo.IdOrganismo;
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


        public static void SetNewIntegrantesCount()
        {
            Organismos organismoDelete = new Organismos();
            organismoDelete.IdOrganismo = 0;

            new OrganismosModel().DeleteOrganismo(organismoDelete);

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT  IdOrg,COUNT(IdORG) AS Total FROM Rel_Org_Func GROUP BY IdOrg";

            Dictionary<int, int> orgInt = new Dictionary<int, int>();

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        orgInt.Add(Convert.ToInt32(reader["IdOrg"]), Convert.ToInt32(reader["Total"]));
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

            OrganismosModel.UpdateNumIntegrantes(orgInt);

        }

        private static void UpdateNumIntegrantes(Dictionary<int, int> orgInt)
        {
            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbDataAdapter dataAdapter;

            foreach (KeyValuePair<int, int> pair in orgInt)
            {

                DataSet dataSet = new DataSet();
                DataRow dr;

                try
                {
                    string sqlCadena = "SELECT * FROM Organismos WHERE idOrg = " + pair.Key;
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, oleConne);

                    dataAdapter.Fill(dataSet, "Organismo");

                    dr = dataSet.Tables["Organismo"].Rows[0];
                    dr.BeginEdit();

                    dr["Integrantes"] = pair.Value;

                    dr.EndEdit();

                    dataAdapter.UpdateCommand = oleConne.CreateCommand();
                    dataAdapter.UpdateCommand.CommandText = "UPDATE Organismos SET Integrantes = @Integrantes " +
                                                            " WHERE idOrg = @idOrg";


                    dataAdapter.UpdateCommand.Parameters.Add("@Integrantes", OleDbType.Numeric, 0, "Integrantes");
                    dataAdapter.UpdateCommand.Parameters.Add("@idOrg", OleDbType.Numeric, 0, "idOrg");

                    dataAdapter.Update(dataSet, "Organismo");

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

        /// <summary>
        /// Devuelve los funcionarios adscritos a un organismo para efectos de la integración del mismo
        /// </summary>
        /// <param name="idOrganismo"></param>
        /// <returns></returns>
        public List<int> GetFuncionariosPorOrganismo(int idOrganismo)
        {
            List<int> listaFuncionarios = new List<int>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Rel_Org_Func WHERE IdOrg = @IdOrganismo";

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
                        listaFuncionarios.Add(reader["IdFunc"] as int? ?? -1);
                       
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

            return listaFuncionarios;
        }
    }
}
