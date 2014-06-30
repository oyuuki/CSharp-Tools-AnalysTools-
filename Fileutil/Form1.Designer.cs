namespace FileUtil
{
    partial class Form1
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
            this.txtFolder = new OyuLib.Windows.Forms.ExTextBox(this.components);
            this.exFolderDialogButton1 = new OyuLib.Windows.Forms.ExFolderDialogButton(this.components);
            this.txtFileNames = new OyuLib.Windows.Forms.ExTextBox(this.components);
            this.exListBox1 = new OyuLib.Windows.Forms.ExListBox(this.components);
            this.exButton1 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton2 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.txtBefExtension = new OyuLib.Windows.Forms.ExTextBox(this.components);
            this.txtAftExtention = new OyuLib.Windows.Forms.ExTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(12, 14);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(100, 19);
            this.txtFolder.TabIndex = 0;
            // 
            // exFolderDialogButton1
            // 
            this.exFolderDialogButton1.Inter_test = this.txtFolder;
            this.exFolderDialogButton1.Location = new System.Drawing.Point(118, 12);
            this.exFolderDialogButton1.Name = "exFolderDialogButton1";
            this.exFolderDialogButton1.Size = new System.Drawing.Size(75, 23);
            this.exFolderDialogButton1.TabIndex = 2;
            this.exFolderDialogButton1.Text = "フォルダ選択";
            this.exFolderDialogButton1.UseVisualStyleBackColor = true;
            // 
            // txtFileNames
            // 
            this.txtFileNames.Location = new System.Drawing.Point(12, 39);
            this.txtFileNames.Name = "txtFileNames";
            this.txtFileNames.Size = new System.Drawing.Size(181, 19);
            this.txtFileNames.TabIndex = 3;
            // 
            // exListBox1
            // 
            this.exListBox1.FormattingEnabled = true;
            this.exListBox1.ItemHeight = 12;
            this.exListBox1.Location = new System.Drawing.Point(12, 98);
            this.exListBox1.Name = "exListBox1";
            this.exListBox1.Size = new System.Drawing.Size(260, 148);
            this.exListBox1.TabIndex = 4;
            // 
            // exButton1
            // 
            this.exButton1.Location = new System.Drawing.Point(199, 37);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(75, 23);
            this.exButton1.TabIndex = 5;
            this.exButton1.Text = "検索";
            this.exButton1.UseVisualStyleBackColor = true;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // exButton2
            // 
            this.exButton2.Location = new System.Drawing.Point(199, 66);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(75, 23);
            this.exButton2.TabIndex = 6;
            this.exButton2.Text = "拡張子リネーム";
            this.exButton2.UseVisualStyleBackColor = true;
            this.exButton2.Click += new System.EventHandler(this.exButton2_Click);
            // 
            // txtBefExtension
            // 
            this.txtBefExtension.Location = new System.Drawing.Point(36, 66);
            this.txtBefExtension.Name = "txtBefExtension";
            this.txtBefExtension.Size = new System.Drawing.Size(62, 19);
            this.txtBefExtension.TabIndex = 7;
            // 
            // txtAftExtention
            // 
            this.txtAftExtention.Location = new System.Drawing.Point(127, 66);
            this.txtAftExtention.Name = "txtAftExtention";
            this.txtAftExtention.Size = new System.Drawing.Size(62, 19);
            this.txtAftExtention.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "後";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAftExtention);
            this.Controls.Add(this.txtBefExtension);
            this.Controls.Add(this.exButton2);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.exListBox1);
            this.Controls.Add(this.txtFileNames);
            this.Controls.Add(this.exFolderDialogButton1);
            this.Controls.Add(this.txtFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OyuLib.Windows.Forms.ExTextBox txtFolder;
        private OyuLib.Windows.Forms.ExFolderDialogButton exFolderDialogButton1;
        private OyuLib.Windows.Forms.ExTextBox txtFileNames;
        private OyuLib.Windows.Forms.ExListBox exListBox1;
        private OyuLib.Windows.Forms.ExButton exButton1;
        private OyuLib.Windows.Forms.ExButton exButton2;
        private OyuLib.Windows.Forms.ExTextBox txtBefExtension;
        private OyuLib.Windows.Forms.ExTextBox txtAftExtention;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

