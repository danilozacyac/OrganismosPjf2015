using System;
using System.Collections.ObjectModel;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class EstadosSingleton
    {
        private static ObservableCollection<CommonProperties> estadoFuncionarios;

        private EstadosSingleton()
        {
        }

        public static ObservableCollection<CommonProperties> EstadoFuncionarios
        {
            get
            {
                if (estadoFuncionarios == null)
                    estadoFuncionarios = new FuncionariosModel().GetEstadoFuncionarios();

                return estadoFuncionarios;
            }
        }
    }
}
