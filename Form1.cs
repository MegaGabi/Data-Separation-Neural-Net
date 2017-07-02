using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace NN_matricies
{
    public partial class Form1 : Form
    {
        Color paint = Color.Red;
        bool    painting = false,
                InLearningProcess = false,
                stop = false;
        int width, height;

        enum coloridx { r, g, b};

        Dictionary<PointF, double[]> data = new Dictionary<PointF, double[]>();
        NeuralNetwork nn = new NeuralNetwork();

        private delegate void SetControlPropertyThreadSafeDelegate  (
                                                                    Control control,
                                                                    string propertyName,
                                                                    object propertyValue
                                                                    );

        public static void SetControlPropertyThreadSafe (
                                                        Control control,
                                                        string propertyName,
                                                        object propertyValue
                                                        )
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        public Form1()
        {
            InitializeComponent();
            width = (pnl_DrawHere.Width / 100);
            height = (pnl_DrawHere.Height / 100);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Drawing(e);
        }

        private void Drawing(MouseEventArgs e)
        {
            float x = (float)(e.X / width) * width, y = (float)(e.Y / height) * height;

            x_pos.Text = "x:" + x;
            y_pos.Text = "y:" + y;

            if (painting && !InLearningProcess)
            {
                var g = pnl_DrawHere.CreateGraphics();

                if (e.Button == MouseButtons.Left)
                {
                    g.FillRectangle(new SolidBrush(paint), x, y, width, height);

                    try
                    {
                        data.Add(new PointF(x / pnl_DrawHere.Width, y / pnl_DrawHere.Height), ColorToIndex(paint));
                    }
                    catch
                    {
                        data[new PointF(x / pnl_DrawHere.Width, y / pnl_DrawHere.Height)] = ColorToIndex(paint);
                    }
                }
                else
                {
                    g.FillRectangle(Brushes.White, x, y, width, height);

                    try
                    {
                        data.Remove(new PointF(x / pnl_DrawHere.Width, y / pnl_DrawHere.Height));
                    }
                    catch { }
                }

                g.Flush();
            }
        }

        public double[] ColorToIndex(Color rgb)
        {
            return  rgb.R == 255 ?  new double[] { 1, 0, 0 } :
                    rgb.B == 255 ?  new double[] { 0, 0, 1 } :
                                    new double[] { 0, 1, 0 };
        }

        public Color ColorFromIndex(double[,] rgb)
        {
            double i = rgb.Reshape().IndexOf(rgb.Max());
            if (rgb.Max() == 0) return Color.Black;
            return i == 0 ? Color.Red : i == 1 ? Color.Green : i == 2 ? Color.Blue : Color.Black;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;

            Drawing(e);
        }

        private void rb_Green_CheckedChanged(object sender, EventArgs e)
        {
            paint = rb_Red.Checked ? Color.Red : rb_Blue.Checked ? Color.Blue : rb_Green.Checked ? Color.Green : Color.Black;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var g = pnl_DrawHere.CreateGraphics();

            g.Clear(Color.White);
            g.Flush();

            pnl_Rbs.Invalidate();

            data.Clear();
            nn.Clear();
        }

        private void btn_Amnesia_Click(object sender, EventArgs e)
        {
            nn.Clear();
        }

        private void pnl_DrawHere_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var thrd = new Thread(() => { LearnThread(); stop = false;});
            thrd.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void LearnThread()
        {
            SetControlPropertyThreadSafe(btn_Learn, "Enabled", false);
            SetControlPropertyThreadSafe(btn_Clear, "Enabled", false);
            SetControlPropertyThreadSafe(btn_Amnesia, "Enabled", false);
            SetControlPropertyThreadSafe(btn_Stop, "Enabled", true);
            SetControlPropertyThreadSafe(l_CurrIter, "Visible", true);
            InLearningProcess = true;

            int it_cnt = (int)nud_IterationsNumber.Value;
            int it_show = (int)((it_cnt / 20.0) < 1.0 ? 1 : it_cnt / 20.0);

            for (int itr = 0; itr < it_cnt && !stop; itr++)
            {
                nn.Learn(data);

                if (((itr % (it_show) == 0) && chkbx_RdrwInTheEnd.Checked == false)
                    ||
                    (itr == it_cnt - 1))
                {
                    var g = pnl_DrawHere.CreateGraphics();

                    int sizex = (pnl_DrawHere.Width / width), sizey = (pnl_DrawHere.Height / height);

                    for (int i = 0; i < sizey; i++)
                    {
                        float x = 0, y = 0;
                        double[,] ans = null;
                        for (int j = 0; j < sizex; j++)
                        {
                            x = j * width;
                            y = i * height;

                            if (!data.ContainsKey(new PointF(x / pnl_DrawHere.Width, y / pnl_DrawHere.Height)))
                            {
                                ans = nn.FeedForward(new PointF(x / pnl_DrawHere.Width, y / pnl_DrawHere.Height));
                                var res = ColorFromIndex(ans);
                                Color neural = (res == Color.Red ? Color.LightPink : res == Color.Green ? Color.LightGreen : Color.LightBlue);
                                g.FillRectangle(new SolidBrush(neural), x, y, width, height);
                            }
                        }
                    }

                    pnl_Rbs.Invalidate();
                }

                SetControlPropertyThreadSafe(l_CurrIter, "Text", "Iteration: " + itr);
            }

            SetControlPropertyThreadSafe(btn_Learn, "Enabled", true);
            SetControlPropertyThreadSafe(btn_Clear, "Enabled", true);
            SetControlPropertyThreadSafe(btn_Amnesia, "Enabled", true);
            SetControlPropertyThreadSafe(btn_Stop, "Enabled", false);
            SetControlPropertyThreadSafe(l_CurrIter, "Visible", false);
            InLearningProcess = false;
        }
    }
}
