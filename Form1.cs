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

            var list = ConversionService.GetConversionParameters(extensionBeforeConvert, extensionAfterConvert);

            if (list.Count == 0)
            {
                return;
            }

            var converter = ConversionService.GetConverter(extensionBeforeConvert);
            converter.Convert(list[0], list[1], list[2]);
        }
    }
}