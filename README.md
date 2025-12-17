# IsVPNOn - Windows VPN Status Monitor

![Windows](https://img.shields.io/badge/Windows-10%2F11-blue)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![License](https://img.shields.io/badge/license-BSD%203--Clause-blue)
![Version](https://img.shields.io/badge/version-1.0.0-orange)

A lightweight Windows application that runs in the system tray and monitors your VPN connection status by checking your public IP address.

## 📋 Features

- **🖥️ System Tray Integration** - Runs discreetly in the notification area
- **🎯 Real-time Monitoring** - Continuously checks VPN connection status
- **🎨 Visual Indicators** - Color-coded icons (Red = VPN active, Green = VPN inactive)
- **💾 Settings Persistence** - Automatically saves and restores your configuration
- **📊 Multiple IP Services** - Supports various IP checking services
- **📦 Portable** - Single executable, no installation required

## 🚀 Quick Start

### Download
Download the latest release from the [Releases page](https://github.com/GreenMap-chan/IsVPNOn/releases/latest).

### Installation
1. Download `IsVPNOn-vX.X.X.zip`
2. Extract to any folder
3. Run `IsVPNOn.exe`

No installation required - it's a portable application!

### Status Indicators
- **🟢 Green Icon** - VPN is NOT active (your real IP is visible)
- **🔴 Red Icon** - VPN IS active (using VPN IP)
- **🟡 Yellow Icon** - Connection error

## 🛠️ How It Works

1. **Set Your Normal IP**: Enter your regular public IP address
2. **Select IP Service**: Choose from supported IP checking services
3. **Start Monitoring**: The app periodically checks your current IP
4. **Get Visual Feedback**: System tray icon changes color based on VPN status

### IP Checking Logic:
- If current IP ≠ your normal IP → VPN is active (Red)
- If current IP = your normal IP → VPN is inactive (Green)
- If cannot reach IP service → Connection error (Yellow)

## 🏗️ Building from Source

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows 10/11
- Visual Studio 2022 or VS Code

## 📄 License

This project is licensed under the **BSD 3-Clause License**.
