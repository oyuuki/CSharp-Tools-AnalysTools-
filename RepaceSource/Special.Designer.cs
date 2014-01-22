namespace RepaceSource
{
    partial class Special
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
            this.exDgvSpe = new OyuLib.OyuWindows.Interface.ExDataGridView.ExDataGridViewControl(this.components);
            this.lblPreset = new System.Windows.Forms.Label();
            this.exBtnExecute = new OyuLib.OyuWindows.Interface.ExButton.ExButton(this.components);
            this.exBtnReturn = new OyuLib.OyuWindows.Interface.ExButton.ExButton(this.components);
            this.exAddRow = new OyuLib.OyuWindows.Interface.ExButton.ExButton(this.components);
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExecuteChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColNewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExperience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exDgvSpe)).BeginInit();
            this.SuspendLayout();
            // 
            // exDgvSpe
            // 
            this.exDgvSpe.AllowUserToAddRows = false;
            this.exDgvSpe.AllowUserToDeleteRows = false;
            this.exDgvSpe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDgvSpe.ColumnNamesortAsNumber = new string[0];
            this.exDgvSpe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNo,
            this.ColExecuteChk,
            this.ColNewText,
            this.ColExperience});
            this.exDgvSpe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDgvSpe.IsSkipFocusReadOnlyCell = false;
            this.exDgvSpe.Location = new System.Drawing.Point(3, 36);
            this.exDgvSpe.Name = "exDgvSpe";
            this.exDgvSpe.RowTemplate.Height = 21;
            this.exDgvSpe.Size = new System.Drawing.Size(695, 233);
            this.exDgvSpe.TabIndex = 5;
            this.exDgvSpe.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.exDgvSpe_RowsAdded);
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreset.Location = new System.Drawing.Point(3, 9);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(40, 14);
            this.lblPreset.TabIndex = 6;
            this.lblPreset.Text = "Preset";
            // 
            // exBtnExecute
            // 
            this.exBtnExecute.Location = new System.Drawing.Point(572, 275);
            this.exBtnExecute.Name = "exBtnExecute";
            this.exBtnExecute.Size = new System.Drawing.Size(126, 23);
            this.exBtnExecute.TabIndex = 11;
            this.exBtnExecute.Text = "保存";
            this.exBtnExecute.UseVisualStyleBackColor = true;
            this.exBtnExecute.Click += new System.EventHandler(this.exBtnExecute_Click);
            // 
            // exBtnReturn
            // 
            this.exBtnReturn.Location = new System.Drawing.Point(440, 275);
            this.exBtnReturn.Name = "exBtnReturn";
            this.exBtnReturn.Size = new System.Drawing.Size(126, 23);
            this.exBtnReturn.TabIndex = 10;
            this.exBtnReturn.Text = "戻る";
            this.exBtnReturn.UseVisualStyleBackColor = true;
            this.exBtnReturn.Click += new System.EventHandler(this.exBtnReturn_Click);
            // 
            // exAddRow
            // 
            this.exAddRow.Location = new System.Drawing.Point(572, 7);
            this.exAddRow.Name = "exAddRow";
            this.exAddRow.Size = new System.Drawing.Size(126, 23);
            this.exAddRow.TabIndex = 12;
            this.exAddRow.Text = "行追加(10行)";
            this.exAddRow.UseVisualStyleBackColor = true;
            this.exAddRow.Click += new System.EventHandler(this.exAddRow_Click);
            // 
            // ColNo
            // 
            this.ColNo.HeaderText = "No.";
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            this.ColNo.Width = 35;
            // 
            // ColExecuteChk
            // 
            this.ColExecuteChk.HeaderText = "実施";
            this.ColExecuteChk.Name = "ColExecuteChk";
            this.ColExecuteChk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColExecuteChk.Width = 40;
            // 
            // ColNewText
            // 
            this.ColNewText.HeaderText = "置換処理名";
            this.ColNewText.Name = "ColNewText";
            this.ColNewText.ReadOnly = true;
            this.ColNewText.Width = 200;
            // 
            // ColExperience
            // 
            this.ColExperience.HeaderText = "詳細";
            this.ColExperience.Name = "ColExperience";
            this.ColExperience.ReadOnly = true;
            this.ColExperience.Width = 350;
            // 
            // Special
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 305);
            this.Controls.Add(this.exAddRow);
            this.Controls.Add(this.exBtnExecute);
            this.Controls.Add(this.exBtnReturn);
            this.Controls.Add(this.lblPreset);
            this.Controls.Add(this.exDgvSpe);
            this.Name = "Special";
            this.Text = "Special";
            this.Load += new System.EventHandler(this.Special_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exDgvSpe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OyuLib.OyuWindows.Interface.ExDataGridView.ExDataGridViewControl exDgvSpe;
        private System.Windows.Forms.Label lblPreset;
        private OyuLib.OyuWindows.Interface.ExButton.ExButton exBtnExecute;
        private OyuLib.OyuWindows.Interface.ExButton.ExButton exBtnReturn;
        private OyuLib.OyuWindows.Interface.ExButton.ExButton exAddRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColExecuteChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExperience;
    }
}