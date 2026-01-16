using FileConverter.Interfaces;
using Spire.Pdf;

namespace FileConverter.Converters
{
    public class PdfConverter : IConverter
    {
        public void Convert(string inputPath, string outputPath, string outputExtension)
        {
            try
            {
                // 1. Make a PdfDocument container
                var pdfDocument = new PdfDocument();

                // 2. Download a path to file
                pdfDocument.LoadFromFile(inputPath);

                // 3. Export to needed extension
                FileFormat targetFormat = outputExtension.ToLower() switch
                {
                    ".docx" => FileFormat.DOCX,
                    ".html" => FileFormat.HTML,
                    _ => throw new NotSupportedException(
                        $"PDF → {outputExtension} not supported")
                };

                pdfDocument.SaveToFile(outputPath, targetFormat);
                pdfDocument.Close();

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