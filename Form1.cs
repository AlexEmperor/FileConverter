using Spire.Doc;
using Spire.Doc.Documents;

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

            //Выбор исходного Markdown файла
            using var ofd = new OpenFileDialog();
            ofd.Filter = $"Markdown files|*.{extensionBeforeConvert}|All files|*.*";
            ofd.Title = $"Select Markdown File";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return; // пользователь отменил
            }

            string markdownPath = ofd.FileName;

            //Выбор места для PDF
            using var sfd = new SaveFileDialog();
            sfd.Filter = $"{extensionAfterConvert} files|*.pdf";
            sfd.Title = $"Save {extensionAfterConvert} As";

            // предлагаем имя по умолчанию
            sfd.FileName = Path.GetFileNameWithoutExtension(markdownPath) + $".{extensionAfterConvert}";

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return; // пользователь отменил
            }

            string pdfPath = sfd.FileName;

            // Конвертация
            Convert(markdownPath, pdfPath);

            MessageBox.Show("Conversion completed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Convert(string markdownPath, string pdfPath)
        {
            try
            {
                // 1. Создаём контейнер документа
                Document doc = new();

                // 2. Загружаем Markdown (парсинг)
                doc.LoadFromFile(markdownPath, FileFormat.Markdown);

                // Настройки страницы: Section соответствует «страничной» единице в PDF.
                // С помощью нескольких Section можно делать колонки или управлять разрывами страниц в произвольных местах.
                Section section = doc.Sections[0];

                section.PageSetup.PageSize = PageSize.A4;
                section.PageSetup.Orientation = PageOrientation.Portrait;

                // 3. Настройка полей (в миллиметрах): порядок — верх, низ, левое, правое
                float margin = 17.9f;
                section.PageSetup.Margins.Top = margin;
                section.PageSetup.Margins.Bottom = margin;
                section.PageSetup.Margins.Left = margin;
                section.PageSetup.Margins.Right = margin;

                // 4. Экспорт в PDF
                doc.SaveToFile(pdfPath, FileFormat.PDF);

                // 5. Закрываем документ
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conversion failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
