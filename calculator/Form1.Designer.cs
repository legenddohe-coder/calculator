namespace calculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnSettings = new ModernButton();
            lblHistory = new Label();
            lblDisplay = new Label();
            
            // Row 0
            btnClear = new ModernButton();
            btnPlusMinus = new ModernButton();
            btnPercent = new ModernButton();
            btnDivide = new ModernButton();

            // Row 1
            btn7 = new ModernButton();
            btn8 = new ModernButton();
            btn9 = new ModernButton();
            btnMultiply = new ModernButton();

            // Row 2
            btn4 = new ModernButton();
            btn5 = new ModernButton();
            btn6 = new ModernButton();
            btnMinus = new ModernButton();

            // Row 3
            btn1 = new ModernButton();
            btn2 = new ModernButton();
            btn3 = new ModernButton();
            btnPlus = new ModernButton();

            // Row 4
            btn0 = new ModernButton();
            btnDot = new ModernButton();
            btnBackspace = new ModernButton();
            btnEqual = new ModernButton();

            // Full In-App Settings Overlay Panel (covers whole client area)
            pnlSettingsOverlay = new Panel();
            lblSettingsTitle = new Label();
            btnCloseOverlay = new ModernButton();
            btnDoneSettings = new ModernButton();

            pnlSettingsOverlay.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Calculator";

            // btnSettings
            btnSettings.BorderRadius = 17;
            btnSettings.IconType = ButtonIconType.Gear;
            btnSettings.Location = new Point(306, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(34, 34);
            btnSettings.TabIndex = 1;
            btnSettings.Click += btnSettings_Click;

            // lblHistory
            lblHistory.Font = new Font("Segoe UI", 11F);
            lblHistory.Location = new Point(20, 50);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(320, 24);
            lblHistory.TabIndex = 2;
            lblHistory.TextAlign = ContentAlignment.MiddleRight;

            // lblDisplay
            lblDisplay.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            lblDisplay.Location = new Point(20, 78);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(320, 64);
            lblDisplay.TabIndex = 3;
            lblDisplay.Text = "0";
            lblDisplay.TextAlign = ContentAlignment.MiddleRight;

            // Row 0: AC, +/-, %, ÷ (y = 154)
            btnClear.BorderRadius = 35;
            btnClear.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            btnClear.Location = new Point(19, 154);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 70);
            btnClear.TabIndex = 4;
            btnClear.Text = "AC";
            btnClear.IconType = ButtonIconType.None;
            btnClear.Click += btnClear_Click;

            btnPlusMinus.BorderRadius = 35;
            btnPlusMinus.IconType = ButtonIconType.PlusMinus;
            btnPlusMinus.Location = new Point(103, 154);
            btnPlusMinus.Name = "btnPlusMinus";
            btnPlusMinus.Size = new Size(70, 70);
            btnPlusMinus.TabIndex = 5;
            btnPlusMinus.Click += btnPlusMinus_Click;

            btnPercent.BorderRadius = 35;
            btnPercent.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnPercent.Location = new Point(187, 154);
            btnPercent.Name = "btnPercent";
            btnPercent.Size = new Size(70, 70);
            btnPercent.TabIndex = 6;
            btnPercent.Text = "%";
            btnPercent.IconType = ButtonIconType.None;
            btnPercent.Click += btnPercent_Click;

            btnDivide.BorderRadius = 35;
            btnDivide.IconType = ButtonIconType.Divide;
            btnDivide.Location = new Point(271, 154);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(70, 70);
            btnDivide.TabIndex = 7;
            btnDivide.Click += Operator_Click;

            // Row 1: 7, 8, 9, × (y = 236)
            btn7.BorderRadius = 35;
            btn7.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn7.Location = new Point(19, 236);
            btn7.Name = "btn7";
            btn7.Size = new Size(70, 70);
            btn7.TabIndex = 8;
            btn7.Text = "7";
            btn7.IconType = ButtonIconType.None;
            btn7.Click += Number_Click;

            btn8.BorderRadius = 35;
            btn8.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn8.Location = new Point(103, 236);
            btn8.Name = "btn8";
            btn8.Size = new Size(70, 70);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.IconType = ButtonIconType.None;
            btn8.Click += Number_Click;

            btn9.BorderRadius = 35;
            btn9.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn9.Location = new Point(187, 236);
            btn9.Name = "btn9";
            btn9.Size = new Size(70, 70);
            btn9.TabIndex = 10;
            btn9.Text = "9";
            btn9.IconType = ButtonIconType.None;
            btn9.Click += Number_Click;

            btnMultiply.BorderRadius = 35;
            btnMultiply.IconType = ButtonIconType.Multiply;
            btnMultiply.Location = new Point(271, 236);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(70, 70);
            btnMultiply.TabIndex = 11;
            btnMultiply.Text = "×";
            btnMultiply.Click += Operator_Click;

            // Row 2: 4, 5, 6, - (y = 318)
            btn4.BorderRadius = 35;
            btn4.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn4.Location = new Point(19, 318);
            btn4.Name = "btn4";
            btn4.Size = new Size(70, 70);
            btn4.TabIndex = 12;
            btn4.Text = "4";
            btn4.IconType = ButtonIconType.None;
            btn4.Click += Number_Click;

            btn5.BorderRadius = 35;
            btn5.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn5.Location = new Point(103, 318);
            btn5.Name = "btn5";
            btn5.Size = new Size(70, 70);
            btn5.TabIndex = 13;
            btn5.Text = "5";
            btn5.IconType = ButtonIconType.None;
            btn5.Click += Number_Click;

            btn6.BorderRadius = 35;
            btn6.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn6.Location = new Point(187, 318);
            btn6.Name = "btn6";
            btn6.Size = new Size(70, 70);
            btn6.TabIndex = 14;
            btn6.Text = "6";
            btn6.IconType = ButtonIconType.None;
            btn6.Click += Number_Click;

            btnMinus.BorderRadius = 35;
            btnMinus.IconType = ButtonIconType.Minus;
            btnMinus.Location = new Point(271, 318);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(70, 70);
            btnMinus.TabIndex = 15;
            btnMinus.Text = "−";
            btnMinus.Click += Operator_Click;

            // Row 3: 1, 2, 3, + (y = 400)
            btn1.BorderRadius = 35;
            btn1.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn1.Location = new Point(19, 400);
            btn1.Name = "btn1";
            btn1.Size = new Size(70, 70);
            btn1.TabIndex = 16;
            btn1.Text = "1";
            btn1.IconType = ButtonIconType.None;
            btn1.Click += Number_Click;

            btn2.BorderRadius = 35;
            btn2.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn2.Location = new Point(103, 400);
            btn2.Name = "btn2";
            btn2.Size = new Size(70, 70);
            btn2.TabIndex = 17;
            btn2.Text = "2";
            btn2.IconType = ButtonIconType.None;
            btn2.Click += Number_Click;

            btn3.BorderRadius = 35;
            btn3.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn3.Location = new Point(187, 400);
            btn3.Name = "btn3";
            btn3.Size = new Size(70, 70);
            btn3.TabIndex = 18;
            btn3.Text = "3";
            btn3.IconType = ButtonIconType.None;
            btn3.Click += Number_Click;

            btnPlus.BorderRadius = 35;
            btnPlus.IconType = ButtonIconType.Plus;
            btnPlus.Location = new Point(271, 400);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(70, 70);
            btnPlus.TabIndex = 19;
            btnPlus.Text = "+";
            btnPlus.Click += Operator_Click;

            // Row 4: 0, ., ⌫, = (y = 482)
            btn0.BorderRadius = 35;
            btn0.Font = new Font("Segoe UI", 17F, FontStyle.Regular);
            btn0.Location = new Point(19, 482);
            btn0.Name = "btn0";
            btn0.Size = new Size(70, 70);
            btn0.TabIndex = 20;
            btn0.Text = "0";
            btn0.IconType = ButtonIconType.None;
            btn0.Click += Number_Click;

            btnDot.BorderRadius = 35;
            btnDot.IconType = ButtonIconType.Dot;
            btnDot.Location = new Point(103, 482);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(70, 70);
            btnDot.TabIndex = 21;
            btnDot.Click += btnDot_Click;

            btnBackspace.BorderRadius = 35;
            btnBackspace.IconType = ButtonIconType.Backspace;
            btnBackspace.Location = new Point(187, 482);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(70, 70);
            btnBackspace.TabIndex = 22;
            btnBackspace.Click += btnBackspace_Click;

            btnEqual.BorderRadius = 35;
            btnEqual.IconType = ButtonIconType.Equal;
            btnEqual.Location = new Point(271, 482);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(70, 70);
            btnEqual.TabIndex = 23;
            btnEqual.Click += btnEqual_Click;

            // Full In-App Settings Overlay Panel (covers 0,0 to 360,568)
            pnlSettingsOverlay.Location = new Point(0, 0);
            pnlSettingsOverlay.Name = "pnlSettingsOverlay";
            pnlSettingsOverlay.Size = new Size(360, 568);
            pnlSettingsOverlay.TabIndex = 99;
            pnlSettingsOverlay.Visible = false;

            // lblSettingsTitle
            lblSettingsTitle.AutoSize = true;
            lblSettingsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSettingsTitle.Location = new Point(20, 16);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(120, 28);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "Themes";

            // btnCloseOverlay
            btnCloseOverlay.BorderRadius = 16;
            btnCloseOverlay.Location = new Point(308, 14);
            btnCloseOverlay.Name = "btnCloseOverlay";
            btnCloseOverlay.Size = new Size(32, 32);
            btnCloseOverlay.TabIndex = 1;
            btnCloseOverlay.Text = "";
            btnCloseOverlay.IconType = ButtonIconType.Close;
            btnCloseOverlay.Click += (s, e) => CloseSettingsOverlay();

            // btnDoneSettings (pill button with generous whitespace)
            btnDoneSettings.BorderRadius = 25;
            btnDoneSettings.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            btnDoneSettings.Location = new Point(19, 496);
            btnDoneSettings.Name = "btnDoneSettings";
            btnDoneSettings.Size = new Size(322, 50);
            btnDoneSettings.TabIndex = 2;
            btnDoneSettings.Text = "Done";
            btnDoneSettings.IconType = ButtonIconType.None;
            btnDoneSettings.Click += (s, e) => CloseSettingsOverlay();

            pnlSettingsOverlay.Controls.Add(lblSettingsTitle);
            pnlSettingsOverlay.Controls.Add(btnCloseOverlay);
            pnlSettingsOverlay.Controls.Add(btnDoneSettings);

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 568);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator";
            KeyPreview = true;
            KeyDown += Form1_KeyDown;

            Controls.Add(pnlSettingsOverlay); // Overlay covers when visible
            Controls.Add(lblTitle);
            Controls.Add(btnSettings);
            Controls.Add(lblHistory);
            Controls.Add(lblDisplay);

            Controls.Add(btnClear);
            Controls.Add(btnPlusMinus);
            Controls.Add(btnPercent);
            Controls.Add(btnDivide);

            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnMultiply);

            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btnMinus);

            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btnPlus);

            Controls.Add(btn0);
            Controls.Add(btnDot);
            Controls.Add(btnBackspace);
            Controls.Add(btnEqual);

            pnlSettingsOverlay.ResumeLayout(false);
            pnlSettingsOverlay.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ModernButton btnSettings;
        private Label lblHistory;
        private Label lblDisplay;

        private ModernButton btnClear;
        private ModernButton btnPlusMinus;
        private ModernButton btnPercent;
        private ModernButton btnDivide;

        private ModernButton btn7;
        private ModernButton btn8;
        private ModernButton btn9;
        private ModernButton btnMultiply;

        private ModernButton btn4;
        private ModernButton btn5;
        private ModernButton btn6;
        private ModernButton btnMinus;

        private ModernButton btn1;
        private ModernButton btn2;
        private ModernButton btn3;
        private ModernButton btnPlus;

        private ModernButton btn0;
        private ModernButton btnDot;
        private ModernButton btnBackspace;
        private ModernButton btnEqual;

        // In-App Settings Overlay Controls
        private Panel pnlSettingsOverlay;
        private Label lblSettingsTitle;
        private ModernButton btnCloseOverlay;
        private ModernButton btnDoneSettings;
    }
}
