# 🧰 Package Manager Console - JetBrains Internship Challenge

A sleek, Rider-inspired shell runner for Windows, built with **.NET + WPF**.  
Easily execute terminal commands, view real-time output, copy results, and enjoy a JetBrains-style developer experience. ⚡

![Screenshot - Main UI](https://github.com/mgedna/Package.Manager.Console/releases/download/PackageManagerConsole/screenshot-1.png)

*JetBrains Rider–inspired interface with live terminal output and color-coded streams.*

---

## ✨ Features

- 🎯 Real-time command execution via `cmd.exe`
- 🎨 Color-coded output:
  - 🟢 Green for standard output
  - 🔴 Red for errors
- ⌨️ Run commands using `Enter` or `Run` button
- 📋 Copy output to clipboard
- 🧼 Clear output with one click
- 📊 Status bar for live feedback
- 🖤 Full dark theme styled after JetBrains Rider

---

## 📸 Screenshots

| ✅ Success Command | ❌ Error Command |
|-------------------|-----------------|
| ![Success](https://github.com/mgedna/Package.Manager.Console/releases/download/PackageManagerConsole/screenshot-ok.png) | ![Error](https://github.com/mgedna/Package.Manager.Console/releases/download/PackageManagerConsole/screenshot-error.png) |

---

## 🧱 Built With

- [.NET 6 / 7 / 8](https://dotnet.microsoft.com/)
- WPF (`RichTextBox`, `ProcessStartInfo`)
- Async/await for responsive UI

---

## ✅ Unit & Integration Testing

This project includes both **unit** and **integration tests** for the shell execution logic:

- ✅ Tests for valid command execution
- ✅ Tests for invalid or unknown commands
- ✅ Tests that assert exit codes and output streams

**Tools used:**
- [`xUnit`](https://xunit.net/) for test structure
- Mocked + real shell processes for reliability

```bash
dotnet test
```

📁 Test code is cleanly separated in `tests` folder.

![Passed Tests](https://github.com/mgedna/Package.Manager.Console/releases/download/PackageManagerConsole/tests-ok.png)

---

## 🚀 Getting Started

### Requirements
- Windows OS
- [.NET Desktop Runtime](https://dotnet.microsoft.com/en-us/download)

### 📦 Download

- [🔽 Download Package Manager Console v1.0 (Asset.zip)](https://github.com/mgedna/Package.Manager.Console/releases/download/PackageManagerConsole/Asset.zip)
- Unzip and run: `Package.Manager.Console.exe`
- No install required ✅

---

## 🛠 Future Plans

- 🌐 Cross-platform support (Linux/macOS via `/bin/bash`)
- 🔁 Command history navigation (↑ ↓)
- 🧪 Integrated test panel
- 🎨 Light/dark mode switch

---

## 🙋‍♀️ Author

Made with ❤️ by [Edna Memedula](https://github.com/mgedna)  
📧 Connect: [LinkedIn](https://www.linkedin.com/in/edna-memedula-24b519245/)
