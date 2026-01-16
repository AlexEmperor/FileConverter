using FileConverter.Interfaces;
using Spire.Doc;
using Spire.Doc.Documents;

namespace FileConverter.Converters
{
    public class WordConverter : IConverter
    {
        public void Convert(string filePath, string outputPath, string outputExtension)
        {
            try
            {
                // 1. Make a document container
                var document = new Document();

                // 2. Download a path to file
                document.LoadFromFile(filePath);

                Section section = document.Sections[0];

                section.PageSetup.PageSize = PageSize.A4;
                section.PageSetup.Orientation = PageOrientation.Portrait;

                // 3. Margin settings
                float margin = 17.9f;
                section.PageSetup.Margins.Top = margin;
                section.PageSetup.Margins.Bottom = margin;
                section.PageSetup.Margins.Left = margin;
                section.PageSetup.Margins.Right = margin;

                // 4. Export to needed extension
                FileFormat targetFormat = outputExtension.ToLower() switch
                {
                    ".pdf" => FileFormat.PDF,
                    ".html" => FileFormat.Html,
                    ".txt" => FileFormat.Txt,
                    _ => throw new NotSupportedException($"Unsupported format: {outputExtension}")
                };

                document.SaveToFile(outputPath, targetFormat);
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
    }
}