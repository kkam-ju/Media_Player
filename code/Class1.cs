using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Music123
{
    public class CircleSlider : Control
    {
        public CircleSlider()
        {
            this.Size = new Size(12, 12);

            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                       ControlStyles.UserPaint |
                       ControlStyles.AllPaintingInWmPaint |
                       ControlStyles.OptimizedDoubleBuffer |
                       ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;  // 투명 배경

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // 부모 배경을 복사해 그려서 투명 효과처럼 보이게 함
            if (this.Parent != null)
            {
                Graphics g = pevent.Graphics;
                Rectangle rect = new Rectangle(Point.Empty, this.Size);

                using (Bitmap bmp = new Bitmap(this.Parent.ClientSize.Width, this.Parent.ClientSize.Height))
                {
                    this.Parent.DrawToBitmap(bmp, this.Parent.ClientRectangle);
                    g.DrawImage(bmp, -this.Location.X, -this.Location.Y);
                }
            }
            else
            {
                base.OnPaintBackground(pevent);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Brush b = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(b, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}