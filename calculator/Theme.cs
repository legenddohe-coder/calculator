using System.Drawing;

namespace calculator
{
    public class AppTheme
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public bool IsDark { get; set; } = true;
        public bool IsGlass { get; set; } = false;

        // Form & Display
        public Color BackgroundColor { get; set; }
        public Color DisplayBackground { get; set; }
        public Color CardBackground { get; set; }
        public Color PrimaryTextColor { get; set; }
        public Color SecondaryTextColor { get; set; }
        public Color BorderColor { get; set; }

        // Number Buttons (0-9, .)
        public Color NumberBtnColor { get; set; }
        public Color NumberBtnTextColor { get; set; }
        public Color NumberBtnHoverColor { get; set; }

        // Operator Buttons (+, -, ×, ÷, =)
        public Color OperatorBtnColor { get; set; }
        public Color OperatorBtnTextColor { get; set; }
        public Color OperatorBtnHoverColor { get; set; }

        // Function Buttons (AC, ±, %, ⌫)
        public Color FunctionBtnColor { get; set; }
        public Color FunctionBtnTextColor { get; set; }
        public Color FunctionBtnHoverColor { get; set; }

        // Settings / Accent
        public Color AccentColor { get; set; }
        public Color AccentHoverColor { get; set; }
    }

    public static class Themes
    {
        public static readonly AppTheme AppleClassicDark = new()
        {
            Id = "apple-dark",
            Name = "Apple Dark",
            IsDark = true,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(28, 28, 30),
            DisplayBackground = Color.FromArgb(28, 28, 30),
            CardBackground = Color.FromArgb(42, 42, 46),
            PrimaryTextColor = Color.FromArgb(255, 255, 255),
            SecondaryTextColor = Color.FromArgb(160, 160, 165),
            BorderColor = Color.FromArgb(58, 58, 62),

            NumberBtnColor = Color.FromArgb(50, 50, 52),
            NumberBtnTextColor = Color.FromArgb(255, 255, 255),
            NumberBtnHoverColor = Color.FromArgb(70, 70, 74),

            OperatorBtnColor = Color.FromArgb(255, 159, 10),
            OperatorBtnTextColor = Color.FromArgb(255, 255, 255),
            OperatorBtnHoverColor = Color.FromArgb(255, 179, 64),

            FunctionBtnColor = Color.FromArgb(90, 90, 95),
            FunctionBtnTextColor = Color.FromArgb(255, 255, 255),
            FunctionBtnHoverColor = Color.FromArgb(115, 115, 120),

            AccentColor = Color.FromArgb(255, 159, 10),
            AccentHoverColor = Color.FromArgb(255, 179, 64)
        };

        public static readonly AppTheme AppleLightSilver = new()
        {
            Id = "apple-light",
            Name = "Apple Light",
            IsDark = false,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(242, 242, 247),
            DisplayBackground = Color.FromArgb(255, 255, 255),
            CardBackground = Color.FromArgb(255, 255, 255),
            PrimaryTextColor = Color.FromArgb(29, 29, 31),
            SecondaryTextColor = Color.FromArgb(110, 110, 115),
            BorderColor = Color.FromArgb(218, 218, 224),

            NumberBtnColor = Color.FromArgb(255, 255, 255),
            NumberBtnTextColor = Color.FromArgb(29, 29, 31),
            NumberBtnHoverColor = Color.FromArgb(238, 238, 242),

            OperatorBtnColor = Color.FromArgb(255, 149, 0),
            OperatorBtnTextColor = Color.FromArgb(255, 255, 255),
            OperatorBtnHoverColor = Color.FromArgb(255, 170, 45),

            FunctionBtnColor = Color.FromArgb(229, 229, 234),
            FunctionBtnTextColor = Color.FromArgb(29, 29, 31),
            FunctionBtnHoverColor = Color.FromArgb(215, 215, 220),

            AccentColor = Color.FromArgb(255, 149, 0),
            AccentHoverColor = Color.FromArgb(255, 170, 45)
        };

        public static readonly AppTheme LiquidGlass = new()
        {
            Id = "liquid-glass",
            Name = "Liquid Glass",
            IsDark = true,
            IsGlass = true,

            BackgroundColor = Color.FromArgb(16, 20, 32),
            DisplayBackground = Color.FromArgb(24, 30, 48),
            CardBackground = Color.FromArgb(26, 33, 52),
            PrimaryTextColor = Color.FromArgb(240, 249, 255),
            SecondaryTextColor = Color.FromArgb(125, 211, 252),
            BorderColor = Color.FromArgb(56, 189, 248),

            NumberBtnColor = Color.FromArgb(32, 42, 66),
            NumberBtnTextColor = Color.FromArgb(240, 249, 255),
            NumberBtnHoverColor = Color.FromArgb(46, 60, 92),

            OperatorBtnColor = Color.FromArgb(2, 132, 199),
            OperatorBtnTextColor = Color.FromArgb(255, 255, 255),
            OperatorBtnHoverColor = Color.FromArgb(14, 165, 233),

            FunctionBtnColor = Color.FromArgb(40, 52, 80),
            FunctionBtnTextColor = Color.FromArgb(186, 230, 253),
            FunctionBtnHoverColor = Color.FromArgb(56, 72, 110),

            AccentColor = Color.FromArgb(56, 189, 248),
            AccentHoverColor = Color.FromArgb(125, 211, 252)
        };

        public static readonly AppTheme SoftSakuraRose = new()
        {
            Id = "sakura-rose",
            Name = "Soft Sakura",
            IsDark = false,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(255, 241, 242),
            DisplayBackground = Color.FromArgb(255, 255, 255),
            CardBackground = Color.FromArgb(255, 255, 255),
            PrimaryTextColor = Color.FromArgb(136, 19, 55),
            SecondaryTextColor = Color.FromArgb(190, 18, 60),
            BorderColor = Color.FromArgb(254, 205, 211),

            NumberBtnColor = Color.FromArgb(255, 255, 255),
            NumberBtnTextColor = Color.FromArgb(136, 19, 55),
            NumberBtnHoverColor = Color.FromArgb(255, 228, 230),

            OperatorBtnColor = Color.FromArgb(225, 29, 72),
            OperatorBtnTextColor = Color.FromArgb(255, 255, 255),
            OperatorBtnHoverColor = Color.FromArgb(244, 63, 94),

            FunctionBtnColor = Color.FromArgb(254, 205, 211),
            FunctionBtnTextColor = Color.FromArgb(159, 18, 57),
            FunctionBtnHoverColor = Color.FromArgb(251, 160, 175),

            AccentColor = Color.FromArgb(225, 29, 72),
            AccentHoverColor = Color.FromArgb(244, 63, 94)
        };

        public static readonly AppTheme MidnightCyber = new()
        {
            Id = "midnight-cyber",
            Name = "Midnight OLED",
            IsDark = true,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(8, 10, 16),
            DisplayBackground = Color.FromArgb(15, 19, 30),
            CardBackground = Color.FromArgb(17, 23, 36),
            PrimaryTextColor = Color.FromArgb(249, 250, 251),
            SecondaryTextColor = Color.FromArgb(156, 163, 175),
            BorderColor = Color.FromArgb(37, 48, 68),

            NumberBtnColor = Color.FromArgb(22, 28, 42),
            NumberBtnTextColor = Color.FromArgb(249, 250, 251),
            NumberBtnHoverColor = Color.FromArgb(36, 46, 68),

            OperatorBtnColor = Color.FromArgb(16, 185, 129),
            OperatorBtnTextColor = Color.FromArgb(4, 47, 46),
            OperatorBtnHoverColor = Color.FromArgb(52, 211, 153),

            FunctionBtnColor = Color.FromArgb(36, 46, 68),
            FunctionBtnTextColor = Color.FromArgb(209, 213, 219),
            FunctionBtnHoverColor = Color.FromArgb(51, 65, 96),

            AccentColor = Color.FromArgb(16, 185, 129),
            AccentHoverColor = Color.FromArgb(52, 211, 153)
        };

        public static readonly AppTheme NordicSlate = new()
        {
            Id = "nordic-slate",
            Name = "Nordic Slate",
            IsDark = true,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(15, 23, 42),
            DisplayBackground = Color.FromArgb(30, 41, 59),
            CardBackground = Color.FromArgb(30, 41, 59),
            PrimaryTextColor = Color.FromArgb(248, 250, 252),
            SecondaryTextColor = Color.FromArgb(148, 163, 184),
            BorderColor = Color.FromArgb(51, 65, 85),

            NumberBtnColor = Color.FromArgb(30, 41, 59),
            NumberBtnTextColor = Color.FromArgb(248, 250, 252),
            NumberBtnHoverColor = Color.FromArgb(51, 65, 85),

            OperatorBtnColor = Color.FromArgb(56, 189, 248),
            OperatorBtnTextColor = Color.FromArgb(15, 23, 42),
            OperatorBtnHoverColor = Color.FromArgb(125, 211, 252),

            FunctionBtnColor = Color.FromArgb(51, 65, 85),
            FunctionBtnTextColor = Color.FromArgb(226, 232, 240),
            FunctionBtnHoverColor = Color.FromArgb(71, 85, 105),

            AccentColor = Color.FromArgb(56, 189, 248),
            AccentHoverColor = Color.FromArgb(125, 211, 252)
        };

        public static readonly AppTheme ObsidianGold = new()
        {
            Id = "obsidian-gold",
            Name = "Obsidian Gold",
            IsDark = true,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(18, 18, 20),
            DisplayBackground = Color.FromArgb(28, 28, 32),
            CardBackground = Color.FromArgb(32, 32, 36),
            PrimaryTextColor = Color.FromArgb(250, 250, 250),
            SecondaryTextColor = Color.FromArgb(217, 180, 99),
            BorderColor = Color.FromArgb(64, 58, 44),

            NumberBtnColor = Color.FromArgb(36, 36, 40),
            NumberBtnTextColor = Color.FromArgb(250, 250, 250),
            NumberBtnHoverColor = Color.FromArgb(54, 54, 60),

            OperatorBtnColor = Color.FromArgb(234, 179, 8),
            OperatorBtnTextColor = Color.FromArgb(28, 24, 8),
            OperatorBtnHoverColor = Color.FromArgb(250, 204, 21),

            FunctionBtnColor = Color.FromArgb(54, 54, 60),
            FunctionBtnTextColor = Color.FromArgb(250, 204, 21),
            FunctionBtnHoverColor = Color.FromArgb(72, 72, 80),

            AccentColor = Color.FromArgb(234, 179, 8),
            AccentHoverColor = Color.FromArgb(250, 204, 21)
        };

        public static readonly AppTheme ElectricViolet = new()
        {
            Id = "electric-violet",
            Name = "Cyber Violet",
            IsDark = true,
            IsGlass = false,

            BackgroundColor = Color.FromArgb(15, 12, 26),
            DisplayBackground = Color.FromArgb(24, 19, 42),
            CardBackground = Color.FromArgb(28, 22, 50),
            PrimaryTextColor = Color.FromArgb(250, 245, 255),
            SecondaryTextColor = Color.FromArgb(192, 132, 252),
            BorderColor = Color.FromArgb(76, 44, 114),

            NumberBtnColor = Color.FromArgb(32, 26, 56),
            NumberBtnTextColor = Color.FromArgb(250, 245, 255),
            NumberBtnHoverColor = Color.FromArgb(48, 38, 84),

            OperatorBtnColor = Color.FromArgb(168, 85, 247),
            OperatorBtnTextColor = Color.FromArgb(255, 255, 255),
            OperatorBtnHoverColor = Color.FromArgb(192, 132, 252),

            FunctionBtnColor = Color.FromArgb(48, 38, 84),
            FunctionBtnTextColor = Color.FromArgb(233, 213, 255),
            FunctionBtnHoverColor = Color.FromArgb(64, 50, 112),

            AccentColor = Color.FromArgb(168, 85, 247),
            AccentHoverColor = Color.FromArgb(192, 132, 252)
        };

        public static readonly List<AppTheme> All = new()
        {
            AppleClassicDark,
            AppleLightSilver,
            LiquidGlass,
            SoftSakuraRose,
            MidnightCyber,
            NordicSlate,
            ObsidianGold,
            ElectricViolet
        };
    }
}
