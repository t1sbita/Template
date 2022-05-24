using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Template.Api.Business.Reports.DataSets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Template.Api.Business.Reports
{
    public class ReportAlvaraDetailed : ReportBase
    {
        public ReportAlvaraDetailed(MemoryStream stream, List<DataSetAlvaraDetailed> datasets)
        {
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            Document document = CreateDocument(pdfDocument);
            
            MountHeader(document);
            AddLineSeparator(document, 3f);
            AddTitle(document, "SISTEMA SIA - RELATÓRIO DETALHADO", new DeviceRgb(0, 102, 204));
            FillData(document, datasets);
            AddNumberation(pdfDocument, document);

            document.Flush();
            document.Close();
        }

        private void FillData(Document document, List<DataSetAlvaraDetailed> datasets)
        {
            foreach (var dataset in datasets)
            {
                Paragraph identifier = new Paragraph($"{dataset.NumeroAlvara} - {dataset.Requerente.Nome}");
                identifier
                    .SetFontSize(10)
                    .SetFontColor(new DeviceRgb(0, 102, 204))
                    .SetBold();

                document.Add(identifier);
                
                Table tableAlvaraSubtitle = new Table(1)
                    .UseAllAvailableWidth();

                tableAlvaraSubtitle.AddCell(CustomizeSubtitle("Alvará"));
                
                document.Add(tableAlvaraSubtitle);
                AddLineSeparator(document, 2, ColorConstants.GRAY);

                Table dadosAlvara = new Table(UnitValue.CreatePercentArray(12))
                    .SetMarginTop(5)
                    .SetMarginBottom(30)
                    .UseAllAvailableWidth();
                
                dadosAlvara.AddCell(CustomizeFieldNames("Área Ampliada", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Área Construída", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Área Discriminada", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Área Modificada", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Área Nova", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Área Ocupada", 2));
                
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaAmpliada, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaConstruida, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaDiscriminada, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaModificada, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaNova, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaOcupada, 2));
                
                dadosAlvara.AddCell(CustomizeFieldNames("Área Reformada", 3));
                dadosAlvara.AddCell(CustomizeFieldNames("Data de Emissão", 3));
                dadosAlvara.AddCell(CustomizeFieldNames("Bairro", 3));
                dadosAlvara.AddCell(CustomizeFieldNames("CEP", 3));

                dadosAlvara.AddCell(CustomizeCellValues(dataset.AreaReformada, 3));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.DataEmissao, 3));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.Endereco.Bairro, 3));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.Endereco.Cep, 3));

                dadosAlvara.AddCell(CustomizeFieldNames("Logradouro", 5));
                dadosAlvara.AddCell(CustomizeFieldNames("Natureza da Ocupação", 3));
                dadosAlvara.AddCell(CustomizeFieldNames("Número", 2));
                dadosAlvara.AddCell(CustomizeFieldNames("Tipo de Ocupação", 2));

                dadosAlvara.AddCell(CustomizeCellValues(dataset.Endereco.Logradouro, 5));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.NaturezaOcupacao, 3));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.NumeroAlvara, 2));
                dadosAlvara.AddCell(CustomizeCellValues(dataset.TipoOcupacao, 2));

                document.Add(dadosAlvara);


                Table tableProcessoSubtitle = new Table(1)
                    .UseAllAvailableWidth();

                tableProcessoSubtitle.AddCell(CustomizeSubtitle("Processo"));

                document.Add(tableProcessoSubtitle);
                AddLineSeparator(document, 2, ColorConstants.GRAY);

                Table dadosProcesso = new Table(UnitValue.CreatePercentArray(12))
                    .SetMarginTop(5)
                    .SetMarginBottom(30)
                    .UseAllAvailableWidth();

                dadosProcesso.AddCell(CustomizeFieldNames("Ano", 2));
                dadosProcesso.AddCell(CustomizeFieldNames("Centro Intormação", 4));
                dadosProcesso.AddCell(CustomizeFieldNames("Data Criação", 2));
                dadosProcesso.AddCell(CustomizeFieldNames("Data Deferimento", 2));
                dadosProcesso.AddCell(CustomizeFieldNames("Número", 2));

                dadosProcesso.AddCell(CustomizeCellValues(dataset.AnoProcesso, 2));
                dadosProcesso.AddCell(CustomizeCellValues(dataset.CentroInformacao, 4));
                dadosProcesso.AddCell(CustomizeCellValues(dataset.DataCriacao, 2));
                dadosProcesso.AddCell(CustomizeCellValues(dataset.DataDeferimento, 2));
                dadosProcesso.AddCell(CustomizeCellValues(dataset.NumeroProcesso, 2));

                document.Add(dadosProcesso);


                Table tableProprietarioSubtitle = new Table(1)
                    .UseAllAvailableWidth();

                tableProprietarioSubtitle.AddCell(CustomizeSubtitle("Proprietário"));

                document.Add(tableProprietarioSubtitle);
                AddLineSeparator(document, 2, ColorConstants.GRAY);

                Table dadosProprietario = new Table(UnitValue.CreatePercentArray(12))
                    .SetMarginTop(5)
                    .SetMarginBottom(30)
                    .UseAllAvailableWidth();

                if (dataset.Proprietario.NumeroDocumento.Length > 11)
                    dadosProprietario.AddCell(CustomizeFieldNames("CNPJ", 4));
                else
                    dadosProprietario.AddCell(CustomizeFieldNames("CPF", 4));
                dadosProprietario.AddCell(CustomizeFieldNames("DDD", 1));
                dadosProprietario.AddCell(CustomizeFieldNames("Celular", 3));
                dadosProprietario.AddCell(CustomizeFieldNames("DDD", 1));
                dadosProprietario.AddCell(CustomizeFieldNames("Telefone", 3));

                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.NumeroDocumento, 4));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.DddCelular, 1));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Celular, 3));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.DddTelefone, 1));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Telefone, 3));

                dadosProprietario.AddCell(CustomizeFieldNames("Bairro", 3));
                dadosProprietario.AddCell(CustomizeFieldNames("CEP", 3));
                dadosProprietario.AddCell(CustomizeFieldNames("Logradouro", 4));
                dadosProprietario.AddCell(CustomizeFieldNames("Número", 2));

                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Endereco.Bairro, 3));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Endereco.Cep, 3));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Endereco.Logradouro, 4));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Endereco.Numero, 2));

                dadosProprietario.AddCell(CustomizeFieldNames("Nome", 6));
                dadosProprietario.AddCell(CustomizeFieldNames("E-mail", 6));

                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Nome, 6));
                dadosProprietario.AddCell(CustomizeCellValues(dataset.Proprietario.Email, 6));

                document.Add(dadosProprietario);


                Table tableRequerenteSubtitle = new Table(1)
                    .UseAllAvailableWidth();

                tableRequerenteSubtitle.AddCell(CustomizeSubtitle("Requerente"));

                document.Add(tableRequerenteSubtitle);
                AddLineSeparator(document, 2, ColorConstants.GRAY);

                Table dadosRequerente = new Table(UnitValue.CreatePercentArray(12))
                    .SetMarginTop(5)
                    .SetMarginBottom(30)
                    .UseAllAvailableWidth();

                if (dataset.Requerente.NumeroDocumento.Length > 11)
                    dadosRequerente.AddCell(CustomizeFieldNames("CNPJ", 4));
                else
                    dadosRequerente.AddCell(CustomizeFieldNames("CPF", 4));
                dadosRequerente.AddCell(CustomizeFieldNames("DDD", 1));
                dadosRequerente.AddCell(CustomizeFieldNames("Celular", 3));
                dadosRequerente.AddCell(CustomizeFieldNames("DDD", 1));
                dadosRequerente.AddCell(CustomizeFieldNames("Telefone", 3));

                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.NumeroDocumento, 4));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.DddCelular, 1));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Celular, 3));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.DddTelefone, 1));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Telefone, 3));

                dadosRequerente.AddCell(CustomizeFieldNames("Bairro", 3));
                dadosRequerente.AddCell(CustomizeFieldNames("CEP", 3));
                dadosRequerente.AddCell(CustomizeFieldNames("Logradouro", 4));
                dadosRequerente.AddCell(CustomizeFieldNames("Número", 2));

                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Endereco.Bairro, 3));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Endereco.Cep, 3));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Endereco.Logradouro, 4));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Endereco.Numero, 2));

                dadosRequerente.AddCell(CustomizeFieldNames("Nome", 6));
                dadosRequerente.AddCell(CustomizeFieldNames("E-mail", 6));

                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Nome, 6));
                dadosRequerente.AddCell(CustomizeCellValues(dataset.Requerente.Email, 6));

                document.Add(dadosRequerente);

                if (datasets.IndexOf(dataset) != datasets.Count - 1)
                    document.Add(new AreaBreak());
            }
        }

        private Cell CustomizeSubtitle(string subtitle)
        {
            var cell = new Cell().Add(new Paragraph(subtitle));
            cell.SetPaddingLeft(10)
                .SetBackgroundColor(new DeviceRgb(207, 207, 207))
                .SetBorder(Border.NO_BORDER);

            return cell;
        }

        private Cell CustomizeFieldNames(string subtitle, int colEnd)
        {
            var cell = new Cell(1, colEnd).Add(new Paragraph(subtitle));
            cell
                .SetMarginTop(5)
                .SetFontSize(9)
                .SetFontColor(new DeviceRgb(102, 102, 102))
                .SetVerticalAlignment(VerticalAlignment.BOTTOM)
                .SetBorder(Border.NO_BORDER);

            return cell;
        }

        private Cell CustomizeCellValues(string value, int colEnd)
        {
            var cell = new Cell(1, colEnd).Add(new Paragraph(value));
            cell
                .SetMarginBottom(10)
                .SetPaddingLeft(5)
                .SetFontSize(9)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetBorder(new SolidBorder(new DeviceRgb(102, 102, 102), 1));

            return cell;
        }
    }
}
