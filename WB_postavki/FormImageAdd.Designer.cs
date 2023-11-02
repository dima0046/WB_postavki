namespace WB_postavki
{
    partial class FormImageAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new ReaLTaiizor.Controls.Button();
            button2 = new ReaLTaiizor.Controls.Button();
            TextBoxURL = new ReaLTaiizor.Controls.SmallTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BorderColor = Color.FromArgb(32, 34, 37);
            button1.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            button1.EnteredColor = Color.FromArgb(32, 34, 37);
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Image = null;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.InactiveColor = Color.FromArgb(32, 34, 37);
            button1.Location = new Point(325, 44);
            button1.Name = "button1";
            button1.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button1.PressedColor = Color.FromArgb(165, 37, 37);
            button1.Size = new Size(102, 33);
            button1.TabIndex = 2;
            button1.Text = "Отмена";
            button1.TextAlignment = StringAlignment.Center;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BorderColor = Color.FromArgb(32, 34, 37);
            button2.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            button2.EnteredColor = Color.FromArgb(32, 34, 37);
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = null;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.InactiveColor = Color.FromArgb(32, 34, 37);
            button2.Location = new Point(433, 44);
            button2.Name = "button2";
            button2.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button2.PressedColor = Color.FromArgb(165, 37, 37);
            button2.Size = new Size(102, 33);
            button2.TabIndex = 1;
            button2.Text = "OK";
            button2.TextAlignment = StringAlignment.Center;
            button2.Click += button2_Click;
            // 
            // TextBoxURL
            // 
            TextBoxURL.BackColor = Color.Transparent;
            TextBoxURL.BorderColor = Color.FromArgb(180, 180, 180);
            TextBoxURL.CustomBGColor = Color.White;
            TextBoxURL.Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxURL.ForeColor = Color.DimGray;
            TextBoxURL.Location = new Point(2, 12);
            TextBoxURL.MaxLength = 32767;
            TextBoxURL.Multiline = false;
            TextBoxURL.Name = "TextBoxURL";
            TextBoxURL.ReadOnly = false;
            TextBoxURL.Size = new Size(533, 28);
            TextBoxURL.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            TextBoxURL.TabIndex = 0;
            TextBoxURL.TextAlignment = HorizontalAlignment.Left;
            TextBoxURL.UseSystemPasswordChar = false;
            TextBoxURL.TextChanged += TextBoxURL_TextChanged;
            // 
            // FormImageAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 83);
            Controls.Add(TextBoxURL);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "FormImageAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Вставьте URL изображения";
            KeyDown += FormImageAdd_KeyDown;
            PreviewKeyDown += FormImageAdd_PreviewKeyDown;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Button button1;
        private ReaLTaiizor.Controls.Button button2;
        private ReaLTaiizor.Controls.SmallTextBox TextBoxURL;
    }
}