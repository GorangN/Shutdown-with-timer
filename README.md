# Shutdown with Timer

**Shutdown with Timer** is a simple, modern Windows tool to schedule shutdown, lock, or sleep actions on your PC.  
The app is developed using C# (.NET 8) and WPF, and uses the [MahApps.Metro UI framework](https://github.com/MahApps/MahApps.Metro) for a clean, modern user interface.

---

## 🧩 Features

- Scheduled **shutdown**, **lock**, or **sleep**
- Input time in **minutes**
- Modern UI with dark/light theme support
- Minimizes to the system tray
- Lightweight and resource-friendly

---

## 📥 Download

The installer is available in the latest GitHub release:

➡️ [**Download ShutdownTimerSetup.exe** – Latest version](https://github.com/GorangN/Shutdown-with-timer/releases/latest/download/ShutdownTimerSetup.exe)

### 🔄 Other Versions

For other platforms and older releases, visit:  
➡️ [View all releases](https://github.com/GorangN/Shutdown-with-timer/releases)

---

## 🚀 Installation

1. Download the installer  
2. Run `ShutdownTimerSetup.exe`  
3. Follow the setup wizard  
4. Launch the app via the Start Menu or Desktop shortcut

> By default, the app is installed to `C:\Program Files\Shutdown with Timer`.

---

## 🖥️ System Requirements

| Requirement         | Details                             |
|---------------------|--------------------------------------|
| Operating System    | Windows 10 or Windows 11 (64-bit)    |
| .NET Runtime        | .NET 8 (automatically bundled if missing) |

---

## 🧑‍💻 Development

This project is fully open source.

### 💡 Technologies

- [.NET 8 (WPF, C#)](https://dotnet.microsoft.com/)
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro)
- [Inno Setup](https://jrsoftware.org/isinfo.php) for the installer

### 📁 Project Structure

```plaintext
Shutdown-with-timer/
├── LICENSE.txt                  # MIT License
├── README.md                    # This file
├── Setup/                       # Inno Setup script
│   └── ShutdownTimerSetup.iss
├── src/                         # App source code (MainWindow.xaml etc.)
└── .gitignore
```

---

## 🧾 License

This project is licensed under the [MIT License](./LICENSE.txt).  
You are free to use, modify, and distribute the code, including for commercial purposes – with proper attribution to the original author.

---

## 📫 Contact

Developed by **Gorang Nagpal**  
For questions or feedback, feel free to [open an issue](https://github.com/GorangN/Shutdown-with-timer/issues).
