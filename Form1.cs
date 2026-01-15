using FileConverter.Converters;

namespace FileConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            var extensionBeforeConvert = comboBox_FirstExtensions.Text;
            var extensionAfterConvert = comboBox_Extensions.Text;

            var list = Conversion.GetConversionParameters(extensionBeforeConvert, extensionAfterConvert);
            var converter = Conversion.GetConverter(extensionBeforeConvert);

            converter.ConvertInternal(list[0], list[1], list[2]);
        }
    }
}