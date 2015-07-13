using System;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class Bitacora
    {
        private int id;
        private int idMovimiento;
        private int idElemento;
        private string edoActual;
        private string edoAnterior;
        private int idUsuario;
        private string nombreEquipo;
        private DateTime fechaCambio;
        private int fechaCambioInt;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int IdMovimiento
        {
            get
            {
                return this.idMovimiento;
            }
            set
            {
                this.idMovimiento = value;
            }
        }

        public int IdElemento
        {
            get
            {
                return this.idElemento;
            }
            set
            {
                this.idElemento = value;
            }
        }

        public string EdoActual
        {
            get
            {
                return this.edoActual;
            }
            set
            {
                this.edoActual = value;
            }
        }

        public string EdoAnterior
        {
            get
            {
                return this.edoAnterior;
            }
            set
            {
                this.edoAnterior = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }
        }

        public string NombreEquipo
        {
            get
            {
                return this.nombreEquipo;
            }
            set
            {
                this.nombreEquipo = value;
            }
        }

        public DateTime FechaCambio
        {
            get
            {
                return this.fechaCambio;
            }
            set
            {
                this.fechaCambio = value;
            }
        }

        public int FechaCambioInt
        {
            get
            {
                return this.fechaCambioInt;
            }
            set
            {
                this.fechaCambioInt = value;
            }
        }
    }
}
