using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private uint GetActiveProcess()
        {
            uint pid;
            GetWindowThreadProcessId(GetForegroundWindow(), out pid);
            return pid;
        }

        private void Draw(Bitmap image, int x, int y)
        {
            for (int i = 0; i < image.Height; i++)
            {
                int c = 0;
                for (int j = 0; j < image.Width; j++)
                {
                    Color oc = image.GetPixel(j, i);
                    uint xx = GetActiveProcess();
                    if ((_lastPoint.X != -1 && !_lastPoint.Equals(MousePosition)) || _pid != xx)
                    {
                        return;
                    }

                    if ((int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11)) < 110)
                    {
                        if (j == image.Width - 1 && c > 0)
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

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (pbxPreview.Image == null)
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
                    Bitmap bmp = ResizeImage(pbxPreview.Image, overlay.Dim.Width, overlay.Dim.Height);
                    Thread.Sleep(1000);

                    _lastPoint = new Point(-1, -1);
                    _pid = GetActiveProcess();

                    Draw(bmp, overlay.Pos.X, overlay.Pos.Y);
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
                        using (Image im = Image.FromFile(dlg.FileName))
                        {
                            pbxPreview.Image = new Bitmap(im);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
