namespace FileConverter.Interfaces
{
    public interface IConverter
    {
        void Convert(string inputPath, string outputPath, string outputExtension);
    }
}