# Release Notes - Calculator v2.0.0

## What's New in Version 2.0.0

### Complete Apple-Inspired UI & UX Overhaul
- **Modern Circular Keypad**: 70×70px circular buttons designed with Apple Human Interface Guidelines and active press feedback.
- **Optically Centered Vector Glyphs**: Mathematical operators (`+`, `−`, `×`, `÷`, `±`, `⌫`, `⚙`, `✕`) rendered using high-resolution antialiased vector geometry with no font or emoji dependency.
- **Native Title Bar Integration**: Automatic synchronization with Windows 11 Desktop Window Manager (DWM) for seamless dark and light title bars.

### 8 Handcrafted Appearance Themes
1. **Apple Dark** — iOS classic dark slate with warm orange operators.
2. **Apple Light** — macOS silver with clear contrast and amber accents.
3. **Liquid Glass** — VisionOS frosted glass aesthetic with light-catch top reflections.
4. **Soft Sakura** — Soft pastel rose surface with crimson accents.
5. **Midnight OLED** — Pure black background with radiant emerald neon buttons.
6. **Nordic Slate** — Deep studio slate with arctic sky blue accents.
7. **Obsidian Gold** — Luxurious charcoal with champagne gold buttons.
8. **Cyber Violet** — Neon synthwave violet with electric purple highlights.

### In-App Themes Overlay
- Slide-over settings panel integrated inside the calculator window (no separate OS popups).
- 2-column theme preview cards showing color palette swatches, vector checkmark radio indicators, and clear theme names.
- Automatic persistence in local `theme_settings.json`.

### Enhanced Calculation Engine
- Multi-step expression chaining (`5 + 3 × 2`).
- Real-time expression history line above display.
- Dynamic responsive font sizing for long numbers (up to 14 digits).
- Full keyboard numpad support and shortcuts (`Enter`, `Esc`, `Backspace`, operators).

### Standalone Distribution
- Portable single-file release available (`calculator.exe`) with zero runtime dependencies.
