using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using oMath = DocumentFormat.OpenXml.Math;

namespace InaccuracyCalculator.Utils
{
    public static class TemplateEditor
    {
        private static oMath.Subscript CreateSubscript(OpenXmlElement baseText, OpenXmlElement subText, RunProperties runProperties)
        {
            oMath.SubscriptProperties subscriptProperties = new oMath.SubscriptProperties();
            oMath.ControlProperties controlProperties = subscriptProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Subscript subscript = new oMath.Subscript(subscriptProperties);
            subscript.Append(new oMath.Base(baseText));
            subscript.Append(new oMath.SubArgument(subText));
            return subscript;
        }

        private static oMath.Superscript CreateSuperscript(OpenXmlElement baseText, OpenXmlElement supText, RunProperties runProperties)
        {
            oMath.SuperscriptProperties superscriptProperties = new oMath.SuperscriptProperties();
            oMath.ControlProperties controlProperties = superscriptProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Superscript superscript = new oMath.Superscript(superscriptProperties);
            superscript.Append(new oMath.Base(baseText));
            superscript.Append(new oMath.SuperArgument(supText));
            return superscript;
        }

        private static oMath.Delimiter CreateDelimiter(string delimiterChar, RunProperties runProperties, string beginChar, string endChar, params OpenXmlElement[] elements)
        {
            oMath.DelimiterProperties delimiterProperties = new oMath.DelimiterProperties
            {
                BeginChar = new oMath.BeginChar() { Val = beginChar },
                EndChar = new oMath.EndChar() { Val = endChar }
            };
            oMath.ControlProperties controlProperties = delimiterProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Delimiter delimiter = new oMath.Delimiter(delimiterProperties);
            oMath.Base delimiterBase = new oMath.Base();
            oMath.Run baseRun = new oMath.Run();
            baseRun.PrependChild(runProperties.CloneNode(true));
            baseRun.Append(new oMath.Text(delimiterChar));
            for (int i = 0; i < elements.Count(); i++)
            {
                elements[i].PrependChild(runProperties.CloneNode(true));
                delimiterBase.Append(elements[i]);
                if (i != elements.Count() - 1)
                    delimiterBase.Append(baseRun.CloneNode(true));
            }
            delimiter.Append(delimiterBase);
            return delimiter;
        }

        private static oMath.Fraction CreateFraction(RunProperties runProperties, List<OpenXmlElement> numeratorElements, List<OpenXmlElement> denominatorElements)
        {
            oMath.FractionProperties fractionProperties = new oMath.FractionProperties();
            oMath.ControlProperties controlProperties = fractionProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Fraction fraction = new oMath.Fraction(fractionProperties);
            oMath.Numerator fractionNumerator = new oMath.Numerator();
            oMath.Denominator fractionDenominator = new oMath.Denominator();
            for (int i = 0; i < numeratorElements.Count(); i++)
                fractionNumerator.Append(numeratorElements[i].CloneNode(true));
            for (int i = 0; i < denominatorElements.Count(); i++)
                fractionDenominator.Append(denominatorElements[i].CloneNode(true));
            fraction.Append(fractionNumerator, fractionDenominator);
            return fraction;
        }

        private static oMath.Nary CreateSigma(RunProperties runProperties, string supText, string subText, params OpenXmlElement[] elements)
        {
            oMath.NaryProperties naryProperties = new oMath.NaryProperties(new oMath.AccentChar() { Val = new StringValue($"{ReferenceValues.UTFSymbols["sigma"]}") }, new oMath.LimitLocation() { Val = oMath.LimitLocationValues.SubscriptSuperscript }, new oMath.GrowOperators() { Val = oMath.BooleanValues.One });
            oMath.ControlProperties controlProperties = naryProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Nary nary = new oMath.Nary(naryProperties);

            oMath.Run subRun = new oMath.Run();
            subRun.PrependChild(runProperties.CloneNode(true));
            subRun.Append(new oMath.Text(subText));

            oMath.Run supRun = new oMath.Run();
            supRun.PrependChild(runProperties.CloneNode(true));
            supRun.Append(new oMath.Text(supText));

            nary.Append(new oMath.SubArgument(subRun));
            nary.Append(new oMath.SuperArgument(supRun));

            oMath.Base naryBase = nary.AppendChild(new oMath.Base());

            foreach (OpenXmlElement element in elements)
                naryBase.Append(element);
            return nary;
        }

        private static oMath.Accent CreateAccent(RunProperties runProperties, char accentChar, params OpenXmlElement[] elements)
        {
            oMath.AccentProperties accentProperties = new oMath.AccentProperties(new oMath.AccentChar() { Val = new StringValue(accentChar.ToString()) });
            oMath.ControlProperties controlProperties = accentProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Accent accent = new oMath.Accent(accentProperties);

            oMath.Base accentBase = accent.AppendChild(new oMath.Base());

            foreach (OpenXmlElement element in elements)
                accentBase.Append(element);
            return accent;
        }

        private static oMath.Paragraph CreateEquation(string alignment = "left", params OpenXmlElement[] elements)
        {
            oMath.Paragraph mathParagraph = new oMath.Paragraph();
            switch (alignment)
            {
                case "left":
                    mathParagraph.PrependChild(new oMath.ParagraphProperties(new oMath.Justification() { Val = oMath.JustificationValues.Left })); break;
                case "right":
                    mathParagraph.PrependChild(new oMath.ParagraphProperties(new oMath.Justification() { Val = oMath.JustificationValues.Right })); break;
                case "center":
                    mathParagraph.PrependChild(new oMath.ParagraphProperties(new oMath.Justification() { Val = oMath.JustificationValues.Center })); break;
                case "centergroup":
                    mathParagraph.PrependChild(new oMath.ParagraphProperties(new oMath.Justification() { Val = oMath.JustificationValues.CenterGroup })); break;
            }
            oMath.OfficeMath officeMath = mathParagraph.AppendChild(new oMath.OfficeMath());
            foreach (OpenXmlElement element in elements)
                officeMath.Append(element);
            return mathParagraph;
        }

        private static oMath.Radical CreateRad(RunProperties runProperties, params OpenXmlElement[] elements)
        {
            oMath.RadicalProperties radicalProperties = new oMath.RadicalProperties(new oMath.HideDegree() { Val = oMath.BooleanValues.One });
            oMath.ControlProperties controlProperties = radicalProperties.AppendChild(new oMath.ControlProperties());
            controlProperties.Append(runProperties.CloneNode(true));
            oMath.Radical radical = new oMath.Radical(radicalProperties);
            oMath.Base radicalBase = radical.AppendChild(new oMath.Base());
            foreach (OpenXmlElement element in elements)
                radicalBase.Append(element);
            return radical;
        }

        private static OpenXmlElement GenerateElement(string elementName, Calculation calculation)
        {
            RunProperties runProperties = new RunProperties();
            RunFonts runFont = new RunFonts
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman"
            };
            runProperties.Append(new FontSize { Val = new StringValue("28") }, new FontSizeComplexScript { Val = new StringValue("28") });
            runProperties.Append(runFont);

            RunProperties mathRunProperties = new RunProperties();
            RunFonts mathRunFonts = new RunFonts
            {
                EastAsiaTheme = ThemeFontValues.MinorEastAsia,
                Ascii = "Cambria Math",
                HighAnsi = "Cambria Math",
                ComplexScript = "Cambria Math"
            };
            mathRunProperties.Append(mathRunFonts);
            mathRunProperties.Append(new FontSize { Val = new StringValue("28") }, new FontSizeComplexScript { Val = new StringValue("28") });

            switch (elementName)
            {
                case "SortedSelection":
                    Table selection = new Table();
                    TableProperties tableProps = new TableProperties(
                        new TableBorders(
                            new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                                        ),
                        new TableJustification() { Val = TableRowAlignmentValues.Center }
                    );
                    selection.Append(tableProps);
                    TableCellProperties cellProps = new TableCellProperties(
                        new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center },
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" },
                        new TableCellMargin(
                            new LeftMargin() { Width = "100", Type = TableWidthUnitValues.Dxa },
                            new RightMargin() { Width = "100", Type = TableWidthUnitValues.Dxa }
                            )
                    );
                    TableRow headerRow = new TableRow();
                    headerRow.Append(CreateTableCell($"{calculation.PhysicalSymbol}, {calculation.PhysicalUnit}", runProperties, cellProps));
                    foreach (decimal value in calculation.OriginalSelection)
                        headerRow.Append(CreateTableCell(value.ToString(), runProperties, cellProps));
                    selection.Append(headerRow);
                    return selection;

                case "PeakToPeakFormula":
                    return CreateEquation(null, new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("R=")), CreateDelimiter("-", mathRunProperties, "|", "|", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("max")), mathRunProperties), CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("min")), mathRunProperties)));
                case "PeakToPeak":
                    return CreateEquation(null, new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("R=")), CreateDelimiter("-", mathRunProperties, "|", "|", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.OriginalSelection.Max().ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.OriginalSelection.Min().ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"={calculation.PeakToPeak} {calculation.PhysicalUnit}")));
                case "SelectionSize":
                    return new Run(runProperties.CloneNode(true), new Text(calculation.OriginalSelection.Count.ToString()));
                case "UFactor":
                    return new Run(runProperties.CloneNode(true), new Text(calculation.SuitableUFactor.ToString()));
                case "CheckPairFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{calculation.PhysicalSymbol}=")), CreateDelimiter("-", mathRunProperties, "|", "|", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("i+1")), mathRunProperties), CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("i")), mathRunProperties)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("<")), CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("U")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("p,N")), mathRunProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("⋅R"))));
                case "OutliersConclusion":
                    if (!calculation.ValidSelection)
                        return new Paragraph(runProperties.CloneNode(true), new Run(runProperties.CloneNode(true), new Text("Выборка не является связной")));
                    return new Paragraph(runProperties.CloneNode(true), new Run(runProperties.CloneNode(true), new Text(calculation.Outliers.Count == 0 ? "В данной выборке грубые погрешности отсутствуют" : $"В данной выборке присутствует {calculation.Outliers.Count} {(calculation.Outliers.Count > 1 ? "грубых погрешностей" : "грубая погрешность")}")));
                case "SelectionAverageFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateFraction(mathRunProperties, new List<OpenXmlElement>() { CreateSigma(mathRunProperties, "N", "i=1", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("U")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("i")), mathRunProperties)) }, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("N")) })));
                case "SelectionAverage":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateFraction(mathRunProperties, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(string.Join("+", calculation.SelectionValues))) }, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionValues.Count.ToString())) }), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"={calculation.SelectionAverage} {calculation.PhysicalUnit}"))));
                case "RootMeanSquareFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("S")), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), runProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateRad(mathRunProperties, CreateFraction(mathRunProperties, new List<OpenXmlElement>() { CreateSigma(mathRunProperties, "N", "i=1", CreateSuperscript(CreateDelimiter("-", mathRunProperties, "(", ")", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString())))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties)) }, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("N")), CreateDelimiter("-", mathRunProperties, "(", ")", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("N")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("1"))) }))));
                case "RootMeanSquare":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("S")), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), runProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateRad(mathRunProperties, CreateFraction(mathRunProperties, new List<OpenXmlElement>() { CreateSuperscript(CreateDelimiter("-", mathRunProperties, "(", ")", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionValues[0].ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionAverage.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("+...+")), CreateSuperscript(CreateDelimiter("-", mathRunProperties, "(", ")", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionValues[calculation.SelectionValues.Count - 1].ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionAverage.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties), }, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionValues.Count.ToString())), CreateDelimiter("-", mathRunProperties, "(", ")", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionValues.Count.ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("1"))) })), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{calculation.RootMeanSquare} {calculation.PhysicalUnit}"))));
                case "StudentFactor":
                    return new Run(runProperties.CloneNode(true), new Text(calculation.SuitableStudentFactor.ToString()));
                case "ImprecisionStudentFolmula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["delta"]}{calculation.PhysicalSymbol}=")), CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("t")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("p,N")), mathRunProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("⋅")), CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("S")), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), runProperties)));
                case "ImprecisionStudent":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["delta"]}{calculation.PhysicalSymbol}=")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{calculation.SuitableStudentFactor}⋅{calculation.RootMeanSquare}={calculation.ImprecisionStudent} {calculation.PhysicalUnit}"))));
                case "ImprecisionFullFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(ReferenceValues.UTFSymbols["delta"].ToString())), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateRad(mathRunProperties, CreateSuperscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["delta"]}{calculation.PhysicalSymbol}")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("+")), CreateSuperscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(ReferenceValues.UTFSymbols["theta"].ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties))));
                case "ImprecisionFull":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(ReferenceValues.UTFSymbols["delta"].ToString())), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateRad(mathRunProperties, CreateSuperscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.ImprecisionStudent.ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("+")), CreateSuperscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.Accuracy.ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("2")), runProperties)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"={calculation.ImprecisionFull} {calculation.PhysicalUnit}"))));
                case "ImprecisionRelativeFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["small_delta"]}=")), CreateFraction(mathRunProperties, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(ReferenceValues.UTFSymbols["delta"].ToString())), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))) }, new List<OpenXmlElement>() { CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))) }), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("⋅100%"))));
                case "ImprecisionRelative":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["small_delta"]}=")), CreateFraction(mathRunProperties, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.ImprecisionFull.ToString())) }, new List<OpenXmlElement>() { new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.SelectionAverage.ToString())) }), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"⋅100%={calculation.ImprecisionRelative}"))));
                case "ResultFormula":
                    return new Paragraph(runProperties.CloneNode(true), CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{calculation.PhysicalSymbol}=")), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{ReferenceValues.UTFSymbols["plusminus"]}{ReferenceValues.UTFSymbols["delta"]}")), CreateAccent(mathRunProperties, ReferenceValues.UTFSymbols["comb_over"], new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol.ToString())))));
                case "Result":
                    return new Paragraph(runProperties.CloneNode(true),
                        CreateEquation("left", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"{calculation.PhysicalSymbol}={calculation.RoundedAverage}{ReferenceValues.UTFSymbols["plusminus"]}{calculation.RoundedImprecision} {calculation.PhysicalUnit}"))));
            }
            return null;
        }

        private static TableCell CreateTableCell(string text, RunProperties runProperties, TableCellProperties cellProperties)
        {
            TableCell cell = new TableCell();
            Paragraph cellParagraph = new Paragraph();
            Run cellRun = new Run(new Text(text));
            cellRun.PrependChild(runProperties.CloneNode(true));
            cellParagraph.Append(new ParagraphProperties(new Justification() { Val = JustificationValues.Center }));
            cellParagraph.Append(cellRun);
            cell.Append(cellParagraph);
            cell.Append(cellProperties.CloneNode(true));
            return cell;
        }

        public static bool FindAndReplaceTags(Calculation calculation)
        {
            using (WordprocessingDocument templateDoc = WordprocessingDocument.Open(path: @".\resources\template.docx", isEditable: false))
            using (WordprocessingDocument resultDoc = WordprocessingDocument.Create(path: @".\Report.docx", type: WordprocessingDocumentType.Document))
            {
                foreach (OpenXmlPart part in templateDoc.GetPartsOfType<OpenXmlPart>())
                    resultDoc.AddPart(part);

                Body body = resultDoc.MainDocumentPart.Document.Body;
                List<SdtBlock> bodySdt = new List<SdtBlock>();
                List<SdtRun> paragraphSdt = new List<SdtRun>();
                foreach (SdtBlock sdtBlock in body.Descendants<SdtBlock>())
                    bodySdt.Add(sdtBlock);
                foreach (Paragraph paragraph in body.Descendants<Paragraph>())
                    foreach (SdtRun sdtRun in paragraph.Elements<SdtRun>())
                        paragraphSdt.Add(sdtRun);

                RunProperties runProperties = new RunProperties();
                RunFonts runFont = new RunFonts
                {
                    Ascii = "Times New Roman",
                    HighAnsi = "Times New Roman"
                };
                runProperties.Append(new FontSize { Val = new StringValue("28") }, new FontSizeComplexScript { Val = new StringValue("28") });
                runProperties.Append(runFont);

                RunProperties mathRunProperties = new RunProperties();
                RunFonts mathRunFonts = new RunFonts
                {
                    EastAsiaTheme = ThemeFontValues.MinorEastAsia,
                    Ascii = "Cambria Math",
                    HighAnsi = "Cambria Math",
                    ComplexScript = "Cambria Math"
                };
                mathRunProperties.Append(mathRunFonts);
                mathRunProperties.Append(new FontSize { Val = new StringValue("28") }, new FontSizeComplexScript { Val = new StringValue("28") });

                foreach (SdtBlock sdtBlock in bodySdt)
                    if (sdtBlock.SdtProperties != null)
                    {
                        if (sdtBlock.SdtProperties.GetFirstChild<Tag>().Val != "CheckPairs")
                        {
                            OpenXmlElement openXmlElement = GenerateElement(sdtBlock.SdtProperties.GetFirstChild<Tag>().Val, calculation);
                            if (openXmlElement != null)
                                sdtBlock.Parent.ReplaceChild(openXmlElement, sdtBlock);
                        }
                        else
                        {
                            for (int i = 0; i < calculation.OriginalSelection.Count - 1; i++)
                            {
                                decimal currentPair = Math.Abs(calculation.OriginalSelection[i + 1] - calculation.OriginalSelection[i]);
                                bool outlierPresent = currentPair > calculation.SuitableUFactor * calculation.PeakToPeak;
                                bool ignoreOutlier = false;
                                if (outlierPresent)
                                {
                                    if (i == 0 && calculation.OriginalSelection[i] <= calculation.Accuracy)
                                        ignoreOutlier = true;
                                    else if (calculation.OriginalSelection[i + 1] <= calculation.Accuracy)
                                        ignoreOutlier = true;
                                }
                                Paragraph paragraph = new Paragraph(runProperties.CloneNode(true), CreateEquation("left", CreateSubscript(new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.PhysicalSymbol)), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text((i + 1).ToString())), mathRunProperties), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text("=")), CreateDelimiter("-", mathRunProperties, "|", "|", new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.OriginalSelection[i + 1].ToString())), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(calculation.OriginalSelection[i].ToString()))), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text($"={currentPair}")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text(outlierPresent ? ">" : "<")), new oMath.Run(mathRunProperties.CloneNode(true), new oMath.Text((calculation.SuitableUFactor * calculation.PeakToPeak).ToString()))));
                                if (ignoreOutlier)
                                    paragraph.Append(new Run(runProperties.CloneNode(true), new Text(" (не учитывается, так как выборочное значение меньше приборной погрешности)") { Space = SpaceProcessingModeValues.Preserve }));
                                sdtBlock.InsertBeforeSelf(paragraph);
                            }
                            sdtBlock.Parent.RemoveChild(sdtBlock);
                        }
                    }
                foreach (SdtRun sdtRun in paragraphSdt)
                    if (sdtRun.SdtProperties != null)
                    {
                        OpenXmlElement openXmlElement = GenerateElement(sdtRun.SdtProperties.GetFirstChild<Tag>().Val, calculation);
                        if (openXmlElement != null)
                            sdtRun.Parent.ReplaceChild(openXmlElement, sdtRun);
                    }
            }
            return true;
        }
    }
}
