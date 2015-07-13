using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;

namespace OrganismosPjf2015.Singletons
{
    public sealed class OrganismosSingleton : INotifyPropertyChanged
    {
        private static readonly OrganismosSingleton instance = new OrganismosSingleton();

        private OrganismosSingleton()
        {
        }

        public static OrganismosSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        private ObservableCollection<Organismos> plenos;
        private ObservableCollection<Organismos> colegiados;
        private ObservableCollection<Organismos> unitarios;
        private ObservableCollection<Organismos> juzgados;

        public ObservableCollection<Organismos> Plenos
        {
            get
            {
                if (plenos == null)
                    plenos = new OrganismosModel().GetOrganismos(4);

                return plenos;
            }
            set
            {
                this.OnPropertyChanged("Plenos");
            }
        }

        public ObservableCollection<Organismos> Colegiados
        {
            get
            {
                if (colegiados == null)
                    colegiados = new OrganismosModel().GetOrganismos(1);

                return colegiados;
            }
        }

        public ObservableCollection<Organismos> Unitarios
        {
            get
            {
                if (unitarios == null)
                    unitarios = new OrganismosModel().GetOrganismos(2);

                return unitarios;
            }
        }

        public ObservableCollection<Organismos> Juzgados
        {
            get
            {
                if (juzgados == null)
                    juzgados = new OrganismosModel().GetOrganismos(3);

                return juzgados;
            }
        }

        #region Property Change

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
