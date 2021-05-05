using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PaintIt
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int _LeftDown = 0x02;
        private const int _LeftUp = 0x04;

        private Point _lastPoint = new Point(-1, -1);
        private uint _pid;

        private Mat _original;
        private Mat _img = new Mat();
        private ThresholdType _thresholdType = ThresholdType.Binary;
        private double _maxIntensity;

        public Main()
        {
            InitializeComponent();
        }

        private void LeftMouseClick(int xpos1, int ypos1, int xpos2, int ypos2)
        {
            SetCursorPos(xpos1, ypos1);
            mouse_event(_LeftDown, xpos1, ypos1, 0, 0);
            SetCursorPos(xpos2, ypos2);
            mouse_event(_LeftUp, xpos2, ypos2, 0, 0);

            _lastPoint = new Point(xpos2, ypos2);
        }

        private uint GetActiveProcess()
        {
            uint pid;
            GetWindowThreadProcessId(GetForegroundWindow(), out pid);
            return pid;
        }

        private void Draw(Mat image, int x, int y)
        {
            VectorOfVectorOfPoint cnt = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, cnt, null, RetrType.List, ChainApproxMethod.ChainApproxNone);

            Point[][] pts = cnt.ToArrayOfArray();

            for (int i = 0; i < pts.Length; i++)
            {
                for (int j = 0; j < pts[i].Length; j++)
                {
                    Point pt = pts[i][j];
                    if ((_lastPoint.X != -1 && !_lastPoint.Equals(MousePosition)) || _pid != GetActiveProcess())
                    {
                        return;
                    }

                    pt.X += x;
                    pt.Y += y;

                    LeftMouseClick(pt.X, pt.Y, pt.X, pt.Y);
                    Thread.Sleep(10);
                }
            }
            Fill(image, x, y);
        }

        private void Fill(Mat image, int x, int y)
        {
            Array data = image.GetData();

            for (int i = 0; i < image.Rows; i++)
            {
                int c = 0;
                for (int j = 0; j < image.Cols; j++)
                {
                    if ((_lastPoint.X != -1 && !_lastPoint.Equals(MousePosition)) || _pid != GetActiveProcess())
                    {
                        return;
                    }

                    if ((byte)data.GetValue(i, j) == _maxIntensity)
                    {
                        if (j == image.Cols - 1 && c > 0)
                        {
                            int x1 = x + j;
                            int y1 = y + i;

                            LeftMouseClick(x1 - c, y1, x1, y1);
                            c = 0;
                            Thread.Sleep(10);
                        }
                        else
                        {
                            c++;
                        }
                    }
                    else if (c > 0)
                    {
                        int x1 = x + j - 1;
                        int y1 = y + i - 1;

                        LeftMouseClick(x1 - c, y1, x1, y1);
                        c = 0;
                        Thread.Sleep(10);
                    }
                }
            }
        }

        private void radThresh_CheckedChanged(object sender, EventArgs e)
        {
            if (radBin.Checked)
            {
                _thresholdType = ThresholdType.Binary;
            }
            else if (radBinInv.Checked)
            {
                _thresholdType = ThresholdType.BinaryInv;
            }
            else if (radOTSU.Checked)
            {
                _thresholdType = ThresholdType.Otsu;
            }

            if (_original != null)
            {
                CvInvoke.Threshold(_original, _img, trackBarThresh.Value, _maxIntensity, _thresholdType);
                pbxPreview.BackgroundImage = _img.Bitmap;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblPixel.Text = "Threshold Value: " + trackBarThresh.Value.ToString();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_original == null)
            {
                MessageBox.Show("No image selected. Click 'Browse' to select an image.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Hide();
                Thread.Sleep(500);

                Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                using (Graphics g = Graphics.FromImage(image))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, image.Size, CopyPixelOperation.SourceCopy);
                    g.DrawRectangle(Pens.Red, 1, 1, image.Width - 3, image.Height - 3);
                }

                ScreenOverlay overlay = new ScreenOverlay(image);
                Show();

                if (overlay.ShowDialog() == DialogResult.OK)
                {
                    WindowState = FormWindowState.Minimized;
                    image.Dispose();

                    CvInvoke.Resize(_img, _img, new Size(_img.Cols, _img.Rows));
                    CvInvoke.BitwiseNot(_img, _img);

                    Thread.Sleep(2000);

                    _lastPoint = new Point(-1, -1);
                    _pid = GetActiveProcess();

                    Draw(_img, overlay.Pos.X, overlay.Pos.Y);
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open";
                    dlg.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _original = CvInvoke.Imread(dlg.FileName, ImreadModes.Grayscale);

                        double[] minValue, maxValue;
                        Point[] minLocation, maxLocation;
                        _original.MinMax(out minValue, out maxValue, out minLocation, out maxLocation);
                        _maxIntensity = maxValue[0];
                        trackBarThresh.Maximum = (int)_maxIntensity;

                        CvInvoke.Threshold(_original, _img, trackBarThresh.Value, _maxIntensity, _thresholdType);
                        pbxPreview.BackgroundImage = _img.Bitmap;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBarThresh_Scroll(object sender, EventArgs e)
        {
            if (_original != null)
            {
                CvInvoke.Threshold(_original, _img, trackBarThresh.Value, _maxIntensity, _thresholdType);
                pbxPreview.BackgroundImage = _img.Bitmap;
            }
            lblPixel.Text = "Threshold Value: " + trackBarThresh.Value.ToString();
        }
    }
}
