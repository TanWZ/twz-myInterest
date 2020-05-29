namespace myCircleAndProgressbar
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_Operation = new System.Windows.Forms.GroupBox();
            this.groupBox_Output = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_Output = new System.Windows.Forms.RichTextBox();
            this.groupBox_Operation2 = new System.Windows.Forms.GroupBox();
            this.groupBox_Operation1 = new System.Windows.Forms.GroupBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.groupBox_Show = new System.Windows.Forms.GroupBox();
            this.pictureBox_Show = new System.Windows.Forms.PictureBox();
            this.timer_Run = new System.Windows.Forms.Timer(this.components);
            this.timer_ChangeDistance = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_visible = new System.Windows.Forms.GroupBox();
            this.checkBox_CenterPoint = new System.Windows.Forms.CheckBox();
            this.checkBox_RedCircle = new System.Windows.Forms.CheckBox();
            this.checkBox_Red = new System.Windows.Forms.CheckBox();
            this.checkBox_Green = new System.Windows.Forms.CheckBox();
            this.checkBox_Yellow = new System.Windows.Forms.CheckBox();
            this.checkBox_Black = new System.Windows.Forms.CheckBox();
            this.checkBox_Blue = new System.Windows.Forms.CheckBox();
            this.checkBox_Purple = new System.Windows.Forms.CheckBox();
            this.myProgressBar1 = new myCircleAndProgressbar.MyProgressBar();
            this.groupBox_Operation.SuspendLayout();
            this.groupBox_Output.SuspendLayout();
            this.groupBox_Operation2.SuspendLayout();
            this.groupBox_Operation1.SuspendLayout();
            this.groupBox_Show.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Show)).BeginInit();
            this.groupBox_visible.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Operation
            // 
            this.groupBox_Operation.Controls.Add(this.groupBox_Output);
            this.groupBox_Operation.Controls.Add(this.groupBox_Operation2);
            this.groupBox_Operation.Controls.Add(this.groupBox_Operation1);
            this.groupBox_Operation.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_Operation.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Operation.Name = "groupBox_Operation";
            this.groupBox_Operation.Size = new System.Drawing.Size(270, 668);
            this.groupBox_Operation.TabIndex = 0;
            this.groupBox_Operation.TabStop = false;
            this.groupBox_Operation.Text = "Operation";
            // 
            // groupBox_Output
            // 
            this.groupBox_Output.Controls.Add(this.label2);
            this.groupBox_Output.Controls.Add(this.label1);
            this.groupBox_Output.Controls.Add(this.richTextBox_Output);
            this.groupBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Output.Location = new System.Drawing.Point(3, 459);
            this.groupBox_Output.Name = "groupBox_Output";
            this.groupBox_Output.Size = new System.Drawing.Size(264, 206);
            this.groupBox_Output.TabIndex = 2;
            this.groupBox_Output.TabStop = false;
            this.groupBox_Output.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // richTextBox_Output
            // 
            this.richTextBox_Output.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_Output.Location = new System.Drawing.Point(3, 17);
            this.richTextBox_Output.Name = "richTextBox_Output";
            this.richTextBox_Output.Size = new System.Drawing.Size(258, 114);
            this.richTextBox_Output.TabIndex = 0;
            this.richTextBox_Output.Text = "";
            this.richTextBox_Output.TextChanged += new System.EventHandler(this.richTextBox_Output_TextChanged);
            // 
            // groupBox_Operation2
            // 
            this.groupBox_Operation2.Controls.Add(this.groupBox_visible);
            this.groupBox_Operation2.Controls.Add(this.label4);
            this.groupBox_Operation2.Controls.Add(this.label5);
            this.groupBox_Operation2.Controls.Add(this.label3);
            this.groupBox_Operation2.Controls.Add(this.myProgressBar1);
            this.groupBox_Operation2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Operation2.Location = new System.Drawing.Point(3, 187);
            this.groupBox_Operation2.Name = "groupBox_Operation2";
            this.groupBox_Operation2.Size = new System.Drawing.Size(264, 272);
            this.groupBox_Operation2.TabIndex = 1;
            this.groupBox_Operation2.TabStop = false;
            this.groupBox_Operation2.Text = "...";
            // 
            // groupBox_Operation1
            // 
            this.groupBox_Operation1.Controls.Add(this.button_Stop);
            this.groupBox_Operation1.Controls.Add(this.button_Run);
            this.groupBox_Operation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Operation1.Location = new System.Drawing.Point(3, 17);
            this.groupBox_Operation1.Name = "groupBox_Operation1";
            this.groupBox_Operation1.Size = new System.Drawing.Size(264, 170);
            this.groupBox_Operation1.TabIndex = 0;
            this.groupBox_Operation1.TabStop = false;
            this.groupBox_Operation1.Text = "...";
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(154, 51);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(50, 51);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 0;
            this.button_Run.Text = "Run";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // groupBox_Show
            // 
            this.groupBox_Show.Controls.Add(this.pictureBox_Show);
            this.groupBox_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Show.Location = new System.Drawing.Point(270, 0);
            this.groupBox_Show.Name = "groupBox_Show";
            this.groupBox_Show.Size = new System.Drawing.Size(829, 668);
            this.groupBox_Show.TabIndex = 1;
            this.groupBox_Show.TabStop = false;
            this.groupBox_Show.Text = "ShowArea";
            // 
            // pictureBox_Show
            // 
            this.pictureBox_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Show.Location = new System.Drawing.Point(3, 17);
            this.pictureBox_Show.Name = "pictureBox_Show";
            this.pictureBox_Show.Size = new System.Drawing.Size(823, 648);
            this.pictureBox_Show.TabIndex = 0;
            this.pictureBox_Show.TabStop = false;
            this.pictureBox_Show.SizeChanged += new System.EventHandler(this.pictureBox_Show_SizeChanged);
            this.pictureBox_Show.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Show_MouseDown);
            this.pictureBox_Show.MouseEnter += new System.EventHandler(this.pictureBox_Show_MouseEnter);
            this.pictureBox_Show.MouseLeave += new System.EventHandler(this.pictureBox_Show_MouseLeave);
            this.pictureBox_Show.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Show_MouseMove);
            this.pictureBox_Show.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Show_MouseUp);
            // 
            // timer_Run
            // 
            this.timer_Run.Tick += new System.EventHandler(this.timer_Run_Tick);
            // 
            // timer_ChangeDistance
            // 
            this.timer_ChangeDistance.Tick += new System.EventHandler(this.timer_ChangeDistance_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Red\r\nCircle\r\nRadius:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // groupBox_visible
            // 
            this.groupBox_visible.Controls.Add(this.checkBox_Purple);
            this.groupBox_visible.Controls.Add(this.checkBox_Blue);
            this.groupBox_visible.Controls.Add(this.checkBox_Black);
            this.groupBox_visible.Controls.Add(this.checkBox_Yellow);
            this.groupBox_visible.Controls.Add(this.checkBox_Green);
            this.groupBox_visible.Controls.Add(this.checkBox_Red);
            this.groupBox_visible.Controls.Add(this.checkBox_RedCircle);
            this.groupBox_visible.Controls.Add(this.checkBox_CenterPoint);
            this.groupBox_visible.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_visible.Location = new System.Drawing.Point(3, 17);
            this.groupBox_visible.Name = "groupBox_visible";
            this.groupBox_visible.Size = new System.Drawing.Size(118, 252);
            this.groupBox_visible.TabIndex = 3;
            this.groupBox_visible.TabStop = false;
            this.groupBox_visible.Text = "Visible";
            // 
            // checkBox_CenterPoint
            // 
            this.checkBox_CenterPoint.AutoSize = true;
            this.checkBox_CenterPoint.Location = new System.Drawing.Point(6, 26);
            this.checkBox_CenterPoint.Name = "checkBox_CenterPoint";
            this.checkBox_CenterPoint.Size = new System.Drawing.Size(90, 16);
            this.checkBox_CenterPoint.TabIndex = 0;
            this.checkBox_CenterPoint.Text = "CenterPoint";
            this.checkBox_CenterPoint.UseVisualStyleBackColor = true;
            this.checkBox_CenterPoint.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_RedCircle
            // 
            this.checkBox_RedCircle.AutoSize = true;
            this.checkBox_RedCircle.Location = new System.Drawing.Point(6, 48);
            this.checkBox_RedCircle.Name = "checkBox_RedCircle";
            this.checkBox_RedCircle.Size = new System.Drawing.Size(78, 16);
            this.checkBox_RedCircle.TabIndex = 1;
            this.checkBox_RedCircle.Text = "RedCircle";
            this.checkBox_RedCircle.UseVisualStyleBackColor = true;
            this.checkBox_RedCircle.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Red
            // 
            this.checkBox_Red.AutoSize = true;
            this.checkBox_Red.Location = new System.Drawing.Point(6, 89);
            this.checkBox_Red.Name = "checkBox_Red";
            this.checkBox_Red.Size = new System.Drawing.Size(42, 16);
            this.checkBox_Red.TabIndex = 2;
            this.checkBox_Red.Text = "Red";
            this.checkBox_Red.UseVisualStyleBackColor = true;
            this.checkBox_Red.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Green
            // 
            this.checkBox_Green.AutoSize = true;
            this.checkBox_Green.Location = new System.Drawing.Point(6, 111);
            this.checkBox_Green.Name = "checkBox_Green";
            this.checkBox_Green.Size = new System.Drawing.Size(54, 16);
            this.checkBox_Green.TabIndex = 3;
            this.checkBox_Green.Text = "Green";
            this.checkBox_Green.UseVisualStyleBackColor = true;
            this.checkBox_Green.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Yellow
            // 
            this.checkBox_Yellow.AutoSize = true;
            this.checkBox_Yellow.Location = new System.Drawing.Point(6, 133);
            this.checkBox_Yellow.Name = "checkBox_Yellow";
            this.checkBox_Yellow.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Yellow.TabIndex = 4;
            this.checkBox_Yellow.Text = "Yellow";
            this.checkBox_Yellow.UseVisualStyleBackColor = true;
            this.checkBox_Yellow.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Black
            // 
            this.checkBox_Black.AutoSize = true;
            this.checkBox_Black.Location = new System.Drawing.Point(6, 155);
            this.checkBox_Black.Name = "checkBox_Black";
            this.checkBox_Black.Size = new System.Drawing.Size(54, 16);
            this.checkBox_Black.TabIndex = 5;
            this.checkBox_Black.Text = "Black";
            this.checkBox_Black.UseVisualStyleBackColor = true;
            this.checkBox_Black.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Blue
            // 
            this.checkBox_Blue.AutoSize = true;
            this.checkBox_Blue.Location = new System.Drawing.Point(6, 177);
            this.checkBox_Blue.Name = "checkBox_Blue";
            this.checkBox_Blue.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Blue.TabIndex = 6;
            this.checkBox_Blue.Text = "Blue";
            this.checkBox_Blue.UseVisualStyleBackColor = true;
            this.checkBox_Blue.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // checkBox_Purple
            // 
            this.checkBox_Purple.AutoSize = true;
            this.checkBox_Purple.Location = new System.Drawing.Point(6, 199);
            this.checkBox_Purple.Name = "checkBox_Purple";
            this.checkBox_Purple.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Purple.TabIndex = 7;
            this.checkBox_Purple.Text = "Purple";
            this.checkBox_Purple.UseVisualStyleBackColor = true;
            this.checkBox_Purple.CheckedChanged += new System.EventHandler(this.checkBox_Purple_CheckedChanged);
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myProgressBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.myProgressBar1.Location = new System.Drawing.Point(181, 17);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(80, 252);
            this.myProgressBar1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 668);
            this.Controls.Add(this.groupBox_Show);
            this.Controls.Add(this.groupBox_Operation);
            this.Name = "FormMain";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox_Operation.ResumeLayout(false);
            this.groupBox_Output.ResumeLayout(false);
            this.groupBox_Output.PerformLayout();
            this.groupBox_Operation2.ResumeLayout(false);
            this.groupBox_Operation2.PerformLayout();
            this.groupBox_Operation1.ResumeLayout(false);
            this.groupBox_Show.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Show)).EndInit();
            this.groupBox_visible.ResumeLayout(false);
            this.groupBox_visible.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Operation;
        private System.Windows.Forms.GroupBox groupBox_Operation2;
        private System.Windows.Forms.GroupBox groupBox_Operation1;
        private System.Windows.Forms.GroupBox groupBox_Show;
        private System.Windows.Forms.PictureBox pictureBox_Show;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.Timer timer_Run;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.GroupBox groupBox_Output;
        private System.Windows.Forms.RichTextBox richTextBox_Output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_ChangeDistance;
        private MyProgressBar myProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox_visible;
        private System.Windows.Forms.CheckBox checkBox_Purple;
        private System.Windows.Forms.CheckBox checkBox_Blue;
        private System.Windows.Forms.CheckBox checkBox_Black;
        private System.Windows.Forms.CheckBox checkBox_Yellow;
        private System.Windows.Forms.CheckBox checkBox_Green;
        private System.Windows.Forms.CheckBox checkBox_Red;
        private System.Windows.Forms.CheckBox checkBox_RedCircle;
        private System.Windows.Forms.CheckBox checkBox_CenterPoint;
    }
}

