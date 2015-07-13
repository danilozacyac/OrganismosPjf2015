using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrganismosPjf2015.Dao;
using ScjnUtilities;

namespace OrganismosPjf2015.Models
{
    public class UsuariosModel
    {
        public static  bool ObtenerUsuarioContraseña()
        {
            bool bExisteUsuario = false;
            string sOleDb;

            OleDbConnection connection = new OleDbConnection( ConfigurationManager.ConnectionStrings["Directorio"].ToString());

            OleDbCommand cmd;
            OleDbDataReader reader;


            try
            {
                connection.Open();

                sOleDb = "SELECT * FROM Usuarios WHERE usuario = @usuario";// AND Pass = @Pass";
                cmd = new OleDbCommand(sOleDb, connection);
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
                connection.Close();
            }

            return bExisteUsuario;
        }

    }
}
