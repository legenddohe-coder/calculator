#pragma warning disable WFO1000
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace calculator
{
    public enum ButtonIconType
    {
        None,
        Backspace,
        Gear,
        Dot,
        Plus,
        Minus,
        Multiply,
        Divide,
        Equal,
        PlusMinus,
        Close
    }

    public class ModernButton : Button
    {
        private bool _isHovered = false;
        private bool _isPressed = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderRadius { get; set; } = 32;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color NormalColor { get; set; } = Color.FromArgb(50, 50, 52);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HoverColor { get; set; } = Color.FromArgb(70, 70, 74);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PressedColor { get; set; } = Color.FromArgb(90, 90, 94);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TextCustomColor { get; set; } = Color.White;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderCustomColor { get; set; } = Color.Transparent;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderSize { get; set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ButtonIconType IconType { get; set; } = ButtonIconType.None;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsGlass { get; set; } = false;

        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
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
            _isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            Color currentBg = _isPressed ? PressedColor : (_isHovered ? HoverColor : NormalColor);

            // Draw parent background to prevent edge artifacts
            if (Parent != null)
            {
                using SolidBrush parentBrush = new(Parent.BackColor);
                g.FillRectangle(parentBrush, ClientRectangle);
            }

            // Fill rounded button
            using (GraphicsPath path = GetRoundedRectanglePath(rect, BorderRadius))
            {
                using (SolidBrush brush = new(currentBg))
                {
                    g.FillPath(brush, path);
                }

                // Glassmorphism: Refractive light catch on top rim
                if (IsGlass)
                {
                    using Pen glassLightPen = new(Color.FromArgb(70, 255, 255, 255), 1.2f);
                    g.DrawArc(glassLightPen, rect.X + 2, rect.Y + 1, rect.Width - 4, BorderRadius, 190, 160);

                    using Pen glassBorder = new(Color.FromArgb(40, 255, 255, 255), 1.0f);
                    g.DrawPath(glassBorder, path);
                }
                else if (BorderSize > 0 && BorderCustomColor != Color.Transparent)
                {
                    using Pen pen = new(BorderCustomColor, BorderSize);
                    g.DrawPath(pen, path);
                }
            }

            // Draw Icon or Text
            float cx = rect.Width / 2f;
            float cy = rect.Height / 2f;

            switch (IconType)
            {
                case ButtonIconType.Dot:
                    DrawDot(g, cx, cy);
                    break;

                case ButtonIconType.Plus:
                    DrawPlus(g, cx, cy);
                    break;

                case ButtonIconType.Minus:
                    DrawMinus(g, cx, cy);
                    break;

                case ButtonIconType.Multiply:
                    DrawMultiply(g, cx, cy);
                    break;

                case ButtonIconType.Divide:
                    DrawDivide(g, cx, cy);
                    break;

                case ButtonIconType.Equal:
                    DrawEqual(g, cx, cy);
                    break;

                case ButtonIconType.PlusMinus:
                    DrawPlusMinus(g, cx, cy);
                    break;

                case ButtonIconType.Close:
                    DrawClose(g, cx, cy);
                    break;

                case ButtonIconType.Backspace:
                    DrawBackspace(g, cx, cy);
                    break;

                case ButtonIconType.Gear:
                    DrawGear(g, cx, cy);
                    break;

                default:
                    Rectangle textRect = ClientRectangle;
                    textRect.Y -= 1;
                    TextRenderer.DrawText(
                        g,
                        Text,
                        Font,
                        textRect,
                        TextCustomColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine
                    );
                    break;
            }
        }

        private void DrawDot(Graphics g, float cx, float cy)
        {
            float r = 3.6f;
            using SolidBrush brush = new(TextCustomColor);
            g.FillEllipse(brush, cx - r, cy - r, r * 2, r * 2);
        }

        private void DrawPlus(Graphics g, float cx, float cy)
        {
            float len = 10f;
            using Pen pen = new(TextCustomColor, 2.4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy, cx + len, cy);
            g.DrawLine(pen, cx, cy - len, cx, cy + len);
        }

        private void DrawMinus(Graphics g, float cx, float cy)
        {
            float len = 10f;
            using Pen pen = new(TextCustomColor, 2.4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy, cx + len, cy);
        }

        private void DrawMultiply(Graphics g, float cx, float cy)
        {
            float len = 7.5f;
            using Pen pen = new(TextCustomColor, 2.4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy - len, cx + len, cy + len);
            g.DrawLine(pen, cx - len, cy + len, cx + len, cy - len);
        }

        private void DrawDivide(Graphics g, float cx, float cy)
        {
            float len = 10f;
            using Pen pen = new(TextCustomColor, 2.4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy, cx + len, cy);

            float dotR = 2.4f;
            using SolidBrush brush = new(TextCustomColor);
            g.FillEllipse(brush, cx - dotR, cy - 7f - dotR, dotR * 2, dotR * 2);
            g.FillEllipse(brush, cx - dotR, cy + 7f - dotR, dotR * 2, dotR * 2);
        }

        private void DrawEqual(Graphics g, float cx, float cy)
        {
            float len = 10f;
            float dist = 4.5f;
            using Pen pen = new(TextCustomColor, 2.4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy - dist, cx + len, cy - dist);
            g.DrawLine(pen, cx - len, cy + dist, cx + len, cy + dist);
        }

        private void DrawPlusMinus(Graphics g, float cx, float cy)
        {
            float len = 7f;
            using Pen pen = new(TextCustomColor, 2.2f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(pen, cx - len, cy - 4f, cx + len, cy - 4f);
            g.DrawLine(pen, cx, cy - 4f - len, cx, cy - 4f + len);
            g.DrawLine(pen, cx - len, cy + 8f, cx + len, cy + 8f);
        }

        private void DrawClose(Graphics g, float cx, float cy)
        {
            float size = 4.5f;
            using Pen pen = new(TextCustomColor, 2.0f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            g.DrawLine(pen, cx - size, cy - size, cx + size, cy + size);
            g.DrawLine(pen, cx + size, cy - size, cx - size, cy + size);
        }

        private void DrawBackspace(Graphics g, float cx, float cy)
        {
            cx += 1f;
            using Pen pen = new(TextCustomColor, 2.0f) { LineJoin = LineJoin.Round, StartCap = LineCap.Round, EndCap = LineCap.Round };

            PointF[] points =
            [
                new(cx - 12f, cy),
                new(cx - 5f, cy - 8f),
                new(cx + 10f, cy - 8f),
                new(cx + 10f, cy + 8f),
                new(cx - 5f, cy + 8f)
            ];
            g.DrawPolygon(pen, points);

            float crossX = cx + 2.5f;
            float crossR = 3.2f;
            using Pen crossPen = new(TextCustomColor, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawLine(crossPen, crossX - crossR, cy - crossR, crossX + crossR, cy + crossR);
            g.DrawLine(crossPen, crossX - crossR, cy + crossR, crossX + crossR, cy - crossR);
        }

        private void DrawGear(Graphics g, float cx, float cy)
        {
            float rOuter = 7.0f;
            int teeth = 6;
            using Pen toothPen = new(TextCustomColor, 3.2f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

            for (int i = 0; i < teeth; i++)
            {
                double angle = i * Math.PI / 3.0;
                float tx1 = cx + (float)(Math.Cos(angle) * (rOuter + 3.0f));
                float ty1 = cy + (float)(Math.Sin(angle) * (rOuter + 3.0f));
                float tx0 = cx + (float)(Math.Cos(angle) * (rOuter - 1.0f));
                float ty0 = cy + (float)(Math.Sin(angle) * (rOuter - 1.0f));
                g.DrawLine(toothPen, tx0, ty0, tx1, ty1);
            }

            using Pen ringPen = new(TextCustomColor, 2.2f);
            g.DrawEllipse(ringPen, cx - rOuter, cy - rOuter, rOuter * 2, rOuter * 2);
            
            float holeR = 2.8f;
            using SolidBrush holeBrush = new(NormalColor);
            g.FillEllipse(holeBrush, cx - holeR, cy - holeR, holeR * 2, holeR * 2);
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
