using System;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for HistorialFuncionarios.xaml
    /// </summary>
    public partial class HistorialFuncionarios
    {
        private readonly int idFuncionario;

        public HistorialFuncionarios(int idFuncionario)
        {
            InitializeComponent();
            this.idFuncionario = idFuncionario;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RLstHistorial.DataContext = new FuncionariosModel().GetHistorialFuncionarios(idFuncionario);
        }
    }
}
