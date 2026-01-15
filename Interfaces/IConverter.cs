namespace FileConverter.Interfaces
{
    public interface IConverter
    {
        void ConvertInternal(string inputPath, string outputPath, string outputExtension);
    }
}
