using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UsuariosModel.ObtenerUsuarioContraseña())
            {
                StyleManager.ApplicationTheme = new Windows8Theme();

                this.LaunchBusyIndicator();

                string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
            }
        }

        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var x = CambiosSingleton.CambiosOrganismos;
            var y = CambiosSingleton.CambioPresidente;
            var z = FuncionariosSingleton.FuncionariosCollection;
            var a = OrganismosSingleton.Instance.Colegiados;
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
            OrgWin main = new OrgWin();
            main.Show();
            this.Close();
        }

        private void LaunchBusyIndicator()
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }
        
        #endregion
    }
}