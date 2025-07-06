# Shutdown with Timer

**Shutdown with Timer** ist ein einfaches, modernes Windows-Tool zum zeitgesteuerten Herunterfahren, Sperren oder Schlafenlegen des PCs.  
Die Anwendung wurde mit C# (.NET 8) und WPF entwickelt und verwendet das [MahApps.Metro UI-Framework](https://github.com/MahApps/MahApps.Metro) für eine moderne Benutzeroberfläche.

---

## 🧩 Funktionen

- Zeitgesteuertes **Herunterfahren**, **Sperren** oder **Schlafenlegen**
- Eingabe der Zeit in **Minuten**
- Moderne Oberfläche mit Dark/Light-Theme
- Minimierung in den System-Tray
- Kompakte, ressourcenschonende Anwendung

---

## 📥 Download

Der Installer steht im aktuellen GitHub Release zur Verfügung:

➡️ [**ShutdownTimerSetup.exe** – aktuelle Version herunterladen](https://github.com/GorangN/Shutdown-with-timer/releases/latest/download/ShutdownTimerSetup.exe)

### 🔄 Andere Versionen

Für weitere Plattformen und ältere Versionen siehe:  
➡️ [Alle Releases anzeigen](https://github.com/GorangN/Shutdown-with-timer/releases)

---

## 🚀 Installation

1. Lade den Installer herunter
2. Starte `ShutdownTimerSetup.exe`
3. Folge dem Setup-Assistenten
4. Anwendung nach der Installation über Startmenü oder Desktop-Icon starten

> Der Installer legt das Programm standardmäßig unter `C:\Program Files\Shutdown with Timer` ab.

---

## 🖥️ Systemanforderungen

| Voraussetzung         | Details                       |
|------------------------|-------------------------------|
| Betriebssystem         | Windows 10 oder Windows 11 (64 Bit) |
| .NET Runtime           | .NET 8 (wird automatisch mitgeliefert, wenn nicht vorhanden) |

---

## 🧑‍💻 Entwicklung

Dieses Projekt ist vollständig Open Source.

### 💡 Technologien

- [.NET 8 (WPF, C#)](https://dotnet.microsoft.com/)
- [MahApps.Metro](https://github.com/MahApps/MahApps.Metro)
- [Inno Setup](https://jrsoftware.org/isinfo.php) für den Installer

### 📁 Projektstruktur

```plaintext
Shutdown-with-timer/
├── LICENSE.txt                  # MIT-Lizenz
├── README.md                    # Dieses Dokument
├── Setup/                       # Inno Setup Skript
│   └── ShutdownTimerSetup.iss
├── src/                         # Quellcode der Anwendung (MainWindow.xaml etc.)
└── .gitignore
```

### 🛠 Build & Installer erstellen

1. Projekt in Release-Modus kompilieren (`net8.0-windows`)
2. Inno Setup öffnen → `Setup/ShutdownTimerSetup.iss` → Kompilieren (`F9`)
3. Installer wird unter `Documents\Output\ShutdownTimerSetup.exe` generiert

---

## 🧾 Lizenz

Dieses Projekt steht unter der [MIT-Lizenz](./LICENSE.txt).  
Du darfst den Code frei verwenden, verändern und weiterverbreiten, auch für kommerzielle Zwecke – unter Angabe des ursprünglichen Autors.

---

## 📫 Kontakt

Entwickelt von **Gorang Nagpal**  
Bei Fragen oder Feedback: gerne ein [Issue](https://github.com/GorangN/Shutdown-with-timer/issues) eröffnen.
