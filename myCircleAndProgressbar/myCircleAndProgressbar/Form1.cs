using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCircleAndProgressbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        List<MyCircle> allCircles;

        private void button1_Click(object sender, EventArgs e)
        {
            //myCircle1.SelfRunningFlag = true;
            allCircles.ForEach((circle) =>
            {
                circle.SelfRunningFlag = true;
            });

            //showDirection(myCircle1.Direction, myCircle1.CrashType);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myProgressBar1.SetProgressBarMaxValue(200);
            myProgressBar1.SetProgressBarMinValue(10);
            myProgressBar1.SetProgressBarValue(myCircle1.Width);
            myProgressBar1.BarChangeValue += barChangeValue;


            allCircles = new List<MyCircle>();
            //allCircles.Add(myCircle1);
            allCircles.Add(myCircle1);
            //allCircles.Add(myCircle3);

            allCircles.ForEach((circle) =>
            {
                circle.ParentSize = panel_runningArea.Size;
                circle.DisposeCircle += disposeCircle;
                //circle.changeDirectionDelegate += showDirection;

            });

            //myCircle1.ParentSize = panel_runningArea.Size;
            //myCircle1.changeDirectionDelegate += showDirection;
        }

        private bool disposeCircle(MyCircle disposeCircle)
        {
            try
            {
                disposeCircle.Dispose();
                allCircles.Remove(disposeCircle);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void barChangeValue(int newValue)
        {
            allCircles.ForEach((circle) =>
            {
                circle.CircleSize = new Size(newValue, newValue);
            });
        }

        private void showDirection(int newDiretion, CrashWallEnum crashType)
        {
            //label1.Text = newDiretion.ToString();
            //label2.Text = crashType.ToString();
        }

        bool isMouseEnterRunningAreaFlag = false;

        private void panel_runningArea_MouseEnter(object sender, EventArgs e)
        {
            isMouseEnterRunningAreaFlag = true;
            //myCircle1.SelfRunningFlag = false;
            //allCircles.ForEach((circle) =>
            //{
            //    circle.SelfRunningFlag = false;
            //});

        }

        private void panel_runningArea_MouseLeave(object sender, EventArgs e)
        {
            isMouseEnterRunningAreaFlag = false;
            //myCircle1.SelfRunningFlag = true;

        }

        int tinyAdjustX = 2;
        int tinyAdjustY = 5;
        Point followMousePoint;
        private void panel_runningArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseEnterRunningAreaFlag)
            {
                //if (sender is MyCircle)
                //{
                //    followMousePoint = new Point(myCircle1.Location.X + e.Location.X - myCircle1.Width / 2 + tinyAdjustX, myCircle1.Location.Y + e.Location.Y - myCircle1.Height / 2 + tinyAdjustY);
                //}
                //else
                //{
                //    followMousePoint = new Point(e.Location.X - myCircle1.Width / 2 + tinyAdjustX, e.Location.Y - myCircle1.Height / 2 + tinyAdjustY);

                //}

                //myCircle1.Location = followMousePoint;

            }
        }

        private void panel_runningArea_Resize(object sender, EventArgs e)
        {
            //myCircle1.ParentSize = panel_runningArea.Size;

            allCircles.ForEach((circle) =>
            {
                circle.ParentSize = panel_runningArea.Size;
            });

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //myCircle1.CircleColor = Color.Green;
            allCircles.ForEach((circle) =>
            {
                circle.CircleColor = Color.Green;
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyCircle newCircle;
            if (allCircles.Count != 0)
            {
                newCircle = new MyCircle(allCircles[0]);

            }
            else
            {
                newCircle = new MyCircle();
                newCircle.ParentSize = panel_runningArea.Size;
            }
            newCircle.Name = "myCircle" + (allCircles.Count + 1).ToString();
            newCircle.DisposeCircle += disposeCircle;
            //newCircle.ParentSize = panel_runningArea.Size;
            panel_runningArea.Controls.Add(newCircle);
            allCircles.Add(newCircle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            allCircles.ForEach((circle) =>
            {
                circle.SelfRunningFlag = false;
            });
        }
    }
}
