using System;
using System.Collections.ObjectModel;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public class FuncionariosSingleton
    {
        private static ObservableCollection<Funcionarios> funcionarios;

        private FuncionariosSingleton()
        {
        }

        public static ObservableCollection<Funcionarios> FuncionariosCollection
        {
            get
            {
                if (funcionarios == null)
                    funcionarios = new FuncionariosModel().GetFuncionarios(0);

                return funcionarios;
            }
        }


    }
}
