namespace LabCalculator
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
            this.AddColBtn = new System.Windows.Forms.Button();
            this.AddRowBtn = new System.Windows.Forms.Button();
            this.DeleteRowBtn = new System.Windows.Forms.Button();
            this.DeleteColBtn = new System.Windows.Forms.Button();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FormulaTextBox = new System.Windows.Forms.TextBox();
            this.CalculateBtn = new System.Windows.Forms.Button();
            this.ChangeModeBtn = new System.Windows.Forms.Button();
            this.CellNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RefreshTableBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddColBtn
            // 
            this.AddColBtn.Location = new System.Drawing.Point(239, 12);
            this.AddColBtn.Name = "AddColBtn";
            this.AddColBtn.Size = new System.Drawing.Size(34, 36);
            this.AddColBtn.TabIndex = 0;
            this.AddColBtn.Text = "+";
            this.AddColBtn.UseVisualStyleBackColor = true;
            this.AddColBtn.Click += new System.EventHandler(this.AddColBtn_Click);
            // 
            // AddRowBtn
            // 
            this.AddRowBtn.Location = new System.Drawing.Point(71, 12);
            this.AddRowBtn.Name = "AddRowBtn";
            this.AddRowBtn.Size = new System.Drawing.Size(34, 36);
            this.AddRowBtn.TabIndex = 2;
            this.AddRowBtn.Text = "+";
            this.AddRowBtn.UseVisualStyleBackColor = true;
            this.AddRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // DeleteRowBtn
            // 
            this.DeleteRowBtn.Location = new System.Drawing.Point(71, 54);
            this.DeleteRowBtn.Name = "DeleteRowBtn";
            this.DeleteRowBtn.Size = new System.Drawing.Size(34, 36);
            this.DeleteRowBtn.TabIndex = 3;
            this.DeleteRowBtn.Text = "-";
            this.DeleteRowBtn.UseVisualStyleBackColor = true;
            this.DeleteRowBtn.Click += new System.EventHandler(this.DeleteRowBtn_Click);
            // 
            // DeleteColBtn
            // 
            this.DeleteColBtn.Location = new System.Drawing.Point(239, 54);
            this.DeleteColBtn.Name = "DeleteColBtn";
            this.DeleteColBtn.Size = new System.Drawing.Size(34, 36);
            this.DeleteColBtn.TabIndex = 4;
            this.DeleteColBtn.Text = "-";
            this.DeleteColBtn.UseVisualStyleBackColor = true;
            this.DeleteColBtn.Click += new System.EventHandler(this.DeleteCol_Click);
            // 
            // HelpBtn
            // 
            this.HelpBtn.Location = new System.Drawing.Point(1071, 540);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(94, 29);
            this.HelpBtn.TabIndex = 5;
            this.HelpBtn.Text = "Інструкція";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(227, 540);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(94, 29);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Зберегти";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.Location = new System.Drawing.Point(112, 540);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(109, 29);
            this.SaveAsBtn.TabIndex = 7;
            this.SaveAsBtn.Text = "Зберегти як";
            this.SaveAsBtn.UseVisualStyleBackColor = true;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1153, 434);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(12, 540);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(94, 29);
            this.OpenBtn.TabIndex = 8;
            this.OpenBtn.Text = "Відкрити";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // FormulaTextBox
            // 
            this.FormulaTextBox.Location = new System.Drawing.Point(361, 36);
            this.FormulaTextBox.Name = "FormulaTextBox";
            this.FormulaTextBox.Size = new System.Drawing.Size(492, 27);
            this.FormulaTextBox.TabIndex = 9;
            // 
            // CalculateBtn
            // 
            this.CalculateBtn.Location = new System.Drawing.Point(859, 19);
            this.CalculateBtn.Name = "CalculateBtn";
            this.CalculateBtn.Size = new System.Drawing.Size(106, 61);
            this.CalculateBtn.TabIndex = 11;
            this.CalculateBtn.Text = "Розрахунок";
            this.CalculateBtn.UseVisualStyleBackColor = true;
            this.CalculateBtn.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // ChangeModeBtn
            // 
            this.ChangeModeBtn.Location = new System.Drawing.Point(971, 18);
            this.ChangeModeBtn.Name = "ChangeModeBtn";
            this.ChangeModeBtn.Size = new System.Drawing.Size(94, 62);
            this.ChangeModeBtn.TabIndex = 12;
            this.ChangeModeBtn.Text = "Змінити режим";
            this.ChangeModeBtn.UseVisualStyleBackColor = true;
            this.ChangeModeBtn.Click += new System.EventHandler(this.ChangeModeBtn_Click);
            // 
            // CellNameLabel
            // 
            this.CellNameLabel.AutoSize = true;
            this.CellNameLabel.Location = new System.Drawing.Point(304, 39);
            this.CellNameLabel.Name = "CellNameLabel";
            this.CellNameLabel.Size = new System.Drawing.Size(26, 20);
            this.CellNameLabel.TabIndex = 13;
            this.CellNameLabel.Text = "№";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Стовпчики";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Рядки";
            // 
            // RefreshTableBtn
            // 
            this.RefreshTableBtn.Location = new System.Drawing.Point(1071, 18);
            this.RefreshTableBtn.Name = "RefreshTableBtn";
            this.RefreshTableBtn.Size = new System.Drawing.Size(94, 62);
            this.RefreshTableBtn.TabIndex = 16;
            this.RefreshTableBtn.Text = "Очистити таблицю";
            this.RefreshTableBtn.UseVisualStyleBackColor = true;
            this.RefreshTableBtn.Click += new System.EventHandler(this.RefreshTableBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Шлях до файлу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 577);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RefreshTableBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CellNameLabel);
            this.Controls.Add(this.ChangeModeBtn);
            this.Controls.Add(this.CalculateBtn);
            this.Controls.Add(this.FormulaTextBox);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.SaveAsBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.DeleteColBtn);
            this.Controls.Add(this.DeleteRowBtn);
            this.Controls.Add(this.AddRowBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddColBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button AddColBtn;
        private Button AddRowBtn;
        private Button DeleteRowBtn;
        private Button DeleteColBtn;
        private Button HelpBtn;
        private Button SaveBtn;
        private Button SaveAsBtn;
        private DataGridView dataGridView1;
        private Button OpenBtn;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private TextBox FormulaTextBox;
        private Button CalculateBtn;
        private Button ChangeModeBtn;
        private Label CellNameLabel;
        private Label label3;
        private Label label4;
        private Button RefreshTableBtn;
        private Label label5;
    }
}