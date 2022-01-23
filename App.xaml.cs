using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shutdown_with_timer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler<Theme> ThemeChanged;
    public static void RaiseThemeChanged(Theme newTheme) => ThemeChanged?.Invoke(null, newTheme);
    }
}
