﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ScjnUtilities;

namespace OrganismosPjf2015.Dao
{
    public class Estados
    {
        private int idEstado;
        private String estadoStr;
        private String abrev;
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

        public String EstadoStr
        {
            get
            {
                return this.estadoStr;
            }
            set
            {
                this.estadoStr = value;
            }
        }

        public String Abrev
        {
            get
            {
                return this.abrev;
            }
            set
            {
                this.abrev = value;
            }
        }

        public List<Estados> GetEstados()
        {
            List<Estados> estados = new List<Estados>();

            SqlConnection oleConne = new SqlConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd;
            SqlDataReader reader;

            try
            {
                oleConne.Open();

                cmd = new SqlCommand("SELECT * FROM Estados", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estados ciudad = new Estados()
                        {
                            IdEstado = Convert.ToInt32(reader["idEstado"]),
                            EstadoStr = reader["Estado"].ToString(),
                            Abrev = reader["Abrev"].ToString()
                        };

                        estados.Add(ciudad);
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, Estados", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, Estados", "OrganismosPjf2015");
            }
            finally
            {
                oleConne.Close();
            }

            return estados;
        }
    }
}
