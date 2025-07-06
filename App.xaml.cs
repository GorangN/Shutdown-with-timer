using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;


namespace Shutdown_with_timer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler<Theme> ThemeChanged;
        public static void RaiseThemeChanged(Theme newTheme) => ThemeChanged?.Invoke(null, newTheme);

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplySystemTheme();
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General)
            {
                ApplySystemTheme();
            }
        }

        private void ApplySystemTheme()
        {
            bool isDark = IsWindowsInDarkMode();
            var themeName = isDark ? "Dark.Blue" : "Light.Blue";
            ThemeManager.Current.ChangeTheme(Application.Current, themeName);
            RaiseThemeChanged(ThemeManager.Current.DetectTheme(Application.Current));
        }

        private bool IsWindowsInDarkMode()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
                if (key?.GetValue("AppsUseLightTheme") is int value)
                    return value == 0;
            }
            catch { }

            return false;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            base.OnExit(e);
        }
    }

}
