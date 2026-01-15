using FileConverter.Converters;

namespace FileConverter
{
    public partial class Form1 : Form
    {
        private readonly Converter _converter = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            var extensionBeforeConvert = comboBox_FirstExtensions.Text;
            var extensionAfterConvert = comboBox_Extensions.Text;

            _converter.Convert(extensionBeforeConvert, extensionAfterConvert);
        }
    }
}