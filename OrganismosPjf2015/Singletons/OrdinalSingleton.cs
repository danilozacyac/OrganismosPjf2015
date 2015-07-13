using System;
using System.Collections.Generic;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class OrdinalSingleton
    {
        private static List<CommonProperties> ordinales;

        private OrdinalSingleton()
        {
        }

        public static List<CommonProperties> Ordinales
        {
            get
            {
                if (ordinales == null)
                    ordinales = new OrdinalesModel().GetOrdinales();

                return ordinales;
            }
        }
    }
}
