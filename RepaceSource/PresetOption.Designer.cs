namespace RepaceSource
{
    partial class PresetOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.exComboBox1 = new OyuLib.Windows.Forms.ExComboBox();
            this.exBtnSpecialReplace = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exBtnReturn = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exBtnExecute = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exAddRow = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exDgvReplaceText = new OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl(this.components);
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTargetText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReplaceText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsRegex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exDgvReplaceText)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Preset";
            // 
            // exComboBox1
            // 
            this.exComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exComboBox1.FormattingEnabled = true;
            this.exComboBox1.Location = new System.Drawing.Point(53, 6);
            this.exComboBox1.Name = "exComboBox1";
            this.exComboBox1.Size = new System.Drawing.Size(191, 20);
            this.exComboBox1.TabIndex = 4;
            this.exComboBox1.SelectedIndexChanged += new System.EventHandler(this.exComboBox1_SelectedIndexChanged);
            // 
            // exBtnSpecialReplace
            // 
            this.exBtnSpecialReplace.Location = new System.Drawing.Point(12, 387);
            this.exBtnSpecialReplace.Name = "exBtnSpecialReplace";
            this.exBtnSpecialReplace.Size = new System.Drawing.Size(126, 23);
            this.exBtnSpecialReplace.TabIndex = 7;
            this.exBtnSpecialReplace.Text = "別途特殊置換指定";
            this.exBtnSpecialReplace.UseVisualStyleBackColor = true;
            this.exBtnSpecialReplace.Click += new System.EventHandler(this.exBtnSpecialReplace_Click);
            // 
            // exBtnReturn
            // 
            this.exBtnReturn.Location = new System.Drawing.Point(686, 387);
            this.exBtnReturn.Name = "exBtnReturn";
            this.exBtnReturn.Size = new System.Drawing.Size(126, 23);
            this.exBtnReturn.TabIndex = 8;
            this.exBtnReturn.Text = "戻る";
            this.exBtnReturn.UseVisualStyleBackColor = true;
            this.exBtnReturn.Click += new System.EventHandler(this.exBtnReturn_Click);
            // 
            // exBtnExecute
            // 
            this.exBtnExecute.Location = new System.Drawing.Point(839, 387);
            this.exBtnExecute.Name = "exBtnExecute";
            this.exBtnExecute.Size = new System.Drawing.Size(126, 23);
            this.exBtnExecute.TabIndex = 9;
            this.exBtnExecute.Text = "保存";
            this.exBtnExecute.UseVisualStyleBackColor = true;
            this.exBtnExecute.Click += new System.EventHandler(this.exBtnExecute_Click);
            // 
            // exAddRow
            // 
            this.exAddRow.Location = new System.Drawing.Point(839, 9);
            this.exAddRow.Name = "exAddRow";
            this.exAddRow.Size = new System.Drawing.Size(126, 23);
            this.exAddRow.TabIndex = 10;
            this.exAddRow.Text = "行追加(10行)";
            this.exAddRow.UseVisualStyleBackColor = true;
            this.exAddRow.Click += new System.EventHandler(this.exAddRow_Click);
            // 
            // exDgvReplaceText
            // 
            this.exDgvReplaceText.AllowUserToAddRows = false;
            this.exDgvReplaceText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDgvReplaceText.ColumnNamesortAsNumber = new string[0];
            this.exDgvReplaceText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNo,
            this.ColTargetText,
            this.ColReplaceText,
            this.ColCount,
            this.ColIsRegex});
            this.exDgvReplaceText.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDgvReplaceText.IsSkipFocusReadOnlyCell = false;
            this.exDgvReplaceText.Location = new System.Drawing.Point(12, 32);
            this.exDgvReplaceText.Name = "exDgvReplaceText";
            this.exDgvReplaceText.RowTemplate.Height = 21;
            this.exDgvReplaceText.Size = new System.Drawing.Size(953, 344);
            this.exDgvReplaceText.TabIndex = 6;
            this.exDgvReplaceText.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.exDgvReplaceText_RowsAdded);
            // 
            // ColNo
            // 
            this.ColNo.HeaderText = "No.";
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            this.ColNo.Width = 35;
            // 
            // ColTargetText
            // 
            this.ColTargetText.HeaderText = "置換対象文字列";
            this.ColTargetText.Name = "ColTargetText";
            this.ColTargetText.Width = 350;
            // 
            // ColReplaceText
            // 
            this.ColReplaceText.HeaderText = "置換文字列";
            this.ColReplaceText.Name = "ColReplaceText";
            this.ColReplaceText.Width = 350;
            // 
            // ColCount
            // 
            this.ColCount.HeaderText = "置換数";
            this.ColCount.Name = "ColCount";
            this.ColCount.ReadOnly = true;
            this.ColCount.Width = 70;
            // 
            // ColIsRegex
            // 
            this.ColIsRegex.HeaderText = "正規表現";
            this.ColIsRegex.Name = "ColIsRegex";
            this.ColIsRegex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsRegex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColIsRegex.Width = 80;
            // 
            // PresetOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 422);
            this.Controls.Add(this.exAddRow);
            this.Controls.Add(this.exBtnExecute);
            this.Controls.Add(this.exBtnReturn);
            this.Controls.Add(this.exBtnSpecialReplace);
            this.Controls.Add(this.exDgvReplaceText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exComboBox1);
            this.Name = "PresetOption";
            this.Text = "PresetOption";
            this.Load += new System.EventHandler(this.PresetOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exDgvReplaceText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private OyuLib.Windows.Forms.ExComboBox exComboBox1;
        private OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl exDgvReplaceText;
        private OyuLib.Windows.Forms.ExButton exBtnSpecialReplace;
        private OyuLib.Windows.Forms.ExButton exBtnReturn;
        private OyuLib.Windows.Forms.ExButton exBtnExecute;
        private OyuLib.Windows.Forms.ExButton exAddRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTargetText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReplaceText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsRegex;
    }
}