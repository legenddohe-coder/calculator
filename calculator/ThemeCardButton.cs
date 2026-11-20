#pragma warning disable WFO1000
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace calculator
{
    public class ThemeCardButton : Control
    {
        private bool _isHovered = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AppTheme CardTheme { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected { get; set; } = false;

        public ThemeCardButton(AppTheme theme)
        {
            CardTheme = theme;
            Size = new Size(154, 84);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            // Clear parent background
            if (Parent != null)
            {
                using SolidBrush parentBrush = new(Parent.BackColor);
                g.FillRectangle(parentBrush, ClientRectangle);
            }

            using GraphicsPath path = GetRoundedRectanglePath(rect, 13);

            // Card background using elevated CardBackground for contrast
            Color fill = CardTheme.CardBackground;
            if (_isHovered)
            {
                int delta = CardTheme.IsDark ? 14 : -8;
                fill = Color.FromArgb(
                    Math.Clamp(fill.R + delta, 0, 255),
                    Math.Clamp(fill.G + delta, 0, 255),
                    Math.Clamp(fill.B + delta, 0, 255)
                );
            }

            using (SolidBrush brush = new(fill))
            {
                g.FillPath(brush, path);
            }

            // Glassmorphism light catch top rim
            if (CardTheme.IsGlass)
            {
                using Pen glassRim = new(Color.FromArgb(70, 255, 255, 255), 1.2f);
                g.DrawLine(glassRim, rect.Left + 12, rect.Top + 1, rect.Right - 12, rect.Top + 1);
            }

            // Outer Border
            Color borderCol = IsSelected ? CardTheme.AccentColor : Color.FromArgb(CardTheme.IsDark ? 50 : 35, 128, 128, 128);
            float bWidth = IsSelected ? 2.0f : 1.0f;
            using (Pen pen = new(borderCol, bWidth))
            {
                g.DrawPath(pen, path);
            }

            // --- Top Row: 3-Dot Swatches (y = 22) ---
            float dotR = 5.5f;
            float topY = 22f;

            // Dot 1: Background
            using (SolidBrush b1 = new(CardTheme.BackgroundColor))
            using (Pen p1 = new(Color.FromArgb(90, 128, 128, 128), 1f))
            {
                g.FillEllipse(b1, 18f - dotR, topY - dotR, dotR * 2, dotR * 2);
                g.DrawEllipse(p1, 18f - dotR, topY - dotR, dotR * 2, dotR * 2);
            }

            // Dot 2: Button
            using (SolidBrush b2 = new(CardTheme.NumberBtnColor))
            using (Pen p2 = new(Color.FromArgb(90, 128, 128, 128), 1f))
            {
                g.FillEllipse(b2, 34f - dotR, topY - dotR, dotR * 2, dotR * 2);
                g.DrawEllipse(p2, 34f - dotR, topY - dotR, dotR * 2, dotR * 2);
            }

            // Dot 3: Operator Accent
            using (SolidBrush b3 = new(CardTheme.OperatorBtnColor))
            {
                g.FillEllipse(b3, 50f - dotR, topY - dotR, dotR * 2, dotR * 2);
            }

            // --- Top Row: Radio / Checkmark Indicator (Top-Right, y = 22) ---
            float radioX = rect.Width - 18f;
            float radioR = 7.5f;

            if (IsSelected)
            {
                using SolidBrush radioFill = new(CardTheme.AccentColor);
                g.FillEllipse(radioFill, radioX - radioR, topY - radioR, radioR * 2, radioR * 2);

                Color checkCol = CardTheme.IsDark ? Color.Black : Color.White;
                using Pen checkPen = new(checkCol, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                g.DrawLine(checkPen, radioX - 3.5f, topY + 0.5f, radioX - 1.0f, topY + 3.0f);
                g.DrawLine(checkPen, radioX - 1.0f, topY + 3.0f, radioX + 3.5f, topY - 2.5f);
            }
            else
            {
                using Pen radioPen = new(Color.FromArgb(70, 128, 128, 128), 1.2f);
                g.DrawEllipse(radioPen, radioX - radioR, topY - radioR, radioR * 2, radioR * 2);
            }

            // --- Bottom Row: Clean Single-Line Theme Name (y = 48) ---
            Rectangle textRect = new(12, 46, rect.Width - 24, 30);
            TextRenderer.DrawText(
                g,
                CardTheme.Name,
                new Font("Segoe UI", 9.25F, FontStyle.Bold),
                textRect,
                CardTheme.PrimaryTextColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding
            );
        }

        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new();
            int diameter = radius * 2;
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Size size = new(diameter, diameter);
            Rectangle arc = new(rect.Location, size);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
