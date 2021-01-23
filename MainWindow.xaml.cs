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

namespace Shutdown_with_timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Zeitangabe
        public int Zeit
        {
            get { return (int)GetValue(ZeitProperty); }
            set { SetValue(ZeitProperty, value); }
        }
        public static readonly DependencyProperty ZeitProperty = DependencyProperty.Register("Zeit", typeof(int), typeof(MainWindow));
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            void Shutdown()
            {
                Console.Write("Timer(seconds): ");
                var x = Console.ReadLine();
                if (int.TryParse(x, out int timer))
                {
                    Command($"shutdown -s -t {timer}");
                }
            }
        }

        public static void Command(string input)
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
            Console.WriteLine();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press Enter");
            Console.ReadKey();
        }
    }
}
