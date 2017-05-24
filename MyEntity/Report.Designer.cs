namespace MyEntity
{
    partial class Report
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BothRadio = new System.Windows.Forms.RadioButton();
            this.IncomeRadio = new System.Windows.Forms.RadioButton();
            this.SpendingRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contributionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.datetime,
            this.contributionColumn});
            this.dataGridView1.Location = new System.Drawing.Point(90, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(493, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(140, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "View by:";
            // 
            // BothRadio
            // 
            this.BothRadio.AutoSize = true;
            this.BothRadio.Checked = true;
            this.BothRadio.Location = new System.Drawing.Point(321, 67);
            this.BothRadio.Name = "BothRadio";
            this.BothRadio.Size = new System.Drawing.Size(47, 17);
            this.BothRadio.TabIndex = 4;
            this.BothRadio.TabStop = true;
            this.BothRadio.Text = "Both";
            this.BothRadio.UseVisualStyleBackColor = true;
            this.BothRadio.CheckedChanged += new System.EventHandler(this.BothRadio_CheckedChanged);
            this.BothRadio.Click += new System.EventHandler(this.BothRadio_Click);
            // 
            // IncomeRadio
            // 
            this.IncomeRadio.AutoSize = true;
            this.IncomeRadio.Location = new System.Drawing.Point(402, 67);
            this.IncomeRadio.Name = "IncomeRadio";
            this.IncomeRadio.Size = new System.Drawing.Size(65, 17);
            this.IncomeRadio.TabIndex = 5;
            this.IncomeRadio.Text = "Incomes";
            this.IncomeRadio.UseVisualStyleBackColor = true;
            this.IncomeRadio.Click += new System.EventHandler(this.IncomeRadio_Click);
            // 
            // SpendingRadio
            // 
            this.SpendingRadio.AutoSize = true;
            this.SpendingRadio.Location = new System.Drawing.Point(508, 67);
            this.SpendingRadio.Name = "SpendingRadio";
            this.SpendingRadio.Size = new System.Drawing.Size(75, 17);
            this.SpendingRadio.TabIndex = 6;
            this.SpendingRadio.Text = "Spendings";
            this.SpendingRadio.UseVisualStyleBackColor = true;
            this.SpendingRadio.CheckedChanged += new System.EventHandler(this.SpendingRadio_CheckedChanged);
            this.SpendingRadio.Click += new System.EventHandler(this.SpendingRadio_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(87, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total:";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Summ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // datetime
            // 
            this.datetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datetime.HeaderText = "Date";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            // 
            // contributionColumn
            // 
            this.contributionColumn.HeaderText = "Contribution by";
            this.contributionColumn.Name = "contributionColumn";
            this.contributionColumn.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.label3.Location = new System.Drawing.Point(266, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Report";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 311);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpendingRadio);
            this.Controls.Add(this.IncomeRadio);
            this.Controls.Add(this.BothRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton BothRadio;
        private System.Windows.Forms.RadioButton IncomeRadio;
        private System.Windows.Forms.RadioButton SpendingRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn contributionColumn;
        private System.Windows.Forms.Label label3;
    }
}