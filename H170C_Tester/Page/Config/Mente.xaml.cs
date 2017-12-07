﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace H170C_Tester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Mente
    {
        private SolidColorBrush ButtonOnBrush = new SolidColorBrush();
        private SolidColorBrush ButtonOffBrush = new SolidColorBrush();
        private const double ButtonOpacity = 0.4;

        public Mente()
        {
            InitializeComponent();
            CanvasCommLpc1768.DataContext = State.VmComm;
            CanvasCommTarget.DataContext = State.VmComm;


            ButtonOnBrush.Color = Colors.DodgerBlue;
            ButtonOffBrush.Color = Colors.Transparent;
            ButtonOnBrush.Opacity = ButtonOpacity;
            ButtonOffBrush.Opacity = ButtonOpacity;

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            buttonPow.Background = Brushes.Transparent;

            //以下は時間がかかる処理のため、非同期にしないと別ページに遷移した時に若干フリーズする
            Task.Run(() =>
            {
                General.PowSupply(false);
            });

        }


        bool FlagPow;
        private void buttonPow_Click(object sender, RoutedEventArgs e)
        {
            if (FlagPow)
            {
                General.PowSupply(false);
                buttonPow.Background = ButtonOffBrush;
            }
            else
            {
                General.PowSupply(true);
                buttonPow.Background = ButtonOnBrush;
            }

            FlagPow = !FlagPow;
        }




        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            State.VmComm.LPC1768_RX = "";
            State.VmComm.LPC1768_TX = "";
            State.VmComm.TARGET_RX = "";
            State.VmComm.TARGET_TX = "";
        }


        private void buttonStamp_Click(object sender, RoutedEventArgs e)
        {
            buttonStamp.Background = ButtonOnBrush;
            General.StampOn();
            buttonStamp.Background = ButtonOffBrush;
        }

        private void buttonSendLpc1768_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendData1768(tbCommandLpc1768.Text);
        }

        private void buttonSendTarget_Click(object sender, RoutedEventArgs e)
        {
            LPC1768.SendDataTarget(tbCommandTarget.Text);
        }


    }
}
