using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Converters;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.MyUserControls;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls.GridView;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for AddUpdateOrganismo.xaml
    /// </summary>
    public partial class AddUpdateOrganismo
    {
        private Organismos organismo = null;
        private Funcionarios funcionario = null;

        private bool doIntegrationChange = false;

        FuncionariosSelect popAddFuncionario;

        /// <summary>
        /// Se utiliza para ir almacenando el nombre de los funcionarios que integran el tribunal
        /// </summary>
        ObservableCollection<Funcionarios> addFuncionarioToTribunal = null;
        private readonly bool isUpdating = false;
        private bool checkIntegration;
        private readonly int tipoTribunal;

        public AddUpdateOrganismo(int tipoTribunal)
        {
            InitializeComponent();
            organismo = new Organismos();
            organismo.TipoOrganismo = tipoTribunal;

        }

        public AddUpdateOrganismo(Organismos organismo)
        {
            InitializeComponent();
            this.organismo = organismo;
            isUpdating = true;
        }

        public AddUpdateOrganismo(Organismos organismo, bool checkIntegration)
        {
            InitializeComponent();
            this.organismo = organismo;
            isUpdating = true;
            this.checkIntegration = checkIntegration;
        }

        private void WinAddOrganismo_Loaded(object sender, RoutedEventArgs e)
        {
            

            popAddFuncionario = new FuncionariosSelect(organismo.TipoOrganismo);
            SelectControl.Children.Add(popAddFuncionario);

            this.DataContext = organismo;

            this.RcbOrganismo.DataContext = TipoOrganismosSingleton.Tipos;
            this.RcbOrganismo.SelectedValue = organismo.TipoOrganismo;

            RcbOrganismo.IsEnabled = isUpdating;

            this.RcbCircuito.DataContext = CircuitosSingleton.Circuitos;
            this.RcbCircuito.SelectedValue = organismo.Circuito;

            this.RcbOrdinal.DataContext = OrdinalSingleton.Ordinales;
            this.RcbOrdinal.SelectedValue = organismo.Ordinal;

            this.RcbCiudad.DataContext = CiudadesSingleton.Ciudades;
            this.RcbCiudad.SelectedValue = organismo.Ciudad;

            if (organismo.IdFuncionarioPresidente != null && organismo.IdFuncionarioPresidente != 0)
            {
                Funcionarios presidente = (from n in organismo.ListaFuncionarios
                                  where n.IdFuncionario == organismo.IdFuncionarioPresidente
                                  select n).ToList()[0];



                TxtPresidente.Text = presidente.Nombre + " " + presidente.Apellidos;
            }

        }

        private void RcbCiudad_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TxtEstado.Text = new EstadoConverter().Convert(this.RcbCiudad.SelectedValue, null, null, null).ToString();
        }

        private void GridIntegrantes_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (GridIntegrantes.SelectedItem is Funcionarios)
            {
                funcionario = GridIntegrantes.SelectedItem as Funcionarios;
            }
        }

        private void RbtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Esta seguro que este funcionario dejó de pertenecer a este organismo?",
                                                        "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                funcionario.IdOrganismo = organismo.IdOrganismo;
                new FuncionariosModel().DeleteRelacionFuncionario(funcionario);
                organismo.ListaFuncionarios.Remove(funcionario);
                //organismo.RemoveFuncionario(funcionario);

                CambiosSingleton.CambiosOrganismos.Add(organismo.IdOrganismo);
                doIntegrationChange = true;
            }

        }

        private void RbtnAgregaFuncionario_Click(object sender, RoutedEventArgs e)
        {
            PopupFuncionario.IsOpen = true;
            RbtnAceptar.IsEnabled = false;
            RbtnCancelar.IsEnabled = false;
        }

        private void RbtnPopAceptar_Click(object sender, RoutedEventArgs e)
        {
            addFuncionarioToTribunal = new ObservableCollection<Funcionarios>();

            foreach (object item in popAddFuncionario.GridFuncionarios.Items)
            {
                Funcionarios addFuncionario = item as Funcionarios;

                if (addFuncionario.IsSelected)
                {
                    addFuncionarioToTribunal.Add(addFuncionario);

                    if (isUpdating)
                        organismo.ListaFuncionarios.Add(addFuncionario);
                    else
                    {
                        if (organismo.ListaFuncionarios == null)
                            organismo.ListaFuncionarios = new ObservableCollection<Funcionarios>();

                        organismo.ListaFuncionarios.Add(addFuncionario);
                    }

                    doIntegrationChange = true;
                }
            }

            if(doIntegrationChange)
                CambiosSingleton.CambiosOrganismos.Add(organismo.IdOrganismo);

            PopupFuncionario.IsOpen = false;
            RbtnAceptar.IsEnabled = true;
            RbtnCancelar.IsEnabled = true;
        }

        private void RbtnPopCancelar_Click(object sender, RoutedEventArgs e)
        {
            PopupFuncionario.IsOpen = false;
            RbtnAceptar.IsEnabled = true;
            RbtnCancelar.IsEnabled = true;
        }

        private void RbtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //if (Convert.ToInt32(RcbCircuito.SelectedValue) < 1 || Convert.ToInt32(RcbOrdinal.SelectedValue) < 1)
            //{
            //    MessageBox.Show("Debes seleccionar el circuito al que pertenece el tribunal, así como su respectivo ordinal", "ATENCIÓN",
            //                        MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            organismo.TipoOrganismo = Convert.ToInt32(this.RcbOrganismo.SelectedValue);
            organismo.Circuito = Convert.ToInt32(this.RcbCircuito.SelectedValue);
            organismo.Ordinal = Convert.ToInt32(this.RcbOrdinal.SelectedValue);
            organismo.Ciudad = Convert.ToInt32(this.RcbCiudad.SelectedValue);

            //Update Organismo
            if (isUpdating)
            {
                new OrganismosModel(organismo).UpdateOrganismo();
            }
            else
            {
                new OrganismosModel(organismo).AddNuevoOrganismo();

                if (organismo.ListaFuncionarios == null)
                    organismo.ListaFuncionarios = new ObservableCollection<Funcionarios>();

            }

            //Agregamos las nuevas relaciones
            if (addFuncionarioToTribunal != null)
            {
                foreach (Funcionarios funcionario in addFuncionarioToTribunal)
                {
                    new FuncionariosModel().InsertaRelacionFuncionario(funcionario, organismo.IdOrganismo);
                }
            }

            

            if (organismo.DoPresidenteChange)
            {
                CommonProperties newPres = new CommonProperties();
                newPres.Descripcion = organismo.IdOrganismo.ToString();
                newPres.IdElemento = organismo.IdFuncionarioPresidente;
                CambiosSingleton.CambioPresidente.Add(newPres);
            }


            this.Close();
        }

        private void RbtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridIntegrantes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Funcionarios func = GridIntegrantes.SelectedItem as Funcionarios;

            TxtPresidente.Text = func.Nombre + " " + func.Apellidos;
            organismo.IdFuncionarioPresidente = func.IdFuncionario;
            organismo.DoPresidenteChange = true;
        }

        private void TxtPresidente_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }
    }
}
