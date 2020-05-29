namespace myCircleAndProgressbar
{
    partial class MyProgressBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new myCircleAndProgressbar.MyProgressBar.VerticalProgressBar();
            this.label_Top = new System.Windows.Forms.Label();
            this.label_Bottom = new System.Windows.Forms.Label();
            this.label_Move = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBar1.Location = new System.Drawing.Point(47, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(33, 315);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBar1_MouseDown);
            this.progressBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progressBar1_MouseMove);
            // 
            // label_Top
            // 
            this.label_Top.AutoSize = true;
            this.label_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Top.Location = new System.Drawing.Point(0, 0);
            this.label_Top.Name = "label_Top";
            this.label_Top.Size = new System.Drawing.Size(23, 12);
            this.label_Top.TabIndex = 1;
            this.label_Top.Text = "100";
            // 
            // label_Bottom
            // 
            this.label_Bottom.AutoSize = true;
            this.label_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Bottom.Location = new System.Drawing.Point(0, 303);
            this.label_Bottom.Name = "label_Bottom";
            this.label_Bottom.Size = new System.Drawing.Size(11, 12);
            this.label_Bottom.TabIndex = 2;
            this.label_Bottom.Text = "0";
            // 
            // label_Move
            // 
            this.label_Move.AutoSize = true;
            this.label_Move.Location = new System.Drawing.Point(0, 20);
            this.label_Move.Name = "label_Move";
            this.label_Move.Size = new System.Drawing.Size(17, 12);
            this.label_Move.TabIndex = 3;
            this.label_Move.Text = "50";
            // 
            // MyProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Move);
            this.Controls.Add(this.label_Bottom);
            this.Controls.Add(this.label_Top);
            this.Controls.Add(this.progressBar1);
            this.Name = "MyProgressBar";
            this.Size = new System.Drawing.Size(80, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VerticalProgressBar progressBar1;
        private System.Windows.Forms.Label label_Top;
        private System.Windows.Forms.Label label_Bottom;
        private System.Windows.Forms.Label label_Move;
    }
}
