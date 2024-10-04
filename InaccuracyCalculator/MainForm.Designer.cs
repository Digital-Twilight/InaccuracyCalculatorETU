namespace InaccuracyCalculator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ProgramMenu = new System.Windows.Forms.MenuStrip();
            this.File_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Create_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DOCX_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PDF_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectionSizeLabel = new System.Windows.Forms.Label();
            this.SelectionSizeTextBox = new System.Windows.Forms.TextBox();
            this.SelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.Value_1 = new System.Windows.Forms.TextBox();
            this.Value_0 = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.CalculatedDataGridView = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhysicalSymbolTextBox = new System.Windows.Forms.TextBox();
            this.PhysicalSymbolLabel = new System.Windows.Forms.Label();
            this.PhysicalUnitLabel = new System.Windows.Forms.Label();
            this.PhysicalUnitTextBox = new System.Windows.Forms.TextBox();
            this.AccuracyLabel = new System.Windows.Forms.Label();
            this.AccuracyTextBox = new System.Windows.Forms.TextBox();
            this.SelectionSizeTrackBar = new InaccuracyCalculator.NoFocusTrackBar();
            this.ProgramMenu.SuspendLayout();
            this.SelectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgramMenu
            // 
            this.ProgramMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_MenuItem,
            this.About_MenuItem});
            this.ProgramMenu.Location = new System.Drawing.Point(0, 0);
            this.ProgramMenu.Name = "ProgramMenu";
            this.ProgramMenu.Size = new System.Drawing.Size(762, 24);
            this.ProgramMenu.TabIndex = 0;
            this.ProgramMenu.Text = "menuStrip1";
            // 
            // File_MenuItem
            // 
            this.File_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create_MenuItem});
            this.File_MenuItem.Name = "File_MenuItem";
            this.File_MenuItem.Size = new System.Drawing.Size(48, 20);
            this.File_MenuItem.Text = "Файл";
            // 
            // Create_MenuItem
            // 
            this.Create_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DOCX_MenuItem,
            this.PDF_MenuItem});
            this.Create_MenuItem.Name = "Create_MenuItem";
            this.Create_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.Create_MenuItem.Text = "Создать отчёт";
            // 
            // DOCX_MenuItem
            // 
            this.DOCX_MenuItem.Name = "DOCX_MenuItem";
            this.DOCX_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.DOCX_MenuItem.Text = ".docx";
            this.DOCX_MenuItem.Click += new System.EventHandler(this.DOCX_MenuItem_Click);
            // 
            // PDF_MenuItem
            // 
            this.PDF_MenuItem.Name = "PDF_MenuItem";
            this.PDF_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.PDF_MenuItem.Text = ".pdf";
            this.PDF_MenuItem.Click += new System.EventHandler(this.PDF_MenuItem_Click);
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(94, 20);
            this.About_MenuItem.Text = "О программе";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // SelectionSizeLabel
            // 
            this.SelectionSizeLabel.AutoSize = true;
            this.SelectionSizeLabel.Location = new System.Drawing.Point(12, 30);
            this.SelectionSizeLabel.Name = "SelectionSizeLabel";
            this.SelectionSizeLabel.Size = new System.Drawing.Size(93, 13);
            this.SelectionSizeLabel.TabIndex = 1;
            this.SelectionSizeLabel.Text = "Размер выборки";
            // 
            // SelectionSizeTextBox
            // 
            this.SelectionSizeTextBox.Location = new System.Drawing.Point(221, 27);
            this.SelectionSizeTextBox.Name = "SelectionSizeTextBox";
            this.SelectionSizeTextBox.ReadOnly = true;
            this.SelectionSizeTextBox.Size = new System.Drawing.Size(27, 20);
            this.SelectionSizeTextBox.TabIndex = 3;
            this.SelectionSizeTextBox.TabStop = false;
            this.SelectionSizeTextBox.Text = "2";
            this.SelectionSizeTextBox.TextChanged += new System.EventHandler(this.SelectionSizeTextBox_TextChanged);
            // 
            // SelectionGroupBox
            // 
            this.SelectionGroupBox.Controls.Add(this.Value_1);
            this.SelectionGroupBox.Controls.Add(this.Value_0);
            this.SelectionGroupBox.Location = new System.Drawing.Point(12, 78);
            this.SelectionGroupBox.Name = "SelectionGroupBox";
            this.SelectionGroupBox.Size = new System.Drawing.Size(128, 45);
            this.SelectionGroupBox.TabIndex = 5;
            this.SelectionGroupBox.TabStop = false;
            this.SelectionGroupBox.Text = "Выборка";
            // 
            // Value_1
            // 
            this.Value_1.Location = new System.Drawing.Point(67, 19);
            this.Value_1.Name = "Value_1";
            this.Value_1.Size = new System.Drawing.Size(55, 20);
            this.Value_1.TabIndex = 1;
            this.Value_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericalTextBox_KeyPress);
            // 
            // Value_0
            // 
            this.Value_0.Location = new System.Drawing.Point(6, 19);
            this.Value_0.Name = "Value_0";
            this.Value_0.Size = new System.Drawing.Size(55, 20);
            this.Value_0.TabIndex = 0;
            this.Value_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericalTextBox_KeyPress);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(146, 95);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(116, 23);
            this.CalculateButton.TabIndex = 6;
            this.CalculateButton.Text = "Рассчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // CalculatedDataGridView
            // 
            this.CalculatedDataGridView.AllowUserToAddRows = false;
            this.CalculatedDataGridView.AllowUserToDeleteRows = false;
            this.CalculatedDataGridView.AllowUserToResizeColumns = false;
            this.CalculatedDataGridView.AllowUserToResizeRows = false;
            this.CalculatedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalculatedDataGridView.ColumnHeadersVisible = false;
            this.CalculatedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Value});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CalculatedDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.CalculatedDataGridView.Location = new System.Drawing.Point(15, 156);
            this.CalculatedDataGridView.Name = "CalculatedDataGridView";
            this.CalculatedDataGridView.ReadOnly = true;
            this.CalculatedDataGridView.RowHeadersVisible = false;
            this.CalculatedDataGridView.Size = new System.Drawing.Size(735, 324);
            this.CalculatedDataGridView.TabIndex = 7;
            // 
            // Parameter
            // 
            this.Parameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Parameter.HeaderText = "Параметр";
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Значение";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PhysicalSymbolTextBox
            // 
            this.PhysicalSymbolTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhysicalSymbolTextBox.Location = new System.Drawing.Point(248, 124);
            this.PhysicalSymbolTextBox.Name = "PhysicalSymbolTextBox";
            this.PhysicalSymbolTextBox.Size = new System.Drawing.Size(26, 26);
            this.PhysicalSymbolTextBox.TabIndex = 8;
            this.PhysicalSymbolTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PhysicalSymbolLabel
            // 
            this.PhysicalSymbolLabel.AutoSize = true;
            this.PhysicalSymbolLabel.Location = new System.Drawing.Point(12, 131);
            this.PhysicalSymbolLabel.Name = "PhysicalSymbolLabel";
            this.PhysicalSymbolLabel.Size = new System.Drawing.Size(230, 13);
            this.PhysicalSymbolLabel.TabIndex = 9;
            this.PhysicalSymbolLabel.Text = "Символ обозначения физической величины";
            // 
            // PhysicalUnitLabel
            // 
            this.PhysicalUnitLabel.AutoSize = true;
            this.PhysicalUnitLabel.Location = new System.Drawing.Point(280, 131);
            this.PhysicalUnitLabel.Name = "PhysicalUnitLabel";
            this.PhysicalUnitLabel.Size = new System.Drawing.Size(111, 13);
            this.PhysicalUnitLabel.TabIndex = 11;
            this.PhysicalUnitLabel.Text = "Единицы измерения";
            // 
            // PhysicalUnitTextBox
            // 
            this.PhysicalUnitTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhysicalUnitTextBox.Location = new System.Drawing.Point(397, 124);
            this.PhysicalUnitTextBox.Name = "PhysicalUnitTextBox";
            this.PhysicalUnitTextBox.Size = new System.Drawing.Size(26, 26);
            this.PhysicalUnitTextBox.TabIndex = 10;
            this.PhysicalUnitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AccuracyLabel
            // 
            this.AccuracyLabel.AutoSize = true;
            this.AccuracyLabel.Location = new System.Drawing.Point(429, 131);
            this.AccuracyLabel.Name = "AccuracyLabel";
            this.AccuracyLabel.Size = new System.Drawing.Size(120, 13);
            this.AccuracyLabel.TabIndex = 13;
            this.AccuracyLabel.Text = "Погрешность прибора";
            // 
            // AccuracyTextBox
            // 
            this.AccuracyTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccuracyTextBox.Location = new System.Drawing.Point(555, 124);
            this.AccuracyTextBox.Name = "AccuracyTextBox";
            this.AccuracyTextBox.Size = new System.Drawing.Size(51, 26);
            this.AccuracyTextBox.TabIndex = 12;
            this.AccuracyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AccuracyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericalTextBox_KeyPress);
            // 
            // SelectionSizeTrackBar
            // 
            this.SelectionSizeTrackBar.Location = new System.Drawing.Point(111, 27);
            this.SelectionSizeTrackBar.Minimum = 2;
            this.SelectionSizeTrackBar.Name = "SelectionSizeTrackBar";
            this.SelectionSizeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.SelectionSizeTrackBar.TabIndex = 4;
            this.SelectionSizeTrackBar.Value = 2;
            this.SelectionSizeTrackBar.ValueChanged += new System.EventHandler(this.SampleSizeTrackBar_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 492);
            this.Controls.Add(this.AccuracyLabel);
            this.Controls.Add(this.AccuracyTextBox);
            this.Controls.Add(this.PhysicalUnitLabel);
            this.Controls.Add(this.PhysicalUnitTextBox);
            this.Controls.Add(this.PhysicalSymbolLabel);
            this.Controls.Add(this.PhysicalSymbolTextBox);
            this.Controls.Add(this.CalculatedDataGridView);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.SelectionGroupBox);
            this.Controls.Add(this.SelectionSizeTrackBar);
            this.Controls.Add(this.SelectionSizeTextBox);
            this.Controls.Add(this.SelectionSizeLabel);
            this.Controls.Add(this.ProgramMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ProgramMenu;
            this.Name = "MainForm";
            this.Text = "Калькулятор погрешностей ЛЭТИ";
            this.ProgramMenu.ResumeLayout(false);
            this.ProgramMenu.PerformLayout();
            this.SelectionGroupBox.ResumeLayout(false);
            this.SelectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalculatedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ProgramMenu;
        private System.Windows.Forms.ToolStripMenuItem File_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Create_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DOCX_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem PDF_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem;
        private System.Windows.Forms.Label SelectionSizeLabel;
        private System.Windows.Forms.TextBox SelectionSizeTextBox;
        private NoFocusTrackBar SelectionSizeTrackBar;
        private System.Windows.Forms.GroupBox SelectionGroupBox;
        private System.Windows.Forms.TextBox Value_0;
        private System.Windows.Forms.TextBox Value_1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.DataGridView CalculatedDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TextBox PhysicalSymbolTextBox;
        private System.Windows.Forms.Label PhysicalSymbolLabel;
        private System.Windows.Forms.Label PhysicalUnitLabel;
        private System.Windows.Forms.TextBox PhysicalUnitTextBox;
        private System.Windows.Forms.Label AccuracyLabel;
        private System.Windows.Forms.TextBox AccuracyTextBox;
    }
}

