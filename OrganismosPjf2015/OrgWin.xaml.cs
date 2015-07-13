using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.MyUserControls;
using OrganismosPjf2015.Reportes;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for OrgWin.xaml
    /// </summary>
    public partial class OrgWin
    {
        private int busyIndicatorAction = 0;
        private Organismos organismo = null;
        private Funcionarios funcionario = null;

        private Colegiados controlPlenos;
        private Colegiados controlColegiados;
        private Colegiados controlUnitarios;
        private Colegiados controlJuzgados;
        private FuncionariosControl controlFuncionarios;


        private BackgroundWorker worker = new BackgroundWorker();
        ObservableCollection<Organismos> organismosToPrint = null;

        public OrgWin()
        {
            InitializeComponent();
            OrgWin.ShowInTaskbar(this, "Directorio");

            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Usuarios.IdUsuario == 1)
                RBtnIntegracionHoy.IsEnabled = true;
        }

        

        
        

        

        private void Docking_ActivePaneChanged(object sender, Telerik.Windows.Controls.Docking.ActivePangeChangedEventArgs e)
        {
        }

       

        private void SelectObjectSelectedTab()
        {
            switch (Convert.ToInt16(Docking.ActivePane.Tag))
            {
                case 1:
                    organismo = controlColegiados.OrgColegiado;
                    break;
                case 2:
                    organismo = controlUnitarios.OrgColegiado;
                    break;
                case 3:
                    organismo = controlJuzgados.OrgColegiado;
                    break;
                case 4:
                    organismo = controlPlenos.OrgColegiado;
                    break;
                case 5:
                    funcionario = controlFuncionarios.FuncionarioPjf;
                    break;
            }
        }

        /// <summary>
        /// Permite mostrar las ventanas de tipo RadWindow el Taskbar
        /// además permite asignar el icono de la aplicación y el nombre de la ventana
        /// </summary>
        /// <param name="control"></param>
        /// <param name="title"></param>
        public static void ShowInTaskbar(RadWindow control, string title)
        {
            control.Show();
            var window = control.ParentOfType<Window>();
            window.ShowInTaskbar = true;
            window.Title = title;
            var uri = new Uri("pack://application:,,,/Resources/addressbook_blue_256.png");
            window.Icon = BitmapFrame.Create(uri);
        }

        

        private void RadWindow_PreviewClosed(object sender, WindowPreviewClosedEventArgs e)
        {
            if (CambiosSingleton.CambiosOrganismos.Count > 0)
            {
                foreach (int org in CambiosSingleton.CambiosOrganismos)
                {
                    List<int> funcionariosOrganismo = new OrganismosModel().GetFuncionariosPorOrganismo(org);

                    IntegracionesModel model = new IntegracionesModel(org);
                    int idIntegracion = model.GetNewIntegracion();

                    if (idIntegracion != 0)
                    {
                        model.SetIntegracionFuncionarios(funcionariosOrganismo, idIntegracion);

                        Bitacora bitacora = new Bitacora();
                        bitacora.IdMovimiento = 64;
                        bitacora.IdElemento = idIntegracion;
                        bitacora.EdoActual = "Cambio Integracion";
                        bitacora.EdoAnterior = " ";
                        bitacora.NombreEquipo = Environment.MachineName;
                        new BitacoraModel().SetNewBitacoraEntry(bitacora);
                    }
                }
            }

            if (CambiosSingleton.CambioPresidente.Count > 0)
            {
                foreach (CommonProperties pres in CambiosSingleton.CambioPresidente)
                {
                    IntegracionesModel model = new IntegracionesModel(Convert.ToInt32(pres.Descripcion));
                    model.SetNewPresidente(pres.IdElemento);

                    Bitacora bitacora = new Bitacora();
                    bitacora.IdMovimiento = 128;
                    bitacora.IdElemento = pres.IdElemento;
                    bitacora.EdoActual = "Cambio Presidente";
                    bitacora.EdoAnterior = " ";
                    bitacora.NombreEquipo = Environment.MachineName;
                    new BitacoraModel().SetNewBitacoraEntry(bitacora);
                }
            }
        }

        

        

        #region Pane Section


        private RadPane GetExistingPane(int tag)
        {
            RadPane pane = null;

            foreach (RadPane panes in Docking.Panes)
            {
                if (Convert.ToInt32(panes.Tag) == tag)
                {
                    pane = panes;
                    break;
                }
            }
            return pane;
        }

        int action = 0;
        private void AddPane(int tag, string tabTitle, object organoControl)
        {
            action = tag;

            RadPane existingPane = this.GetExistingPane(tag);

            if (existingPane == null)
            {
                RadPane pane = new RadPane();
                pane.Tag = tag;
                pane.Header = tabTitle;
                pane.Content = organoControl;

                PanelCentral.Items.Add(pane);
                Docking.ActivePane = pane;
            }
            else
            {
                existingPane.IsHidden = false;
                Docking.ActivePane = existingPane;
            }
        }

        private void RBtnPlenos_Click(object sender, RoutedEventArgs e)
        {
            if (controlPlenos == null)
                controlPlenos = new Colegiados(4);

            this.AddPane(4, "Plenos de Circuito", controlPlenos);
        }

        private void RBtnColegiados_Click(object sender, RoutedEventArgs e)
        {
            if (controlColegiados == null)
                controlColegiados = new Colegiados(1);

            this.AddPane(1, "Tribunales Colegiados", controlColegiados);
        }

        private void RBtnUnitarios_Click(object sender, RoutedEventArgs e)
        {
            if (controlUnitarios == null)
                controlUnitarios = new Colegiados(2);

            this.AddPane(2, "Tribunales Unitarios", controlUnitarios);
        }

        private void RbtnJuzgados_Click(object sender, RoutedEventArgs e)
        {
            if (controlJuzgados == null)
                controlJuzgados = new Colegiados(3);

            this.AddPane(3, "Juzgados de Circuito", controlJuzgados);
        }

        private void RBtnFuncionarios_Click(object sender, RoutedEventArgs e)
        {
            if (controlFuncionarios == null)
                controlFuncionarios = new FuncionariosControl();

            this.AddPane(5, "Funcionarios", controlFuncionarios);
        }

        #endregion

        #region Acciones

        private void RBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(Docking.ActivePane.Tag) == 5)
            {
                AddUpdateFuncionario add = new AddUpdateFuncionario();
                add.ShowDialog();
            }
            else
            {
                AddUpdateOrganismo add = new AddUpdateOrganismo(Convert.ToInt16(Docking.ActivePane.Tag));
                add.ShowDialog();
            }
        }

        private void RBtnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.SelectObjectSelectedTab();

            if (Convert.ToInt16(Docking.ActivePane.Tag) == 5)
            {
                if (funcionario == null)
                {
                    MessageBox.Show("Seleccione el funcionario que se va a modificar");
                    return;
                }
                AddUpdateFuncionario add = new AddUpdateFuncionario(funcionario);
                add.ShowDialog();
            }
            else
            {
                if (organismo == null)
                {
                    MessageBox.Show("Seleccione el organismo que se va a modificar");
                    return;
                }
                AddUpdateOrganismo add = new AddUpdateOrganismo(organismo);
                add.ShowDialog();
            }
        }

        private void RBtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar este elemento?", "Eliminar:", MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            this.SelectObjectSelectedTab();

            if (MessageBoxResult.Yes == result)
            {
                if (Convert.ToInt16(Docking.ActivePane.Tag) == 5)
                {
                    new FuncionariosModel().DeleteFuncionario(funcionario);
                    FuncionariosSingleton.FuncionariosCollection.Remove(funcionario);
                }
                else
                {
                    new OrganismosModel().DeleteOrganismo(organismo);

                    switch (Convert.ToInt16(Docking.ActivePane.Tag))
                    {
                        case 1:
                            OrganismosSingleton.Instance.Colegiados.Remove(organismo);
                            break;
                        case 2:
                            OrganismosSingleton.Instance.Unitarios.Remove(organismo);
                            break;
                        case 3:
                            OrganismosSingleton.Instance.Juzgados.Remove(organismo);
                            break;
                        case 4:
                            OrganismosSingleton.Instance.Plenos.Remove(organismo);
                            break;
                    }
                }
            }
        }

        private void RBtnView_Click(object sender, RoutedEventArgs e)
        {
            this.SelectObjectSelectedTab();

            if (Convert.ToInt16(Docking.ActivePane.Tag) != 5)
            {
                VerInfoOrganismo ver = new VerInfoOrganismo(organismo);
                ver.ShowDialog();
            }
        }

        private void RBtnHistorial_Click(object sender, RoutedEventArgs e)
        {
            this.SelectObjectSelectedTab();

            if (Convert.ToInt16(Docking.ActivePane.Tag) == 5)
            {
                if (funcionario == null)
                {
                    MessageBox.Show("Seleccione el funcionario del cual desea visualizar el historial");
                    return;
                }
                HistorialFuncionarios historial = new HistorialFuncionarios(funcionario.IdFuncionario);
                historial.ShowDialog();
            }
            else
            {
                if (organismo != null)
                {
                    HistorialOrganismos historial = new HistorialOrganismos(organismo);
                    historial.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione el Organismo del cual desea visualizar el historial", "ATENCIÓN:", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        #endregion

        #region Reportes

        private void RBtnGenWord_Click(object sender, RoutedEventArgs e)
        {
            RadPane selectedPane = PanelCentral.SelectedItem as RadPane;

            int itemSelectedValue = Convert.ToInt32(selectedPane.Tag);

            if (itemSelectedValue == 5)
            {
                busyIndicatorAction = 1;
                this.LaunchBusyIndicator();
            }
            else
            {
                busyIndicatorAction = 2;
                organismosToPrint = new OrganismosModel().GetOrganismos(itemSelectedValue);
                this.LaunchBusyIndicator();
            }
        }

        private void RBtnSelect_Click(object sender, RoutedEventArgs e)
        {
            OrganismosSelect select = new OrganismosSelect();
            select.ShowDialog();
        }

        #endregion

        #region Herramientas

        private void RbtnLeyenda_Click(object sender, RoutedEventArgs e)
        {
            if (funcionario == null)
            {
                MessageBox.Show("Seleccione un funcionario");
            }
            else
            {
                new FuncionariosModel().DeleteTextoInicioNombramiento(funcionario);
            }
        }

        private void RBtnIntegracionHoy_Click(object sender, RoutedEventArgs e)
        {
            this.IntegracionActual(OrganismosSingleton.Instance.Plenos);
            this.IntegracionActual(OrganismosSingleton.Instance.Colegiados);
            this.IntegracionActual(OrganismosSingleton.Instance.Unitarios);
            this.IntegracionActual(OrganismosSingleton.Instance.Juzgados);
        }

        private void IntegracionActual(ObservableCollection<Organismos> organismosIntegra)
        {
            foreach (Organismos organismo in organismosIntegra)
            {
                IntegracionesModel model = new IntegracionesModel(organismo.IdOrganismo);
                int idIntegracion = model.GetNewIntegracion();

                if (idIntegracion != 0)
                {
                    model.SetIntegracionFuncionarios(organismo.ListaFuncionarios, idIntegracion);
                    //Bitacora bitacora = new Bitacora();
                    //bitacora.IdMovimiento = 64;
                    //bitacora.IdElemento = idIntegracion;
                    //bitacora.EdoActual = "Cambio Integracion";
                    //bitacora.EdoAnterior = " ";
                    //bitacora.NombreEquipo = Environment.MachineName;
                    //new BitacoraModel().SetNewBitacoraEntry(bitacora);
                }
            }
        }

        private void RBtnCuentaInt_Click(object sender, RoutedEventArgs e)
        {
            busyIndicatorAction = 3;
            this.LaunchBusyIndicator();
        }

        #endregion

        #region Background Worker

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (busyIndicatorAction == 1)
            {
                FuncionariosWord imprime = new FuncionariosWord(FuncionariosSingleton.FuncionariosCollection);
                imprime.GeneraDocumentoWord();
            }
            else if (busyIndicatorAction == 2)
            {
                OrganismosWord imprime = new OrganismosWord(organismosToPrint);
                imprime.GeneraDocumentoWord();
            }
            else if (busyIndicatorAction == 3)
            {
                OrganismosModel.SetNewIntegrantesCount();
            }
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
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