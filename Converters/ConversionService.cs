using FileConverter.Interfaces;

namespace FileConverter.Converters
{
    public static class ConversionService
    {
        public static List<string> GetConversionParameters(string inputExtension, string outputExtension)
        {
            // 1. Choose file
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{inputExtension} Files|*{inputExtension}|All files|*.*";
            openFileDialog.Title = "Select File";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return [];
            }

            string inputPath = openFileDialog.FileName;

            // 2. Save file
            using var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{outputExtension} files|*{outputExtension}";
            saveFileDialog.Title = "Save converted file";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(inputPath) + outputExtension;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return [];
            }

            string outputPath = saveFileDialog.FileName;

            return [inputPath, outputPath, outputExtension];
        }

        public static IConverter GetConverter(string inputExtension)
        {
            return inputExtension.ToLower() switch
            {
                ".md" => new MarkDownConverter(),
                ".docx" => new WordConverter(),
                ".xlsx" => new ExcelConverter(),
                ".pptx" => new PowerPointConverter(),
                ".pdf" => new PdfConverter(),
                _ => throw new NotSupportedException($"No converter for {inputExtension}")
            };
        }
    }
}