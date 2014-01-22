namespace AnalysisVBFormApl
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.exButton2 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton1 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exDataGridView1 = new OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl(this.components);
            this.exButton3 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exDataGridViewControl12222 = new OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl(this.components);
            this.ColLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColDbName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDBColumnName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDBType2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDBSize2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridViewControl12222)).BeginInit();
            this.SuspendLayout();
            // 
            // exButton2
            // 
            this.exButton2.Location = new System.Drawing.Point(359, 236);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(50, 30);
            this.exButton2.TabIndex = 12;
            this.exButton2.Text = "検索";
            this.exButton2.UseVisualStyleBackColor = true;
            this.exButton2.Click += new System.EventHandler(this.exButton2_Click);
            // 
            // exButton1
            // 
            this.exButton1.Location = new System.Drawing.Point(359, 316);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(50, 30);
            this.exButton1.TabIndex = 10;
            this.exButton1.Text = "戻る";
            this.exButton1.UseVisualStyleBackColor = true;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // exDataGridView1
            // 
            this.exDataGridView1.AllowUserToAddRows = false;
            this.exDataGridView1.AllowUserToDeleteRows = false;
            this.exDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView1.ColumnNamesortAsNumber = new string[0];
            this.exDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLineNumber,
            this.ColType,
            this.ColGrid});
            this.exDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDataGridView1.IsSkipFocusReadOnlyCell = false;
            this.exDataGridView1.Location = new System.Drawing.Point(12, 12);
            this.exDataGridView1.Name = "exDataGridView1";
            this.exDataGridView1.RowHeadersVisible = false;
            this.exDataGridView1.RowTemplate.Height = 21;
            this.exDataGridView1.Size = new System.Drawing.Size(392, 218);
            this.exDataGridView1.TabIndex = 3;
            // 
            // exButton3
            // 
            this.exButton3.Location = new System.Drawing.Point(359, 272);
            this.exButton3.Name = "exButton3";
            this.exButton3.Size = new System.Drawing.Size(50, 38);
            this.exButton3.TabIndex = 14;
            this.exButton3.Text = "行追加(10行)";
            this.exButton3.UseVisualStyleBackColor = true;
            this.exButton3.Click += new System.EventHandler(this.exButton3_Click);
            // 
            // exDataGridViewControl12222
            // 
            this.exDataGridViewControl12222.AllowUserToAddRows = false;
            this.exDataGridViewControl12222.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exDataGridViewControl12222.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.exDataGridViewControl12222.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridViewControl12222.ColumnNamesortAsNumber = new string[0];
            this.exDataGridViewControl12222.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDbName2,
            this.ColDBColumnName2,
            this.ColDBType2,
            this.ColDBSize2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.exDataGridViewControl12222.DefaultCellStyle = dataGridViewCellStyle2;
            this.exDataGridViewControl12222.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDataGridViewControl12222.IsSkipFocusReadOnlyCell = false;
            this.exDataGridViewControl12222.Location = new System.Drawing.Point(12, 236);
            this.exDataGridViewControl12222.Name = "exDataGridViewControl12222";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exDataGridViewControl12222.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.exDataGridViewControl12222.RowHeadersVisible = false;
            this.exDataGridViewControl12222.RowTemplate.Height = 21;
            this.exDataGridViewControl12222.Size = new System.Drawing.Size(345, 110);
            this.exDataGridViewControl12222.TabIndex = 15;
            // 
            // ColLineNumber
            // 
            this.ColLineNumber.HeaderText = "行番号";
            this.ColLineNumber.Name = "ColLineNumber";
            this.ColLineNumber.Width = 70;
            // 
            // ColType
            // 
            this.ColType.HeaderText = "詳細";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            this.ColType.Width = 250;
            // 
            // ColGrid
            // 
            this.ColGrid.HeaderText = "Grid";
            this.ColGrid.Name = "ColGrid";
            this.ColGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColGrid.Width = 45;
            // 
            // ColDbName2
            // 
            this.ColDbName2.HeaderText = "DB名";
            this.ColDbName2.Name = "ColDbName2";
            // 
            // ColDBColumnName2
            // 
            this.ColDBColumnName2.HeaderText = "カラム名";
            this.ColDBColumnName2.Name = "ColDBColumnName2";
            // 
            // ColDBType2
            // 
            this.ColDBType2.HeaderText = "型";
            this.ColDBType2.Name = "ColDBType2";
            this.ColDBType2.ReadOnly = true;
            this.ColDBType2.Width = 50;
            // 
            // ColDBSize2
            // 
            this.ColDBSize2.HeaderText = "サイズ";
            this.ColDBSize2.Name = "ColDBSize2";
            this.ColDBSize2.ReadOnly = true;
            this.ColDBSize2.Width = 70;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 351);
            this.Controls.Add(this.exDataGridViewControl12222);
            this.Controls.Add(this.exButton3);
            this.Controls.Add(this.exButton2);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.exDataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridViewControl12222)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl exDataGridView1;
        private OyuLib.Windows.Forms.ExButton exButton1;
        private OyuLib.Windows.Forms.ExButton exButton2;
        private OyuLib.Windows.Forms.ExButton exButton3;
        private OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl exDataGridViewControl12222;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewButtonColumn ColGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDbName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDBColumnName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDBType2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDBSize2;
    }
}