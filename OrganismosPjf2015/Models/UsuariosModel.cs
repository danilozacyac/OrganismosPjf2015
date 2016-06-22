using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class UsuariosModel
    {
        public static  bool ObtenerUsuarioContraseña()
        {
            bool bExisteUsuario = false;
            string sSql;

            SqlConnection connection = new SqlConnection( ConfigurationManager.ConnectionStrings["Directorio"].ConnectionString);

            SqlCommand cmd;
            SqlDataReader reader;


            try
            {
                connection.Open();

                sSql = "SELECT * FROM Usuarios WHERE usuario = @usuario";// AND Pass = @Pass";
                cmd = new SqlCommand(sSql, connection);
                cmd.Parameters.AddWithValue("@usuario", Environment.UserName.ToUpper());
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuarios.IdUsuario = reader["IdUsuario"] as int? ?? -1;
                    Usuarios.Nombre = reader["Nombre"].ToString();
                    Usuarios.Usuario = reader["Usuario"].ToString();
                    Usuarios.Perfil = reader["Perfil"] as int? ?? -1;

                    bExisteUsuario = true;
                }
                else
                {
                    Usuarios.IdUsuario = -1;
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, UsuariosModel", "OrganismosPjf2015");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, UsuariosModel", "OrganismosPjf2015");
            }
            finally
            {
                connection.Close();
            }

            return bExisteUsuario;
        }

    }
}
