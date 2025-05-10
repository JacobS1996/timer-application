using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Timer
{
    /// <summary>
    /// Interaction logic for TimerUserControl.xaml
    /// </summary>
    public partial class TimerUserControl : UserControl, INotifyPropertyChanged
    {
        private static System.Timers.Timer timer = new System.Timers.Timer(10);


        private static DateTime timerValueDateTime = DateTime.MinValue;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _timerValue = timerValueDateTime.ToString("HH:mm:ss.ff");

        public string? TimerValue
        {
            get 
            {
                return _timerValue; 
            }
            set 
            {
                _timerValue = value;
                OnPropertyChanged();
            }
        } 



        public TimerUserControl()
        {
            InitializeComponent();
            timerTextBlock.DataContext = this;
            
            
          
            



        }
        private void startStopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            RunTimer();
        }

        private void lapSplitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunTimer()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            timerValueDateTime = timerValueDateTime.AddMilliseconds(10);
            TimerValue = timerValueDateTime.ToString("HH:mm:ss:ff");
           
        }

        private void OnPropertyChanged([CallerMemberName] string name = "TimerValue")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    



    }
}
