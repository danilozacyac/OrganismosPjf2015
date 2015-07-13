using System;
using System.Collections.Generic;
using System.Linq;
using OrganismosPjf2015.Dao;

namespace OrganismosPjf2015.Singletons
{
    public class TipoOrganismosSingleton
    {
        private static List<CommonProperties> tipos;

        private TipoOrganismosSingleton()
        {
        }


        public static List<CommonProperties> Tipos
        {
            get
            {
                if (tipos == null)
                {
                    tipos = new List<CommonProperties>();
                    tipos.Add(new CommonProperties(1, "Tribunal Colegiado"));
                    tipos.Add(new CommonProperties(2, "Tribunal Unitario"));
                    tipos.Add(new CommonProperties(3, "Juzgado de Distrito"));
                    tipos.Add(new CommonProperties(4, "Plenos de Circuito"));
                }
                return tipos;
            }
        }
    }
}
