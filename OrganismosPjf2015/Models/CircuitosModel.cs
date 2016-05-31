using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class CircuitosModel
    {
        public List<CommonProperties> GetCircuitos()
        {
            List<CommonProperties> circuitos = new List<CommonProperties>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;
            OleDbDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand("SELECT * FROM Circuitos", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommonProperties circuito = new CommonProperties()
                        {
                            IdElemento = Convert.ToInt32(reader["idCircuito"]),
                            Descripcion = reader["Circuito"].ToString()
                        };

                        circuitos.Add(circuito);
                    }
                }
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, CircuitosModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, CircuitosModel", 0);
            }
            finally
            {
                reader.Close();
                oleConne.Close();
            }

            return circuitos;
        }
    }
}
