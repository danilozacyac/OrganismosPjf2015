using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

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

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd;
            OleDbDataReader reader;

            String sqlCadena = "SELECT * FROM Ciudades";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
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
            catch (OleDbException sql)
            {
                MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
            }
            finally
            {
                oleConne.Close();
            }

            return ciudades;
        }


    }
}
