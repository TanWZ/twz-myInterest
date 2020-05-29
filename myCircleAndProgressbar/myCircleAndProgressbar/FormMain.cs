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
    public partial class FormMain : Form
    {
        #region 构造函数
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量--只用了画圆

        /// <summary>
        /// form加载期间阻止触发事件
        /// </summary>
        bool isLoaded = false;

        /// <summary>
        /// 选择的功能
        /// 0：移动文字
        /// 1：大小圈圈
        /// 2：旋转圆
        /// </summary>
        int choiceFunction = 2;

        //每画一笔，都创建新的bitmap与graphics对象。
        Bitmap bitmap;
        Graphics g;

        //显示相关变量
        int a = 0;
        int clickDown_a = 0;//（此变量参与前进后退的判断。但不准确。受设备性能延迟的影响）

        //画画相关变量
        bool drawFlag = false;
        Point lastP;
        int penSize = 5;
        bool sizeChanging = false;//界面大小调整

        //移动字串相关变量
        bool runStringFlag = false;
        int tickCountString = 1;
        int tickPixString = 5;
        int fontSize = 50;

        //圈圈相关
        bool[] directionFlag = new bool[] { false, false };
        int tickCountMin = 20;
        double maxCircleRadius = 0.5;
        int[] tickCountCircles = new int[] { 1, 1 };
        int[] tickPixCircle = new int[] { 5, 10 };

        //画圆相关
        bool runFlag = false;
        bool mouseEnterShowAreaFlag = false;
        int[] angles = new int[] { 0, 0, 0, 0, 0, 0 };
        int[] speeds = new int[] { 10, 10, 10, 10, 10, 10 };//旋转速度
        int radius = 20;//颜色圆半径
        int oldDistance = 0;
        int distance = 100;
        int distanceChangeGab = 50;//内切圆用的
        int distance2 = 200;//内切圆用的
        int maxDis = 300;
        int minDis = 10;
        bool distanceAddOrSubFlag = false;//大小变化
        bool spinDirection = false;//旋转方向：true顺时针（变大），false逆时针（变小）
        Point point;
        int disClip = 2;//鼠标或滚轮每次加减的距离
        bool lastAddOrSunFlag = false;
        int speedClip = 10;
        bool speedNormalFlag = true;//速度是否正常
        bool[] visible = new bool[] { true, true, true, true, true, true, true, true };
        public const int CenterPoint = 0;
        public const int RedCircle = 1;
        public const int RedSolidCircle = 2;
        public const int GreenSolidCircle = 3;
        public const int YellowSolidCircle = 4;
        public const int BlackSolidCircle = 5;
        public const int BlueSolidCircle = 6;
        public const int PurpleSolidCircle = 7;
        public int Distance
        {
            get { oldDistance = distance; return distance; }
            set
            {
                //这里，用新旧distance控制旋转方向。旋转方向：true顺时针（变大），false逆时针（变小）
                spinDirection = value - oldDistance > 0 ? true : false;

                //oldDistance = distance;//放到get里面
                distance = value;
            }
        }

        //前进后退相关变量
        List<Bitmap> lastBitmaps;
        int listCapacity = 50;
        int currentStep = 0;
        int allStep = 0;

        #endregion

        #region 方法
        ///// <summary>
        ///// 画线。两点之间。
        ///// 现在的问题是，每次在copyDraw里面new Bitmap，会导致ui失去响应，丢失前面一些轨迹
        ///// </summary>
        ///// <param name="color"></param>
        ///// <param name="newP"></param>
        //public void drawLine(Color color, Point newP)
        //{
        //    if (newP == lastP) return;

        //    g = Graphics.FromImage(bitmap);
        //    g.DrawLine(new Pen(color, penSize), lastP, newP);

        //    lastP = newP;

        //    pictureBox_Draw.Image = bitmap;

        //    g.Dispose();
        //}

        ///// <summary>
        ///// 以圆代点画线。用上面画线那个了已经
        ///// </summary>
        ///// <param name="color"></param>
        ///// <param name="rect"></param>
        //public void drawEll(Color color, RectangleF rect)
        //{
        //    g = Graphics.FromImage(bitmap);
        //    g.FillEllipse(new SolidBrush(color), rect);

        //    pictureBox_Draw.Image = bitmap;

        //    g.Dispose();


        //}

        ///// <summary>
        ///// 移动文字TXT
        ///// </summary>
        ///// <param name="color"></param>
        //public void drawString(Color color)
        //{
        //    //g = Graphics.FromImage(bitmap);
        //    //g.DrawString(textBox_RunString.Text == "" ? "NoText." : textBox_RunString.Text, new Font(Font, FontStyle.Bold), new SolidBrush(color), pictureBox_Draw.Location + new Size(pictureBox_Draw.Width / 2, pictureBox_Draw.Height / 2));

        //    //pictureBox_Draw.Image = bitmap;

        //    //g.Dispose();

        //    //多线程
        //    Bitmap temp = bitmap.Clone() as Bitmap;

        //    g = Graphics.FromImage(temp);

        //    int x = tickCountString++ * tickPixString;

        //    if (x > pictureBox_Draw.Width) tickCountString = 1;

        //    FontFamily f = new FontFamily(Font.Name);

        //    g.DrawString(textBox_RunString.Text == "" ? "NoText." : textBox_RunString.Text, new Font(f, fontSize), new SolidBrush(color), pictureBox_Draw.Location + new Size(x, pictureBox_Draw.Height / 2));

        //    pictureBox_Draw.Image = temp;

        //    g.Dispose();
        //}

        ///// <summary>
        ///// 画圈，大小变化那种
        ///// </summary>
        ///// <param name="color"></param>
        //public void drawCircle(Color color)
        //{
        //    Bitmap temp = bitmap.Clone() as Bitmap;

        //    g = Graphics.FromImage(temp);

        //    int x = 0;

        //    x = getX(0);
        //    g.DrawEllipse(new Pen(Color.Red), new Rectangle(new Point(pictureBox_Draw.Width / 2 - x / 2, pictureBox_Draw.Height / 2 - x / 2), new Size(x, x)));

        //    x = getX(1);
        //    g.DrawEllipse(new Pen(Color.Green), new Rectangle(new Point(pictureBox_Draw.Width / 2 - x / 2, pictureBox_Draw.Height / 2 - x / 2), new Size(x, x)));

        //    pictureBox_Draw.Image = temp;

        //    g.Dispose();
        //}

        /// <summary>
        /// 画圆，好几个围绕中心转那种--用下面传point的了
        /// </summary>
        public void drawSpinCircle(Color color, PictureBox pictureBox_Draw)
        {
            Bitmap temp = bitmap.Clone() as Bitmap;

            g = Graphics.FromImage(temp);

            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(new Point(pictureBox_Draw.Width / 2 - 5, pictureBox_Draw.Height / 2 - 5), new Size(10, 10)));//中点
            g.DrawEllipse(new Pen(Color.Red), new Rectangle(new Point(pictureBox_Draw.Width / 2 - Distance, pictureBox_Draw.Height / 2 - Distance), new Size(2 * Distance, 2 * Distance)));//边缘圈

            limitAngle(0);
            int x = (int)(pictureBox_Draw.Width / 2 - radius + (Distance + radius) * Math.Cos(angles[0] * Math.PI / 180));
            int y = (int)(pictureBox_Draw.Height / 2 - radius - (Distance + radius) * Math.Sin(angles[0] * Math.PI / 180));
            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(new Point(x, y), new Size(2 * radius, 2 * radius)));//红圆


            limitAngle(1);
            int x1 = (int)(pictureBox_Draw.Width / 2 - radius - (Distance + radius) * Math.Cos(angles[1] * Math.PI / 180));
            int y1 = (int)(pictureBox_Draw.Height / 2 - radius + (Distance + radius) * Math.Sin(angles[1] * Math.PI / 180));
            g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(new Point(x1, y1), new Size(2 * radius, 2 * radius)));//绿圆

            g.DrawLine(new Pen(Color.Black), new Point(x + radius, y + radius), new Point(x1 + radius, y1 + radius));
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x + radius - 3, y + radius - 3), new Size(6, 6)));
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x1 + radius - 3, y1 + radius - 3), new Size(6, 6)));

            limitAngle(2);
            int x2 = (int)(pictureBox_Draw.Width / 2 - radius + (Distance + radius) * Math.Cos((angles[2] + 90) * Math.PI / 180));
            int y2 = (int)(pictureBox_Draw.Height / 2 - radius - (Distance + radius) * Math.Sin((angles[2] + 90) * Math.PI / 180));
            g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(new Point(x2, y2), new Size(2 * radius, 2 * radius)));//黄圆

            limitAngle(3);
            int x3 = (int)(pictureBox_Draw.Width / 2 - radius - (Distance + radius) * Math.Cos((angles[3] + 90) * Math.PI / 180));
            int y3 = (int)(pictureBox_Draw.Height / 2 - radius + (Distance + radius) * Math.Sin((angles[3] + 90) * Math.PI / 180));
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x3, y3), new Size(2 * radius, 2 * radius)));//黑圆

            g.DrawLine(new Pen(Color.Black), new Point(x2 + radius, y2 + radius), new Point(x3 + radius, y3 + radius));
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x2 + radius - 3, y2 + radius - 3), new Size(6, 6)));
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x3 + radius - 3, y3 + radius - 3), new Size(6, 6)));


            pictureBox_Draw.Image = temp;

            g.Dispose();
        }
        public void drawSpinCircle(Point centerPoint, PictureBox pictureBox_Draw)
        {
            //using (bitmap)
            //{
            bitmap = new Bitmap(pictureBox_Draw.Width, pictureBox_Draw.Height);
            g = Graphics.FromImage(bitmap);

            if (visible[CenterPoint])
            {
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(Point.Subtract(centerPoint, new Size(5, 5)), new Size(10, 10)));//中点

            }
            if (visible[RedCircle])
            {
                g.DrawEllipse(new Pen(Color.Red), new Rectangle(Point.Subtract(centerPoint, new Size(Distance, Distance)), new Size(2 * Distance, 2 * Distance)));//内切边缘圈

            }

            limitAngle(0);
            if (visible[RedSolidCircle])
            {
                //limitAngle(0);
                int x = (int)(centerPoint.X - radius + (Distance + radius) * Math.Cos(angles[0] * Math.PI / 180));
                int yy = (int)((Distance + radius) * Math.Sin(angles[0] * Math.PI / 180));
                int y = centerPoint.Y - radius;// - yy;
                y = spinDirection ? y + yy : y - yy;
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(new Point(x, y), new Size(2 * radius, 2 * radius)));//红圆 
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x + radius - 3, y + radius - 3), new Size(6, 6)));//红圆中点
            }

            limitAngle(1);
            if (visible[GreenSolidCircle])
            {
                //limitAngle(1);
                int x1 = (int)(centerPoint.X - radius - (Distance + radius) * Math.Cos(angles[1] * Math.PI / 180));
                int yy1 = (int)((Distance + radius) * Math.Sin(angles[1] * Math.PI / 180));
                int y1 = centerPoint.Y - radius;// + yy1);
                y1 = spinDirection ? y1 - yy1 : y1 + yy1;
                g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(new Point(x1, y1), new Size(2 * radius, 2 * radius)));//绿圆 
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x1 + radius - 3, y1 + radius - 3), new Size(6, 6)));//绿圆中点
            }

            //g.DrawLine(new Pen(Color.Black), new Point(x + radius, y + radius), new Point(x1 + radius, y1 + radius));//红绿圆中点线
            //g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x + radius - 3, y + radius - 3), new Size(6, 6)));//红圆中点
            //g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x1 + radius - 3, y1 + radius - 3), new Size(6, 6)));//绿圆中点

            limitAngle(2);
            if (visible[YellowSolidCircle])
            {
                //limitAngle(2);
                int x2 = (int)(centerPoint.X - radius + (Distance + radius) * Math.Cos((angles[2] + 120) * Math.PI / 180));
                int yy2 = (int)((Distance + radius) * Math.Sin((angles[2] + 120) * Math.PI / 180));
                int y2 = centerPoint.Y - radius;// - yy2);
                y2 = spinDirection ? y2 + yy2 : y2 - yy2;
                g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(new Point(x2, y2), new Size(2 * radius, 2 * radius)));//黄圆 
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x2 + radius - 3, y2 + radius - 3), new Size(6, 6)));//黄圆中点
            }

            limitAngle(3);
            if (visible[BlackSolidCircle])
            {
                //limitAngle(3);
                int x3 = (int)(centerPoint.X - radius - (Distance + radius) * Math.Cos((angles[3] + 120) * Math.PI / 180));
                int yy3 = (int)((Distance + radius) * Math.Sin((angles[3] + 120) * Math.PI / 180));
                int y3 = centerPoint.Y - radius;// + yy3);
                y3 = spinDirection ? y3 - yy3 : y3 + yy3;
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x3, y3), new Size(2 * radius, 2 * radius)));//黑圆 
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(new Point(x3 + radius - 3, y3 + radius - 3), new Size(6, 6)));//黑圆中点，白色
            }

            //g.DrawLine(new Pen(Color.Black), new Point(x2 + radius, y2 + radius), new Point(x3 + radius, y3 + radius));//黄黑圆中点线
            //g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x2 + radius - 3, y2 + radius - 3), new Size(6, 6)));//黄圆中点
            //g.FillEllipse(new SolidBrush(Color.White), new Rectangle(new Point(x3 + radius - 3, y3 + radius - 3), new Size(6, 6)));//黑圆中点，白色

            limitAngle(4);
            if (visible[BlueSolidCircle])
            {
                //limitAngle(4);
                int x4 = (int)(centerPoint.X - radius + (Distance + radius) * Math.Cos((angles[4] + 60) * Math.PI / 180));
                int yy4 = (int)((Distance + radius) * Math.Sin((angles[4] + 60) * Math.PI / 180));
                int y4 = centerPoint.Y - radius;// - yy4);
                y4 = spinDirection ? y4 + yy4 : y4 - yy4;
                g.FillEllipse(new SolidBrush(Color.Blue), new Rectangle(new Point(x4, y4), new Size(2 * radius, 2 * radius)));//蓝圆 
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x4 + radius - 3, y4 + radius - 3), new Size(6, 6)));//蓝圆中点
            }

            limitAngle(5);
            if (visible[PurpleSolidCircle])
            {
                //limitAngle(5);
                int x5 = (int)(centerPoint.X - radius - (Distance + radius) * Math.Cos((angles[5] + 60) * Math.PI / 180));
                int yy5 = (int)((Distance + radius) * Math.Sin((angles[5] + 60) * Math.PI / 180));
                int y5 = centerPoint.Y - radius;// + yy5);
                y5 = spinDirection ? y5 - yy5 : y5 + yy5;
                g.FillEllipse(new SolidBrush(Color.Purple), new Rectangle(new Point(x5, y5), new Size(2 * radius, 2 * radius)));//紫圆 
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x5 + radius - 3, y5 + radius - 3), new Size(6, 6)));//紫圆中点
            }

            //g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x4 + radius - 3, y4 + radius - 3), new Size(6, 6)));//蓝圆中点
            //g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point(x5 + radius - 3, y5 + radius - 3), new Size(6, 6)));//紫圆中点

            pictureBox_Draw.Image = bitmap;
            g.Dispose();

            //}

            GC.Collect();
        }
        ///// <summary>
        ///// 画圈用的。获取size的大小
        ///// </summary>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public int getX(int index)
        //{
        //    int x = 0;
        //    if (directionFlag[index])
        //    {
        //        x = --tickCountCircles[index] * tickPixCircle[index];

        //        if (tickCountCircles[index] < tickCountMin) directionFlag[index] = false;

        //    }
        //    else
        //    {
        //        x = ++tickCountCircles[index] * tickPixCircle[index];

        //        if (tickCountCircles[index] > pictureBox_Draw.Width * maxCircleRadius / tickPixCircle[index]) directionFlag[index] = true;

        //    }
        //    return x;
        //}

        /// <summary>
        /// 旋转角度和速度控制。画圆用的。
        /// </summary>
        /// <param name="index"></param>
        public void limitAngle(int index)
        {
            angles[index] += speeds[index];
            if (angles[index] > 360)
            {
                angles[index] = speeds[index];
            }

            //angles[index] = spinDirection ? angles[index] : angles[index];
        }

        /// <summary>
        /// 鼠标或滚轮引起的大小改变。速度变化也在内（内切圆半径改变）
        /// </summary>
        /// <param name="addOrSub"></param>
        public void changeDistance(bool addOrSub)
        {
            if (runFlag)
            {
                //距离限制：大于某值时再加或小于某值时再小，都不行
                //if ((Distance >= maxDis && addOrSub) || (Distance < minDis && !addOrSub)) return;
                if ((Distance >= maxDis && addOrSub) || (Distance < minDis && !addOrSub))
                {
                    if (Distance >= maxDis && addOrSub)//还大->变快
                    {
                        speedClip++;
                        writeLogToOutput("Biggest!Faster...");

                    }
                    if (Distance < minDis && !addOrSub)//还小->变慢
                    {
                        speedClip--;
                        writeLogToOutput("Smallest!Slow...");

                    }

                    for (int i = 0; i < speeds.Length; i++)
                    {
                        speeds[i] = speedClip;
                    }

                    speedNormalFlag = false;
                    //return;
                }
                else
                {
                    if (!speedNormalFlag)
                    {
                        speedNormalFlag = true;
                        speedClip = 10;
                        for (int i = 0; i < speeds.Length; i++)
                        {
                            speeds[i] = speedClip;
                        }
                        writeLogToOutput("Speed Normal...");

                    }

                    if (lastAddOrSunFlag != addOrSub)
                    {
                        writeLogToOutput(addOrSub ? "Become Big....." : "Become Samll.....");
                    }
                    lastAddOrSunFlag = addOrSub;
                    //distance2 += addOrSub ? distanceChangeGab : -distanceChangeGab;
                    //distance2 = Math.Max(distance2, maxDis);
                    //distance2 = Math.Min(distance2, minDis);

                    Distance += addOrSub ? disClip : -disClip;

                }

            }
        }

        /// <summary>
        /// 左边进度条引起的大小改变。进度条的委托触发（内切圆半径改变）
        /// </summary>
        /// <param name="newValue"></param>
        private void barChangeDis(int newValue)
        {
            if (runFlag)
            {
                Distance = newValue;

            }
        }

        public void load()
        {
            bitmap = new Bitmap(pictureBox_Show.Width, pictureBox_Show.Height);

            point = new Point(pictureBox_Show.Width / 2, pictureBox_Show.Height / 2);

            maxDis = (int)(Math.Sqrt((Math.Pow(pictureBox_Show.Width, 2) + Math.Pow(pictureBox_Show.Height, 2))) / 4);
            minDis = 10;

            myProgressBar1.SetProgressBarMaxValue(maxDis + disClip);
            myProgressBar1.SetProgressBarMinValue(minDis - disClip);

        }

        /// <summary>
        /// 鼠标或滚轮改变distance之后，传给进度条
        /// </summary>
        private void showDistance()
        {
            //progressBar_Distance.Value = distance;
            //label_CurrentDis.Text = progressBar_Distance.Value.ToString();



            //label_CurrentDis.Location = new Point(label_CurrentDis.Location.X, (int)(progressBar_Distance.Location.Y + progressBar_Distance.Height - progressBar_Distance.Value / ((maxDis - minDis) * (100.0 / progressBar_Distance.Height))));
            myProgressBar1.SetProgressBarValue(Distance);
        }

        public void writeLogToOutput(string message)
        {
            richTextBox_Output.AppendText(DateTime.Now.ToShortTimeString() + "->" + message + Environment.NewLine);
        }

        ///// <summary>
        ///// 画线。每次创建新Bitmap。出于撤销功能考虑。
        ///// </summary>
        //public void copyDraw()
        //{
        //    Bitmap temp1 = (Bitmap)bitmap.Clone();

        //    bitmap = new Bitmap(pictureBox_Draw.Width, pictureBox_Draw.Height);

        //    int width = Math.Min(temp1.Width, bitmap.Width);
        //    int height = Math.Min(temp1.Height, bitmap.Height);

        //    for (int i = 0; i < width; i++)
        //    {
        //        for (int j = 0; j < height; j++)
        //        {
        //            bitmap.SetPixel(i, j, temp1.GetPixel(i, j));
        //        }
        //    }

        //    pictureBox_Draw.Image = bitmap;

        //}

        #endregion

        #region 界面事件处理

        private void FormMain_Load(object sender, EventArgs e)
        {
            isLoaded = true;

            pictureBox_Show.MouseWheel += pictureBox_Show_MouseWheel;
            myProgressBar1.BarChangeValue += barChangeDis;

            checkBox_CenterPoint.Checked = visible[CenterPoint];
            checkBox_RedCircle.Checked = visible[RedCircle];
            checkBox_Red.Checked = visible[RedSolidCircle];
            checkBox_Green.Checked = visible[GreenSolidCircle];
            checkBox_Yellow.Checked = visible[YellowSolidCircle];
            checkBox_Black.Checked = visible[BlackSolidCircle];
            checkBox_Blue.Checked = visible[BlueSolidCircle];
            checkBox_Purple.Checked = visible[PurpleSolidCircle];

            groupBox_visible.Enabled = false;

            load();

            writeLogToOutput("Try to click Run button.");

            isLoaded = false;
        }

        private void pictureBox_Show_MouseEnter(object sender, EventArgs e)
        {
            if (isLoaded) return;

            //Cursor cur = new Cursor("Handwriting.cur");
            //Cursor = cur;

            mouseEnterShowAreaFlag = true;

            pictureBox_Show.Focus();

            //writeLogToOutput(point.ToString());

            //writeLogToOutput((sender as PictureBox).Name);
        }

        private void pictureBox_Show_MouseLeave(object sender, EventArgs e)
        {
            if (isLoaded) return;

            Cursor = Cursors.Default;

            mouseEnterShowAreaFlag = false;

            if (point == null || point.X != pictureBox_Show.Width / 2 || point.Y != pictureBox_Show.Height / 2)
            {
                point = new Point(pictureBox_Show.Width / 2, pictureBox_Show.Height / 2);
            }

        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            if (timer_Run.Enabled)
            {
                writeLogToOutput("Already running...");
                return;
            }
            writeLogToOutput("Running...");

            groupBox_visible.Enabled = true;

            runFlag = true;

            showDistance();

            timer_Run.Start();

        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (!timer_Run.Enabled)
            {
                writeLogToOutput("No running or already stopped...");
                return;

            }
            writeLogToOutput("Stopped...");

            groupBox_visible.Enabled = false;

            runFlag = false;

            timer_Run.Stop();

        }

        private void timer_Run_Tick(object sender, EventArgs e)
        {
            //drawSpinCircle(Color.Red, pictureBox_Show);
            //drawSpinCircle(new Point(pictureBox_Show.Width/2, pictureBox_Show.Height/2), pictureBox_Show);

            try
            {
                drawSpinCircle(point, pictureBox_Show);
                using (Bitmap temp = (Bitmap)(pictureBox_Show.Image).Clone())
                {
                    if (temp != null)
                    {
                        System.IntPtr iconHandle = temp.GetHicon();
                        System.Drawing.Icon icon = Icon.FromHandle(iconHandle);
                        this.Icon = icon;
                    }
                }

            }
            catch (Exception ex)
            {
                //writeLogToOutput(ex.Message);
            }
        }

        private void pictureBox_Show_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLoaded) return;

            if (mouseEnterShowAreaFlag && runFlag)
            {
                if (point == null)
                {
                    point = new Point();
                }
                point = e.Location;

                //writeLogToOutput(point.ToString());
                label1.Text = point.X.ToString();
                label2.Text = point.Y.ToString();
            }
        }

        private void pictureBox_Show_MouseDown(object sender, MouseEventArgs e)
        {
            if (isLoaded) return;

            writeLogToOutput(e.Button.ToString() + " down.");

            if (timer_ChangeDistance.Enabled) return;

            if (e.Button == MouseButtons.Left)
            {
                distanceAddOrSubFlag = true;

            }
            else if (e.Button == MouseButtons.Right)
            {
                distanceAddOrSubFlag = false;
            }

            timer_ChangeDistance.Start();

        }

        private void pictureBox_Show_MouseUp(object sender, MouseEventArgs e)
        {
            if (isLoaded) return;

            writeLogToOutput(e.Button.ToString() + " up.");

            timer_ChangeDistance.Stop();
        }

        private void richTextBox_Output_TextChanged(object sender, EventArgs e)
        {
            richTextBox_Output.ScrollToCaret();

        }

        private void timer_ChangeDistance_Tick(object sender, EventArgs e)
        {
            changeDistance(distanceAddOrSubFlag);

            showDistance();

        }

        private void pictureBox_Show_SizeChanged(object sender, EventArgs e)
        {
            label3.Text = pictureBox_Show.Size.Width.ToString();
            label4.Text = pictureBox_Show.Size.Height.ToString();

            load();
        }

        private void pictureBox_Show_MouseWheel(object sender, MouseEventArgs e)
        {

            label5.Text = e.Delta.ToString();

            bool flag = e.Delta > 0 ? true : false;

            changeDistance(flag);
            showDistance();

        }

        private void checkBox_Purple_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaded) return;

            //MessageBox.Show((sender as CheckBox).Name.Substring(9));

            switch ((sender as CheckBox).Name.Substring(9))
            {
                case "CenterPoint":
                    visible[CenterPoint] = checkBox_CenterPoint.Checked;

                    break;
                case "RedCircle":
                    visible[RedCircle] = checkBox_RedCircle.Checked;

                    break;
                case "Red":
                    visible[RedSolidCircle] = checkBox_Red.Checked;

                    break;
                case "Green":
                    visible[GreenSolidCircle] = checkBox_Green.Checked;

                    break;
                case "Yellow":
                    visible[YellowSolidCircle] = checkBox_Yellow.Checked;

                    break;
                case "Black":
                    visible[BlackSolidCircle] = checkBox_Black.Checked;

                    break;
                case "Blue":
                    visible[BlueSolidCircle] = checkBox_Blue.Checked;

                    break;
                case "Purple":
                    visible[PurpleSolidCircle] = checkBox_Purple.Checked;

                    break;
                default:
                    break;
            }

        }

        #endregion

    }
}
