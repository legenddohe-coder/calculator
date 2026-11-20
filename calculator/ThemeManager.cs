using System.Text.Json;

namespace calculator
{
    public static class ThemeManager
    {
        private static AppTheme _currentTheme = Themes.AppleClassicDark;
        private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "theme_settings.json");

        public static event Action<AppTheme>? ThemeChanged;

        static ThemeManager()
        {
            LoadSavedTheme();
        }

        public static AppTheme CurrentTheme
        {
            get => _currentTheme;
            private set
            {
                _currentTheme = value;
                ThemeChanged?.Invoke(_currentTheme);
                SaveThemePreference();
            }
        }

        public static void SetTheme(string themeId)
        {
            var found = Themes.All.FirstOrDefault(t => t.Id == themeId);
            if (found != null)
            {
                CurrentTheme = found;
            }
        }

        public static void SetTheme(AppTheme theme)
        {
            if (theme != null)
            {
                CurrentTheme = theme;
            }
        }

        private static void SaveThemePreference()
        {
            try
            {
                var data = new { ThemeId = _currentTheme.Id };
                string json = JsonSerializer.Serialize(data);
                File.WriteAllText(SettingsFilePath, json);
            }
            catch
            {
                // Silently ignore write errors
            }
        }

        private static void LoadSavedTheme()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string json = File.ReadAllText(SettingsFilePath);
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("ThemeId", out var prop))
                    {
                        string? id = prop.GetString();
                        var found = Themes.All.FirstOrDefault(t => t.Id == id);
                        if (found != null)
                        {
                            _currentTheme = found;
                        }
                    }
                }
            }
            catch
            {
                _currentTheme = Themes.AppleClassicDark;
            }
        }
    }
}
