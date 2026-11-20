using System.Globalization;
using System.Runtime.InteropServices;

namespace calculator
{
    public partial class Form1 : Form
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        private double _firstNumber = 0;
        private string _pendingOperation = "";
        private bool _isNewEntry = true;
        private bool _hasError = false;

        private readonly List<ThemeCardButton> _themeCards = new();

        public Form1()
        {
            InitializeComponent();

            BuildThemeCardsInOverlay();

            ThemeManager.ThemeChanged += OnThemeChanged;
            ApplyCurrentTheme();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyCurrentTheme();
        }

        private void BuildThemeCardsInOverlay()
        {
            int startY = 66;
            int cardWidth = 154;
            int cardHeight = 84;
            int cardGap = 12;

            for (int i = 0; i < Themes.All.Count; i++)
            {
                var theme = Themes.All[i];
                int row = i / 2;
                int col = i % 2;
                int x = (col == 0) ? 19 : 187;
                int y = startY + (row * (cardHeight + cardGap));

                ThemeCardButton card = new(theme)
                {
                    Size = new Size(cardWidth, cardHeight),
                    Location = new Point(x, y),
                    IsSelected = (theme.Id == ThemeManager.CurrentTheme.Id)
                };

                card.Click += (s, e) =>
                {
                    ThemeManager.SetTheme(theme);
                };

                _themeCards.Add(card);
                pnlSettingsOverlay.Controls.Add(card);
            }
        }

        private void ApplyDwmTheme(AppTheme t)
        {
            if (!IsHandleCreated) return;

            try
            {
                int isDark = t.IsDark ? 1 : 0;
                DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref isDark, sizeof(int));

                // Paint native title bar background to match theme (Windows 11)
                Color bg = t.BackgroundColor;
                int colorBgr = bg.R | (bg.G << 8) | (bg.B << 16);
                DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref colorBgr, sizeof(int));

                // Paint native title bar text color
                Color fg = t.PrimaryTextColor;
                int textBgr = fg.R | (fg.G << 8) | (fg.B << 16);
                DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref textBgr, sizeof(int));
            }
            catch { }
        }

        private void OnThemeChanged(AppTheme theme)
        {
            ApplyCurrentTheme();
        }

        private void ApplyCurrentTheme()
        {
            var t = ThemeManager.CurrentTheme;

            ApplyDwmTheme(t);

            BackColor = t.BackgroundColor;
            lblTitle.ForeColor = t.PrimaryTextColor;
            lblHistory.ForeColor = t.SecondaryTextColor;
            lblDisplay.ForeColor = t.PrimaryTextColor;

            // Full In-App Overlay Styling
            pnlSettingsOverlay.BackColor = t.BackgroundColor;
            lblSettingsTitle.ForeColor = t.PrimaryTextColor;

            btnCloseOverlay.NormalColor = Color.Transparent;
            btnCloseOverlay.HoverColor = Color.FromArgb(30, t.PrimaryTextColor.R, t.PrimaryTextColor.G, t.PrimaryTextColor.B);
            btnCloseOverlay.PressedColor = Color.FromArgb(60, t.PrimaryTextColor.R, t.PrimaryTextColor.G, t.PrimaryTextColor.B);
            btnCloseOverlay.TextCustomColor = t.SecondaryTextColor;
            btnCloseOverlay.Invalidate();

            btnDoneSettings.NormalColor = t.AccentColor;
            btnDoneSettings.HoverColor = t.AccentHoverColor;
            btnDoneSettings.PressedColor = t.AccentHoverColor;
            btnDoneSettings.TextCustomColor = t.IsDark ? Color.Black : Color.White;
            btnDoneSettings.Invalidate();

            // Refresh cards selection and colors
            foreach (var card in _themeCards)
            {
                card.IsSelected = (card.CardTheme.Id == t.Id);
                card.Invalidate();
            }

            // Top Header Settings button
            btnSettings.NormalColor = Color.FromArgb(25, t.PrimaryTextColor.R, t.PrimaryTextColor.G, t.PrimaryTextColor.B);
            btnSettings.HoverColor = Color.FromArgb(50, t.PrimaryTextColor.R, t.PrimaryTextColor.G, t.PrimaryTextColor.B);
            btnSettings.PressedColor = Color.FromArgb(80, t.PrimaryTextColor.R, t.PrimaryTextColor.G, t.PrimaryTextColor.B);
            btnSettings.TextCustomColor = t.AccentColor;
            btnSettings.Invalidate();

            // Number buttons (0-9, .)
            ModernButton[] numButtons = [btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnDot];
            foreach (var btn in numButtons)
            {
                btn.IsGlass = t.IsGlass;
                btn.NormalColor = t.NumberBtnColor;
                btn.HoverColor = t.NumberBtnHoverColor;
                btn.PressedColor = t.NumberBtnHoverColor;
                btn.TextCustomColor = t.NumberBtnTextColor;
                btn.Invalidate();
            }

            // Operator buttons (÷, ×, −, +, =)
            ModernButton[] opButtons = [btnDivide, btnMultiply, btnMinus, btnPlus, btnEqual];
            foreach (var btn in opButtons)
            {
                btn.IsGlass = t.IsGlass;
                btn.NormalColor = t.OperatorBtnColor;
                btn.HoverColor = t.OperatorBtnHoverColor;
                btn.PressedColor = t.OperatorBtnHoverColor;
                btn.TextCustomColor = t.OperatorBtnTextColor;
                btn.Invalidate();
            }

            // Function buttons (AC, ±, %, ⌫)
            ModernButton[] fnButtons = [btnClear, btnPlusMinus, btnPercent, btnBackspace];
            foreach (var btn in fnButtons)
            {
                btn.IsGlass = t.IsGlass;
                btn.NormalColor = t.FunctionBtnColor;
                btn.HoverColor = t.FunctionBtnHoverColor;
                btn.PressedColor = t.FunctionBtnHoverColor;
                btn.TextCustomColor = t.FunctionBtnTextColor;
                btn.Invalidate();
            }

            Invalidate(true);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSettingsOverlay.Visible = !pnlSettingsOverlay.Visible;
            if (pnlSettingsOverlay.Visible)
            {
                pnlSettingsOverlay.BringToFront();
            }
        }

        private void CloseSettingsOverlay()
        {
            pnlSettingsOverlay.Visible = false;
        }

        private void Number_Click(object sender, EventArgs e)
        {
            if (_hasError) ResetCalculator();

            if (sender is Button btn)
            {
                AppendDigit(btn.Text);
            }
        }

        private void AppendDigit(string digit)
        {
            if (_isNewEntry || lblDisplay.Text == "0")
            {
                lblDisplay.Text = digit;
                _isNewEntry = false;
            }
            else
            {
                if (lblDisplay.Text.Length < 14)
                {
                    lblDisplay.Text += digit;
                }
            }

            AdjustDisplayFontSize();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (_hasError) ResetCalculator();

            if (_isNewEntry)
            {
                lblDisplay.Text = "0.";
                _isNewEntry = false;
            }
            else if (!lblDisplay.Text.Contains('.'))
            {
                lblDisplay.Text += ".";
            }

            AdjustDisplayFontSize();
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            if (_hasError) return;

            if (sender is ModernButton btn)
            {
                string op = btn.IconType switch
                {
                    ButtonIconType.Divide => "÷",
                    ButtonIconType.Multiply => "×",
                    ButtonIconType.Minus => "−",
                    ButtonIconType.Plus => "+",
                    _ => btn.Text
                };

                if (!_isNewEntry && !string.IsNullOrEmpty(_pendingOperation))
                {
                    CalculateIntermediate();
                }
                else
                {
                    if (double.TryParse(lblDisplay.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        _firstNumber = val;
                    }
                }

                _pendingOperation = op;
                lblHistory.Text = $"{FormatNumber(_firstNumber)} {_pendingOperation}";
                _isNewEntry = true;
            }
        }

        private void CalculateIntermediate()
        {
            if (double.TryParse(lblDisplay.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double secondNumber))
            {
                double result = ExecuteMath(_firstNumber, secondNumber, _pendingOperation);
                _firstNumber = result;
                lblDisplay.Text = FormatNumber(result);
                AdjustDisplayFontSize();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (_hasError || string.IsNullOrEmpty(_pendingOperation)) return;

            if (double.TryParse(lblDisplay.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double secondNumber))
            {
                if (_pendingOperation == "÷" && secondNumber == 0)
                {
                    ShowError("Cannot divide by 0");
                    return;
                }

                double result = ExecuteMath(_firstNumber, secondNumber, _pendingOperation);
                lblHistory.Text = $"{FormatNumber(_firstNumber)} {_pendingOperation} {FormatNumber(secondNumber)} =";
                lblDisplay.Text = FormatNumber(result);
                _firstNumber = result;
                _pendingOperation = "";
                _isNewEntry = true;
                AdjustDisplayFontSize();
            }
        }

        private double ExecuteMath(double a, double b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "−" or "-" => a - b,
                "×" or "*" => a * b,
                "÷" or "/" => b != 0 ? a / b : 0,
                _ => b
            };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            _firstNumber = 0;
            _pendingOperation = "";
            _isNewEntry = true;
            _hasError = false;
            lblDisplay.Text = "0";
            lblHistory.Text = "";
            AdjustDisplayFontSize();
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (_hasError) return;

            if (double.TryParse(lblDisplay.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
            {
                val = -val;
                lblDisplay.Text = FormatNumber(val);
                AdjustDisplayFontSize();
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (_hasError) return;

            if (double.TryParse(lblDisplay.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
            {
                val /= 100.0;
                lblDisplay.Text = FormatNumber(val);
                AdjustDisplayFontSize();
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (_hasError || _isNewEntry) return;

            if (lblDisplay.Text.Length > 1)
            {
                lblDisplay.Text = lblDisplay.Text[..^1];
                if (lblDisplay.Text == "-" || lblDisplay.Text == "-0")
                {
                    lblDisplay.Text = "0";
                    _isNewEntry = true;
                }
            }
            else
            {
                lblDisplay.Text = "0";
                _isNewEntry = true;
            }

            AdjustDisplayFontSize();
        }

        private void ShowError(string message)
        {
            _hasError = true;
            lblDisplay.Text = message;
            lblHistory.Text = "";
            AdjustDisplayFontSize();
        }

        private static string FormatNumber(double num)
        {
            if (double.IsNaN(num) || double.IsInfinity(num)) return "Error";
            return num.ToString("G12", CultureInfo.InvariantCulture);
        }

        private void AdjustDisplayFontSize()
        {
            int len = lblDisplay.Text.Length;
            if (len <= 8)
                lblDisplay.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            else if (len <= 11)
                lblDisplay.Font = new Font("Segoe UI", 24F, FontStyle.Regular);
            else
                lblDisplay.Font = new Font("Segoe UI", 18F, FontStyle.Regular);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlSettingsOverlay.Visible)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    CloseSettingsOverlay();
                    e.Handled = true;
                }
                return;
            }

            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift)
            {
                AppendDigit(((int)e.KeyCode - (int)Keys.D0).ToString());
                e.Handled = true;
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                AppendDigit(((int)e.KeyCode - (int)Keys.NumPad0).ToString());
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                btnDot.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Add || (e.KeyCode == Keys.Oemplus && e.Shift))
            {
                btnPlus.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                btnMinus.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                btnMultiply.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                btnDivide.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Oemplus)
            {
                btnEqual.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                btnBackspace.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClear.PerformClick();
                e.Handled = true;
            }
        }
    }
}
