using System;
using System.Collections.Generic;
using System.Linq;
using OrganismosPjf2015.Dao;

namespace OrganismosPjf2015.Singletons
{
    class CambiosSingleton
    {
        private static List<int> cambiosOrganismos;
        private static List<CommonProperties> cambioPresidente;

        private CambiosSingleton()
        {
        }

        public static List<int> CambiosOrganismos
        {
            get
            {
                if (cambiosOrganismos == null)
                    cambiosOrganismos = new List<int>();

                return cambiosOrganismos;
            }
        }

        public static List<CommonProperties> CambioPresidente
        {
            get
            {
                if (cambioPresidente == null)
                    cambioPresidente = new List<CommonProperties>();

                return cambioPresidente;
            }
        }
    }
}
