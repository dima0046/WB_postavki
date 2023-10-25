namespace WB_postavki
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dataGridView1 = new DataGridView();
            buttonSavePodsorti = new Button();
            btnopen = new Button();
            bindingSourcePodsorti = new BindingSource(components);
            bindingSourceFullTable = new BindingSource(components);
            panel2 = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            label1 = new Label();
            panel1 = new Panel();
            btmHam = new PictureBox();
            sidebar = new FlowLayoutPanel();
            buttonPodsortiTab = new Button();
            panel3 = new Panel();
            buttonKoroba = new Button();
            panel4 = new Panel();
            button2 = new Button();
            SidebarTransition = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btmHam).BeginInit();
            sidebar.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(947, 156);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(291, 486);
            dataGridView1.TabIndex = 1;
            // 
            // buttonSavePodsorti
            // 
            buttonSavePodsorti.FlatStyle = FlatStyle.System;
            buttonSavePodsorti.Location = new Point(753, 156);
            buttonSavePodsorti.Name = "buttonSavePodsorti";
            buttonSavePodsorti.Size = new Size(169, 26);
            buttonSavePodsorti.TabIndex = 1;
            buttonSavePodsorti.Text = "Сохранить подсорты";
            buttonSavePodsorti.UseVisualStyleBackColor = true;
            buttonSavePodsorti.Click += buttonSavePodsorti_Click;
            // 
            // btnopen
            // 
            btnopen.FlatStyle = FlatStyle.System;
            btnopen.Location = new Point(597, 156);
            btnopen.Name = "btnopen";
            btnopen.Size = new Size(113, 26);
            btnopen.TabIndex = 0;
            btnopen.Text = "Открыть";
            btnopen.UseVisualStyleBackColor = true;
            btnopen.Click += btnopen_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(nightControlBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(btmHam);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1217, 44);
            panel2.TabIndex = 1;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(1078, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(57, 7);
            label1.Name = "label1";
            label1.Size = new Size(128, 30);
            label1.TabIndex = 2;
            label1.Text = "WB Asistent";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(23, 24, 29);
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(185, 56);
            panel1.TabIndex = 4;
            // 
            // btmHam
            // 
            btmHam.Dock = DockStyle.Left;
            btmHam.Image = (Image)resources.GetObject("btmHam.Image");
            btmHam.Location = new Point(0, 0);
            btmHam.Name = "btmHam";
            btmHam.Size = new Size(40, 44);
            btmHam.SizeMode = PictureBoxSizeMode.CenterImage;
            btmHam.TabIndex = 1;
            btmHam.TabStop = false;
            btmHam.Click += btmHam_Click;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(23, 24, 29);
            sidebar.Controls.Add(buttonPodsortiTab);
            sidebar.Controls.Add(panel3);
            sidebar.Controls.Add(panel4);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 44);
            sidebar.Margin = new Padding(0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(185, 572);
            sidebar.TabIndex = 2;
            // 
            // buttonPodsortiTab
            // 
            buttonPodsortiTab.BackColor = Color.FromArgb(23, 24, 29);
            buttonPodsortiTab.CausesValidation = false;
            buttonPodsortiTab.FlatAppearance.BorderSize = 0;
            buttonPodsortiTab.FlatStyle = FlatStyle.Flat;
            buttonPodsortiTab.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPodsortiTab.ForeColor = SystemColors.Window;
            buttonPodsortiTab.Image = (Image)resources.GetObject("buttonPodsortiTab.Image");
            buttonPodsortiTab.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPodsortiTab.Location = new Point(0, 0);
            buttonPodsortiTab.Margin = new Padding(0);
            buttonPodsortiTab.Name = "buttonPodsortiTab";
            buttonPodsortiTab.Size = new Size(185, 52);
            buttonPodsortiTab.TabIndex = 3;
            buttonPodsortiTab.Text = "         Подсорты";
            buttonPodsortiTab.TextAlign = ContentAlignment.MiddleLeft;
            buttonPodsortiTab.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(23, 24, 29);
            panel3.Controls.Add(buttonKoroba);
            panel3.Location = new Point(0, 52);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(185, 56);
            panel3.TabIndex = 4;
            // 
            // buttonKoroba
            // 
            buttonKoroba.BackColor = Color.FromArgb(23, 24, 29);
            buttonKoroba.CausesValidation = false;
            buttonKoroba.FlatAppearance.BorderSize = 0;
            buttonKoroba.FlatStyle = FlatStyle.Flat;
            buttonKoroba.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonKoroba.ForeColor = SystemColors.Window;
            buttonKoroba.Image = (Image)resources.GetObject("buttonKoroba.Image");
            buttonKoroba.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKoroba.Location = new Point(1, 4);
            buttonKoroba.Margin = new Padding(0);
            buttonKoroba.Name = "buttonKoroba";
            buttonKoroba.Size = new Size(185, 52);
            buttonKoroba.TabIndex = 3;
            buttonKoroba.Text = "         Короба";
            buttonKoroba.TextAlign = ContentAlignment.MiddleLeft;
            buttonKoroba.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(23, 24, 29);
            panel4.Controls.Add(button2);
            panel4.Location = new Point(0, 108);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(185, 56);
            panel4.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(23, 24, 29);
            button2.CausesValidation = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Window;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(1, 3);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(185, 52);
            button2.TabIndex = 3;
            button2.Text = "         Склады";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // SidebarTransition
            // 
            SidebarTransition.Interval = 5;
            SidebarTransition.Tick += SidebarTransition_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 616);
            Controls.Add(dataGridView1);
            Controls.Add(buttonSavePodsorti);
            Controls.Add(sidebar);
            Controls.Add(btnopen);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(816, 616);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WB поставки";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btmHam).EndInit();
            sidebar.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnopen;
        private DataGridView dataGridView1;
        private BindingSource bindingSourcePodsorti;
        private BindingSource bindingSourceFullTable;
        private Button buttonSavePodsorti;
        private Panel panel2;
        private Label label1;
        private PictureBox btmHam;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private FlowLayoutPanel sidebar;
        private Button buttonPodsortiTab;
        private Panel panel1;
        private Button buttonKoroba;
        private Button button2;
        private Panel panel3;
        private Panel panel4;
        private System.Windows.Forms.Timer SidebarTransition;
    }
}