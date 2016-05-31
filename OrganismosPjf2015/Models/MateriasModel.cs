using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class MateriasModel
    {
        public List<CommonProperties> GetMaterias()
        {
            List<CommonProperties> materias = new List<CommonProperties>();

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Directorio"].ToString());
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand("SELECT * FROM Materias", oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommonProperties materia = new CommonProperties()
                        {
                            IdElemento = Convert.ToInt32(reader["idMateria"]),
                            Descripcion = reader["Materia"].ToString()
                        };

                        materias.Add(materia);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, MateriasModel", 0);
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, MateriasModel", 0);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return materias;
        }
    }
}
