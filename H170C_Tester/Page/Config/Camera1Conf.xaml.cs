using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using OpenCvSharp;
using System.Windows.Input;
using System.Linq;
using System;
using System.Threading;
using static System.Threading.Thread;
using System.Windows.Media.Animation;

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
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Flags.EnableCam1ConfPage = false;
            labelMess.Opacity = 0;
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            RingCal.IsActive = false;

            IsEnableSave = false;

            if (!General.cam1.CamState)
                return;
            State.VmMainWindow.MainWinEnable = false;
            await Task.Delay(1200);
            State.VmMainWindow.MainWinEnable = true;
            State.SetCam1Prop();
            General.cam1.Start();
        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            RedOn = false;
            BlueOn = false;
            GreenOn = false;
            resetView();

            FlagLabeling = false;

            buttonLabeling.IsEnabled = true;
            canvasLdPoint.IsEnabled = true;

            //TODO:
            //LEDを全消灯させる処理
            General.ResetIo();
            if (!General.cam1.CamState)
                return;
            await General.cam1.Stop();
            State.SetCam1Prop();
            Flags.EnableCam1ConfPage = true;
        }

        private void resetView()
        {
            State.VmCamera1Point.LED1 = "";
            State.VmCamera1Point.LED2 = "";
            State.VmCamera1Point.LED3 = "";
            State.VmCamera1Point.LED4 = "";
            State.VmCamera1Point.LED5 = "";
            State.VmCamera1Point.LED6 = "";
            State.VmCamera1Point.LED7 = "";

            State.VmCamera1Point.LED1LumR = "";
            State.VmCamera1Point.LED2LumR = "";
            State.VmCamera1Point.LED3LumR = "";
            State.VmCamera1Point.LED4LumR = "";
            State.VmCamera1Point.LED5LumR = "";
            State.VmCamera1Point.LED6LumR = "";
            State.VmCamera1Point.LED7LumR = "";

            State.VmCamera1Point.LED1LumG = "";
            State.VmCamera1Point.LED2LumG = "";
            State.VmCamera1Point.LED3LumG = "";
            State.VmCamera1Point.LED4LumG = "";
            State.VmCamera1Point.LED5LumG = "";
            State.VmCamera1Point.LED6LumG = "";
            State.VmCamera1Point.LED7LumG = "";

            State.VmCamera1Point.LED1LumB = "";
            State.VmCamera1Point.LED2LumB = "";
            State.VmCamera1Point.LED3LumB = "";
            State.VmCamera1Point.LED4LumB = "";
            State.VmCamera1Point.LED5LumB = "";
            State.VmCamera1Point.LED6LumB = "";
            State.VmCamera1Point.LED7LumB = "";

            State.VmCamera1Point.HueLed1R = "";
            State.VmCamera1Point.HueLed2R = "";
            State.VmCamera1Point.HueLed3R = "";
            State.VmCamera1Point.HueLed4R = "";
            State.VmCamera1Point.HueLed5R = "";
            State.VmCamera1Point.HueLed6R = "";
            State.VmCamera1Point.HueLed7R = "";

            State.VmCamera1Point.HueLed1G = "";
            State.VmCamera1Point.HueLed2G = "";
            State.VmCamera1Point.HueLed3G = "";
            State.VmCamera1Point.HueLed4G = "";
            State.VmCamera1Point.HueLed5G = "";
            State.VmCamera1Point.HueLed6G = "";
            State.VmCamera1Point.HueLed7G = "";

            State.VmCamera1Point.HueLed1B = "";
            State.VmCamera1Point.HueLed2B = "";
            State.VmCamera1Point.HueLed3B = "";
            State.VmCamera1Point.HueLed4B = "";
            State.VmCamera1Point.HueLed5B = "";
            State.VmCamera1Point.HueLed6B = "";
            State.VmCamera1Point.HueLed7B = "";


            State.VmCamera1Point.ColLed1R = General.OffBrush;
            State.VmCamera1Point.ColLed2R = General.OffBrush;
            State.VmCamera1Point.ColLed3R = General.OffBrush;
            State.VmCamera1Point.ColLed4R = General.OffBrush;
            State.VmCamera1Point.ColLed5R = General.OffBrush;
            State.VmCamera1Point.ColLed6R = General.OffBrush;
            State.VmCamera1Point.ColLed7R = General.OffBrush;

            State.VmCamera1Point.ColLed1G = General.OffBrush;
            State.VmCamera1Point.ColLed2G = General.OffBrush;
            State.VmCamera1Point.ColLed3G = General.OffBrush;
            State.VmCamera1Point.ColLed4G = General.OffBrush;
            State.VmCamera1Point.ColLed5G = General.OffBrush;
            State.VmCamera1Point.ColLed6G = General.OffBrush;
            State.VmCamera1Point.ColLed7G = General.OffBrush;

            State.VmCamera1Point.ColLed1B = General.OffBrush;
            State.VmCamera1Point.ColLed2B = General.OffBrush;
            State.VmCamera1Point.ColLed3B = General.OffBrush;
            State.VmCamera1Point.ColLed4B = General.OffBrush;
            State.VmCamera1Point.ColLed5B = General.OffBrush;
            State.VmCamera1Point.ColLed6B = General.OffBrush;
            State.VmCamera1Point.ColLed7B = General.OffBrush;

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
            State.camCommonProp.OpenCnt = General.cam1.OpenCnt;
            State.camCommonProp.CloseCnt = General.cam1.CloseCnt;

        }
        private void SaveRedLum()
        {
            State.cam1Prop.LumRedLed1 = Double.Parse(State.VmCamera1Point.LED1LumR);
            State.cam1Prop.LumRedLed2 = Double.Parse(State.VmCamera1Point.LED2LumR);
            State.cam1Prop.LumRedLed3 = Double.Parse(State.VmCamera1Point.LED3LumR);
            State.cam1Prop.LumRedLed4 = Double.Parse(State.VmCamera1Point.LED4LumR);
            State.cam1Prop.LumRedLed5 = Double.Parse(State.VmCamera1Point.LED5LumR);
            State.cam1Prop.LumRedLed6 = Double.Parse(State.VmCamera1Point.LED6LumR);
            State.cam1Prop.LumRedLed7 = Double.Parse(State.VmCamera1Point.LED7LumR);
        }
        private void SaveBlueLum()
        {
            State.cam1Prop.LumBlueLed1 = Double.Parse(State.VmCamera1Point.LED1LumB);
            State.cam1Prop.LumBlueLed2 = Double.Parse(State.VmCamera1Point.LED2LumB);
            State.cam1Prop.LumBlueLed3 = Double.Parse(State.VmCamera1Point.LED3LumB);
            State.cam1Prop.LumBlueLed4 = Double.Parse(State.VmCamera1Point.LED4LumB);
            State.cam1Prop.LumBlueLed5 = Double.Parse(State.VmCamera1Point.LED5LumB);
            State.cam1Prop.LumBlueLed6 = Double.Parse(State.VmCamera1Point.LED6LumB);
            State.cam1Prop.LumBlueLed7 = Double.Parse(State.VmCamera1Point.LED7LumB);
        }
        private void SaveGreenLum()
        {
            State.cam1Prop.LumGreenLed1 = Double.Parse(State.VmCamera1Point.LED1LumG);
            State.cam1Prop.LumGreenLed2 = Double.Parse(State.VmCamera1Point.LED2LumG);
            State.cam1Prop.LumGreenLed3 = Double.Parse(State.VmCamera1Point.LED3LumG);
            State.cam1Prop.LumGreenLed4 = Double.Parse(State.VmCamera1Point.LED4LumG);
            State.cam1Prop.LumGreenLed5 = Double.Parse(State.VmCamera1Point.LED5LumG);
            State.cam1Prop.LumGreenLed6 = Double.Parse(State.VmCamera1Point.LED6LumG);
            State.cam1Prop.LumGreenLed7 = Double.Parse(State.VmCamera1Point.LED7LumG);
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
            if (BlueOn || GreenOn || FlagLabeling || ShowHue)
                return;

            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }


            RedOn = !RedOn;
            if (RedOn)
            {
                buttonSavePoint.IsEnabled = false;
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
                buttonSavePoint.IsEnabled = true;
                buttonRed.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }

        }

        bool BlueOn;
        private async void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            if (RedOn || GreenOn || FlagLabeling || ShowHue)
                return;

            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }


            BlueOn = !BlueOn;
            if (BlueOn)
            {
                buttonSavePoint.IsEnabled = false;
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
                buttonSavePoint.IsEnabled = true;
                buttonBlue.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }
        }

        bool GreenOn;
        private async void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            if (RedOn || BlueOn || FlagLabeling || ShowHue)
                return;

            if (!General.CheckPress())
            {
                MessageBox.Show("プレス治具のレバーを下げてください");
                return;
            }


            GreenOn = !GreenOn;
            if (GreenOn)
            {
                buttonSavePoint.IsEnabled = false;
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
                buttonSavePoint.IsEnabled = true;
                buttonGreen.Background = General.OffBrush;
                LPC1768.SendDataTarget("C");//LED7,8の赤
            }
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
            IsEnableSave = false;
            Task.Run(() =>
            {
                while (FlagLabeling)
                {
                    if (General.cam1.blobs == null) continue;
                    var blobInfo = General.cam1.blobs.Clone();

                    ////正方形のブロブだけ抽出（dpだけ抽出）
                    //var rectBlobs = blobInfo.Where(pair =>
                    //{
                    //    CvRect rect = pair.Value.Rect;
                    //    return Math.Abs(rect.Height - rect.Width) < 10;
                    //});


                    var SortRectBlob = blobInfo.OrderByDescending(b => b.Value.Centroid.X).ToList();
                    if (SortRectBlob.Count() != 7)
                    {
                        if (RedOn)
                        {
                            State.VmCamera1Point.LED1LumR = "";
                            State.VmCamera1Point.LED2LumR = "";
                            State.VmCamera1Point.LED3LumR = "";
                            State.VmCamera1Point.LED4LumR = "";
                            State.VmCamera1Point.LED5LumR = "";
                            State.VmCamera1Point.LED6LumR = "";
                            State.VmCamera1Point.LED7LumR = "";
                        }
                        else if (GreenOn)
                        {
                            State.VmCamera1Point.LED1LumG = "";
                            State.VmCamera1Point.LED2LumG = "";
                            State.VmCamera1Point.LED3LumG = "";
                            State.VmCamera1Point.LED4LumG = "";
                            State.VmCamera1Point.LED5LumG = "";
                            State.VmCamera1Point.LED6LumG = "";
                            State.VmCamera1Point.LED7LumG = "";
                        }
                        else if (BlueOn)
                        {
                            State.VmCamera1Point.LED1LumB = "";
                            State.VmCamera1Point.LED2LumB = "";
                            State.VmCamera1Point.LED3LumB = "";
                            State.VmCamera1Point.LED4LumB = "";
                            State.VmCamera1Point.LED5LumB = "";
                            State.VmCamera1Point.LED6LumB = "";
                            State.VmCamera1Point.LED7LumB = "";
                        }

                        State.VmCamera1Point.LED1 = "";
                        State.VmCamera1Point.LED2 = "";
                        State.VmCamera1Point.LED3 = "";
                        State.VmCamera1Point.LED4 = "";
                        State.VmCamera1Point.LED5 = "";
                        State.VmCamera1Point.LED6 = "";
                        State.VmCamera1Point.LED7 = "";

                        IsEnableSave = false;
                        continue;
                    }

                    IsEnableSave = true;

                    //ビューモデルの更新
                    if (RedOn)
                    {
                        State.VmCamera1Point.LED1LumR = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera1Point.LED2LumR = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera1Point.LED3LumR = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera1Point.LED4LumR = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera1Point.LED5LumR = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera1Point.LED6LumR = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera1Point.LED7LumR = SortRectBlob[6].Value.Area.ToString();
                    }
                    else if (GreenOn)
                    {
                        State.VmCamera1Point.LED1LumG = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera1Point.LED2LumG = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera1Point.LED3LumG = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera1Point.LED4LumG = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera1Point.LED5LumG = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera1Point.LED6LumG = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera1Point.LED7LumG = SortRectBlob[6].Value.Area.ToString();
                    }
                    else if (BlueOn)
                    {
                        State.VmCamera1Point.LED1LumB = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera1Point.LED2LumB = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera1Point.LED3LumB = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera1Point.LED4LumB = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera1Point.LED5LumB = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera1Point.LED6LumB = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera1Point.LED7LumB = SortRectBlob[6].Value.Area.ToString();
                    }
                    State.VmCamera1Point.LED1 = SortRectBlob[0].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[0].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED2 = SortRectBlob[1].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[1].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED3 = SortRectBlob[2].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[2].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED4 = SortRectBlob[3].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[3].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED5 = SortRectBlob[4].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[4].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED6 = SortRectBlob[5].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[5].Value.Centroid.Y.ToString("F0");
                    State.VmCamera1Point.LED7 = SortRectBlob[6].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[6].Value.Centroid.Y.ToString("F0");
                }

                IsEnableSave = false;
            });
        }

        bool FlagLabeling;
        private void buttonLabeling_Click(object sender, RoutedEventArgs e)
        {
            if (!RedOn && !GreenOn && !BlueOn)
                return;


            FlagLabeling = !FlagLabeling;

            buttonHue.IsEnabled = !FlagLabeling;
            buttonLabeling.Background = FlagLabeling ? General.OnBrush : General.OffBrush;

            if (FlagLabeling)
            {
                General.cam1.ResetFlag();
                General.cam1.FlagLabeling = true;

                labeling();
            }
            else
            {
                General.cam1.ResetFlag();
            }

        }


        bool IsBusy = false;
        private async void buttonSavePoint_Click(object sender, RoutedEventArgs e)
        {
            if (IsBusy)
                return;
            try
            {
                if (!General.CheckPress())
                {
                    MessageBox.Show("ゴールデンサンプルをセットして\nレバーを下げてください");
                    return;
                }


                buttonRed.IsEnabled = false;
                buttonGreen.IsEnabled = false;
                buttonBlue.IsEnabled = false;
                buttonLabeling.IsEnabled = false;
                buttonHue.IsEnabled = false;

                buttonSavePoint.Background = Brushes.DodgerBlue;
                resetView();
                IsBusy = true;
                RingCal.IsActive = true;

                ///////////////////////////////////////////////////
                //赤を点灯させる処理
                ///////////////////////////////////////////////////

                var result = true;
                await Task.Run(() =>
                {
                    General.PowSupply(true);

                    LPC1768.SendDataTarget("WP3101");//LED1,2の赤
                    LPC1768.SendDataTarget("WP1201");//LED3,4の赤
                    LPC1768.SendDataTarget("WP1701");//LED5,6の赤
                    LPC1768.SendDataTarget("WP2201");//LED7,8の赤
                    RedOn = true;//
                    GreenOn = false;
                    BlueOn = false;
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam1.ResetFlag();
                    General.cam1.FlagLabeling = true;
                    labeling();
                    var tm = new GeneralTimer(3000);
                    tm.Start();
                    while (true)
                    {
                        if (tm.FlagTimeout)
                        {
                            FlagLabeling = false;
                            result = false;
                            return;
                        }
                        if (IsEnableSave)
                            break;
                    }
                    FlagLabeling = false;
                    General.cam1.ResetFlag();
                    if (!TestLed.CheckColor1ForDebug(TestLed.COLOR.RED))
                    {
                        result = false;
                        return;
                    }


                    LPC1768.SendDataTarget("C");//LED7,8の赤
                    Sleep(1000);

                    ///////////////////////////////////////////////////
                    //緑を点灯させる処理
                    ///////////////////////////////////////////////////

                    LPC1768.SendDataTarget("WP1001");//LED1,2の緑
                    LPC1768.SendDataTarget("WP1301");//LED3,4の緑
                    LPC1768.SendDataTarget("WP2001");//LED5,6の緑
                    LPC1768.SendDataTarget("WP2301");//LED7,8の緑

                    RedOn = false;
                    GreenOn = true;//
                    BlueOn = false;
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam1.ResetFlag();
                    General.cam1.FlagLabeling = true;
                    labeling();
                    tm = new GeneralTimer(3000);
                    tm.Start();
                    while (true)
                    {
                        if (tm.FlagTimeout)
                        {
                            FlagLabeling = false;
                            result = false;
                            return;
                        }
                        if (IsEnableSave)
                            break;
                    }
                    FlagLabeling = false;
                    General.cam1.ResetFlag();
                    if (!TestLed.CheckColor1ForDebug(TestLed.COLOR.GREEN))
                    {
                        result = false;
                        return;
                    }

                    LPC1768.SendDataTarget("C");//LED7,8の赤
                    Sleep(1000);

                    ///////////////////////////////////////////////////
                    //青を点灯させる処理
                    ///////////////////////////////////////////////////

                    LPC1768.SendDataTarget("WP3001");//LED1,2の青
                    LPC1768.SendDataTarget("WP1101");//LED3,4の青
                    LPC1768.SendDataTarget("WP1601");//LED5,6の青
                    LPC1768.SendDataTarget("WP2101");//LED7,8の青

                    RedOn = false;
                    GreenOn = false;
                    BlueOn = true;//
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam1.ResetFlag();
                    General.cam1.FlagLabeling = true;
                    labeling();
                    tm = new GeneralTimer(3000);
                    tm.Start();
                    while (true)
                    {
                        if (tm.FlagTimeout)
                        {
                            FlagLabeling = false;
                            result = false;
                            return;
                        }
                        if (IsEnableSave)
                            break;
                    }
                    FlagLabeling = false;
                    General.cam1.ResetFlag();
                    if (!TestLed.CheckColor1ForDebug(TestLed.COLOR.BLUE))
                    {
                        result = false;
                        return;
                    }

                    LPC1768.SendDataTarget("C");//LED7,8の赤

                    //この時点で、座標、輝度がすべて表示されているはずなので保存する（カメラ設定も同時に保存する）
                    SavePoint();
                    SaveRedLum();
                    SaveBlueLum();
                    SaveGreenLum();
                    SaveCameraCommonProp();
                });


                if (result)
                {
                    General.PlaySound(General.soundSuccess);
                    labelMess.Content = "自動補正完了しました！";
                    labelMess.Foreground = Brushes.DodgerBlue;
                    (FindResource("SbMessage") as Storyboard).Begin();
                    return;
                }
                else
                {
                    FlagLabeling = false;
                    General.cam1.ResetFlag();
                    LPC1768.SendDataTarget("C");//LED7,8の赤

                    Sleep(150);
                    General.PlaySound(General.soundFail);
                    labelMess.Content = "LED全点灯が認識できません\nカメラプロパティの調整をしてください";
                    labelMess.Foreground = Brushes.HotPink;
                    (FindResource("SbMessage") as Storyboard).Begin();
                }
            }
            finally
            {
                buttonSavePoint.Background = Brushes.Transparent;
                RedOn = false;
                GreenOn = false;
                BlueOn = false;
                buttonRed.IsEnabled = true;
                buttonGreen.IsEnabled = true;
                buttonBlue.IsEnabled = true;
                buttonLabeling.IsEnabled = true;
                buttonHue.IsEnabled = true;
                IsBusy = false;
                RingCal.IsActive = false;
            }
        }

        bool ShowHue;

        private void ButtonHue_Click(object sender, RoutedEventArgs e)
        {

            if (!RedOn && !GreenOn && !BlueOn)
                return;

            ShowHue = !ShowHue;

            buttonLabeling.IsEnabled = !ShowHue;

            buttonHue.Background = ShowHue ? General.OnBrush : General.OffBrush;

            if (ShowHue)
            {
                General.cam1.ResetFlag();

                TestLed.COLOR col;
                if (RedOn)
                    col = TestLed.COLOR.RED;
                else if (GreenOn)
                    col = TestLed.COLOR.GREEN;
                else
                    col = TestLed.COLOR.BLUE;


                Task.Run(() =>
                {
                    while (ShowHue)
                    {
                        TestLed.CheckColor1ForDebug(col);
                        Sleep(100);
                    }
                });
            }
            else
            {
                General.cam1.ResetFlag();
            }
        }

    }
}
