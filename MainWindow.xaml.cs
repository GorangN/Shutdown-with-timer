using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using ControlzEx.Theming;

namespace Shutdown_with_timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), () => CanExecute));
            }
        }
        public bool CanExecute
        {
            get
            {
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
                return true;
            }
        }

        public void MyAction()
        {
            ExecutionSwitchTheme();
        }

        private void ExecutionSwitchTheme()
        {
            var theme = ThemeManager.Current.DetectTheme(App.Current);
            var newTheme = ThemeManager.Current.GetInverseTheme(theme);
            _ = ThemeManager.Current.ChangeTheme(App.Current, newTheme);
            App.RaiseThemeChanged(newTheme);
        }

        #region Zeitangabe
        //public int Zeit
        //{
        //    get { return (int)GetValue(ZeitProperty); }
        //    set { SetValue(ZeitProperty, value); }
        //}
        public static readonly DependencyProperty ZeitProperty = DependencyProperty.Register("Zeit", typeof(int), typeof(MainWindow));
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Shutdown(sender, e);
            this.Close();
            MessageBox.Show($"The PC will shutdown in {TextBox_Timer.Text} minutes");
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            bool timeconvert = int.TryParse(TextBox_Timer.Text, out _);
            if (timeconvert)
            {
                string input = TextBox_Timer.Text;
                if (input?.Length == 0)
                {
                    Shutdown(sender, e);
                }
                else if (int.TryParse(input, out int timer))
                {
                    timer *= 60;
                    Command($"shutdown -s -t {timer}");
                }
                else
                {
                    Shutdown(sender, e);
                }
            }
            else
            {
                TextBox_Timer.Text.DefaultIfEmpty();
            }
        }

        public void Command(string input)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            _ = process.Start();
            process.StandardInput.WriteLine(input);
            process.StandardInput.Flush();
            process.StandardInput.Close();
        }

        private void TextBox_Timer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.Clear();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
