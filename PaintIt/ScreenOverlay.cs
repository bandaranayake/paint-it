using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintIt
{
    public partial class ScreenOverlay : Form
    {
        private int _antOffset;
        private Pen _dotPen;
        private Point _pt1;
        private Point _pt2;
        private Point _pos;
        private Size _dim;

        public Point Pos { get => _pos; set => _pos = value; }
        public Size Dim { get => _dim; set => _dim = value; }

        public ScreenOverlay(Bitmap screenBmp)
        {
            InitializeComponent();
            float[] dashValues = { 5, 5 };
            _dotPen = new Pen(Color.Red, 1);
            _dotPen.DashStyle = DashStyle.Custom;
            _dotPen.DashPattern = dashValues;
            pbxOverlay.Image = screenBmp;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _antOffset++;
            _antOffset %= 10;
            pbxOverlay.Refresh();
        }

        private void ScreenOverlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void pbxOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            _pt1 = MousePosition;
            _pt2 = MousePosition;
        }

        private void pbxOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pt2 = MousePosition;
            }
        }

        private void pbxOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            int width = Math.Abs(_pt1.X - _pt2.X);
            int height = Math.Abs(_pt1.Y - _pt2.Y);

            if (width > 2 && height > 2)
            {
                _dim.Width = width;
                _dim.Height = height;

                if (_pt1.X > _pt2.X && _pt1.Y > _pt2.Y)
                {
                    _pos.X = _pt2.X;
                    _pos.Y = _pt2.Y;
                }
                else if (_pt1.X > _pt2.X && _pt1.Y < _pt2.Y)
                {
                    _pos.X = _pt2.X;
                    _pos.Y = _pt1.Y;
                }
                else if (_pt1.X < _pt2.X && _pt1.Y > _pt2.Y)
                {
                    _pos.X = _pt1.X;
                    _pos.Y = _pt2.Y;
                }
                else
                {
                    _pos.X = _pt1.X;
                    _pos.Y = _pt1.Y;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void pbxOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (!_pt1.Equals(_pt2))
            {
                int width = Math.Abs(_pt1.X - _pt2.X);
                int height = Math.Abs(_pt1.Y - _pt2.Y);

                if (width > 2 && height > 2)
                {
                    _dotPen.DashOffset = _antOffset;
                    e.Graphics.DrawImageUnscaled(pbxOverlay.Image, 0, 0);

                    if (_pt1.X > _pt2.X && _pt1.Y > _pt2.Y)
                    {
                        e.Graphics.DrawRectangle(_dotPen, _pt2.X, _pt2.Y, width, height);
                    }
                    else if (_pt1.X > _pt2.X && _pt1.Y < _pt2.Y)
                    {
                        e.Graphics.DrawRectangle(_dotPen, _pt2.X, _pt1.Y, width, height);
                    }
                    else if (_pt1.X < _pt2.X && _pt1.Y > _pt2.Y)
                    {
                        e.Graphics.DrawRectangle(_dotPen, _pt1.X, _pt2.Y, width, height);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(_dotPen, _pt1.X, _pt1.Y, width, height);
                    }
                }
            }
        }
    }
}
