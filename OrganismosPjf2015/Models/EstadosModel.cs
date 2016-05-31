using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class EstadosModel
    {
        public List<Estados> GetEstados()
        {
            List<Estados> estados = new List<Estados>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand("SELECT * FROM Estados", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estados estado = new Estados()
                        {
                            IdEstado = Convert.ToInt32(reader["idEstado"]),
                            EstadoStr = reader["Estado"].ToString(),
                            Abrev = reader["Abrev"].ToString()
                        };

                        estados.Add(estado);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, EstadosModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, EstadosModel", 0);
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
