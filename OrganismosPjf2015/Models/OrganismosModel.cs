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

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado " +
                               " ON O.IdCiudad = C.IdCiudad WHERE IdTpoOrg = @TipoOrg ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new SqlCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@TipoOrg", tipoOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        Organismos organismoAdd = new Organismos();
                        organismoAdd.IdOrganismo = Convert.ToInt32(reader["IdOrganismo"]);
                        organismoAdd.TipoOrganismo = reader["IdTpoOrg"] as int? ?? -1;
                        organismoAdd.Circuito = reader["IdCircuito"] as int? ?? -1;
                        organismoAdd.Ordinal = reader["IdOrdinal"] as int? ?? -1;
                        organismoAdd.Materia = reader["IdMateria"] as int? ?? -1;
                        organismoAdd.Organismo = reader["Organismo"].ToString();
                        organismoAdd.Direccion = reader["Direccion"].ToString();
                        organismoAdd.Telefonos = reader["Tels"].ToString();
                        organismoAdd.Ciudad = reader["IdCiudad"] as int? ?? -1;
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
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
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

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            String sqlCadena = "SELECT O.*, C.Ciudad, E.Abrev " +
                               "FROM Organismos O INNER JOIN (Ciudades C INNER JOIN Estados E ON C.IdEstado = E.IdEstado) ON O.IdCiudad = C.IdCiudad WHERE IdOrganismo = @IdOrg ORDER BY OrdenImpr";

            try
            {
                oleConne.Open();

                cmd = new SqlCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdOrg", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        organismo.IdOrganismo = Convert.ToInt32(reader["IdOrganismo"]);
                        organismo.TipoOrganismo = reader["IdTpoOrg"] as int? ?? -1;
                        organismo.Circuito = reader["IdCircuito"] as int? ?? -1;
                        organismo.Ordinal = reader["IDOrdinal"] as int? ?? -1;
                        organismo.Materia = reader["IdMateria"] as int? ?? -1;
                        organismo.Organismo = reader["Organismo"].ToString();
                        organismo.Direccion = reader["Direccion"].ToString();
                        organismo.Telefonos = reader["Tels"].ToString();
                        organismo.Ciudad = reader["IdCiudad"] as int? ?? -1;
                        organismo.Integrantes = reader["Integrantes"] as int? ?? -1;
                        organismo.OrdenImpresion = reader["OrdenImpr"] as int? ?? -1;
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
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
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;
            try
            {
                int idOrg = DataBaseUtilities.GetNextIdForUse("Organismos", "IdOrganismo", oleConne);
                if (idOrg != 0)
                {

                    organismo.IdOrganismo = idOrg;
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Organismos WHERE IdOrganismo = 0", oleConne);

                    dataAdapter.Fill(dataSet, "Organismo");

                    dr = dataSet.Tables["Organismo"].NewRow();
                    dr["IdOrganismo"] = idOrg;
                    dr["IdTpoOrg"] = organismo.TipoOrganismo;
                    dr["IdCircuito"] = organismo.Circuito;
                    dr["IdOrdinal"] = organismo.Ordinal;
                    dr["IdMateria"] = organismo.Materia;
                    dr["Organismo"] = organismo.Organismo;
                    dr["Direccion"] = organismo.Direccion;
                    dr["Tels"] = organismo.Telefonos;
                    dr["IdCiudad"] = organismo.Ciudad;
                    dr["Integrantes"] = organismo.Integrantes;
                    dr["OrdenImpr"] = organismo.OrdenImpresion;

                    dataSet.Tables["Organismo"].Rows.Add(dr);

                    //dataAdapter.UpdateCommand = connectionEpsOle.CreateCommand();
                    dataAdapter.InsertCommand = oleConne.CreateCommand();
                    dataAdapter.InsertCommand.CommandText =
                                                           "INSERT INTO Organismos(IdOrganismo,IdTpoOrg,IdCircuito,IdOrdinal,IdMateria,Organismo,Direccion," +
                                                           "Tels,IdCiudad,Integrantes,OrdenImpr)" +
                                                           " VALUES(@IdOrganismo,@IdTpoOrg,@IdCircuito,@IdOrdinal,@IdMateria,@Organismo,@Direccion," +
                                                           "@Tels,@IdCiudad,@Integrantes,@OrdenImpr)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdOrganismo", SqlDbType.Int, 0, "IdOrganismo");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTpoOrg", SqlDbType.Int, 0, "IdTpoOrg");
                    dataAdapter.InsertCommand.Parameters.Add("@IdCircuito", SqlDbType.Int, 0, "IdCircuito");
                    dataAdapter.InsertCommand.Parameters.Add("@IdOrdinal", SqlDbType.Int, 0, "IdOrdinal");
                    dataAdapter.InsertCommand.Parameters.Add("@IdMateria", SqlDbType.Int, 0, "IdMateria");
                    dataAdapter.InsertCommand.Parameters.Add("@Organismo", SqlDbType.VarChar, 0, "Organismo");
                    dataAdapter.InsertCommand.Parameters.Add("@Direccion", SqlDbType.VarChar, 0, "Direccion");
                    dataAdapter.InsertCommand.Parameters.Add("@Tels", SqlDbType.VarChar, 0, "Tels");
                    dataAdapter.InsertCommand.Parameters.Add("@IdCiudad", SqlDbType.Int, 0, "IdCiudad");
                    dataAdapter.InsertCommand.Parameters.Add("@Integrantes", SqlDbType.Int, 0, "Integrantes");
                    dataAdapter.InsertCommand.Parameters.Add("@OrdenImpr", SqlDbType.Int, 0, "OrdenImpr");

                    dataAdapter.Update(dataSet, "Organismo");

                    dataSet.Dispose();
                    dataAdapter.Dispose();

                    Bitacora bitacora = new Bitacora()
                    {
                        IdMovimiento = 1,
                        IdElemento = organismo.IdOrganismo,
                        EdoActual = organismo.Organismo,
                        EdoAnterior = " ",
                        NombreEquipo = Environment.MachineName
                    };
                    new BitacoraModel().SetNewBitacoraEntry(bitacora);

                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            finally
            {
                oleConne.Close();
            }
            
        }// fin InsertarRegistro

        public void UpdateOrganismo()
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM Organismos WHERE IdOrganismo = " + organismo.IdOrganismo;
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(sqlCadena, oleConne);

                dataAdapter.Fill(dataSet, "Organismo");

                dr = dataSet.Tables["Organismo"].Rows[0];
                dr.BeginEdit();
                dr["IdTpoOrg"] = organismo.TipoOrganismo;
                dr["IDCircuito"] = organismo.Circuito;
                dr["IdOrdinal"] = organismo.Ordinal;
                dr["IdMateria"] = organismo.Materia;
                dr["Organismo"] = organismo.Organismo;
                dr["Direccion"] = organismo.Direccion;
                dr["Tels"] = organismo.Telefonos;
                dr["IdCiudad"] = organismo.Ciudad;
                dr["Integrantes"] = organismo.Integrantes;
                dr["OrdenImpr"] = organismo.OrdenImpresion;
                dr.EndEdit();

                dataAdapter.UpdateCommand = oleConne.CreateCommand();
                dataAdapter.UpdateCommand.CommandText = "UPDATE Organismos SET IdTpoOrg = @IdTpoOrg, IDCircuito = @IDCircuito,IdOrdinal = @IdOrdinal,IdMateria = @IdMateria," +
                                                        "Organismo = @Organismo,Direccion = @Direccion, Tels = @Tels,IdCiudad = @IdCiudad," +
                                                        "Integrantes = @Integrantes,OrdenImpr = @OrdenImpr" +
                                                        " WHERE IdOrganismo = @IdOrganismo";

                dataAdapter.UpdateCommand.Parameters.Add("@IdTpoOrg", SqlDbType.Int, 0, "IdTpoOrg");
                dataAdapter.UpdateCommand.Parameters.Add("@IDCircuito", SqlDbType.Int, 0, "IDCircuito");
                dataAdapter.UpdateCommand.Parameters.Add("@IdOrdinal", SqlDbType.Int, 0, "IdOrdinal");
                dataAdapter.UpdateCommand.Parameters.Add("@IdMateria", SqlDbType.Int, 0, "IdMateria");
                dataAdapter.UpdateCommand.Parameters.Add("@Organismo", SqlDbType.VarChar, 0, "Organismo");
                dataAdapter.UpdateCommand.Parameters.Add("@Direccion", SqlDbType.VarChar, 0, "Direccion");
                dataAdapter.UpdateCommand.Parameters.Add("@Tels", SqlDbType.VarChar, 0, "Tels");
                dataAdapter.UpdateCommand.Parameters.Add("@IdCiudad", SqlDbType.Int, 0, "IdCiudad");
                dataAdapter.UpdateCommand.Parameters.Add("@Integrantes", SqlDbType.Int, 0, "Integrantes");
                dataAdapter.UpdateCommand.Parameters.Add("@OrdenImpr", SqlDbType.Int, 0, "OrdenImpr");
                dataAdapter.UpdateCommand.Parameters.Add("@IdOrganismo", SqlDbType.Int, 0, "IdOrganismo");

                dataAdapter.Update(dataSet, "Organismo");

                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            finally
            {
                oleConne.Close();
            }
        }

        public void DeleteOrganismo(Organismos organismo)
        {
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM Rel_Org_Func WHERE IdOrganismo = " + organismo.IdOrganismo;
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Organismos WHERE IdOrganismo = " + organismo.IdOrganismo;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            finally
            {
                cmd.Dispose();
                oleConne.Close();
            }
        }


        public static void SetNewIntegrantesCount()
        {
            Organismos organismoDelete = new Organismos() { IdOrganismo = 0 };

            new OrganismosModel().DeleteOrganismo(organismoDelete);

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            Dictionary<int, int> orgInt = new Dictionary<int, int>();

            try
            {
                oleConne.Open();

                cmd = new SqlCommand("SELECT  IdOrganismo,COUNT(IdOrganismo) AS Total FROM Rel_Org_Func GROUP BY IdOrganismo", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        orgInt.Add(Convert.ToInt32(reader["IdOrganismo"]), Convert.ToInt32(reader["Total"]));
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
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
            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlDataAdapter dataAdapter;

            foreach (KeyValuePair<int, int> pair in orgInt)
            {

                DataSet dataSet = new DataSet();
                DataRow dr;

                try
                {
                    string sqlCadena = "SELECT * FROM Organismos WHERE IdOrganismo = " + pair.Key;
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand(sqlCadena, oleConne);

                    dataAdapter.Fill(dataSet, "Organismo");

                    dr = dataSet.Tables["Organismo"].Rows[0];
                    dr.BeginEdit();

                    dr["Integrantes"] = pair.Value;

                    dr.EndEdit();

                    dataAdapter.UpdateCommand = oleConne.CreateCommand();
                    dataAdapter.UpdateCommand.CommandText = "UPDATE Organismos SET Integrantes = @Integrantes " +
                                                            " WHERE IdOrganismo = @IdOrganismo";


                    dataAdapter.UpdateCommand.Parameters.Add("@Integrantes", SqlDbType.Int, 0, "Integrantes");
                    dataAdapter.UpdateCommand.Parameters.Add("@IdOrganismo", SqlDbType.Int, 0, "IdOrganismo");

                    dataAdapter.Update(dataSet, "Organismo");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                }
                catch (SqlException ex)
                {
                    string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                    ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
                }
                catch (Exception ex)
                {
                    string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                    ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
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

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new SqlCommand("SELECT * FROM Rel_Org_Func WHERE IdOrganismo = @IdOrganismo", oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listaFuncionarios.Add(reader["IdFuncionario"] as int? ?? -1);
                       
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "OrganismosPjf2015");
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
