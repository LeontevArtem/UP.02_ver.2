using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using GroupDocs.Conversion;
using GroupDocs.Conversion.Options.Convert;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Reports.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        Func<Page, int> BackClick;
        Page ParrentPage;

        public Main(Page parrentPage, Func<Page, int> BackClick)
        {
            InitializeComponent();
            BackButton.MouseDown += delegate { BackClick(parrentPage); };
            this.BackClick = BackClick;
            this.ParrentPage = parrentPage;
        }
        string report_type; string date; string name; string equipment; string serial_number; int price;
        public void AddClick(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "docx";
            if (cd.SelectedIndex == 0) saveFileDialog.FileName = "приема-передачи оборудования на временное пользование";
            else if (cd.SelectedIndex == 1) saveFileDialog.FileName = "приема-передачи расходных материалов";
            else if (cd.SelectedIndex == 2) saveFileDialog.FileName = "приема-передачи оборудования";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(saveFileDialog.FileName+".docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    Paragraph paragraph1 = new Paragraph();
                    paragraph1.Append(new Run(new Text("АКТ")));
                    FormatCenter(paragraph1);
                    body.Append(paragraph1);

                    Paragraph paragraph2 = new Paragraph();
                    paragraph2.Append(new Run(new Text($"{cd.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "")}")));
                    FormatCenter(paragraph2);
                    body.Append(paragraph2);

                    Paragraph paragraph3 = new Paragraph();
                    paragraph3.Append(new Run(new Text($"г.Пермь                                                                                                 {"00:00:00"}")));
                    FormatBoth(paragraph3, "0", true, "200", "450");
                    body.Append(paragraph3);

                    Paragraph paragraph4 = new Paragraph();
                    if (cd.SelectedIndex == 0) paragraph4.Append(new Run(new Text($"КГАПОУ Пермский Авиационный техникум им. А.Д. Швецова в целях обеспечением необходимым оборудованием для исполнения должностных обязанностей передаёт сотруднику {"АТРИМ"}, а сотрудник принимает от учебного учреждения следующее оборудование:")));
                    else if (cd.SelectedIndex == 1) paragraph4.Append(new Run(new Text($"КГАПОУ Пермский Авиационный техникум им. А.Д. Швецова в целях обеспечением необходимым оборудованием для исполнения должностных обязанностей передаёт сотруднику Иванову И.И., а сотрудник принимает от учебного учреждения следующие расходные материалы:")));
                    else if (cd.SelectedIndex == 2) paragraph4.Append(new Run(new Text($"КГАПОУ Пермский Авиационный техникум им. А.Д. Швецова в целях обеспечением необходимым оборудованием для исполнения должностных обязанностей передаёт сотруднику Иванову И.И., а сотрудник принимает от учебного учреждения следующее оборудование:")));
                    FormatBoth(paragraph4, "720", false, null, null);
                    body.Append(paragraph4);

                    Paragraph paragraph5 = new Paragraph();
                    paragraph5.Append(new Run(new Text($"{"СТУЛ"}, серийный номер {"67238п8--34а-3а3"}, стоимостью {"234"} руб.")));
                    FormatBoth(paragraph5, "720", true, "300", "500");
                    body.Append(paragraph5);

                    if (cd.SelectedIndex == 0)
                    {
                        Paragraph paragraph6 = new Paragraph();
                        paragraph6.Append(new Run(new Text($"По окончанию должностных работ {"00:00:00"} года, работник обязуется вернуть полученное оборудование.")));
                        FormatBoth(paragraph6, "720", false, null, null);
                        body.Append(paragraph6);
                    }

                    Paragraph paragraph7 = new Paragraph();
                    paragraph7.Append(new Run(new Text($"{"АРТИМ"}                                __________________              ____________")));
                    FormatBoth(paragraph7, "0", true, "800", null);
                    body.Append(paragraph7);

                    foreach (var paragraph in body.Descendants<Paragraph>())
                    {
                        foreach (var run in paragraph.Descendants<Run>())
                        {
                            foreach (var text in run.Descendants<Text>())
                            {
                                RunProperties runProperties = run.GetFirstChild<RunProperties>();
                                if (runProperties == null)
                                {
                                    runProperties = new RunProperties();
                                    run.InsertBefore(runProperties, text);
                                }
                                runProperties.Append(new RunFonts() { HighAnsi = "Times New Roman" });
                                runProperties.Append(new FontSize() { Val = "28" });
                            }
                        }
                    }
                    mainPart.Document.Save();

                }
                if (CheckPDF.IsChecked == true)
                {
                    using (var converter = new Converter(saveFileDialog.FileName+".docx"))
                    {
                        converter.Convert(saveFileDialog.FileName+".pdf", new PdfConvertOptions());
                        File.Delete(saveFileDialog.FileName + ".docx");
                    }
                }
            }
        }
        void FormatCenter(Paragraph paragraph)
        {
            paragraph.ParagraphProperties = new ParagraphProperties(new Indentation() { FirstLine = "720" }, new SpacingBetweenLines() { Line = "360", LineRule = LineSpacingRuleValues.Auto });
            var alignment1 = new Justification { Val = JustificationValues.Center };
            paragraph.GetFirstChild<ParagraphProperties>().Justification = alignment1;
        }
        void FormatBoth(Paragraph paragraph, string FL, bool interval, string before, string after)
        {
            if (interval == false) paragraph.ParagraphProperties = new ParagraphProperties(new Indentation() { FirstLine = FL }, new SpacingBetweenLines() { Line = "360", LineRule = LineSpacingRuleValues.Auto });
            else paragraph.ParagraphProperties = new ParagraphProperties(new Indentation() { FirstLine = FL }, new SpacingBetweenLines() { Before = before, After = after });
            var alignment1 = new Justification { Val = JustificationValues.Both };
            paragraph.GetFirstChild<ParagraphProperties>().Justification = alignment1;
        }
    }
}
