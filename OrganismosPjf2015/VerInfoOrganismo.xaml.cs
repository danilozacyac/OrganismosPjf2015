using System;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Dao;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for VerInfoOrganismo.xaml
    /// </summary>
    public partial class VerInfoOrganismo
    {
        private readonly Organismos organismo;

        public VerInfoOrganismo(Organismos organismo)
        {
            InitializeComponent();
            this.organismo = organismo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = organismo;
        }
    }
}
