﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class OrdinalesModel
    {
        public List<CommonProperties> GetOrdinales()
        {
            List<CommonProperties> ordinales = new List<CommonProperties>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand("SELECT * FROM Ordinales", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommonProperties ordinal = new CommonProperties()
                        {
                            IdElemento = Convert.ToInt32(reader["idOrdinal"]),
                            Descripcion = reader["Ordinal"].ToString()
                        };

                        ordinales.Add(ordinal);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrdinalesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrdinalesModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return ordinales;
        }
    }
}
