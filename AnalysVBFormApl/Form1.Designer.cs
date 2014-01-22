namespace AnalysVBFormApl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkColorMemo = new System.Windows.Forms.CheckBox();
            this.exLabel1 = new OyuLib.OyuWindows.Compornent.ExButton.ExLabel(this.components);
            this.exTxtDBCRUD = new OyuLib.OyuWindows.Compornent.ExTextBox(this.components);
            this.exBtnCopyMemo = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exBtnReload = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exBtnWrite = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exTxtMemo = new OyuLib.OyuWindows.Compornent.ExTextBox(this.components);
            this.exTxtSearchText = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exTxtSearch = new OyuLib.OyuWindows.Compornent.ExTextBox(this.components);
            this.exButton3 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exButton2 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exButton1 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exTextSource = new OyuLib.OyuWindows.Compornent.ExTextBox(this.components);
            this.lblFileName = new OyuLib.OyuWindows.Compornent.ExButton.ExLabel(this.components);
            this.exVBFileDialogButton1 = new OyuLib.OyuWindows.Compornent.ExButton.ExVBFileDialogButton(this.components);
            this.exTxtSourcepath = new OyuLib.OyuWindows.Compornent.ExTextBox(this.components);
            this.exDataGridView1 = new OyuLib.OyuWindows.Compornent.ExDataGridView.ExDataGridViewControl(this.components);
            this.exBtnCopyOrino = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exButton4 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exButton5 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.exButton6 = new OyuLib.OyuWindows.Compornent.ExButton.ExButton(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColOriginalSortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTabIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDoGrid = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReadOnly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImeMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSigu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 10);
            this.label1.TabIndex = 4;
            this.label1.Text = "ソースフルパス";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.checkBox1.Location = new System.Drawing.Point(418, 251);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 14);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "常に手前に表示する";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkColorMemo
            // 
            this.chkColorMemo.AutoSize = true;
            this.chkColorMemo.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.chkColorMemo.Location = new System.Drawing.Point(258, 94);
            this.chkColorMemo.Name = "chkColorMemo";
            this.chkColorMemo.Size = new System.Drawing.Size(123, 14);
            this.chkColorMemo.TabIndex = 20;
            this.chkColorMemo.Text = "メモのある行に色をつける";
            this.chkColorMemo.UseVisualStyleBackColor = true;
            this.chkColorMemo.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // exLabel1
            // 
            this.exLabel1.AutoSize = true;
            this.exLabel1.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exLabel1.Location = new System.Drawing.Point(11, 320);
            this.exLabel1.Name = "exLabel1";
            this.exLabel1.Size = new System.Drawing.Size(121, 10);
            this.exLabel1.TabIndex = 22;
            this.exLabel1.Text = "使用DB   例)MstXXXX CRD";
            // 
            // exTxtDBCRUD
            // 
            this.exTxtDBCRUD.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.exTxtDBCRUD.Location = new System.Drawing.Point(12, 334);
            this.exTxtDBCRUD.Multiline = true;
            this.exTxtDBCRUD.Name = "exTxtDBCRUD";
            this.exTxtDBCRUD.ReadOnly = true;
            this.exTxtDBCRUD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.exTxtDBCRUD.Size = new System.Drawing.Size(159, 34);
            this.exTxtDBCRUD.TabIndex = 21;
            this.exTxtDBCRUD.TextChanged += new System.EventHandler(this.exTxtMemo_TextChanged);
            // 
            // exBtnCopyMemo
            // 
            this.exBtnCopyMemo.Enabled = false;
            this.exBtnCopyMemo.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exBtnCopyMemo.Location = new System.Drawing.Point(177, 337);
            this.exBtnCopyMemo.Name = "exBtnCopyMemo";
            this.exBtnCopyMemo.Size = new System.Drawing.Size(69, 31);
            this.exBtnCopyMemo.TabIndex = 19;
            this.exBtnCopyMemo.Text = "コピー(メモのみ)";
            this.exBtnCopyMemo.UseVisualStyleBackColor = true;
            this.exBtnCopyMemo.Click += new System.EventHandler(this.exBtnCopyMemo_Click);
            // 
            // exBtnReload
            // 
            this.exBtnReload.Enabled = false;
            this.exBtnReload.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exBtnReload.Location = new System.Drawing.Point(175, 316);
            this.exBtnReload.Name = "exBtnReload";
            this.exBtnReload.Size = new System.Drawing.Size(71, 22);
            this.exBtnReload.TabIndex = 18;
            this.exBtnReload.Text = "リロード";
            this.exBtnReload.UseVisualStyleBackColor = true;
            this.exBtnReload.Click += new System.EventHandler(this.exBtnReload_Click);
            // 
            // exBtnWrite
            // 
            this.exBtnWrite.Enabled = false;
            this.exBtnWrite.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exBtnWrite.Location = new System.Drawing.Point(177, 253);
            this.exBtnWrite.Name = "exBtnWrite";
            this.exBtnWrite.Size = new System.Drawing.Size(69, 29);
            this.exBtnWrite.TabIndex = 17;
            this.exBtnWrite.Text = "メモ書き込み";
            this.exBtnWrite.UseVisualStyleBackColor = true;
            this.exBtnWrite.Click += new System.EventHandler(this.exBtnWrite_Click);
            // 
            // exTxtMemo
            // 
            this.exTxtMemo.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.exTxtMemo.Location = new System.Drawing.Point(12, 254);
            this.exTxtMemo.Multiline = true;
            this.exTxtMemo.Name = "exTxtMemo";
            this.exTxtMemo.ReadOnly = true;
            this.exTxtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.exTxtMemo.Size = new System.Drawing.Size(159, 63);
            this.exTxtMemo.TabIndex = 16;
            this.exTxtMemo.TextChanged += new System.EventHandler(this.exTxtMemo_TextChanged);
            // 
            // exTxtSearchText
            // 
            this.exTxtSearchText.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exTxtSearchText.Location = new System.Drawing.Point(504, 3);
            this.exTxtSearchText.Name = "exTxtSearchText";
            this.exTxtSearchText.Size = new System.Drawing.Size(72, 19);
            this.exTxtSearchText.TabIndex = 14;
            this.exTxtSearchText.Text = "テキスト検索";
            this.exTxtSearchText.UseVisualStyleBackColor = true;
            this.exTxtSearchText.Click += new System.EventHandler(this.exTxtSearchText_Click);
            // 
            // exTxtSearch
            // 
            this.exTxtSearch.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.exTxtSearch.Location = new System.Drawing.Point(379, 4);
            this.exTxtSearch.Name = "exTxtSearch";
            this.exTxtSearch.Size = new System.Drawing.Size(121, 19);
            this.exTxtSearch.TabIndex = 12;
            // 
            // exButton3
            // 
            this.exButton3.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton3.Location = new System.Drawing.Point(330, 2);
            this.exButton3.Name = "exButton3";
            this.exButton3.Size = new System.Drawing.Size(46, 21);
            this.exButton3.TabIndex = 11;
            this.exButton3.Text = "再読込";
            this.exButton3.UseVisualStyleBackColor = true;
            this.exButton3.Click += new System.EventHandler(this.exButton3_Click);
            // 
            // exButton2
            // 
            this.exButton2.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton2.Location = new System.Drawing.Point(507, 268);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(69, 38);
            this.exButton2.TabIndex = 10;
            this.exButton2.Text = "設計書用に変換 and Copy";
            this.exButton2.UseVisualStyleBackColor = true;
            this.exButton2.Click += new System.EventHandler(this.exButton2_Click);
            // 
            // exButton1
            // 
            this.exButton1.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton1.Location = new System.Drawing.Point(418, 267);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(87, 50);
            this.exButton1.TabIndex = 9;
            this.exButton1.Text = "タイトルラベル並び替え(項目名が一部変更されます)";
            this.exButton1.UseVisualStyleBackColor = true;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // exTextSource
            // 
            this.exTextSource.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.exTextSource.Location = new System.Drawing.Point(249, 254);
            this.exTextSource.Multiline = true;
            this.exTextSource.Name = "exTextSource";
            this.exTextSource.ReadOnly = true;
            this.exTextSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.exTextSource.Size = new System.Drawing.Size(163, 84);
            this.exTextSource.TabIndex = 8;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.lblFileName.Location = new System.Drawing.Point(278, 7);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(42, 10);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "exLabel1";
            // 
            // exVBFileDialogButton1
            // 
            this.exVBFileDialogButton1.Inter_test = this.exTxtSourcepath;
            this.exVBFileDialogButton1.IsMultiple = false;
            this.exVBFileDialogButton1.Location = new System.Drawing.Point(224, 0);
            this.exVBFileDialogButton1.Name = "exVBFileDialogButton1";
            this.exVBFileDialogButton1.Size = new System.Drawing.Size(51, 23);
            this.exVBFileDialogButton1.TabIndex = 6;
            this.exVBFileDialogButton1.Text = "ファイル...";
            this.exVBFileDialogButton1.UseVisualStyleBackColor = true;
            // 
            // exTxtSourcepath
            // 
            this.exTxtSourcepath.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.exTxtSourcepath.Location = new System.Drawing.Point(62, 3);
            this.exTxtSourcepath.Name = "exTxtSourcepath";
            this.exTxtSourcepath.Size = new System.Drawing.Size(162, 19);
            this.exTxtSourcepath.TabIndex = 1;
            this.exTxtSourcepath.TextChanged += new System.EventHandler(this.exTxtSourcepath_TextChanged);
            // 
            // exDataGridView1
            // 
            this.exDataGridView1.AllowUserToAddRows = false;
            this.exDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView1.ColumnNamesortAsNumber = new string[0];
            this.exDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColOriginalSortNo,
            this.Colnumber,
            this.ColTabIndex,
            this.ColName,
            this.ColType,
            this.ColSize,
            this.ColFormat,
            this.ColDoGrid,
            this.ColSource,
            this.ColId,
            this.ColReadOnly,
            this.ColImeMode,
            this.ColSigu,
            this.ColMemo});
            this.exDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.exDataGridView1.IsSkipFocusReadOnlyCell = true;
            this.exDataGridView1.Location = new System.Drawing.Point(12, 24);
            this.exDataGridView1.Name = "exDataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.exDataGridView1.RowHeadersVisible = false;
            this.exDataGridView1.RowTemplate.Height = 21;
            this.exDataGridView1.Size = new System.Drawing.Size(560, 225);
            this.exDataGridView1.TabIndex = 2;
            this.exDataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.exDataGridView1_EditingControlShowing);
            this.exDataGridView1.SelectionChanged += new System.EventHandler(this.exDataGridView1_SelectionChanged);
            // 
            // exBtnCopyOrino
            // 
            this.exBtnCopyOrino.Enabled = false;
            this.exBtnCopyOrino.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exBtnCopyOrino.Location = new System.Drawing.Point(177, 283);
            this.exBtnCopyOrino.Name = "exBtnCopyOrino";
            this.exBtnCopyOrino.Size = new System.Drawing.Size(69, 33);
            this.exBtnCopyOrino.TabIndex = 23;
            this.exBtnCopyOrino.Text = "オリジナルNo書き込み";
            this.exBtnCopyOrino.UseVisualStyleBackColor = true;
            this.exBtnCopyOrino.Click += new System.EventHandler(this.exBtnCopyOrino_Click);
            // 
            // exButton4
            // 
            this.exButton4.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton4.Location = new System.Drawing.Point(418, 318);
            this.exButton4.Name = "exButton4";
            this.exButton4.Size = new System.Drawing.Size(87, 26);
            this.exButton4.TabIndex = 24;
            this.exButton4.Text = "CRUD出力";
            this.exButton4.UseVisualStyleBackColor = true;
            this.exButton4.Click += new System.EventHandler(this.exButton4_Click);
            // 
            // exButton5
            // 
            this.exButton5.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton5.Location = new System.Drawing.Point(507, 312);
            this.exButton5.Name = "exButton5";
            this.exButton5.Size = new System.Drawing.Size(69, 29);
            this.exButton5.TabIndex = 25;
            this.exButton5.Text = "CRUD出力(ファイル選択)";
            this.exButton5.UseVisualStyleBackColor = true;
            this.exButton5.Click += new System.EventHandler(this.exButton5_Click);
            // 
            // exButton6
            // 
            this.exButton6.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.exButton6.Location = new System.Drawing.Point(507, 340);
            this.exButton6.Name = "exButton6";
            this.exButton6.Size = new System.Drawing.Size(69, 36);
            this.exButton6.TabIndex = 26;
            this.exButton6.Text = "メモ出力(ファイル選択)";
            this.exButton6.UseVisualStyleBackColor = true;
            this.exButton6.Click += new System.EventHandler(this.exButton6_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkColorMemo);
            this.panel1.Location = new System.Drawing.Point(9, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 124);
            this.panel1.TabIndex = 27;
            // 
            // ColOriginalSortNo
            // 
            this.ColOriginalSortNo.HeaderText = "オリジナルNo";
            this.ColOriginalSortNo.Name = "ColOriginalSortNo";
            this.ColOriginalSortNo.Width = 70;
            // 
            // Colnumber
            // 
            this.Colnumber.HeaderText = "No";
            this.Colnumber.Name = "Colnumber";
            this.Colnumber.ReadOnly = true;
            this.Colnumber.Width = 30;
            // 
            // ColTabIndex
            // 
            this.ColTabIndex.HeaderText = "TabIndex";
            this.ColTabIndex.Name = "ColTabIndex";
            this.ColTabIndex.ReadOnly = true;
            this.ColTabIndex.Width = 60;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "項目名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 115;
            // 
            // ColType
            // 
            this.ColType.HeaderText = "型";
            this.ColType.Name = "ColType";
            this.ColType.ReadOnly = true;
            // 
            // ColSize
            // 
            this.ColSize.HeaderText = "サイズ";
            this.ColSize.Name = "ColSize";
            this.ColSize.ReadOnly = true;
            this.ColSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSize.Width = 30;
            // 
            // ColFormat
            // 
            this.ColFormat.HeaderText = "書式";
            this.ColFormat.Name = "ColFormat";
            this.ColFormat.ReadOnly = true;
            // 
            // ColDoGrid
            // 
            this.ColDoGrid.HeaderText = "Grid";
            this.ColDoGrid.Name = "ColDoGrid";
            this.ColDoGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDoGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDoGrid.Text = "Do Grid";
            this.ColDoGrid.Width = 30;
            // 
            // ColSource
            // 
            this.ColSource.HeaderText = "ソース";
            this.ColSource.Name = "ColSource";
            this.ColSource.ReadOnly = true;
            this.ColSource.Visible = false;
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColReadOnly
            // 
            this.ColReadOnly.HeaderText = "ReadOnly";
            this.ColReadOnly.Name = "ColReadOnly";
            this.ColReadOnly.ReadOnly = true;
            this.ColReadOnly.Visible = false;
            // 
            // ColImeMode
            // 
            this.ColImeMode.HeaderText = "ImeMode";
            this.ColImeMode.Name = "ColImeMode";
            this.ColImeMode.ReadOnly = true;
            this.ColImeMode.Visible = false;
            // 
            // ColSigu
            // 
            this.ColSigu.HeaderText = "シグネチャ";
            this.ColSigu.Name = "ColSigu";
            this.ColSigu.ReadOnly = true;
            this.ColSigu.Visible = false;
            this.ColSigu.Width = 250;
            // 
            // ColMemo
            // 
            this.ColMemo.HeaderText = "メモ";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            this.ColMemo.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 377);
            this.Controls.Add(this.exButton6);
            this.Controls.Add(this.exButton5);
            this.Controls.Add(this.exButton4);
            this.Controls.Add(this.exBtnCopyOrino);
            this.Controls.Add(this.exLabel1);
            this.Controls.Add(this.exTxtDBCRUD);
            this.Controls.Add(this.exBtnCopyMemo);
            this.Controls.Add(this.exBtnReload);
            this.Controls.Add(this.exBtnWrite);
            this.Controls.Add(this.exTxtMemo);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.exTxtSearchText);
            this.Controls.Add(this.exTxtSearch);
            this.Controls.Add(this.exButton3);
            this.Controls.Add(this.exButton2);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.exTextSource);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.exVBFileDialogButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exDataGridView1);
            this.Controls.Add(this.exTxtSourcepath);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "現行ソース解析ツール";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OyuLib.OyuWindows.Compornent.ExTextBox exTxtSourcepath;
        private OyuLib.OyuWindows.Compornent.ExDataGridView.ExDataGridViewControl exDataGridView1;
        private System.Windows.Forms.Label label1;
        private OyuLib.OyuWindows.Compornent.ExButton.ExVBFileDialogButton exVBFileDialogButton1;
        private OyuLib.OyuWindows.Compornent.ExButton.ExLabel lblFileName;
        private OyuLib.OyuWindows.Compornent.ExTextBox exTextSource;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton1;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton2;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton3;
        private OyuLib.OyuWindows.Compornent.ExTextBox exTxtSearch;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exTxtSearchText;
        private System.Windows.Forms.CheckBox checkBox1;
        private OyuLib.OyuWindows.Compornent.ExTextBox exTxtMemo;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exBtnWrite;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exBtnReload;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exBtnCopyMemo;
        private System.Windows.Forms.CheckBox chkColorMemo;
        private OyuLib.OyuWindows.Compornent.ExTextBox exTxtDBCRUD;
        private OyuLib.OyuWindows.Compornent.ExButton.ExLabel exLabel1;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exBtnCopyOrino;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton4;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton5;
        private OyuLib.OyuWindows.Compornent.ExButton.ExButton exButton6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOriginalSortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTabIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFormat;
        private System.Windows.Forms.DataGridViewButtonColumn ColDoGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReadOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColImeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSigu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
        private System.Windows.Forms.Panel panel1;

    }
}

