using ControlzEx.Theming;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Shutdown_with_timer
{
    public partial class App : Application
    {
        public static event EventHandler<Theme> ThemeChanged;

        public static void RaiseThemeChanged(Theme newTheme) =>
            ThemeChanged?.Invoke(null, newTheme);

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
            ApplySystemTheme();
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

            if (isDark)
            {
                ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
            }
            else
            {
                // CustomLight.xaml muss im Projekt enthalten sein
                try
                {
                    var customLightDict = new ResourceDictionary
                    {
                        Source = new Uri("CustomLight.xaml", UriKind.Relative)
                    };
                    Resources.MergedDictionaries.Add(customLightDict);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CustomLight.xaml konnte nicht geladen werden: " + ex.Message);
                }
            }

            RaiseThemeChanged(ThemeManager.Current.DetectTheme(this));
        }

        private bool IsWindowsInDarkMode()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
                if (key?.GetValue("AppsUseLightTheme") is int value)
                {
                    return value == 0;
                }
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
