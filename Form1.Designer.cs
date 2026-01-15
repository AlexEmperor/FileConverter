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
            SuspendLayout();
            // 
            // ButtonConvert
            // 
            ButtonConvert.Location = new Point(162, 105);
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
            comboBox_Extensions.Items.AddRange(new object[] { "pdf" });
            comboBox_Extensions.Location = new Point(450, 180);
            comboBox_Extensions.Name = "comboBox_Extensions";
            comboBox_Extensions.Size = new Size(151, 28);
            comboBox_Extensions.TabIndex = 1;
            comboBox_Extensions.Text = "pdf";
            // 
            // comboBox_FirstExtensions
            // 
            comboBox_FirstExtensions.FormattingEnabled = true;
            comboBox_FirstExtensions.Items.AddRange(new object[] { "md" });
            comboBox_FirstExtensions.Location = new Point(450, 118);
            comboBox_FirstExtensions.Name = "comboBox_FirstExtensions";
            comboBox_FirstExtensions.Size = new Size(151, 28);
            comboBox_FirstExtensions.TabIndex = 2;
            comboBox_FirstExtensions.Text = "md";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 691);
            Controls.Add(comboBox_FirstExtensions);
            Controls.Add(comboBox_Extensions);
            Controls.Add(ButtonConvert);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonConvert;
        private ComboBox comboBox_Extensions;
        private ComboBox comboBox_FirstExtensions;
    }
}
