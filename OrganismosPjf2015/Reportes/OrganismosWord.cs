using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using OrganismosPjf2015.Dao;
using OrganismosPjf2015.Models;
using OrganismosPjf2015.Singletons;
using Word = Microsoft.Office.Interop.Word;

namespace OrganismosPjf2015.Reportes
{
    public class OrganismosWord
    {
        private readonly ObservableCollection<Organismos> organismos;
        private ObservableCollection<CommonProperties> listaFunciones;
        Word.Application oWord;
        Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;

        public OrganismosWord(ObservableCollection<Organismos> organismos)
        {
            this.organismos = organismos;
        }

        public void GeneraDocumentoWord()
        {
            listaFunciones = new FuncionesModel().GetFunciones(2);

            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);


            Microsoft.Office.Interop.Word.Paragraph par = oDoc.Content.Paragraphs.Add(ref oMissing);


            foreach (Organismos organismo in organismos)
            {
                par.Range.Font.Bold = 1;
                par.Range.Font.Size = Convert.ToInt32(ConfigurationManager.AppSettings["FontSize"]);
                par.Range.Font.Name = ConfigurationManager.AppSettings["FontFamily"];

                par.Range.Text = organismo.Organismo;
                par.Range.InsertParagraphAfter();

                par.Range.Font.Bold = 0;

                if (organismo.Ciudad != 3)
                {
                    Ciudad cd = (from n in CiudadesSingleton.Ciudades
                                 where n.IdCiudad == organismo.Ciudad
                                 select n).ToList()[0];

                    par.Range.Text = String.Format("{0}, {1}", cd.CiudadStr, (from n in CiudadesSingleton.Estados
                                                                              where n.IdEstado == cd.IdEstado
                                                                              select n.Abrev).ToList()[0]);

                    par.Range.InsertParagraphAfter();
                }

                foreach (Funcionarios funcionario in organismo.ListaFuncionarios)
                {

                    if (organismo.TipoOrganismo == 3)
                    {
                        if (String.IsNullOrEmpty(funcionario.Texto))
                            par.Range.Text = String.Format("{0} {1} {2}", (funcionario.EnFunciones == 101) ? "Juez administrador" : funcionario.Puesto, funcionario.Nombre, funcionario.Apellidos);
                        else
                        {
                            par.Range.Text = String.Format("{0} {1}", funcionario.Nombre, funcionario.Apellidos);
                            par.Range.InsertParagraphAfter();
                            par.Range.Text = String.Format("({0})", this.GetCompleteDate(funcionario.Texto));
                        }
                    }
                    else
                        par.Range.Text = String.Format("{0} {1} {2}", funcionario.Puesto, funcionario.Nombre, funcionario.Apellidos);

                    //if (funcionario.EnFunciones > 100)
                    //{
                    //    par.Range.InsertParagraphAfter();
                    //    par.Range.Text = (from n in listaFunciones
                    //                      where n.IdElemento == funcionario.EnFunciones
                    //                          select n.Descripcion).ToList()[0];
                    //}

                    if (!String.IsNullOrEmpty(funcionario.Texto.Trim()) && organismo.TipoOrganismo != 3)
                    {
                        par.Range.InsertParagraphAfter();
                        par.Range.Text = String.Format("({0})", this.GetCompleteDate(funcionario.Texto));
                    }
                    par.Range.InsertParagraphAfter();
                    par.Range.ParagraphFormat.SpaceAfter = 0;
                }

                par.Range.InsertParagraphAfter();
            }

            oWord.Visible = true;
        }


        private String GetCompleteDate(String stringDate)
        {
            try
            {
                int startPos = stringDate.IndexOf('/');
                string justDate = stringDate.Substring(startPos - 2);

                string[] breakDate = justDate.Split('/');

                justDate = String.Format("A partir del {0} de {1} de {2}", GetDay(breakDate[0]), CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(breakDate[1])), breakDate[2]);

                return justDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                return stringDate;
            }
        }

        private String GetDay(String day)
        {
            int dia = Convert.ToInt32(day);

            if (dia == 1)
                return "1o.";
            else
                return dia.ToString();
        }
    }
}
