using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class Integraciones
    {
        private int idIntegracion;
        private DateTime? fechaIntegracion;
        private ObservableCollection<Funcionarios> integrantes;
        private ObservableCollection<Funcionarios> presidentes;
        private string organismo;

        public int IdIntegracion
        {
            get
            {
                return this.idIntegracion;
            }
            set
            {
                this.idIntegracion = value;
            }
        }

        public DateTime? FechaIntegracion
        {
            get
            {
                return this.fechaIntegracion;
            }
            set
            {
                this.fechaIntegracion = value;
            }
        }

        public ObservableCollection<Funcionarios> Integrantes
        {
            get
            {
                return this.integrantes;
            }
            set
            {
                this.integrantes = value;
            }
        }

        public ObservableCollection<Funcionarios> Presidentes
        {
            get
            {
                return this.presidentes;
            }
            set
            {
                this.presidentes = value;
            }
        }

        public string Organismo
        {
            get
            {
                return this.organismo;
            }
            set
            {
                this.organismo = value;
            }
        }

        
    }
}
