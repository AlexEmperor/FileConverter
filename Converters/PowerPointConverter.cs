using FileConverter.Interfaces;
using Spire.Presentation;

namespace FileConverter.Converters
{
    public class PowerPointConverter : IConverter
    {
        public void Convert(string inputPath, string outputPath, string outputExtension)
        {
            try
            {
                // 1. Make a presentation container
                var presentation = new Presentation();

                // 2. Download a path to file
                presentation.LoadFromFile(inputPath);

                // 3. Export to needed extension
                FileFormat targetFormat = outputExtension.ToLower() switch
                {
                    ".pdf" => FileFormat.PDF,
                    ".html" => FileFormat.Html,
                    _ => throw new NotSupportedException(
                        $"Presentation → {outputExtension} not supported")
                };

                presentation.SaveToFile(outputPath, targetFormat);

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