namespace TpMain
{
    partial class UpSub
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
            btn_Ok = new Button();
            btn_Select = new Button();
            btn_Cancel = new Button();
            lb_Path = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(506, 42);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(206, 90);
            btn_Ok.TabIndex = 0;
            btn_Ok.Text = "확인버튼";
            btn_Ok.UseVisualStyleBackColor = true;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Select
            // 
            btn_Select.Location = new Point(74, 42);
            btn_Select.Name = "btn_Select";
            btn_Select.Size = new Size(377, 186);
            btn_Select.TabIndex = 1;
            btn_Select.Text = "파일 선택 버튼";
            btn_Select.UseVisualStyleBackColor = true;
            btn_Select.Click += btn_Select_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(506, 138);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(206, 90);
            btn_Cancel.TabIndex = 2;
            btn_Cancel.Text = "취소버튼";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // lb_Path
            // 
            lb_Path.AutoSize = true;
            lb_Path.Location = new Point(74, 269);
            lb_Path.Name = "lb_Path";
            lb_Path.Size = new Size(39, 15);
            lb_Path.TabIndex = 3;
            lb_Path.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(344, 269);
            label1.Name = "label1";
            label1.Size = new Size(137, 31);
            label1.TabIndex = 4;
            label1.Text = "쓰레기 파일";
            // 
            // UpSub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lb_Path);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Select);
            Controls.Add(btn_Ok);
            Name = "UpSub";
            Text = "UpSub";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Ok;
        private Button btn_Select;
        private Button btn_Cancel;
        private Label lb_Path;
        private Label label1;
    }
}