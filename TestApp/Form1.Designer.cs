﻿namespace TestApp
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
            this.exListBox1 = new OyuLib.Windows.Forms.ExListBox(this.components);
            this.exButton1 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton2 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton3 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.exButton4 = new OyuLib.Windows.Forms.ExButton(this.components);
            this.SuspendLayout();
            // 
            // exListBox1
            // 
            this.exListBox1.FormattingEnabled = true;
            this.exListBox1.ItemHeight = 12;
            this.exListBox1.Location = new System.Drawing.Point(12, 153);
            this.exListBox1.Name = "exListBox1";
            this.exListBox1.ScrollAlwaysVisible = true;
            this.exListBox1.Size = new System.Drawing.Size(1487, 280);
            this.exListBox1.TabIndex = 1;
            // 
            // exButton1
            // 
            this.exButton1.Location = new System.Drawing.Point(12, 12);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(1487, 27);
            this.exButton1.TabIndex = 0;
            this.exButton1.Text = "exButton1";
            this.exButton1.UseVisualStyleBackColor = true;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // exButton2
            // 
            this.exButton2.Location = new System.Drawing.Point(12, 48);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(1487, 27);
            this.exButton2.TabIndex = 2;
            this.exButton2.Text = "exButton2";
            this.exButton2.UseVisualStyleBackColor = true;
            this.exButton2.Click += new System.EventHandler(this.exButton2_Click);
            // 
            // exButton3
            // 
            this.exButton3.Location = new System.Drawing.Point(12, 81);
            this.exButton3.Name = "exButton3";
            this.exButton3.Size = new System.Drawing.Size(1487, 27);
            this.exButton3.TabIndex = 3;
            this.exButton3.Text = "exButton3";
            this.exButton3.UseVisualStyleBackColor = true;
            this.exButton3.Click += new System.EventHandler(this.exButton3_Click);
            // 
            // exButton4
            // 
            this.exButton4.Location = new System.Drawing.Point(12, 120);
            this.exButton4.Name = "exButton4";
            this.exButton4.Size = new System.Drawing.Size(1487, 27);
            this.exButton4.TabIndex = 4;
            this.exButton4.Text = "exButton4";
            this.exButton4.UseVisualStyleBackColor = true;
            this.exButton4.Click += new System.EventHandler(this.exButton4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 454);
            this.Controls.Add(this.exButton4);
            this.Controls.Add(this.exButton3);
            this.Controls.Add(this.exButton2);
            this.Controls.Add(this.exListBox1);
            this.Controls.Add(this.exButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OyuLib.Windows.Forms.ExButton exButton1;
        private OyuLib.Windows.Forms.ExListBox exListBox1;
        private OyuLib.Windows.Forms.ExButton exButton2;
        private OyuLib.Windows.Forms.ExButton exButton3;
        private OyuLib.Windows.Forms.ExButton exButton4;
    }
}

