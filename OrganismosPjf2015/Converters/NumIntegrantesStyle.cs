using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OrganismosPjf2015.Dao;

namespace OrganismosPjf2015.Converters
{
    public class NumIntegrantesStyle : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is Organismos)
            {
                Organismos organismo = item as Organismos;
                if (organismo.ListaFuncionarios.Count == 0)
                {
                    return SinIntegrantes;
                }
                else if (organismo.ListaFuncionarios.Count > 3)
                {
                    return MasIntegrantes;
                }
                else
                {
                    return AlgunIntegrante;
                }
            }
            else if (item is Funcionarios)
            {
                Funcionarios funcionario = item as Funcionarios;

                if (funcionario.IdOrganismo == 0)
                    return SinIntegrantes;
                else
                    return AlgunIntegrante;

            }
            return null;



        }

        public Style SinIntegrantes { get; set; }

        public Style AlgunIntegrante { get; set; }

        public Style MasIntegrantes { get; set; }
    }
}
