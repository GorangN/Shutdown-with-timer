namespace Shutdown_with_timer
{
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Forms;
    using System.Resources;

    using MahApps.Metro.Controls;
    using System;
    using ControlzEx.Theming;

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
            NotifyIcon _notifyIcon = new NotifyIcon();
            //_notifyIcon.Icon = new System.Drawing.Icon(@"Resources/iconfinder_exit_17902.ico");
            //_notifyIcon.Text = "Shutdown Timer";
            //_notifyIcon.Click += NotifyIcon_Click;
            //_notifyIcon.Visible = true;
            //_notifyIcon.ContextMenuStrip.Items.Add("Status");

            InitializeComponent();
            DataContext = this;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string value = TypeOfDestruction();
            this.WindowState = WindowState.Minimized;
            Hide();
            //TODO: Minimize to System Tray

            System.Windows.MessageBox.Show($"The PC will {value} in {TextBox_Timer.Text} minutes \n\n Confirm with OK: ");
            ExecuteCommand(sender, e, value);
        }

        private string TypeOfDestruction()
        {
            string value = "Error";
            if (comboBox.SelectedItem == shutdown)
            {
                value = "shutdown";
            }
            else if (comboBox.SelectedItem == sleep)
            {
                value = "sleep";
            }
            else if (comboBox.SelectedItem == lockdesktop)
            {
                value = "lockScreen";
            }
            return value;
        }
        private void ExecuteCommand(object sender, RoutedEventArgs e, string value)
        {
            if (value == "shutdown")
            {
                Shutdown(sender, e);
            }
            else if (value == "sleep")
            {
                Sleep(sender, e);
            }
            else if (value == "lockScreen")
            {
                LockScreen(sender, e);
            }
        }

        #region TypeOfExecution
        private void LockScreen(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox_Timer.Text, out _))
            {
                string input = TextBox_Timer.Text;
                if ((input?.Length) != 0)
                {
                    if (int.TryParse(input, out int timer))
                    {
                        timer *= 1000 * 60;
                        System.Threading.Thread.Sleep(timer);
                        Command("Rundll32.exe user32.dll,LockWorkStation");
                    }
                }
            }
        }

        private void Sleep(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox_Timer.Text, out _))
            {
                string input = TextBox_Timer.Text;
                if ((input?.Length) != 0)
                {
                    if (int.TryParse(input, out int timer))
                    {
                        timer *= 1000 * 60;
                        System.Threading.Thread.Sleep(timer);
                        Command("rundll32.exe powrprof.dll, SetSuspendState Sleep");
                    }
                }
            }
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            bool timeconvert = int.TryParse(TextBox_Timer.Text, out _);
            if (timeconvert)
            {
                string input = TextBox_Timer.Text;
                if ((input?.Length) != 0)
                {
                    if (int.TryParse(input, out int timer))
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
                    Shutdown(sender, e);
                }
            }
            else
            {
                TextBox_Timer.Text.DefaultIfEmpty();
            }
        }
        #endregion

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
            var textbox = sender as System.Windows.Controls.TextBox;
            textbox.Clear();
        }
<<<<<<< HEAD

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
=======
>>>>>>> 746ba54dac73f59bb24e1b1fb346b9f42e5c25f6
    }
}
