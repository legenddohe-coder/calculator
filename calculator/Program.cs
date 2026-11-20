namespace calculator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Length > 0 && args[0] == "--capture-screenshots")
            {
                CaptureScreenshots();
                return;
            }

            Application.Run(new Form1());
        }

        private static void CaptureScreenshots()
        {
            string outDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "docs", "screenshots"));
            Directory.CreateDirectory(outDir);

            using Form1 form = new();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(50, 50);
            form.Show();

            var lblHistoryField = typeof(Form1).GetField("lblHistory", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var lblDisplayField = typeof(Form1).GetField("lblDisplay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pnlOverlayField = typeof(Form1).GetField("pnlSettingsOverlay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Label? lblHistory = lblHistoryField?.GetValue(form) as Label;
            Label? lblDisplay = lblDisplayField?.GetValue(form) as Label;
            Panel? pnlOverlay = pnlOverlayField?.GetValue(form) as Panel;

            if (lblHistory != null) lblHistory.Text = "1,024 × 8 =";
            if (lblDisplay != null) lblDisplay.Text = "8,192";

            foreach (var theme in Themes.All)
            {
                ThemeManager.SetTheme(theme);
                if (pnlOverlay != null) pnlOverlay.Visible = false;
                form.Refresh();
                Application.DoEvents();
                Thread.Sleep(80);

                using Bitmap bmp = new(form.ClientSize.Width, form.ClientSize.Height);
                form.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                string path = Path.Combine(outDir, $"{theme.Id}.png");
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            // Capture Themes Overlay Panel
            if (pnlOverlay != null)
            {
                ThemeManager.SetTheme(Themes.AppleClassicDark);
                pnlOverlay.Visible = true;
                pnlOverlay.BringToFront();
                pnlOverlay.Refresh();
                form.Refresh();
                Application.DoEvents();
                Thread.Sleep(100);

                using Bitmap bmp = new(pnlOverlay.Width, pnlOverlay.Height);
                pnlOverlay.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                string path = Path.Combine(outDir, "themes-overlay.png");
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            form.Close();
        }
    }
}