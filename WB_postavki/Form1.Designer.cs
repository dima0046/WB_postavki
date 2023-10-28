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
            bindingSourcePodsorti = new BindingSource(components);
            bindingSourceFullTable = new BindingSource(components);
            panelMenu = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            label1 = new Label();
            btmHam = new PictureBox();
            sidebar = new FlowLayoutPanel();
            panelPodsorti = new Panel();
            buttonPodsorti = new Button();
            panelSkladi = new Panel();
            buttonSkladi = new Button();
            panelKoroba = new Panel();
            buttonKoroba = new Button();
            buttonPodsortiTab = new Button();
            SidebarTransition = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).BeginInit();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btmHam).BeginInit();
            sidebar.SuspendLayout();
            panelPodsorti.SuspendLayout();
            panelSkladi.SuspendLayout();
            panelKoroba.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.White;
            panelMenu.Controls.Add(nightControlBox1);
            panelMenu.Controls.Add(label1);
            panelMenu.Controls.Add(btmHam);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1217, 31);
            panelMenu.TabIndex = 1;
            panelMenu.MouseDown += panelMenu_MouseDown;
            panelMenu.MouseMove += panelMenu_MouseMove;
            panelMenu.MouseUp += panelMenu_MouseUp;
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
            label1.Location = new Point(57, -1);
            label1.Name = "label1";
            label1.Size = new Size(188, 30);
            label1.TabIndex = 2;
            label1.Text = "WB Выручалочка";
            // 
            // btmHam
            // 
            btmHam.Dock = DockStyle.Left;
            btmHam.Image = (Image)resources.GetObject("btmHam.Image");
            btmHam.Location = new Point(0, 0);
            btmHam.Name = "btmHam";
            btmHam.Size = new Size(40, 31);
            btmHam.SizeMode = PictureBoxSizeMode.CenterImage;
            btmHam.TabIndex = 1;
            btmHam.TabStop = false;
            btmHam.Click += btmHam_Click;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(23, 24, 29);
            sidebar.Controls.Add(panelPodsorti);
            sidebar.Controls.Add(panelSkladi);
            sidebar.Controls.Add(panelKoroba);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 31);
            sidebar.Margin = new Padding(0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(185, 585);
            sidebar.TabIndex = 2;
            // 
            // panelPodsorti
            // 
            panelPodsorti.BackColor = Color.FromArgb(23, 24, 29);
            panelPodsorti.Controls.Add(buttonPodsorti);
            panelPodsorti.Location = new Point(0, 0);
            panelPodsorti.Margin = new Padding(0);
            panelPodsorti.Name = "panelPodsorti";
            panelPodsorti.Size = new Size(185, 52);
            panelPodsorti.TabIndex = 4;
            // 
            // buttonPodsorti
            // 
            buttonPodsorti.BackColor = Color.FromArgb(23, 24, 29);
            buttonPodsorti.CausesValidation = false;
            buttonPodsorti.FlatAppearance.BorderSize = 0;
            buttonPodsorti.FlatStyle = FlatStyle.Flat;
            buttonPodsorti.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPodsorti.ForeColor = SystemColors.Window;
            buttonPodsorti.Image = (Image)resources.GetObject("buttonPodsorti.Image");
            buttonPodsorti.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPodsorti.Location = new Point(0, 0);
            buttonPodsorti.Margin = new Padding(0);
            buttonPodsorti.Name = "buttonPodsorti";
            buttonPodsorti.Size = new Size(185, 52);
            buttonPodsorti.TabIndex = 3;
            buttonPodsorti.Text = "         Подсорты";
            buttonPodsorti.TextAlign = ContentAlignment.MiddleLeft;
            buttonPodsorti.UseVisualStyleBackColor = false;
            buttonPodsorti.Click += buttonPodsorti_Click;
            // 
            // panelSkladi
            // 
            panelSkladi.BackColor = Color.FromArgb(23, 24, 29);
            panelSkladi.Controls.Add(buttonSkladi);
            panelSkladi.Location = new Point(0, 52);
            panelSkladi.Margin = new Padding(0);
            panelSkladi.Name = "panelSkladi";
            panelSkladi.Size = new Size(185, 52);
            panelSkladi.TabIndex = 4;
            // 
            // buttonSkladi
            // 
            buttonSkladi.BackColor = Color.FromArgb(23, 24, 29);
            buttonSkladi.CausesValidation = false;
            buttonSkladi.FlatAppearance.BorderSize = 0;
            buttonSkladi.FlatStyle = FlatStyle.Flat;
            buttonSkladi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSkladi.ForeColor = SystemColors.Window;
            buttonSkladi.Image = (Image)resources.GetObject("buttonSkladi.Image");
            buttonSkladi.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSkladi.Location = new Point(1, 0);
            buttonSkladi.Margin = new Padding(0);
            buttonSkladi.Name = "buttonSkladi";
            buttonSkladi.Size = new Size(185, 52);
            buttonSkladi.TabIndex = 3;
            buttonSkladi.Text = "         Склады";
            buttonSkladi.TextAlign = ContentAlignment.MiddleLeft;
            buttonSkladi.UseVisualStyleBackColor = false;
            buttonSkladi.Click += button2_Click;
            // 
            // panelKoroba
            // 
            panelKoroba.BackColor = Color.FromArgb(23, 24, 29);
            panelKoroba.Controls.Add(buttonKoroba);
            panelKoroba.Location = new Point(0, 104);
            panelKoroba.Margin = new Padding(0);
            panelKoroba.Name = "panelKoroba";
            panelKoroba.Size = new Size(185, 52);
            panelKoroba.TabIndex = 4;
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
            buttonKoroba.Click += buttonKoroba_Click;
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
            buttonPodsortiTab.Size = new Size(157, 52);
            buttonPodsortiTab.TabIndex = 3;
            buttonPodsortiTab.Text = "         Подсорты";
            buttonPodsortiTab.TextAlign = ContentAlignment.MiddleLeft;
            buttonPodsortiTab.UseVisualStyleBackColor = false;
            // 
            // SidebarTransition
            // 
            SidebarTransition.Interval = 3;
            SidebarTransition.Tick += SidebarTransition_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 616);
            Controls.Add(sidebar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MinimumSize = new Size(816, 616);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WB поставки";
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).EndInit();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btmHam).EndInit();
            sidebar.ResumeLayout(false);
            panelPodsorti.ResumeLayout(false);
            panelSkladi.ResumeLayout(false);
            panelKoroba.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bindingSourcePodsorti;
        private BindingSource bindingSourceFullTable;
        private Panel panelMenu;
        private Label label1;
        private PictureBox btmHam;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private FlowLayoutPanel sidebar;
        private Button buttonPodsortiTab;
        private Button buttonKoroba;
        private Button buttonSkladi;
        private Panel panelKoroba;
        private Panel panelSkladi;
        private System.Windows.Forms.Timer SidebarTransition;
        private Panel panelPodsorti;
        private Button buttonPodsorti;
    }
}