using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class CiudadesSingleton
    {
        private static ObservableCollection<Ciudad> ciudades;

        private CiudadesSingleton()
        {
        }

        public static ObservableCollection<Ciudad> Ciudades
        {
            get
            {
                if (ciudades == null)
                    ciudades = new CiudadesModel().GetCiudades();

                return ciudades;
            }
        }

        private static List<Estados> estados;


        public static List<Estados> Estados
        {
            get
            {
                if (estados == null)
                    estados = new EstadosModel().GetEstados();

                return estados;
            }
        }
    }
}
