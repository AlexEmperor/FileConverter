using FileConverter.Interfaces;
using Spire.Xls;

namespace FileConverter.Converters
{
    public class ExcelConverter : IConverter
    {
        public void Convert(string inputPath, string outputPath, string outputExtension)
        {
            try
            {
                // 1. Make a Excel workbook container
                var workbook = new Workbook();

                // 2. Download a path to file
                workbook.LoadFromFile(inputPath);

                // 3. Export to needed extension
                FileFormat targetFormat = outputExtension.ToLower() switch
                {
                    ".pdf" => FileFormat.PDF,
                    ".html" => FileFormat.HTML,
                    ".csv" => FileFormat.CSV,
                    _ => throw new NotSupportedException(
                        $"Excel → {outputExtension} is not supported")
                };

                workbook.SaveToFile(outputPath, targetFormat);

                MessageBox.Show("Conversion completed!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conversion failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}