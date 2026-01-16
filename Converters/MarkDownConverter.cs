using FileConverter.Interfaces;
using Spire.Doc;
using Spire.Doc.Documents;

namespace FileConverter.Converters
{
    public class MarkDownConverter : IConverter
    {
        public void Convert(string inputPath, string outputPath, string outputExtension)
        {
            switch (outputExtension.ToLower())
            {
                case ".pdf":
                case ".docx":
                    ConvertDirect(inputPath, outputPath, outputExtension);
                    break;

                case ".html":
                    ConvertViaDocx(inputPath, outputPath, FileFormat.Html);
                    break;

                case ".txt":
                    ConvertViaDocx(inputPath, outputPath, FileFormat.Txt);
                    break;

                default:
                    throw new NotSupportedException(
                        $"Markdown → {outputExtension} not supported");
            }
        }

        private void ConvertDirect(string inputPath, string outputPath, string outputExtension)
        {
            try
            {
                var document = new Document();
                document.LoadFromFile(inputPath, FileFormat.Markdown);

                Section section = document.Sections[0];
                section.PageSetup.PageSize = PageSize.A4;
                section.PageSetup.Orientation = PageOrientation.Portrait;

                float margin = 17.9f;
                section.PageSetup.Margins.Top = margin;
                section.PageSetup.Margins.Bottom = margin;
                section.PageSetup.Margins.Left = margin;
                section.PageSetup.Margins.Right = margin;

                var format = outputExtension == ".pdf" ? FileFormat.PDF : FileFormat.Docx;
                document.SaveToFile(outputPath, format);
                document.Close();

                MessageBox.Show("Conversion completed!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conversion failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ConvertViaDocx(string inputPath, string outputPath, FileFormat targetExtension)
        {
            try
            {
                string tempFileDOCX = Path.GetTempFileName() + ".docx";

                var documentDOCX = new Document();
                documentDOCX.LoadFromFile(inputPath, FileFormat.Markdown);

                Section section = documentDOCX.Sections[0];
                section.PageSetup.PageSize = PageSize.A4;
                section.PageSetup.Orientation = PageOrientation.Portrait;

                float margin = 17.9f;
                section.PageSetup.Margins.Top = margin;
                section.PageSetup.Margins.Bottom = margin;
                section.PageSetup.Margins.Left = margin;
                section.PageSetup.Margins.Right = margin;

                documentDOCX.SaveToFile(tempFileDOCX, FileFormat.Docx);
                documentDOCX.Close();

                var documentWithNewExtension = new Document();

                documentWithNewExtension.LoadFromFile(tempFileDOCX, FileFormat.Docx);
                documentWithNewExtension.SaveToFile(outputPath, targetExtension);
                documentWithNewExtension.Close();

                File.Delete(tempFileDOCX);

                MessageBox.Show("Conversion completed!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conversion failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}