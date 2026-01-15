using Spire.Doc;
using Spire.Doc.Documents;
/*using Spire.Pdf;
using Spire.Presentation;
using Spire.Xls;*/

namespace FileConverter.Converters
{
    public class Converter
    {
        public void Convert(string extensionBeforeConvert, string extensionAfterConvert)
        {
            //1. Choose the file to convert
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{extensionBeforeConvert.ToUpper()} Files|*{extensionBeforeConvert}|All files|*.*";
            openFileDialog.Title = $"Select File";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = openFileDialog.FileName;

            //2. Choose the folder to save file
            using var safeFileDialog = new SaveFileDialog();
            safeFileDialog.Filter = $"{extensionAfterConvert} files|*{extensionAfterConvert}";
            safeFileDialog.Title = $"Save file as";
            safeFileDialog.FileName = Path.GetFileNameWithoutExtension(filePath) + $"{extensionAfterConvert}";

            if (safeFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string outputPath = safeFileDialog.FileName;

            //3. Conversion
            Conversion(filePath, outputPath, extensionAfterConvert);

        }

        public void Conversion(string filePath, string outputPath, string outputExtension)
        {
            try
            {
                // 1. Make a document container
                Document document = new();

                // 2. Download a path to file
                document.LoadFromFile(filePath, FileFormat.Markdown);

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
                    ".docx" => FileFormat.Docx,
                    ".html" => FileFormat.Html,
                    ".txt" => FileFormat.Txt,
                    /* ".png" => FileFormat.,
                     ".jpg" => FileFormat.,
                     ".csv" => FileFormat.,*/
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