using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganismosPjf2015.Converters;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for HistorialOrganismos.xaml
    /// </summary>
    public partial class HistorialOrganismos
    {
        private Organismos organismo;

        public HistorialOrganismos(Organismos organismo)
        {
            InitializeComponent();
            this.organismo = organismo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (organismo.Integraciones == null)
                organismo.Integraciones = new IntegracionesModel(organismo.IdOrganismo).GetIntegracionesByOrganismo();

            RLstFechasInt.DataContext = organismo.Integraciones;
        }

        private void RLstFechasInt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Integraciones integracion = RLstFechasInt.SelectedItem as Integraciones;

            RLstIntegracion.DataContext = integracion.Integrantes;
            RLstPresidentes.DataContext = integracion.Presidentes;
        }

        private void RLstPresidentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Funcionarios funcionario = RLstPresidentes.SelectedItem as Funcionarios;

            if(funcionario != null)
                TxtFPresidente.Text = new LongDateConverter().Convert(funcionario.Texto, null, null, null).ToString();
        }

        
    }
}
