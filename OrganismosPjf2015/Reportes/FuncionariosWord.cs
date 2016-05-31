using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using OrganismosPjf2015.Dao;
using Word = Microsoft.Office.Interop.Word;

namespace OrganismosPjf2015.Reportes
{
    public class FuncionariosWord
    {
        private readonly ObservableCollection<Funcionarios> funcionarios;
        Word.Application oWord;
        Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;

        public FuncionariosWord(ObservableCollection<Funcionarios> funcionarios)
        {
            this.funcionarios = funcionarios;
        }

        public void GeneraDocumentoWord()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            Microsoft.Office.Interop.Word.Paragraph par = oDoc.Content.Paragraphs.Add(ref oMissing);

            foreach (Funcionarios funcionario in funcionarios)
            {
                par.Range.Font.Bold = 0;
                par.Range.Font.Size = Convert.ToInt32(ConfigurationManager.AppSettings["FontSize"]);
                par.Range.Font.Name = ConfigurationManager.AppSettings["FontFamily"];

                par.Range.Text = String.Format("{0} {1} {2}", funcionario.Puesto, funcionario.Apellidos, funcionario.Nombre);
                par.Range.InsertParagraphAfter();
            }

            oWord.Visible = true;
        }
    }
}
