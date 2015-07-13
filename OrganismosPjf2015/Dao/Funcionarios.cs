using System;
using System.ComponentModel;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class Funcionarios : INotifyPropertyChanged
    {
        private bool isSelected;
        private int idFuncionario;
        private int idOrganismo;
        private String puesto;
        private String apellidos;
        private String nombre;
        private int activo;
        /// <summary>
        /// Fecha a partir de la cual entra en funciones
        /// </summary>
        private String texto;
        private bool doOrgChange = false;


        /// <summary>
        /// Identificador de la Leyenda que se asiga a un funcionario cuando ocupa una función adicional a la primaria dentro
        /// de un tribunal o juzgado
        /// </summary>
        private int enFunciones;

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }

        public int IdFuncionario
        {
            get
            {
                return this.idFuncionario;
            }
            set
            {
                this.idFuncionario = value;
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

        public String Puesto
        {
            get
            {
                return this.puesto;
            }
            set
            {
                this.puesto = value;
            }
        }

        public String Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }

        public String Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public int Activo
        {
            get
            {
                return this.activo;
            }
            set
            {
                this.activo = value;
                this.OnPropertyChanged("Activo");
            }
        }

        public String Texto
        {
            get
            {
                return this.texto;
            }
            set
            {
                this.texto = value;
            }
        }

        public bool DoOrgChange
        {
            get
            {
                return this.doOrgChange;
            }
            set
            {
                this.doOrgChange = value;
                this.OnPropertyChanged("DoOrgChange");
            }
        }


        public int EnFunciones
        {
            get
            {
                return this.enFunciones;
            }
            set
            {
                this.enFunciones = value;
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if(propertyName.Equals("DoOrgChange"))
                doOrgChange = true;
        }

        #endregion // INotifyPropertyChanged Members
    }
}
