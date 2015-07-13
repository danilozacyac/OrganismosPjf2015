using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.Singletons;
using Telerik.Windows.Controls;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for ConfirmarIntegracion.xaml
    /// </summary>
    public partial class ConfirmarIntegracion
    {
        private int idOrganismo;
        private int tipoOrganismo;
        private ObservableCollection<Funcionarios> listaIntegracion;
        private ObservableCollection<Funcionarios> listaDescartados;
        private FuncionariosModel model;
        
        public ConfirmarIntegracion(int idOrganismo,int tipoOrganismo)
        {
            InitializeComponent();
            this.idOrganismo = idOrganismo;
            this.tipoOrganismo = tipoOrganismo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            model = new FuncionariosModel();

            listaIntegracion = model.GetFuncionariosPorOrganismo(idOrganismo);
            listaDescartados = new ObservableCollection<Funcionarios>();

            LstIntegracion.DataContext = listaIntegracion;
            LstDiscards.DataContext = listaDescartados;
        }

        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (LstIntegracion.SelectedItem != null)
            {
                Funcionarios seleccionado = LstIntegracion.SelectedItem as Funcionarios;
                listaDescartados.Add(seleccionado);
                listaIntegracion.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione el integrante que desea eliminar");
            }
        }

        private void BtnReasigna_Click(object sender, RoutedEventArgs e)
        {
            if (LstDiscards.SelectedItem != null)
            {
                Funcionarios seleccionado = LstDiscards.SelectedItem as Funcionarios;
                listaDescartados.Remove(seleccionado);
                listaIntegracion.Add(seleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione el integrante que desea reasignar");
            }
        }

        private void BtnVer_Click(object sender, RoutedEventArgs e)
        {
            Organismos organismo = null;

            if (tipoOrganismo == 1)
                organismo = (from n in OrganismosSingleton.Instance.Colegiados
                             where n.IdOrganismo == idOrganismo
                             select n).ToList()[0];
            else if (tipoOrganismo == 2)
                organismo = (from n in OrganismosSingleton.Instance.Unitarios
                             where n.IdOrganismo == idOrganismo
                             select n).ToList()[0];
            else if (tipoOrganismo == 3)
                organismo = (from n in OrganismosSingleton.Instance.Juzgados
                             where n.IdOrganismo == idOrganismo
                             select n).ToList()[0];

            AddUpdateOrganismo updateOrg = new AddUpdateOrganismo(organismo,false);
            this.Close();
            updateOrg.ShowDialog();

        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //if (listaDescartados.Count > 0)
            //{
            //    foreach (Funcionarios func in listaDescartados)
            //    {
            //        model.DeleteRelacionFuncionario(func);
            //    }
            //}

            //new IntegracionesModel(listaIntegracion, idOrganismo).SetIntegracionFuncionarios();

            this.Close();
        }
    }
}
