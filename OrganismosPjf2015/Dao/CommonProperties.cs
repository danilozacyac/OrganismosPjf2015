using System;
using System.Linq;

namespace OrganismosPjf2015.Dao
{
    public class CommonProperties
    {
        private int idElemento;
        private String descripcion;

        public CommonProperties() { }

        public CommonProperties(int idElemento, String descripcion)
        {
            this.idElemento = idElemento;
            this.descripcion = descripcion;
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

        public String Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
    }
}
