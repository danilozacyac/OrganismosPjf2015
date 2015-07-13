using System;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class Usuarios
    {
        private static int idUsuario;
        private static string nombre;
        private static string usuario;
        private static int perfil;
        
        public static int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public static string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public static string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public static int Perfil
        {
            get
            {
                return perfil;
            }
            set
            {
                perfil = value;
            }
        }
    }
}
