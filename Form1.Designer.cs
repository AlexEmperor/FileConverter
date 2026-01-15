namespace FileConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonConvert = new Button();
            comboBox_Extensions = new ComboBox();
            comboBox_FirstExtensions = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // ButtonConvert
            // 
            ButtonConvert.Location = new Point(439, 114);
            ButtonConvert.Name = "ButtonConvert";
            ButtonConvert.Size = new Size(171, 52);
            ButtonConvert.TabIndex = 0;
            ButtonConvert.Text = "Convert";
            ButtonConvert.UseVisualStyleBackColor = true;
            ButtonConvert.Click += ButtonConvert_Click;
            // 
            // comboBox_Extensions
            // 
            comboBox_Extensions.FormattingEnabled = true;
            comboBox_Extensions.Items.AddRange(new object[] { ".pdf", ".docx", ".html", ".txt", ".png", ".jpg", ".csv" });
            comboBox_Extensions.Location = new Point(115, 190);
            comboBox_Extensions.Name = "comboBox_Extensions";
            comboBox_Extensions.Size = new Size(151, 28);
            comboBox_Extensions.TabIndex = 1;
            comboBox_Extensions.Text = ".pdf";
            // 
            // comboBox_FirstExtensions
            // 
            comboBox_FirstExtensions.FormattingEnabled = true;
            comboBox_FirstExtensions.Items.AddRange(new object[] { ".md", ".docx", ".pdf", ".xlsx", ".pptx" });
            comboBox_FirstExtensions.Location = new Point(115, 99);
            comboBox_FirstExtensions.Name = "comboBox_FirstExtensions";
            comboBox_FirstExtensions.Size = new Size(151, 28);
            comboBox_FirstExtensions.TabIndex = 2;
            comboBox_FirstExtensions.Text = ".md";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 76);
            label1.Name = "label1";
            label1.Size = new Size(212, 20);
            label1.TabIndex = 3;
            label1.Text = "Расширение до конвертации";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 167);
            label2.Name = "label2";
            label2.Size = new Size(236, 20);
            label2.TabIndex = 4;
            label2.Text = "Расширение после конвертации";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 355);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox_FirstExtensions);
            Controls.Add(comboBox_Extensions);
            Controls.Add(ButtonConvert);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonConvert;
        private ComboBox comboBox_Extensions;
        private ComboBox comboBox_FirstExtensions;
        private Label label1;
        private Label label2;
    }
}
