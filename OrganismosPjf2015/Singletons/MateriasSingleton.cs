using System;
using System.Collections.Generic;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class MateriasSingleton
    {
        private static List<CommonProperties> materias;

        private MateriasSingleton()
        {
        }

        public static List<CommonProperties> Materias
        {
            get
            {
                if (materias == null)
                    materias = new MateriasModel().GetMaterias();

                return materias;
            }
        }
    }
}
