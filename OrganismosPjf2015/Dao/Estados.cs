﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
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

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;
            OleDbDataReader reader;

            String sqlCadena = "SELECT * FROM Estados";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estados ciudad = new Estados();
                        ciudad.IdEstado = Convert.ToInt32(reader["idEstado"]);
                        ciudad.EstadoStr = reader["Estado"].ToString();
                        ciudad.Abrev = reader["Abrev"].ToString();

                        estados.Add(ciudad);
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
                oleConne.Close();
            }

            return estados;
        }
    }
}