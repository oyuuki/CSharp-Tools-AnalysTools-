namespace OyuLib.OyuWindows.Interface.ExDataGridView
{
    partial class ExDataGridViewControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ExDataGridViewControl
            // 
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.RowTemplate.Height = 21;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExDataGridView_CellClick);
            this.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ExDataGridView_RowsAdded);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
