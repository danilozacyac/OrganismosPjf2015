using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Singletons;
using ScjnUtilities;

namespace OrganismosPjf2015.MyUserControls
{
    /// <summary>
    /// Lógica de interacción para FuncionariosControl.xaml
    /// </summary>
    public partial class FuncionariosControl : UserControl
    {
        public Funcionarios FuncionarioPjf = null;
        private BackgroundWorker worker = new BackgroundWorker();

        public FuncionariosControl()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;  
        }

        private void UserFuncionarios_Loaded(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();

            }
        }

        private void GridFuncionarios_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            FuncionarioPjf = GridFuncionarios.SelectedItem as Funcionarios;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                this.GridFuncionarios.DataContext = (from n in FuncionariosSingleton.FuncionariosCollection
                                    where n.Nombre.ToUpper().Contains(StringUtilities.ConvMayEne(tempString)) ||
                                          n.Apellidos.ToUpper().Contains(StringUtilities.ConvMayEne(tempString))
                                    select n).ToList();
            }
            else
                this.GridFuncionarios.DataContext = FuncionariosSingleton.FuncionariosCollection;

            
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = FuncionariosSingleton.FuncionariosCollection;
        }

        private void UpdateGridDataSource(ObservableCollection<Funcionarios> funcionariosResult)
        {
            this.GridFuncionarios.DataContext = funcionariosResult;
            this.BusyIndicator.IsBusy = false;
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action<ObservableCollection<Funcionarios>>(this.UpdateGridDataSource), e.Result);
        }
    }
}