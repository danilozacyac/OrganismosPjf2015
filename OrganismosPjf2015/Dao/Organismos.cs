using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class Organismos : INotifyPropertyChanged
    {
        private bool isSelected;
        private int idOrganismo;
        private int tipoOrganismo;
        private int circuito;
        private int ordinal;
        private int materia;
        private String organismo;
        private String direccion;
        private String telefonos;
        //private String descrCiudad = "";
        private String ciudadStr;
        private int ciudad;
        private int integrantes;
        private int ordenImpresion;
        private int idFuncionarioPresidente;
        private bool doPresidenteChange;
        private ObservableCollection<Funcionarios> listaFuncionarios;
        private ObservableCollection<Integraciones> integraciones;


        

       

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value;
            }
        }

        public int TipoOrganismo
        {
            get
            {
                return this.tipoOrganismo;
            }
            set
            {
                this.tipoOrganismo = value;
            }
        }

        public int Circuito
        {
            get
            {
                return this.circuito;
            }
            set
            {
                this.circuito = value;
                this.OnPropertyChanged("Circuito");
            }
        }

        public int Ordinal
        {
            get
            {
                return this.ordinal;
            }
            set
            {
                this.ordinal = value;
                this.OnPropertyChanged("Ordinal");
            }
        }

        public int Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }

        public String Organismo
        {
            get
            {
                return this.organismo;
            }
            set
            {
                this.organismo = value;
                this.OnPropertyChanged("Organismo");
            }
        }

        public String Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
                this.OnPropertyChanged("Direccion");
            }
        }

        public String Telefonos
        {
            get
            {
                return this.telefonos;
            }
            set
            {
                this.telefonos = value;
                this.OnPropertyChanged("Telefonos");
            }
        }

        public String CiudadStr
        {
            get
            {
                return this.ciudadStr;
            }
            set
            {
                this.ciudadStr = value;
            }
        }

        //public String DescrCiudad
        //{
        //    get
        //    {
        //        return this.descrCiudad;
        //    }
        //    set
        //    {
        //        this.descrCiudad = value;
        //    }
        //}

        public int Ciudad
        {
            get
            {
                return this.ciudad;
            }
            set
            {
                this.ciudad = value;
                this.OnPropertyChanged("Ciudad");
            }
        }

        public int Integrantes
        {
            get
            {
                return this.integrantes;
            }
            set
            {
                this.integrantes = value;
                this.OnPropertyChanged("Integrantes");
            }
        }

        public int OrdenImpresion
        {
            get
            {
                return this.ordenImpresion;
            }
            set
            {
                this.ordenImpresion = value;
                this.OnPropertyChanged("OrdenImpresion");
            }
        }

        public bool DoPresidenteChange
        {
            get
            {
                return this.doPresidenteChange;
            }
            set
            {
                this.doPresidenteChange = value;
            }
        }

        public int IdFuncionarioPresidente
        {
            get
            {
                return this.idFuncionarioPresidente;
            }
            set
            {
                this.idFuncionarioPresidente = value;
                this.OnPropertyChanged("IdFuncionarioPresidente");
            }
        }

        public ObservableCollection<Funcionarios> ListaFuncionarios
        {
            get
            {
                return this.listaFuncionarios;
            }
            set
            {
                this.listaFuncionarios = value;
                this.OnPropertyChanged("ListaFuncionarios");
            }
        }


        public ObservableCollection<Integraciones> Integraciones
        {
            get
            {
                return this.integraciones;
            }
            set
            {
                this.integraciones = value;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            
        }

        #endregion // INotifyPropertyChanged Members
    }
}
