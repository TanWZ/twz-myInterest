using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Threading;

namespace myCircleAndProgressbar
{
    public partial class MyCircle : UserControl
    {
        public MyCircle()
        {
            InitializeComponent();

            circleColor = Color.Black;
            sb = new SolidBrush(circleColor);

            Random r = new Random(DateTime.Now.Millisecond);
            direction = r.Next(0, 360);

            crashType = CrashWallEnum.Default;

            contextMenuStrip1.Opened += ContextMenuStrip1_Opened;
            contextMenuStrip1.Closed += ContextMenuStrip1_Closed;

            selfDrivenThread = new Thread(selfDriven);
            selfDrivenThread.Start();
        }

        public MyCircle(MyCircle copyCircle):this()
        {
            circleColor = copyCircle.CircleColor;
            sb = new SolidBrush(circleColor);
            //toolTipStr = copyCircle.ToolTipStr;

            parentSize = copyCircle.ParentSize;

            CircleSize = copyCircle.CircleSize;

            selfRunningInterval = copyCircle.selfRunningInterval;

            selfRunningSpeed = copyCircle.SelfRunningSpeed;

        }

        Thread selfDrivenThread;

        private bool selfRunningFlag = false;
        /// <summary>
        /// 自驱动是否进行
        /// </summary>
        public bool SelfRunningFlag
        {
            get
            {
                return selfRunningFlag;
            }

            set
            {
                selfRunningFlag = value;
            }
        }

        private int selfRunningInterval = 100;
        /// <summary>
        /// 自驱动间隔
        /// </summary>
        public int SelfRunningInterval
        {
            get
            {
                return selfRunningInterval;
            }

            set
            {
                selfRunningInterval = value;
            }
        }

        private int selfRunningSpeed = 10;
        /// <summary>
        /// 自驱动速度
        /// </summary>
        public int SelfRunningSpeed
        {
            get
            {
                return selfRunningSpeed;
            }

            set
            {
                selfRunningSpeed = value;
            }
        }

        public delegate void ChangeDirectionDelegate(int newDiretion, CrashWallEnum crashType);
        public ChangeDirectionDelegate changeDirectionDelegate;
        void selfDriven()
        {
            while (true)
            {
                if (SelfRunningFlag && mouseLeaveFlag && !mouseRightClick)
                {
                    Location = new Point(Location.X + (int)(selfRunningSpeed * Math.Cos(direction * Math.PI / 180)), Location.Y + (int)(selfRunningSpeed * Math.Sin(direction * Math.PI / 180)));


                    if (judgeNewDirection()) changeDirectionDelegate?.Invoke(direction, CrashType);
                }

                Thread.Sleep(SelfRunningInterval);
            }


        }

        private bool judgeNewDirection()
        {
            if (Location.Y <= 0 && parentSize.Width - Size.Width == Location.X)
            {
                //右上
                direction = 225;
                crashType = CrashWallEnum.RightTop;
                return true;
            }
            if (parentSize.Height - Size.Height == Location.Y && parentSize.Width - Size.Width == Location.X)
            {
                //右下
                direction = 135;
                crashType = CrashWallEnum.RightButtom;

                return true;

            }
            if (Location.Y == 0 && Location.X == 0)
            {
                //左上
                direction = 315;
                crashType = CrashWallEnum.LeftTop;
                return true;
            }
            if (parentSize.Height - Size.Height == Location.Y && Location.X <= 0)
            {
                //左下
                direction = 45;
                crashType = CrashWallEnum.LeftButtom;
                return true;
            }
            if (parentSize.Width - Size.Width <= Location.X || Location.X <= 0)
            {
                //右，左可以合并
                direction = direction < 180 ? 180 - direction : 540 - direction;

                if (Location.X <= 0)
                {
                    Location = new Point(0, Location.Y);
                    crashType = CrashWallEnum.Left;
                }
                if (parentSize.Width - Size.Width <= Location.X)
                {
                    Location = new Point(parentSize.Width - Size.Width, Location.Y);
                    crashType = CrashWallEnum.Right;
                }
                return true;
            }
            //if (Location.X <= 0)
            //{
            //    //左
            //    direction = Direction < 180 ? 180 - Direction : 540 - Direction;
            //}
            if (Location.Y <= 0 || parentSize.Height - Size.Height <= Location.Y)
            {
                //上，下相同
                direction = 360 - direction;

                if (Location.Y <= 0)
                {
                    Location = new Point(Location.X, 0);
                    crashType = CrashWallEnum.Top;
                }
                if (parentSize.Height - Size.Height <= Location.Y)
                {
                    Location = new Point(Location.X, parentSize.Height - Size.Height);
                    crashType = CrashWallEnum.Buttom;
                }
                return true;
            }
            //if (parentSize.Height - Size.Height <= Location.Y)
            //{
            //    //下
            //    direction = 360 - Direction;
            //}

            return false;

        }

        private Size parentSize;
        /// <summary>
        /// 父容器大小
        /// </summary>
        public Size ParentSize
        {
            get
            {
                return parentSize;
            }

            set
            {
                parentSize = value;
            }
        }

        private Color circleColor;// = Color.Green;
        /// <summary>
        /// 颜色
        /// </summary>
        public Color CircleColor
        {
            get { return circleColor; }
            set
            {
                circleColor = value;
                sb = new SolidBrush(circleColor);
                OnPaint(new PaintEventArgs(this.CreateGraphics(), new Rectangle(0, 0, Width - 2, Height - 2)));
            }
        }

        int width = 50;
        int height = 50;
        /// <summary>
        /// 大小
        /// </summary>
        public Size CircleSize
        {
            get { return new Size(width, height); }
            set
            {
                width = value.Width;
                height = value.Height;
                OnResize(EventArgs.Empty);
                this.Invalidate();
            }
        }

        int direction;
        /// <summary>
        /// 方向
        /// </summary>
        public int Direction
        {
            get { return direction; }
        }

        private CrashWallEnum crashType;
        /// <summary>
        /// 碰撞类型
        /// </summary>
        public CrashWallEnum CrashType
        {
            get { return crashType; }
        }

        /// <summary>
        /// 鼠标停留提示
        /// </summary>
        public string ToolTipStr
        {
            get
            {
                return toolTipStr;
            }

            set
            {
                toolTipStr = value;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Width = width;
            Height = height;
            //this.Invalidate();
        }

        SolidBrush sb;// = new SolidBrush(CircleColor);
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //pevent.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(10, 10, 100, 100));
            Graphics g = pevent.Graphics;
            //g.Clear(Color.Transparent);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //g.DrawEllipse(new Pen(circleColor), new Rectangle(0, 0, Width - 2, Height - 2));
            //g.FillEllipse(sb, new Rectangle(0, 0, Width - 2, Height - 2));

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();//创建一条线
            path.AddEllipse(0, 0, Width, Height);//画一个椭圆 （x,y,宽,高）
            //Graphics g = CreateGraphics();//为窗体创建画布
            //g.DrawEllipse(new Pen(Color.Black, 2), 1, 1, Width - 2, Height - 2);//为画布画一个椭圆(笔,x,y，宽,高)
            g.FillEllipse(sb, new Rectangle(0, 0, Width, Height));
            Region = new Region(path);//设置控件的窗口区域
        }

        string toolTipStr = "Hi.";
        bool mouseLeaveFlag = true;
        ToolTip toolTip = new ToolTip();
        private void MyCircle_MouseEnter(object sender, EventArgs e)
        {
            //selfRunningFlag = false;
            //selfDrivenThread.Suspend();
            mouseLeaveFlag = false;

            toolTip.SetToolTip(this, $@"{toolTipStr}My name is {Name}.{(selfRunningFlag ? "I'm running." : "I'm waiting.")}");
        }

        private void MyCircle_MouseLeave(object sender, EventArgs e)
        {
            //selfRunningFlag = true;
            //selfDrivenThread.Resume();
            mouseLeaveFlag = true;
        }

        bool mouseRightClick = false;
        private void MyCircle_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    mouseRightClick = true;
            //    contextMenuStrip1.Show(this, e.Location);
                
            //}
        }

        private void ContextMenuStrip1_Opened(object sender, EventArgs e)
        {
            mouseRightClick = true;
        }

        private void ContextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //MessageBox.Show("ok");
            mouseRightClick = false;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selfRunningFlag = true;
            mouseLeaveFlag = true;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selfRunningFlag = false;
        }

        public delegate bool DisposeCircleDelegate(MyCircle circleDispose);
        public DisposeCircleDelegate DisposeCircle;
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeCircle?.Invoke(this);
            //this.Dispose();
        }
    }

    /// <summary>
    /// 碰壁类型
    /// </summary>
    public enum CrashWallEnum
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 8,
        /// <summary>
        /// 右。0
        /// </summary>
        Right = 0,
        /// <summary>
        /// 左。1
        /// </summary>
        Left = 1,
        /// <summary>
        /// 上。2
        /// </summary>
        Top = 2,
        /// <summary>
        /// 下。3
        /// </summary>
        Buttom = 3,
        /// <summary>
        /// 右上。4
        /// </summary>
        RightTop = 4,
        /// <summary>
        /// 右下。5
        /// </summary>
        RightButtom = 5,
        /// <summary>
        /// 左上。6
        /// </summary>
        LeftTop = 6,
        /// <summary>
        /// 左下。7
        /// </summary>
        LeftButtom = 7
    }
}
