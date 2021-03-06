﻿using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace OrganismosPjf2015.Dao
{
    public class Ciudad
    {
        private int idCiudad;
        private int idEstado;
        private String ciudadStr;

        public String CiudadStr
        {
            get
            {
                return this.ciudadStr;
            }
            set
            {
                this.ciudadStr = value;
            }
        }

        public int IdCiudad
        {
            get
            {
                return this.idCiudad;
            }
            set
            {
                this.idCiudad = value;
            }
        }

        public int IdEstado
        {
            get
            {
                return this.idEstado;
            }
            set
            {
                this.idEstado = value;
            }
        }

        public List<Ciudad> GetCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd;
            SqlDataReader reader;

            try
            {
                oleConne.Open();

                cmd = new SqlCommand("SELECT * FROM Ciudades", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ciudad ciudad = new Ciudad();
                        ciudad.IdCiudad = Convert.ToInt32(reader["idCiudad"]);
                        ciudad.IdEstado = Convert.ToInt32(reader["idEstado"]);
                        ciudad.CiudadStr = reader["Ciudad"].ToString();

                        ciudades.Add(ciudad);
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, Ciudad", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, Ciudad", "OrganismosPjf2015");
            }
            finally
            {
                oleConne.Close();
            }

            return ciudades;
        }


    }
}
