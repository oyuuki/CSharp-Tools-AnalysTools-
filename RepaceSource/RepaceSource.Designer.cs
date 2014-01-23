﻿namespace RepaceSource
{
    partial class RepaceSource
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.exComboBox1 = new OyuLib.Windows.Forms.ExComboBox();
            this.extxtProFolder = new OyuLib.Windows.Forms.ExTextBox(this.components);
            this.exProFolderDialogButton = new OyuLib.Windows.Forms.ExFolderDialogButton(this.components);
            this.exDgvLog = new OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl(this.components);
            this.exBtnExecute = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton1 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exBtnSaveLog = new OyuLib.Windows.Forms.ExButton(this.components);
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOldText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReplaceString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exDgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Preset";
            // 
            // exComboBox1
            // 
            this.exComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exComboBox1.FormattingEnabled = true;
            this.exComboBox1.Location = new System.Drawing.Point(823, 10);
            this.exComboBox1.Name = "exComboBox1";
            this.exComboBox1.Size = new System.Drawing.Size(191, 20);
            this.exComboBox1.TabIndex = 2;
            this.exComboBox1.SelectedIndexChanged += new System.EventHandler(this.exComboBox1_SelectedIndexChanged);
            // 
            // extxtProFolder
            // 
            this.extxtProFolder.Location = new System.Drawing.Point(12, 12);
            this.extxtProFolder.Name = "extxtProFolder";
            this.extxtProFolder.Size = new System.Drawing.Size(276, 19);
            this.extxtProFolder.TabIndex = 1;
            this.extxtProFolder.TextChanged += new System.EventHandler(this.extxtProFolder_TextChanged);
            // 
            // exProFolderDialogButton
            // 
            this.exProFolderDialogButton.Inter_test = this.extxtProFolder;
            this.exProFolderDialogButton.Location = new System.Drawing.Point(294, 10);
            this.exProFolderDialogButton.Name = "exProFolderDialogButton";
            this.exProFolderDialogButton.Size = new System.Drawing.Size(75, 23);
            this.exProFolderDialogButton.TabIndex = 0;
            this.exProFolderDialogButton.Text = "選択";
            this.exProFolderDialogButton.UseVisualStyleBackColor = true;
            // 
            // exDgvLog
            // 
            this.exDgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDgvLog.ColumnNamesortAsNumber = new string[0];
            this.exDgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNo,
            this.ColFileName,
            this.ColLineNumber,
            this.ColOldText,
            this.ColNewText,
            this.ColReplaceString});
            this.exDgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDgvLog.IsSkipFocusReadOnlyCell = false;
            this.exDgvLog.Location = new System.Drawing.Point(12, 37);
            this.exDgvLog.Name = "exDgvLog";
            this.exDgvLog.RowTemplate.Height = 21;
            this.exDgvLog.Size = new System.Drawing.Size(1141, 344);
            this.exDgvLog.TabIndex = 4;
            this.exDgvLog.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.exDgvLog_RowsAdded);
            // 
            // exBtnExecute
            // 
            this.exBtnExecute.Location = new System.Drawing.Point(1027, 387);
            this.exBtnExecute.Name = "exBtnExecute";
            this.exBtnExecute.Size = new System.Drawing.Size(126, 23);
            this.exBtnExecute.TabIndex = 5;
            this.exBtnExecute.Text = "実行";
            this.exBtnExecute.UseVisualStyleBackColor = true;
            this.exBtnExecute.Click += new System.EventHandler(this.exBtnExecute_Click);
            // 
            // exButton1
            // 
            this.exButton1.Location = new System.Drawing.Point(1027, 8);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(126, 23);
            this.exButton1.TabIndex = 7;
            this.exButton1.Text = "プリセット設定";
            this.exButton1.UseVisualStyleBackColor = true;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // exBtnSaveLog
            // 
            this.exBtnSaveLog.Location = new System.Drawing.Point(872, 387);
            this.exBtnSaveLog.Name = "exBtnSaveLog";
            this.exBtnSaveLog.Size = new System.Drawing.Size(126, 23);
            this.exBtnSaveLog.TabIndex = 8;
            this.exBtnSaveLog.Text = "ログ保存";
            this.exBtnSaveLog.UseVisualStyleBackColor = true;
            this.exBtnSaveLog.Click += new System.EventHandler(this.exBtnSaveLog_Click);
            // 
            // ColNo
            // 
            this.ColNo.HeaderText = "No.";
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            this.ColNo.Width = 35;
            // 
            // ColFileName
            // 
            this.ColFileName.HeaderText = "File";
            this.ColFileName.Name = "ColFileName";
            this.ColFileName.ReadOnly = true;
            // 
            // ColLineNumber
            // 
            this.ColLineNumber.HeaderText = "行";
            this.ColLineNumber.Name = "ColLineNumber";
            this.ColLineNumber.ReadOnly = true;
            this.ColLineNumber.Width = 35;
            // 
            // ColOldText
            // 
            this.ColOldText.HeaderText = "変更前";
            this.ColOldText.Name = "ColOldText";
            this.ColOldText.ReadOnly = true;
            this.ColOldText.Width = 350;
            // 
            // ColNewText
            // 
            this.ColNewText.HeaderText = "変更後";
            this.ColNewText.Name = "ColNewText";
            this.ColNewText.ReadOnly = true;
            this.ColNewText.Width = 350;
            // 
            // ColReplaceString
            // 
            this.ColReplaceString.HeaderText = "変更元文字列";
            this.ColReplaceString.Name = "ColReplaceString";
            this.ColReplaceString.ReadOnly = true;
            this.ColReplaceString.Width = 300;
            // 
            // RepaceSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 412);
            this.Controls.Add(this.exBtnSaveLog);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.exBtnExecute);
            this.Controls.Add(this.exDgvLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exComboBox1);
            this.Controls.Add(this.extxtProFolder);
            this.Controls.Add(this.exProFolderDialogButton);
            this.Name = "RepaceSource";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.exDgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OyuLib.Windows.Forms.ExFolderDialogButton exProFolderDialogButton;
        private OyuLib.Windows.Forms.ExTextBox extxtProFolder;
        private OyuLib.Windows.Forms.ExComboBox exComboBox1;
        private System.Windows.Forms.Label label1;
        private OyuLib.Windows.Forms.DataGridView.ExDataGridViewControl exDgvLog;
        private OyuLib.Windows.Forms.ExButton exBtnExecute;
        private OyuLib.Windows.Forms.ExButton exButton1;
        private OyuLib.Windows.Forms.ExButton exBtnSaveLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOldText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNewText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReplaceString;
    }
}

