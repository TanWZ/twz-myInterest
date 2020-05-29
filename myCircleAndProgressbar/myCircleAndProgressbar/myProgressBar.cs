using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myCircleAndProgressbar
{
    /// <summary>
    /// 自定义控件--基于progressBar。
    /// 多了上下限显示和当前值显示。
    /// 以及鼠标点击进度条设置值。
    /// 使用前设置最大最小值（默认0-100）以及当前值。
    /// 单击进度条设置新值，委托BarChangeValue。可以挂载相应事件
    /// </summary>
    public partial class MyProgressBar : UserControl
    {
        /// <summary>
        /// 网上找到的，把进度条竖起来并从下到上增加。似乎和窗口样式相关？有待探索
        /// </summary>
        public class VerticalProgressBar : ProgressBar
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x04;
                    return cp;
                }
            }
        }

        public MyProgressBar()
        {
            InitializeComponent();

            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            label_Top.Text = progressBar1.Maximum.ToString();
            label_Bottom.Text = progressBar1.Minimum.ToString();
        }

        public delegate void BarChangeValueDelegate(int newValue);
        /// <summary>
        /// 进度条值产生变化。可以进行相应处理。
        /// </summary>
        public BarChangeValueDelegate BarChangeValue;

        /// <summary>
        /// 设置进度条当前值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetProgressBarValue(int value)
        {
            try
            {
                //Invoke(new Action(() =>
                //{
                //    progressBar1.Value = value;
                //    System.Threading.Thread.Sleep(500);
                //    changeLabelLocation();
                //}));

                progressBar1.Value = value;
                //System.Threading.Thread.Sleep(500);
                changeLabelLocation();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置进度条最大值。失败则恢复默认值100
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public bool SetProgressBarMaxValue(int maxValue)
        {
            try
            {
                progressBar1.Maximum = maxValue;
                label_Top.Text = progressBar1.Maximum.ToString();

                changeLabelLocation();

            }
            catch (Exception ex)
            {
                maxValue = 100;
                progressBar1.Maximum = maxValue;
                label_Top.Text = progressBar1.Maximum.ToString();

                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置进度条最小值。失败则恢复默认值0
        /// </summary>
        /// <param name="minValue"></param>
        /// <returns></returns>
        public bool SetProgressBarMinValue(int minValue)
        {
            try
            {
                progressBar1.Minimum = minValue;
                label_Bottom.Text = progressBar1.Minimum.ToString();

                changeLabelLocation();

            }
            catch (Exception ex)
            {
                minValue = 0;
                progressBar1.Minimum = minValue;
                label_Bottom.Text = progressBar1.Minimum.ToString();

                return false;
            }
            return true;
        }


        //下面是private方法和变量

        /// <summary>
        /// 中间label用来显示当前值，和进度一起移动。Y的上下限是其他两个label的Y。
        /// </summary>
        private void changeLabelLocation()
        {
            double x = progressBar1.Maximum - progressBar1.Value;
            double y = progressBar1.Maximum - progressBar1.Minimum;
            int z = label_Bottom.Location.Y - label_Top.Location.Y;
            label_Move.Text = progressBar1.Value.ToString();
            label_Move.Location = new Point(0, (int)((x) / (y) * z));//progressBar1.Height
        }

        /// <summary>
        /// 单击进度条，把进度条拉到当前选择位置，值一起改变。并通知外界
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            //
            //toolTip1.SetToolTip(progressBar1, e.Y.ToString());
            SetProgressBarValue(v);

            BarChangeValue?.Invoke(v);
        }

        ToolTip toolTip1 = new ToolTip();
        int pp = 0;
        int v = 0;//经过换算的值，换算过程在下面。配合外面用的。不是鼠标click点下的e.Y
        /// <summary>
        /// 鼠标位于进度条上时，显示当前位置的值。解决了闪烁。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            //label_Move.Text = e.Y.ToString();
            if (e.Y != pp)//这个判断解决了提示框闪烁
            {
                v = progressBar1.Maximum - e.Y * (progressBar1.Maximum - progressBar1.Minimum) / progressBar1.Height;
                toolTip1.SetToolTip(progressBar1, v.ToString());
                pp = e.Y;
            }
        }

    }

}
