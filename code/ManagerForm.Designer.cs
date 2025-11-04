namespace TpMain
{
    partial class ManagerForm
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
            DGV_Users = new DataGridView();
            btn_UserLoad = new Button();
            btn_UserDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Users).BeginInit();
            SuspendLayout();
            // 
            // DGV_Users
            // 
            DGV_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Users.Location = new Point(30, 21);
            DGV_Users.Name = "DGV_Users";
            DGV_Users.RowTemplate.Height = 25;
            DGV_Users.Size = new Size(655, 501);
            DGV_Users.TabIndex = 0;
            // 
            // btn_UserLoad
            // 
            btn_UserLoad.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_UserLoad.Location = new Point(732, 21);
            btn_UserLoad.Name = "btn_UserLoad";
            btn_UserLoad.Size = new Size(195, 114);
            btn_UserLoad.TabIndex = 1;
            btn_UserLoad.Text = "불러오기";
            btn_UserLoad.UseVisualStyleBackColor = true;
            btn_UserLoad.Click += btn_UserLoad_Click;
            // 
            // btn_UserDelete
            // 
            btn_UserDelete.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_UserDelete.Location = new Point(732, 170);
            btn_UserDelete.Name = "btn_UserDelete";
            btn_UserDelete.Size = new Size(195, 114);
            btn_UserDelete.TabIndex = 2;
            btn_UserDelete.Text = "삭제";
            btn_UserDelete.UseVisualStyleBackColor = true;
            btn_UserDelete.Click += btn_UserDelete_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(961, 557);
            Controls.Add(btn_UserDelete);
            Controls.Add(btn_UserLoad);
            Controls.Add(DGV_Users);
            Name = "ManagerForm";
            Text = "ManagerForm";
            Load += ManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Users).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Users;
        private Button btn_UserLoad;
        private Button btn_UserDelete;
    }
}