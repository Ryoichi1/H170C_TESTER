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
    public partial class Camera2Conf
    {
        bool IsEnableSave;

        public Camera2Conf()
        {
            InitializeComponent();
            this.DataContext = General.cam2;
            canvasLdPoint.DataContext = State.VmCamera2Point;
            toggleSw.IsChecked = General.cam2.Opening;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Flags.EnableStartCheck = false;
            labelMess.Opacity = 0;
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            RingCal.IsActive = false;

            IsEnableSave = false;

            if (!General.cam2.CamState)
                return;
            State.VmMainWindow.MainWinEnable = false;
            await Task.Delay(1200);
            State.VmMainWindow.MainWinEnable = true;
            State.SetCam2Prop();
            General.cam2.Start();
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
            if (!General.cam2.CamState)
                return;
            await General.cam2.Stop();
            State.SetCam2Prop();
            Flags.EnableStartCheck = true;
        }

        private void resetView()
        {
            State.VmCamera2Point.LED8 = "";
            State.VmCamera2Point.LED9 = "";
            State.VmCamera2Point.LED10 = "";
            State.VmCamera2Point.LED11 = "";
            State.VmCamera2Point.LED12 = "";
            State.VmCamera2Point.LED13 = "";
            State.VmCamera2Point.LED14 = "";

            State.VmCamera2Point.LED8LumR = "";
            State.VmCamera2Point.LED9LumR = "";
            State.VmCamera2Point.LED10LumR = "";
            State.VmCamera2Point.LED11LumR = "";
            State.VmCamera2Point.LED12LumR = "";
            State.VmCamera2Point.LED13LumR = "";
            State.VmCamera2Point.LED14LumR = "";

            State.VmCamera2Point.LED8LumG = "";
            State.VmCamera2Point.LED9LumG = "";
            State.VmCamera2Point.LED10LumG = "";
            State.VmCamera2Point.LED11LumG = "";
            State.VmCamera2Point.LED12LumG = "";
            State.VmCamera2Point.LED13LumG = "";
            State.VmCamera2Point.LED14LumG = "";

            State.VmCamera2Point.LED8LumB = "";
            State.VmCamera2Point.LED9LumB = "";
            State.VmCamera2Point.LED10LumB = "";
            State.VmCamera2Point.LED11LumB = "";
            State.VmCamera2Point.LED12LumB = "";
            State.VmCamera2Point.LED13LumB = "";
            State.VmCamera2Point.LED14LumB = "";

            State.VmCamera2Point.HueLed8R = "";
            State.VmCamera2Point.HueLed9R = "";
            State.VmCamera2Point.HueLed10R = "";
            State.VmCamera2Point.HueLed11R = "";
            State.VmCamera2Point.HueLed12R = "";
            State.VmCamera2Point.HueLed13R = "";
            State.VmCamera2Point.HueLed14R = "";

            State.VmCamera2Point.HueLed8G = "";
            State.VmCamera2Point.HueLed9G = "";
            State.VmCamera2Point.HueLed10G = "";
            State.VmCamera2Point.HueLed11G = "";
            State.VmCamera2Point.HueLed12G = "";
            State.VmCamera2Point.HueLed13G = "";
            State.VmCamera2Point.HueLed14G = "";

            State.VmCamera2Point.HueLed8B = "";
            State.VmCamera2Point.HueLed9B = "";
            State.VmCamera2Point.HueLed10B = "";
            State.VmCamera2Point.HueLed11B = "";
            State.VmCamera2Point.HueLed12B = "";
            State.VmCamera2Point.HueLed13B = "";
            State.VmCamera2Point.HueLed14B = "";


            State.VmCamera2Point.ColLed8R = General.OffBrush;
            State.VmCamera2Point.ColLed9R = General.OffBrush;
            State.VmCamera2Point.ColLed10R = General.OffBrush;
            State.VmCamera2Point.ColLed11R = General.OffBrush;
            State.VmCamera2Point.ColLed12R = General.OffBrush;
            State.VmCamera2Point.ColLed13R = General.OffBrush;
            State.VmCamera2Point.ColLed14R = General.OffBrush;

            State.VmCamera2Point.ColLed8G = General.OffBrush;
            State.VmCamera2Point.ColLed9G = General.OffBrush;
            State.VmCamera2Point.ColLed10G = General.OffBrush;
            State.VmCamera2Point.ColLed11G = General.OffBrush;
            State.VmCamera2Point.ColLed12G = General.OffBrush;
            State.VmCamera2Point.ColLed13G = General.OffBrush;
            State.VmCamera2Point.ColLed14G = General.OffBrush;

            State.VmCamera2Point.ColLed8B = General.OffBrush;
            State.VmCamera2Point.ColLed9B = General.OffBrush;
            State.VmCamera2Point.ColLed10B = General.OffBrush;
            State.VmCamera2Point.ColLed11B = General.OffBrush;
            State.VmCamera2Point.ColLed12B = General.OffBrush;
            State.VmCamera2Point.ColLed13B = General.OffBrush;
            State.VmCamera2Point.ColLed14B = General.OffBrush;

        }


        private void SaveCameraCommonProp()
        {
            //すべてのデータを保存する
            State.camCommonProp.Brightness = General.cam2.Brightness;
            State.camCommonProp.Contrast = General.cam2.Contrast;
            State.camCommonProp.Hue = General.cam2.Hue;
            State.camCommonProp.Saturation = General.cam2.Saturation;
            State.camCommonProp.Sharpness = General.cam2.Sharpness;
            State.camCommonProp.Gamma = General.cam2.Gamma;
            State.camCommonProp.Gain = General.cam2.Gain;
            State.camCommonProp.Exposure = General.cam2.Exposure;
            State.camCommonProp.Whitebalance = General.cam2.Wb;
            State.camCommonProp.Theta = General.cam2.Theta;
            State.camCommonProp.BinLevel = General.cam2.BinLevel;

            State.camCommonProp.Opening = General.cam2.Opening;
            State.camCommonProp.OpenCnt = General.cam2.OpenCnt;
            State.camCommonProp.CloseCnt = General.cam2.CloseCnt;

        }
        private void SaveRedLum()
        {
            State.cam2Prop.LumRedLed8 = Double.Parse(State.VmCamera2Point.LED8LumR);
            State.cam2Prop.LumRedLed9 = Double.Parse(State.VmCamera2Point.LED9LumR);
            State.cam2Prop.LumRedLed10 = Double.Parse(State.VmCamera2Point.LED10LumR);
            State.cam2Prop.LumRedLed11 = Double.Parse(State.VmCamera2Point.LED11LumR);
            State.cam2Prop.LumRedLed12 = Double.Parse(State.VmCamera2Point.LED12LumR);
            State.cam2Prop.LumRedLed13 = Double.Parse(State.VmCamera2Point.LED13LumR);
            State.cam2Prop.LumRedLed14 = Double.Parse(State.VmCamera2Point.LED14LumR);
        }
        private void SaveBlueLum()
        {
            State.cam2Prop.LumBlueLed8 = Double.Parse(State.VmCamera2Point.LED8LumB);
            State.cam2Prop.LumBlueLed9 = Double.Parse(State.VmCamera2Point.LED9LumB);
            State.cam2Prop.LumBlueLed10 = Double.Parse(State.VmCamera2Point.LED10LumB);
            State.cam2Prop.LumBlueLed11 = Double.Parse(State.VmCamera2Point.LED11LumB);
            State.cam2Prop.LumBlueLed12 = Double.Parse(State.VmCamera2Point.LED12LumB);
            State.cam2Prop.LumBlueLed13 = Double.Parse(State.VmCamera2Point.LED13LumB);
            State.cam2Prop.LumBlueLed14 = Double.Parse(State.VmCamera2Point.LED14LumB);
        }
        private void SaveGreenLum()
        {
            State.cam2Prop.LumGreenLed8 = Double.Parse(State.VmCamera2Point.LED8LumG);
            State.cam2Prop.LumGreenLed9 = Double.Parse(State.VmCamera2Point.LED9LumG);
            State.cam2Prop.LumGreenLed10 = Double.Parse(State.VmCamera2Point.LED10LumG);
            State.cam2Prop.LumGreenLed11 = Double.Parse(State.VmCamera2Point.LED11LumG);
            State.cam2Prop.LumGreenLed12 = Double.Parse(State.VmCamera2Point.LED12LumG);
            State.cam2Prop.LumGreenLed13 = Double.Parse(State.VmCamera2Point.LED13LumG);
            State.cam2Prop.LumGreenLed14 = Double.Parse(State.VmCamera2Point.LED14LumG);
        }

        private void SavePoint()
        {
            State.cam2Prop.LED8 = State.VmCamera2Point.LED8;
            State.cam2Prop.LED9 = State.VmCamera2Point.LED9;
            State.cam2Prop.LED10 = State.VmCamera2Point.LED10;
            State.cam2Prop.LED11 = State.VmCamera2Point.LED11;
            State.cam2Prop.LED12 = State.VmCamera2Point.LED12;
            State.cam2Prop.LED13 = State.VmCamera2Point.LED13;
            State.cam2Prop.LED14 = State.VmCamera2Point.LED14;
        }


        private void im_MouseLeave(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Hidden;
            tbHsv.Visibility = System.Windows.Visibility.Hidden;
            General.cam2.FlagHsv = false;
        }

        private void im_MouseEnter(object sender, MouseEventArgs e)
        {
            General.cam2.FlagHsv = true;
            tbHsv.Visibility = System.Windows.Visibility.Visible;
        }

        private void im_MouseMove(object sender, MouseEventArgs e)
        {
            tbPoint.Visibility = System.Windows.Visibility.Visible;
            Point point = e.GetPosition(im);
            tbPoint.Text = "XY=" + ((int)(point.X)).ToString() + "/" + ((int)(point.Y)).ToString();

            General.cam2.PointX = (int)point.X;
            General.cam2.PointY = (int)point.Y;

            tbHsv.Text = "HSV=" + General.cam2.Hdata.ToString() + "," + General.cam2.Sdata.ToString() + "," + General.cam2.Vdata.ToString();
        }

        bool RedOn;
        private async void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            if (BlueOn || GreenOn || FlagLabeling)
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

                    LPC1768.SendDataTarget("WP2501");//LED9,10の赤
                    LPC1768.SendDataTarget("WP3301");//LED11,12の赤
                    LPC1768.SendDataTarget("WP3701");//LED13,14の赤
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
            if (RedOn || GreenOn || FlagLabeling)
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

                    LPC1768.SendDataTarget("WP2401");//LED9,10の青
                    LPC1768.SendDataTarget("WP2701");//LED11,12の青
                    LPC1768.SendDataTarget("WP3501");//LED13,14の青
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
            if (RedOn || BlueOn || FlagLabeling)
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

                    LPC1768.SendDataTarget("WP2601");//LED9,10の緑
                    LPC1768.SendDataTarget("WP3401");//LED11,12の緑
                    LPC1768.SendDataTarget("WP0001");//LED13,14の緑
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
            General.cam2.Opening = true;
        }

        private void toggleSw_Unchecked(object sender, RoutedEventArgs e)
        {
            General.cam2.Opening = false;
        }


        private void labeling()
        {
            IsEnableSave = false;
            Task.Run(() =>
            {
                while (FlagLabeling)
                {
                    if (General.cam2.blobs == null) continue;
                    var blobInfo = General.cam2.blobs.Clone();

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
                            State.VmCamera2Point.LED8LumR = "";
                            State.VmCamera2Point.LED9LumR = "";
                            State.VmCamera2Point.LED10LumR = "";
                            State.VmCamera2Point.LED11LumR = "";
                            State.VmCamera2Point.LED12LumR = "";
                            State.VmCamera2Point.LED13LumR = "";
                            State.VmCamera2Point.LED14LumR = "";
                        }
                        else if (GreenOn)
                        {
                            State.VmCamera2Point.LED8LumG = "";
                            State.VmCamera2Point.LED9LumG = "";
                            State.VmCamera2Point.LED10LumG = "";
                            State.VmCamera2Point.LED11LumG = "";
                            State.VmCamera2Point.LED12LumG = "";
                            State.VmCamera2Point.LED13LumG = "";
                            State.VmCamera2Point.LED14LumG = "";
                        }
                        else if (BlueOn)
                        {
                            State.VmCamera2Point.LED8LumB = "";
                            State.VmCamera2Point.LED9LumB = "";
                            State.VmCamera2Point.LED10LumB = "";
                            State.VmCamera2Point.LED11LumB = "";
                            State.VmCamera2Point.LED12LumB = "";
                            State.VmCamera2Point.LED13LumB = "";
                            State.VmCamera2Point.LED14LumB = "";
                        }

                        State.VmCamera2Point.LED8 = "";
                        State.VmCamera2Point.LED9 = "";
                        State.VmCamera2Point.LED10 = "";
                        State.VmCamera2Point.LED11 = "";
                        State.VmCamera2Point.LED12 = "";
                        State.VmCamera2Point.LED13 = "";
                        State.VmCamera2Point.LED14 = "";

                        IsEnableSave = false;
                        continue;
                    }

                    IsEnableSave = true;

                    //ビューモデルの更新
                    if (RedOn)
                    {
                        State.VmCamera2Point.LED8LumR = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera2Point.LED9LumR = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera2Point.LED10LumR = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera2Point.LED11LumR = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera2Point.LED12LumR = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera2Point.LED13LumR = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera2Point.LED14LumR = SortRectBlob[6].Value.Area.ToString();
                    }
                    else if (GreenOn)
                    {
                        State.VmCamera2Point.LED8LumG = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera2Point.LED9LumG = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera2Point.LED10LumG = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera2Point.LED11LumG = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera2Point.LED12LumG = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera2Point.LED13LumG = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera2Point.LED14LumG = SortRectBlob[6].Value.Area.ToString();
                    }
                    else if (BlueOn)
                    {
                        State.VmCamera2Point.LED8LumB = SortRectBlob[0].Value.Area.ToString();
                        State.VmCamera2Point.LED9LumB = SortRectBlob[1].Value.Area.ToString();
                        State.VmCamera2Point.LED10LumB = SortRectBlob[2].Value.Area.ToString();
                        State.VmCamera2Point.LED11LumB = SortRectBlob[3].Value.Area.ToString();
                        State.VmCamera2Point.LED12LumB = SortRectBlob[4].Value.Area.ToString();
                        State.VmCamera2Point.LED13LumB = SortRectBlob[5].Value.Area.ToString();
                        State.VmCamera2Point.LED14LumB = SortRectBlob[6].Value.Area.ToString();
                    }
                    State.VmCamera2Point.LED8 = SortRectBlob[0].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[0].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED9 = SortRectBlob[1].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[1].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED10 = SortRectBlob[2].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[2].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED11 = SortRectBlob[3].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[3].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED12 = SortRectBlob[4].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[4].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED13 = SortRectBlob[5].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[5].Value.Centroid.Y.ToString("F0");
                    State.VmCamera2Point.LED14 = SortRectBlob[6].Value.Centroid.X.ToString("F0") + "/" + SortRectBlob[6].Value.Centroid.Y.ToString("F0");
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

            buttonLabeling.Background = FlagLabeling ? General.OnBrush : General.OffBrush;

            if (FlagLabeling)
            {
                General.cam2.ResetFlag();
                General.cam2.FlagLabeling = true;

                labeling();
            }
            else
            {
                General.cam2.ResetFlag();
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

                    LPC1768.SendDataTarget("WP2501");//LED9,10の赤
                    LPC1768.SendDataTarget("WP3301");//LED11,12の赤
                    LPC1768.SendDataTarget("WP3701");//LED13,14の赤
                    LPC1768.SendDataTarget("WP2201");//LED7,8の赤

                    RedOn = true;//
                    GreenOn = false;
                    BlueOn = false;
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam2.ResetFlag();
                    General.cam2.FlagLabeling = true;
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
                    General.cam2.ResetFlag();
                    if (!TestLed.CheckColor2ForDebug(TestLed.COLOR.RED))
                    {
                        result = false;
                        return;
                    }


                    LPC1768.SendDataTarget("C");//LED7,8の赤
                    Sleep(1000);

                    ///////////////////////////////////////////////////
                    //緑を点灯させる処理
                    ///////////////////////////////////////////////////
                    LPC1768.SendDataTarget("WP2601");//LED9,10の緑
                    LPC1768.SendDataTarget("WP3401");//LED11,12の緑
                    LPC1768.SendDataTarget("WP0001");//LED13,14の緑
                    LPC1768.SendDataTarget("WP2301");//LED7,8の緑

                    RedOn = false;
                    GreenOn = true;//
                    BlueOn = false;
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam2.ResetFlag();
                    General.cam2.FlagLabeling = true;
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
                    General.cam2.ResetFlag();
                    if (!TestLed.CheckColor2ForDebug(TestLed.COLOR.GREEN))
                    {
                        result = false;
                        return;
                    }

                    LPC1768.SendDataTarget("C");//LED7,8の赤
                    Sleep(1000);

                    ///////////////////////////////////////////////////
                    //青を点灯させる処理
                    ///////////////////////////////////////////////////
                    LPC1768.SendDataTarget("WP2401");//LED9,10の青
                    LPC1768.SendDataTarget("WP2701");//LED11,12の青
                    LPC1768.SendDataTarget("WP3501");//LED13,14の青
                    LPC1768.SendDataTarget("WP2101");//LED7,8の青	

                    RedOn = false;
                    GreenOn = false;
                    BlueOn = true;//
                    Sleep(1000);

                    //ラベリング処理
                    FlagLabeling = true;
                    General.cam2.ResetFlag();
                    General.cam2.FlagLabeling = true;
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
                    General.cam2.ResetFlag();
                    if (!TestLed.CheckColor2ForDebug(TestLed.COLOR.BLUE))
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
                    General.cam2.ResetFlag();
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

            ShowHue = !ShowHue;

            buttonLabeling.IsEnabled = !ShowHue;

            buttonHue.Background = ShowHue ? General.OnBrush : General.OffBrush;

            if (ShowHue)
            {
                General.cam2.ResetFlag();

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
                        TestLed.CheckColor2ForDebug(col);
                        Sleep(100);
                    }
                });
            }
            else
            {
                General.cam2.ResetFlag();
            }
        }

    }
}
