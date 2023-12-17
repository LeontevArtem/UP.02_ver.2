using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Report
    {
        public void XLS()
        {
            //БАЗА ГДЕ!
            //НЕТУ БАЗЫ, НЕТ ОТЧЕТА
        }
        public void DOCX(string report_type, string date, string name, string equipment, string serial_number, int price)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create("asdasd.docx", WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                Paragraph paragraph1 = new Paragraph();
                paragraph1.Append(new Run(new Text("АКТ")));
                FormatCenter(paragraph1);
                body.Append(paragraph1);

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Append(new Run(new Text($"{report_type}")));
                FormatCenter(paragraph2);
                body.Append(paragraph2);

                Paragraph paragraph3 = new Paragraph();
                paragraph3.Append(new Run(new Text($"г.Пермь                                                                                                 {date}")));
                FormatBoth(paragraph3, "0", true, "200", "450");
                body.Append(paragraph3);

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Append(new Run(new Text($"КГАПОУ Пермский Авиационный техникум им. А.Д. Швецова в целях обеспечением необходимым оборудованием для исполнения должностных обязанностей передаёт сотруднику {name}, а сотрудник принимает от учебного учреждения следующее оборудование:")));
                FormatBoth(paragraph4, "720", false, null, null);
                body.Append(paragraph4);

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Append(new Run(new Text($"{equipment}, серийный номер {serial_number}, стоимостью {price} руб.")));
                FormatBoth(paragraph5, "720", true, "300", "500");
                body.Append(paragraph5);

                if (report_type == "приема-передачи оборудования на временное пользование")
                {
                    Paragraph paragraph6 = new Paragraph();
                    paragraph6.Append(new Run(new Text($"По окончанию должностных работ {date} года, работник обязуется вернуть полученное оборудование.")));
                    FormatBoth(paragraph6, "720", false, null, null);
                    body.Append(paragraph6);
                }

                Paragraph paragraph7 = new Paragraph();
                paragraph7.Append(new Run(new Text($"{name}                                __________________              ____________")));
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
