namespace myCircleAndProgressbar
{
    partial class Form1
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
            this.panel_operationArea = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_runningArea = new System.Windows.Forms.Panel();
            this.myCircle1 = new myCircleAndProgressbar.MyCircle();
            this.myProgressBar1 = new myCircleAndProgressbar.MyProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_operationArea.SuspendLayout();
            this.panel_runningArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_operationArea
            // 
            this.panel_operationArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_operationArea.Controls.Add(this.label1);
            this.panel_operationArea.Controls.Add(this.myProgressBar1);
            this.panel_operationArea.Controls.Add(this.button4);
            this.panel_operationArea.Controls.Add(this.button3);
            this.panel_operationArea.Controls.Add(this.button2);
            this.panel_operationArea.Controls.Add(this.button1);
            this.panel_operationArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_operationArea.Location = new System.Drawing.Point(0, 0);
            this.panel_operationArea.Name = "panel_operationArea";
            this.panel_operationArea.Size = new System.Drawing.Size(206, 461);
            this.panel_operationArea.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "StopAll";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "AddCircle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Green";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "RunAll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_runningArea
            // 
            this.panel_runningArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_runningArea.Controls.Add(this.myCircle1);
            this.panel_runningArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_runningArea.Location = new System.Drawing.Point(206, 0);
            this.panel_runningArea.Name = "panel_runningArea";
            this.panel_runningArea.Size = new System.Drawing.Size(540, 461);
            this.panel_runningArea.TabIndex = 5;
            this.panel_runningArea.MouseEnter += new System.EventHandler(this.panel_runningArea_MouseEnter);
            this.panel_runningArea.MouseLeave += new System.EventHandler(this.panel_runningArea_MouseLeave);
            this.panel_runningArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_runningArea_MouseMove);
            this.panel_runningArea.Resize += new System.EventHandler(this.panel_runningArea_Resize);
            // 
            // myCircle1
            // 
            this.myCircle1.CircleColor = System.Drawing.Color.Black;
            this.myCircle1.CircleSize = new System.Drawing.Size(50, 50);
            this.myCircle1.Location = new System.Drawing.Point(98, 51);
            this.myCircle1.Name = "myCircle1";
            this.myCircle1.ParentSize = new System.Drawing.Size(0, 0);
            this.myCircle1.SelfRunningFlag = false;
            this.myCircle1.SelfRunningInterval = 100;
            this.myCircle1.SelfRunningSpeed = 10;
            this.myCircle1.Size = new System.Drawing.Size(50, 50);
            this.myCircle1.TabIndex = 1;
            this.myCircle1.ToolTipStr = "Hi.";
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myProgressBar1.Location = new System.Drawing.Point(114, 68);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(59, 155);
            this.myProgressBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 461);
            this.Controls.Add(this.panel_runningArea);
            this.Controls.Add(this.panel_operationArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_operationArea.ResumeLayout(false);
            this.panel_operationArea.PerformLayout();
            this.panel_runningArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_operationArea;
        private System.Windows.Forms.Panel panel_runningArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MyCircle myCircle1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private MyProgressBar myProgressBar1;
        private System.Windows.Forms.Label label1;
    }
}