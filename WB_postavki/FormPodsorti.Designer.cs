namespace WB_postavki
{
    partial class FormPodsorti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPodsorti));
            btnOpen = new ReaLTaiizor.Controls.Button();
            btnSave = new ReaLTaiizor.Controls.Button();
            button2 = new ReaLTaiizor.Controls.Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.Transparent;
            btnOpen.BackgroundImage = (Image)resources.GetObject("btnOpen.BackgroundImage");
            btnOpen.BackgroundImageLayout = ImageLayout.None;
            btnOpen.BorderColor = Color.FromArgb(32, 34, 37);
            btnOpen.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnOpen.EnteredColor = Color.FromArgb(32, 34, 37);
            btnOpen.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageAlign = ContentAlignment.MiddleCenter;
            btnOpen.InactiveColor = Color.FromArgb(32, 34, 37);
            btnOpen.Location = new Point(2, 6);
            btnOpen.Name = "btnOpen";
            btnOpen.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnOpen.PressedColor = Color.FromArgb(165, 37, 37);
            btnOpen.Size = new Size(45, 45);
            btnOpen.TabIndex = 0;
            btnOpen.TextAlignment = StringAlignment.Center;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.BackgroundImageLayout = ImageLayout.None;
            btnSave.BorderColor = Color.FromArgb(32, 34, 37);
            btnSave.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnSave.EnteredColor = Color.FromArgb(32, 34, 37);
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleCenter;
            btnSave.InactiveColor = Color.FromArgb(32, 34, 37);
            btnSave.Location = new Point(53, 6);
            btnSave.Name = "btnSave";
            btnSave.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnSave.PressedColor = Color.FromArgb(165, 37, 37);
            btnSave.Size = new Size(45, 45);
            btnSave.TabIndex = 0;
            btnSave.TextAlignment = StringAlignment.Center;
            btnSave.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.BorderColor = Color.FromArgb(32, 34, 37);
            button2.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            button2.EnteredColor = Color.FromArgb(32, 34, 37);
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleCenter;
            button2.InactiveColor = Color.FromArgb(32, 34, 37);
            button2.Location = new Point(104, 6);
            button2.Name = "button2";
            button2.PressedBorderColor = Color.FromArgb(165, 37, 37);
            button2.PressedColor = Color.FromArgb(165, 37, 37);
            button2.Size = new Size(45, 45);
            button2.TabIndex = 0;
            button2.TextAlignment = StringAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 60);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 390);
            dataGridView1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnOpen);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 54);
            panel1.TabIndex = 5;
            // 
            // FormPodsorti
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPodsorti";
            Text = "FormPodsorti";
            FormClosed += FormPodsorti_FormClosed;
            Load += FormPodsorti_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.Button btnOpen;
        private ReaLTaiizor.Controls.Button btnSave;
        private ReaLTaiizor.Controls.Button button2;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}