using System;
using System.Collections.Generic;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class CircuitosSingleton
    {
        private static List<CommonProperties> circuitos;

        private CircuitosSingleton()
        {
        }

        public static List<CommonProperties> Circuitos
        {
            get
            {
                if (circuitos == null)
                    circuitos = new CircuitosModel().GetCircuitos();

                return circuitos;
            }
        }
    }
}
