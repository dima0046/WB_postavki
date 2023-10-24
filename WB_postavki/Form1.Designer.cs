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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnopen = new Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            labelTables1 = new Label();
            pictureBoxTables1 = new PictureBox();
            bindingSourcePodsorti = new BindingSource(components);
            bindingSourceFullTable = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTables1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnopen, 1, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1217, 609);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnopen
            // 
            btnopen.Location = new Point(203, 3);
            btnopen.Name = "btnopen";
            btnopen.Size = new Size(75, 23);
            btnopen.TabIndex = 0;
            btnopen.Text = "Открыть";
            btnopen.UseVisualStyleBackColor = true;
            btnopen.Click += btnopen_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(200, 32);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(997, 557);
            dataGridView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 32);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(200, 557);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(labelTables1);
            panel1.Controls.Add(pictureBoxTables1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(194, 49);
            panel1.TabIndex = 2;
            // 
            // labelTables1
            // 
            labelTables1.AutoSize = true;
            labelTables1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelTables1.Location = new Point(40, 8);
            labelTables1.Margin = new Padding(0);
            labelTables1.Name = "labelTables1";
            labelTables1.Size = new Size(124, 32);
            labelTables1.TabIndex = 1;
            labelTables1.Text = "Подсорты";
            // 
            // pictureBoxTables1
            // 
            pictureBoxTables1.Dock = DockStyle.Left;
            pictureBoxTables1.Image = (Image)resources.GetObject("pictureBoxTables1.Image");
            pictureBoxTables1.Location = new Point(0, 0);
            pictureBoxTables1.Name = "pictureBoxTables1";
            pictureBoxTables1.Size = new Size(30, 49);
            pictureBoxTables1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxTables1.TabIndex = 0;
            pictureBoxTables1.TabStop = false;
            // 
            // bindingSourcePodsorti
            // 
            bindingSourcePodsorti.CurrentChanged += bindingSourcePodsorti_CurrentChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 609);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(816, 616);
            Name = "FormMain";
            Text = "WB поставки";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTables1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourcePodsorti).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceFullTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnopen;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private PictureBox pictureBoxTables1;
        private Label labelTables1;
        private BindingSource bindingSourcePodsorti;
        private BindingSource bindingSourceFullTable;
    }
}