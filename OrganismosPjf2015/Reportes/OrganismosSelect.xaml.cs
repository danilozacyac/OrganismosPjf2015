using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls;

namespace OrganismosPjf2015.Reportes
{
    /// <summary>
    /// Interaction logic for OrganismosSelect.xaml
    /// </summary>
    public partial class OrganismosSelect
    {
        private Organismos organismoSeleccionado;

        private readonly AddUpdateFuncionario ventanaPadre;
        private bool isPrinting = false;
        private int selectedOrganism = 0;

        public OrganismosSelect()
        {
            InitializeComponent();
            this.isPrinting = true;
        }

        public OrganismosSelect(AddUpdateFuncionario ventanaPadre)
        {
            InitializeComponent();
            this.ventanaPadre = ventanaPadre;

        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RgridOrganismo.DataContext = OrganismosSingleton.Instance.Colegiados;
            selectedOrganism = 1;

            this.RgridOrganismo.Columns[0].IsVisible = isPrinting;

            if (isPrinting)
                this.Header = "Imprimir organismos seleccionados";
        }

        private void RbtnColegiados_Click(object sender, RoutedEventArgs e)
        {
            RgridOrganismo.DataContext = OrganismosSingleton.Instance.Colegiados;
            selectedOrganism = 1;
        }

        private void RbtnUnitarios_Click(object sender, RoutedEventArgs e)
        {
            RgridOrganismo.DataContext = OrganismosSingleton.Instance.Unitarios;
            selectedOrganism = 2;
        }

        private void RbtnJuzgados_Click(object sender, RoutedEventArgs e)
        {
            RgridOrganismo.DataContext = OrganismosSingleton.Instance.Juzgados;
            selectedOrganism = 3;
        }

        private void RgridOrganismo_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            organismoSeleccionado = RgridOrganismo.SelectedItem as Organismos;
        }

        private void RbtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (!isPrinting)
            {
                if (organismoSeleccionado == null)
                {
                    MessageBox.Show("Si asigna o modifica la adscripción seleccione un organismo, \nde lo contrario presione Cancelar");
                    return;
                }

                ventanaPadre.organismo = organismoSeleccionado;

                //ConstValues.OrganismoForFuncionario = organismoSeleccionado.IdOrganismo;
                //ConstValues.OrganismoForFuncionarioStr = organismoSeleccionado.Organismo;
                DialogResult = true;
                this.Close();
            }
            else
            {
                ObservableCollection<Organismos> organismosList = new ObservableCollection<Organismos>();

                if (selectedOrganism != 0)
                {
                    switch (selectedOrganism)
                    {
                        case 1:
                            foreach (Organismos org in OrganismosSingleton.Instance.Colegiados)
                            {
                                if (org.IsSelected == true)
                                {
                                    organismosList.Add(org);
                                    org.IsSelected = false;
                                }
                            }
                            break;
                        case 2:
                            foreach (Organismos org in OrganismosSingleton.Instance.Unitarios)
                            {
                                if (org.IsSelected == true)
                                {
                                    organismosList.Add(org);
                                    org.IsSelected = false;
                                }
                            }
                            break;
                        case 3:
                            foreach (Organismos org in OrganismosSingleton.Instance.Juzgados)
                            {
                                if (org.IsSelected == true)
                                {
                                    organismosList.Add(org);
                                    org.IsSelected = false;
                                }
                            }
                            break;
                    }

                    OrganismosWord word = new OrganismosWord(organismosList);
                    word.GeneraDocumentoWord();
                    this.Close();
                }
            }
        }

        private void RbtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //ConstValues.OrganismoForFuncionario = 0;
            DialogResult = false;
            this.Close();
        }

        
    }
}
