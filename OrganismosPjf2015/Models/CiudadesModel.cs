using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class CiudadesModel
    {
        public ObservableCollection<Ciudad> GetCiudades()
        {
            ObservableCollection<Ciudad> ciudades = new ObservableCollection<Ciudad>();

            SqlConnection oleConne = new SqlConnection( ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new SqlCommand("SELECT * FROM Ciudades", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ciudad ciudad = new Ciudad()
                        {
                            IdCiudad = Convert.ToInt32(reader["idCiudad"]),
                            IdEstado = Convert.ToInt32(reader["idEstado"]),
                            CiudadStr = reader["Ciudad"].ToString()
                        };

                        ciudades.Add(ciudad);
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, CiudadesModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, CiudadesModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return ciudades;
        }
    }
}
