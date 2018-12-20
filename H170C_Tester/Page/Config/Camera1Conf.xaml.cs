using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using OpenCvSharp;
using System.Windows.Input;
using System.Linq;
using System;
using System.Threading;

namespace H170C_Tester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Camera1Conf
    {
        bool IsEnableSave;

        public Camera1Conf()
        {
            InitializeComponent();
            this.DataContext = General.cam1;
            canvasLdPoint.DataContext = State.VmCamera1Point;
            toggleSw.IsChecked = General.cam1.Opening;

            IsEnableSave = false;

            buttonSaveRed.IsEnabled = false;
            buttonSaveGreen.IsEnabled = false;
            buttonSaveBlue.IsEnabled = false;
            buttonSavePoint.IsEnabled = false;

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.MainWinEnable = false;
            await Task.Delay(1200);
            State.VmMainWindow.MainWinEnable = true;
            State.SetCam1Prop();
            General.cam1.Start();
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;

        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            RedOn = false;
            BlueOn = false;
            GreenOn = false;
            await General.cam1.Stop();
            resetView();

            FlagLabeling = false;
            BinSw = false;

            buttonLabeling.IsEnabled = true;
            buttonBin.IsEnabled = true;
            canvasLdPoint.IsEnabled = true;

            //TODO:
            //LEDを全消灯させる処理
            General.ResetIo();
            State.SetCam1Prop();
            await Task.Delay(500);
        }

        private void resetView()
        {
            buttonRed.Background = General.OffBrush;
            buttonBlue.Background = General.OffBrush;
            buttonGreen.Background = General.OffBrush;
            buttonBin.Background = General.OffBrush;

            State.VmCamera1Point.LED1 = "";
            State.VmCamera1Point.LED2 = "";
            State.VmCamera1Point.LED3 = "";
            State.VmCamera1Point.LED4 = "";
            State.VmCamera1Point.LED5 = "";
            State.VmCamera1Point.LED6 = "";
            State.VmCamera1Point.LED7 = "";

        }


        private void SaveCameraCommonProp()
        {
            //すべてのデータを保存する
            State.camCommonProp.Brightness = General.cam1.Brightness;
            State.camCommonProp.Contrast = General.cam1.Contrast;
            State.camCommonProp.Hue = General.cam1.Hue;
            State.camCommonProp.Saturation = General.cam1.Saturation;
            State.camCommonProp.Sharpness = General.cam1.Sharpness;
            State.camCommonProp.Gamma = General.cam1.Gamma;
            State.camCommonProp.Gain = General.cam1.Gain;
            State.camCommonProp.Exposure = General.cam1.Exposure;
            State.camCommonProp.Whitebalance = General.cam1.Wb;
            State.camCommonProp.Theta = General.cam1.Theta;
            State.camCommonProp.BinLevel = General.cam1.BinLevel;

            State.camCommonProp.Opening = General.cam1.Opening;
            State.camCommonProp.OpenCnt = General.cam1.openCnt;
            State.camCommonProp.CloseCnt = General.cam1.closeCnt;

        }
        private void SaveRedLum()
        {
            State.cam1Prop.LumRedLed1 = Double.Parse(State.VmCamera1Point.LED1Lum);
            State.cam1Prop.LumRedLed2 = Double.Parse(State.VmCamera1Point.LED2Lum);
            State.cam1Prop.LumRedLed3 = Double.Parse(State.VmCamera1Point.LED3Lum);
            State.cam1Prop.LumRedLed4 = Double.Parse(State.VmCamera1Point.LED4Lum);
            State.cam1Prop.LumRedLed5 = Double.Parse(State.VmCamera1Point.LED5Lum);
            State.cam1Prop.LumRedLed6 = Double.Parse(State.VmCamera1Point.LED6Lum);
            State.cam1Prop.LumRedLed7 = Double.Parse(State.VmCamera1Point.LED7Lum);
        }
        private void SaveBlueLum()
        {
            State.cam1Prop.LumBlueLed1 = Double.Parse(State.VmCamera1Point.LED1Lum);
            State.cam1Prop.LumBlueLed2 = Double.Parse(State.VmCamera1Point.LED2Lum);
            State.cam1Prop.LumBlueLed3 = Double.Parse(State.VmCamera1Point.LED3Lum);
            State.cam1Prop.LumBlueLed4 = Double.Parse(State.VmCamera1Point.LED4Lum);
            State.cam1Prop.LumBlueLed5 = Double.Parse(State.VmCamera1Point.LED5Lum);
            State.cam1Prop.LumBlueLed6 = Double.Parse(State.VmCamera1Point.LED6Lum);
            State.cam1Prop.LumBlueLed7 = Double.Parse(State.VmCamera1Point.LED7Lum);
        }
        private void SaveGreenLum()
        {
            State.cam1Prop.LumGreenLed1 = Double.Parse(State.VmCamera1Point.LED1Lum);
            State.cam1Prop.LumGreenLed2 = Double.Parse(State.VmCamera1Point.LED2Lum);
            State.cam1Prop.LumGreenLed3 = Double.Parse(State.VmCamera1Point.LED3Lum);
            State.cam1Prop.LumGreenLed4 = Double.Parse(State.VmCamera1Point.LED4Lum);
            State.cam1Prop.LumGreenLed5 = Double.Parse(State.VmCamera1Point.LED5Lum);
            State.cam1Prop.LumGreenLed6 = Double.Parse(State.VmCamera1Point.LED6Lum);
            State.cam1Prop.LumGreenLed7 = Double.Parse(State.VmCamera1Point.LED7Lum);
        }

        private void SavePoint()
        {
            State.cam1Prop.LED1 = State.VmCamera1Point.LED1;
            State.cam1Prop.LED2 = State.VmCamera1Point.LED2;
            State.cam1Prop.LED3 = State.VmCamera1Point.LED3;
            State.cam1Prop.LED4 = State.VmCamera1Point.LED4;
            State.cam1Prop.LED5 = State.VmCamera1Point.LED5;
            State.cam1Prop.LED6 = State.VmCamera1Point.LED6;
            State.cam1Prop.LED7 = State.VmCamera1Point.LED7;
        }


        private void im_MouseLeave(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            General.cam1.FlagHsv = false;
        }

        private void im_MouseEnter(object sender, MouseEventArgs e)
        {
            General.cam1.FlagHsv = true;
            tbHsv.Visibility = System.Windows.Visibility.Visible;
        }

        private void im_MouseMove(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Visible;
            Point point = e.GetPosition(im);
            tbPoint.Text = "XY=" + ((int)(point.X)).ToString() + "/" + ((int)(point.Y)).ToString();

            General.cam1.PointX = (int)point.X;
            General.cam1.PointY = (int)point.Y;

            tbHsv.Text = "HSV=" + General.cam1.Hdata.ToString() + "," + General.cam1.Sdata.ToString() + "," + General.cam1.Vdata.ToString();
        }

        bool RedOn;
        private async void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }

            if (BlueOn || GreenOn || FlagLabeling) return;

            RedOn = !RedOn;
            if (RedOn)
            {
                buttonSaveRed.IsEnabled = true;
                buttonRed.Background = General.OnBrush;
                await Task.Run(() =>
                {
                    General.PowSupply(true);

                    LPC1768.SendDataTarget("WP3101");//LED1,2の赤
                    LPC1768.SendDataTarget("WP1201");//LED3,4の赤
                    LPC1768.SendDataTarget("WP1701");//LED5,6の赤
                    LPC1768.SendDataTarget("WP2201");//LED7,8の赤
                });
            }
            else
            {
                buttonSaveRed.IsEnabled = false;
                buttonRed.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }

        }

        bool BlueOn;
        private async void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }

            if (RedOn || GreenOn || FlagLabeling) return;

            BlueOn = !BlueOn;
            if (BlueOn)
            {
                buttonSaveBlue.IsEnabled = true;
                buttonBlue.Background = General.OnBrush;
                await Task.Run(() =>
                {
                    General.PowSupply(true);
                    Thread.Sleep(500);
                    LPC1768.SendDataTarget("WP3001");//LED1,2の青
                    LPC1768.SendDataTarget("WP1101");//LED3,4の青
                    LPC1768.SendDataTarget("WP1601");//LED5,6の青
                    LPC1768.SendDataTarget("WP2101");//LED7,8の青
                });
            }
            else
            {
                buttonSaveBlue.IsEnabled = false;
                buttonBlue.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }
        }

        bool GreenOn;
        private async void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }

            if (RedOn || BlueOn || FlagLabeling) return;

            GreenOn = !GreenOn;
            if (GreenOn)
            {
                buttonSaveGreen.IsEnabled = true;
                buttonGreen.Background = General.OnBrush;
                await Task.Run(() =>
                {
                    General.PowSupply(true);
                    Thread.Sleep(500);
                    LPC1768.SendDataTarget("WP1001");//LED1,2の緑
                    LPC1768.SendDataTarget("WP1301");//LED3,4の緑
                    LPC1768.SendDataTarget("WP2001");//LED5,6の緑
                    LPC1768.SendDataTarget("WP2301");//LED7,8の緑
                });
            }
            else
            {
                buttonSaveGreen.IsEnabled = false;
                buttonGreen.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }
        }







        bool BinSw = false;
        private void buttonBin_Click(object sender, RoutedEventArgs e)
        {
            General.cam1.ResetFlag();
            BinSw = !BinSw;
            General.cam1.FlagBin = BinSw;
            buttonBin.Background = BinSw ? Brushes.DodgerBlue : Brushes.Transparent;

            buttonLabeling.IsEnabled = !BinSw;
            canvasLdPoint.IsEnabled = !BinSw;

        }


        private void toggleSw_Checked(object sender, RoutedEventArgs e)
        {
            General.cam1.Opening = true;
        }

        private void toggleSw_Unchecked(object sender, RoutedEventArgs e)
        {
            General.cam1.Opening = false;
        }


        private void labeling()
        {
            Task.Run(() =>
            {
                while (FlagLabeling)
                {
                    if (General.cam1.blobs == null) continue;
                    var blobInfo = General.cam1.blobs.Clone();

                    //正方形のブロブだけ抽出（dpだけ抽出）
                    var rectBlobs = blobInfo.Where(pair =>
                    {
                        CvRect rect = pair.Value.Rect;
                        return Math.Abs(rect.Height - rect.Width) < 10;
                    });


                    var SortRectBlob = rectBlobs.OrderByDescending(b => b.Value.Centroid.X).ToList();
                    if (SortRectBlob.Count() != 7)
                    {
                        State.VmCamera1Point.LED1 = "";
                        State.VmCamera1Point.LED1Lum = "";

                        State.VmCamera1Point.LED2 = "";
                        State.VmCamera1Point.LED2Lum = "";

                        State.VmCamera1Point.LED3 = "";
                        State.VmCamera1Point.LED3Lum = "";

                        State.VmCamera1Point.LED4 = "";
                        State.VmCamera1Point.LED4Lum = "";

                        State.VmCamera1Point.LED5 = "";
                        State.VmCamera1Point.LED5Lum = "";

                        State.VmCamera1Point.LED6 = "";
                        State.VmCamera1Point.LED6Lum = "";

                        State.VmCamera1Point.LED7 = "";
                        State.VmCamera1Point.LED7Lum = "";

                        IsEnableSave = false;
                        continue;
                    }

                    IsEnableSave = true;

                    //ビューモデルの更新
                    State.VmCamera1Point.LED1 = SortRectBlob[0].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[0].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED1Lum = SortRectBlob[0].Value.Area.ToString();

                    State.VmCamera1Point.LED2 = SortRectBlob[1].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[1].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED2Lum = SortRectBlob[1].Value.Area.ToString();

                    State.VmCamera1Point.LED3 = SortRectBlob[2].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[2].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED3Lum = SortRectBlob[2].Value.Area.ToString();

                    State.VmCamera1Point.LED4 = SortRectBlob[3].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[3].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED4Lum = SortRectBlob[3].Value.Area.ToString();

                    State.VmCamera1Point.LED5 = SortRectBlob[4].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[4].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED5Lum = SortRectBlob[4].Value.Area.ToString();

                    State.VmCamera1Point.LED6 = SortRectBlob[5].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[5].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED6Lum = SortRectBlob[5].Value.Area.ToString();

                    State.VmCamera1Point.LED7 = SortRectBlob[6].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[6].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED7Lum = SortRectBlob[6].Value.Area.ToString();
                }

                //終了処理
                State.VmCamera1Point.LED1 = "";
                State.VmCamera1Point.LED1Lum = "";

                State.VmCamera1Point.LED2 = "";
                State.VmCamera1Point.LED2Lum = "";

                State.VmCamera1Point.LED3 = "";
                State.VmCamera1Point.LED3Lum = "";

                State.VmCamera1Point.LED4 = "";
                State.VmCamera1Point.LED4Lum = "";

                State.VmCamera1Point.LED5 = "";
                State.VmCamera1Point.LED5Lum = "";

                State.VmCamera1Point.LED6 = "";
                State.VmCamera1Point.LED6Lum = "";

                State.VmCamera1Point.LED7 = "";
                State.VmCamera1Point.LED7Lum = "";
                IsEnableSave = false;
            });
        }

        bool FlagLabeling;
        private void buttonLabeling_Click(object sender, RoutedEventArgs e)
        {
            if (!RedOn && !GreenOn && !BlueOn)
                return;

            FlagLabeling = !FlagLabeling;

            buttonBin.IsEnabled = !FlagLabeling;

            buttonLabeling.Background = FlagLabeling ? General.OnBrush : General.OffBrush;

            if (FlagLabeling)
            {
                buttonSavePoint.IsEnabled = true;
                General.cam1.ResetFlag();
                General.cam1.FlagLabeling = true;

                labeling();
            }
            else
            {
                buttonSavePoint.IsEnabled = false;
                General.cam1.ResetFlag();
            }

        }

        private async void buttonSaveCamProp_Click(object sender, RoutedEventArgs e)
        {
            buttonSaveCamProp.Background = Brushes.DodgerBlue;
            SaveCameraCommonProp();
            await Task.Delay(150);
            General.PlaySound(General.soundSuccess);
            buttonSaveCamProp.Background = Brushes.Transparent;
        }

        private async void buttonSaveRed_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEnableSave)
                return;

            buttonSaveRed.Background = Brushes.DodgerBlue;
            SaveRedLum();
            await Task.Delay(150);
            General.PlaySound(General.soundSuccess);
            buttonSaveRed.Background = Brushes.Transparent;
        }

        private async void buttonSaveBlue_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEnableSave)
                return;

            buttonSaveBlue.Background = Brushes.DodgerBlue;
            SaveBlueLum();
            await Task.Delay(150);
            General.PlaySound(General.soundSuccess);
            buttonSaveBlue.Background = Brushes.Transparent;
        }

        private async void buttonSaveGreen_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEnableSave)
                return;

            buttonSaveGreen.Background = Brushes.DodgerBlue;
            SaveGreenLum();
            await Task.Delay(150);
            General.PlaySound(General.soundSuccess);
            buttonSaveGreen.Background = Brushes.Transparent;
        }

        private async void buttonSavePoint_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEnableSave)
                return;

            buttonSavePoint.Background = Brushes.DodgerBlue;
            SavePoint();
            await Task.Delay(150);
            General.PlaySound(General.soundSuccess);
            buttonSavePoint.Background = Brushes.Transparent;

        }


    }
}
