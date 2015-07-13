using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.Reportes;
using OrganismosPjf2015.Singletons;

namespace OrganismosPjf2015
{
    /// <summary>
    /// Interaction logic for AddUpdateFuncionario.xaml
    /// </summary> 
    public partial class AddUpdateFuncionario
    {
        private Funcionarios funcionario;
        public Organismos organismo;
        private readonly bool isUpdating = false;

        //private int idOrganismo = 0;

        public AddUpdateFuncionario()
        {
            InitializeComponent();
            funcionario = new Funcionarios();
        }

        public AddUpdateFuncionario(Funcionarios funcionario)
        {
            InitializeComponent();
            this.funcionario = funcionario;
            isUpdating = true;
            
            
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = funcionario;
            RcbNombramiento.Text = funcionario.Puesto;
            CbxEstadoFunc.DataContext = EstadosSingleton.EstadoFuncionarios;
            RCbxFunciones.DataContext = new FuncionesModel().GetFunciones(2);

                this.Header = (isUpdating ) ? "Actualizar Funcionario" : "Agregar Funcionario";

            TxtOrganismo.Text = this.GetOrganismoString();

            if (!TxtOrganismo.Text.Equals("Sin Adscripción"))
                RbtnEditOrganismo.IsEnabled = false;

            CbxEstadoFunc.SelectedValue = funcionario.Activo;
            RCbxFunciones.SelectedValue = funcionario.EnFunciones;
        }

        private void RbtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            funcionario.Puesto = RcbNombramiento.Text;
            funcionario.Texto = TxtFecha.Text;
            funcionario.Activo = Convert.ToInt32(CbxEstadoFunc.SelectedValue);
            funcionario.EnFunciones = Convert.ToInt16(RCbxFunciones.SelectedValue);

            if (!isUpdating)
            {
                if (organismo == null)
                {
                    MessageBox.Show("Seleccione el organismo al que estara adscrito el funcionario");
                    return;
                }
                new FuncionariosModel().AddNewFuncionario(funcionario, organismo);
                FuncionariosSingleton.FuncionariosCollection.Add(funcionario);
            }
            else
            {
                new FuncionariosModel().UpdateFuncionario(funcionario);

                //if (organismo != null && funcionario.DoOrgChange == true)
                //{
                //    ConfirmarIntegracion confirma = new ConfirmarIntegracion(organismo.IdOrganismo,organismo.TipoOrganismo);
                //    confirma.ShowDialog();
                //}
            }

            DialogResult = true;
            this.Close();
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void RbtnEditOrganismo_Click(object sender, RoutedEventArgs e)
        {
            OrganismosSelect adscripcion = new OrganismosSelect(this);
            adscripcion.ShowDialog();

            if (adscripcion.DialogResult == true)
            {
                funcionario.IdOrganismo = organismo.IdOrganismo;
                TxtOrganismo.Text = organismo.Organismo;

                if (isUpdating)
                {
                    new FuncionariosModel().InsertaRelacionFuncionario(funcionario);
                    organismo.ListaFuncionarios.Add(funcionario);
                    //OrganismosSingleton.Instance.AddFuncionarioToOrganismo(organismo, funcionario);
                }

                CambiosSingleton.CambiosOrganismos.Add(organismo.IdOrganismo);

                RbtnEditOrganismo.IsEnabled = false;
            }
        }

        private void RbtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (funcionario.IdOrganismo != 0)
            {
                organismo = new OrganismosModel().GetOrganismoPorId(funcionario.IdOrganismo);

                switch (organismo.TipoOrganismo)
                {
                    case 1: organismo = (from n in OrganismosSingleton.Instance.Colegiados
                                         where n.IdOrganismo == organismo.IdOrganismo
                                         select n).ToList()[0];
                        break;
                    case 2: organismo = (from n in OrganismosSingleton.Instance.Unitarios
                                         where n.IdOrganismo == organismo.IdOrganismo
                                         select n).ToList()[0];
                        break;
                    case 3: organismo = (from n in OrganismosSingleton.Instance.Juzgados
                                         where n.IdOrganismo == organismo.IdOrganismo
                                         select n).ToList()[0];
                        break;
                    case 4: organismo = (from n in OrganismosSingleton.Instance.Plenos
                                         where n.IdOrganismo == organismo.IdOrganismo
                                         select n).ToList()[0];
                        break;
                }

                new FuncionariosModel().DeleteRelacionFuncionario(funcionario);

                organismo.ListaFuncionarios.Remove(funcionario);

                CambiosSingleton.CambiosOrganismos.Add(organismo.IdOrganismo);

                funcionario.IdOrganismo = 0;
                TxtOrganismo.Text = "Sin Adscripción";
                RbtnEditOrganismo.IsEnabled = true;

            }
        }

        private String GetOrganismoString()
        {
            List<Organismos> org = OrganismosSingleton.Instance.Colegiados.Where(o => o.IdOrganismo == funcionario.IdOrganismo).ToList();

            if (org.Count == 0)
                org = OrganismosSingleton.Instance.Unitarios.Where(o => o.IdOrganismo == funcionario.IdOrganismo).ToList();

            if (org.Count == 0)
                org = OrganismosSingleton.Instance.Juzgados.Where(o => o.IdOrganismo == funcionario.IdOrganismo).ToList();

            if(org.Count > 0)
                organismo = org[0];


            return (org.Count > 0) ? org[0].Organismo : "Sin Adscripción";
        }
    }
}
