# Contributing to Modern Calculator

First off, thank you for considering contributing to **Modern Calculator**! Contributions from the community help make this project even better.

---

## Code of Conduct
Please be respectful, constructive, and helpful when participating in discussions, reporting issues, or opening pull requests.

---

## How Can I Contribute?

### 1. Reporting Bugs
- Search existing issues to ensure the bug hasn't already been reported.
- Open a new issue with a clear title, reproduction steps, expected behavior, and screenshots if applicable.

### 2. Suggesting Enhancements & New Themes
- We welcome ideas for new curated color palettes and themes!
- To propose a new theme, ensure it aligns with high-contrast readability and Apple HIG guidelines (distinct numbers, operators, and background tokens).

### 3. Submitting Pull Requests (PRs)
1. **Fork the Repository**:
   Click the **Fork** button on the GitHub repository to create your own copy.
2. **Clone your Fork**:
   ```bash
   git clone https://github.com/<your-username>/calculator.git
   cd calculator
   ```
3. **Create a Feature Branch**:
   ```bash
   git checkout -b feature/amazing-new-feature
   ```
4. **Make Your Changes**:
   - Follow existing C# / .NET 10 naming conventions.
   - Adhere to the **Apple Human Interface Guidelines (HIG)**:
     - No low-resolution bitmap icons or emojis in UI buttons.
     - Vector math glyphs rendered with anti-aliasing.
     - Generous padding and optical alignment.
5. **Verify the Build**:
   ```powershell
   dotnet build calculator/calculator.csproj
   ```
6. **Commit Your Changes**:
   ```bash
   git commit -m "feat: add support for scientific functions"
   ```
7. **Push to Your Fork**:
   ```bash
   git push origin feature/amazing-new-feature
   ```
8. **Open a Pull Request**:
   Go to your fork on GitHub and click **Compare & pull request**. Describe your changes clearly.

---

## Coding Standards
- **Framework**: .NET 10.0 (C# 13+) Windows Forms.
- **DPI Awareness**: Ensure all custom controls handle high-DPI scaling gracefully.
- **Design Consistency**: Follow the palette architecture in `Theme.cs` and custom painting in `ModernButton.cs`.
