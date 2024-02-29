using System.CodeDom;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Gonzales_MovementAndTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Moves a control from left to right using a timer and margins
    /// </summary>
    public partial class MainWindow : Window
    {
        private int gMoveDirection = 1;
        private int gMoveValue = 0;
        private int dirdir = -1;
        int i = 0;
        int ii = 0;
        DispatcherTimer testTimer;


        public MainWindow()
        {
            InitializeComponent();
            testTimer_Setup();
            sldMoveLength.Value = 20;
            sldTimeDelay.Value = 1000;
            tbTimerCounter.TextAlignment = (TextAlignment)HorizontalAlignment.Center;

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you Sure?", "Do you want to Exit?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        

        private void sldTimeDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void sldMoveLength_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
        private void MoveImage()
        {
            gMoveValue = (int)sldMoveLength.Value;
            tbTimerCounter.Text = testTimer.Interval.TotalMilliseconds.ToString();

            Thickness coord = imgMovement.Margin;
            int moveLength = (int)sldMoveLength.Value;
            if (coord.Right > 25 && dirdir == -1)
            {
                moveLength = moveLength * gMoveDirection;
                coord.Left = coord.Left + moveLength;
                coord.Right = coord.Right - moveLength;
                imgMovement.Margin = coord;
            }
            else
            {
                dirdir = 0;
            }

            if (coord.Left > 25 && dirdir == 0)
            { 
                moveLength = moveLength * gMoveDirection*-1;
                coord.Left = coord.Left + moveLength;
                coord.Right = coord.Right - moveLength;
                imgMovement.Margin = coord;
            }
            else
            {
                dirdir = -1;
            }
                
                
               
                
        }
        private void testTimer_Setup()
        {
            testTimer = new DispatcherTimer();
            testTimer.Tick += new EventHandler( TestTimer_Tick);
            testTimer.Interval = TimeSpan.FromMilliseconds(sldTimeDelay.Value);
        }
        private void winMain_ContentRendered(object sender, EventArgs e)
        {
            //-- There may be other lines of code here. Leave them alone.
            testTimer_Setup();
        }
        private void TestTimer_Tick(object sender, EventArgs e)
        {
            MoveImage();
            lblTimeDelaySliderVal.Content = sldTimeDelay.Value;
            lblMovementSliderVal.Content = sldMoveLength.Value;
            testTimer.Interval = TimeSpan.FromMilliseconds(sldTimeDelay.Value);
            tbTimerCounter.Text = DateTime.Now.Second.ToString();
            
            if(DateTime.Now.Second.ToString() == "59")
            {
                i += 1;
                tbTimerCounter_minute.Text = i.ToString();
            }
            if(i == 60)
            {
                i = 0;
                ii += 1;
                tbTimerCounter_hour.Text = i.ToString();
            }
             

        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            testTimer.Start();
            btnStart.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Visible;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            testTimer.Stop();
            btnStop.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Visible;
        }
    }
}