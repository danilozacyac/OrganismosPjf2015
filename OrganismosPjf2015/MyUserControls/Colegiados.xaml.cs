using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls;

namespace OrganismosPjf2015.MyUserControls
{
    /// <summary>
    /// Lógica de interacción para Colegiados.xaml
    /// </summary>
    public partial class Colegiados : UserControl 
    {
        public Organismos OrgColegiado = null;
        private readonly int tipoOrganismo;

        private BackgroundWorker worker = new BackgroundWorker();

        public Colegiados()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;  
        }

        public Colegiados(int tipoOrganismo) 
        {
            InitializeComponent();
            this.tipoOrganismo = tipoOrganismo;
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;  
        }

        private void UserColegiados_Loaded(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();
                
            }
        }

        private void GridColegiados_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            
            OrgColegiado = GridColegiados.SelectedItem as Organismos;

        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (tipoOrganismo == 1)
                e.Result = OrganismosSingleton.Instance.Colegiados;
            else if (tipoOrganismo == 2)
                e.Result = OrganismosSingleton.Instance.Unitarios;
            else if (tipoOrganismo == 3)
                e.Result = OrganismosSingleton.Instance.Juzgados;
            else if (tipoOrganismo == 4)
                e.Result = OrganismosSingleton.Instance.Plenos;
        }

        private void UpdateGridDataSource(ObservableCollection<Organismos> employees)
        {
            this.GridColegiados.DataContext = employees;
            this.BusyIndicator.IsBusy = false;
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
        }
    }
}
