using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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
using System.Timers;
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.Timers.Timer _animationsTimer = new System.Timers.Timer(20); // 20 ms Interval
        private bool goToRight = true;
        private bool goDown = true;

        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Elapsed += (sender, e) =>
            {
                Dispatcher.Invoke(BallPositioning); // Zugriff auf den UI-Thread
            };
            
        }

        private void BallPositioning()
        {
            var x = Canvas.GetLeft(Ball);

            if(goToRight)
            {
                Canvas.SetLeft(Ball, x + 5);
            }
            else
            {
                Canvas.SetLeft(Ball, x - 5);
            }

            if(x + Ball.Width >=PlayGround.ActualWidth)
            {
                goToRight = false;
            }
            else if(x <= 0)
            {
                goToRight= true;
            }
            var y = Canvas.GetTop(Ball);

            if (goDown)
            {
                Canvas.SetTop(Ball, y + 5);
            }
            else
            {
                Canvas.SetTop(Ball, y - 5);
            }

            if (y + Ball.Height >= PlayGround.ActualHeight)
            {
                goDown = false;
            }
            else if (y <= 0)
            {
                goDown = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_animationsTimer.Enabled)
            {
                _animationsTimer.Stop();
            }
            else
            {
                _animationsTimer.Start();
            }
                       
           

        }
    }
}
