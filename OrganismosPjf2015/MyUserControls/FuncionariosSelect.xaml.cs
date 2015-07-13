using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.MyUserControls
{
    /// <summary>
    /// Lógica de interacción para FuncionariosSelect.xaml
    /// </summary>
    public partial class FuncionariosSelect : UserControl
    {
        public ObservableCollection<Funcionarios> TodosFuncionarios;
        private readonly int tipoOrganismo = 0;


        public FuncionariosSelect()
        {
            InitializeComponent();

        }

        public FuncionariosSelect(int tipoOrganismo)
        {
            InitializeComponent();
            this.tipoOrganismo = tipoOrganismo;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TodosFuncionarios = new FuncionariosModel().GetFuncionarios(tipoOrganismo);
            GridFuncionarios.DataContext = TodosFuncionarios;
        }
    }
}
