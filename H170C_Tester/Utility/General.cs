using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;

namespace H170C_Tester
{


    public static class General
    {

        //インスタンス変数の宣言
        public static SoundPlayer player = null;
        public static SoundPlayer soundPass = null;
        public static SoundPlayer soundPassLong = null;
        public static SoundPlayer soundFail = null;
        public static SoundPlayer soundAlarm = null;
        public static SoundPlayer soundSuccess = null;
        public static SoundPlayer soundNotice = null;


        public static SolidColorBrush DialogOnBrush = new SolidColorBrush();
        public static SolidColorBrush OnBrush = new SolidColorBrush();
        public static SolidColorBrush OffBrush = new SolidColorBrush();
        public static SolidColorBrush NgBrush = new SolidColorBrush();


        //インスタンスを生成する必要がある周辺機器
        public static Camera cam1;
        public static Camera cam2;


        static General()
        {
            //オーディオリソースを取り出す
            General.soundPass = new SoundPlayer(@"Resources\Wav\Pass.wav");
            General.soundPassLong = new SoundPlayer(@"Resources\Wav\PassLong.wav");
            General.soundFail = new SoundPlayer(@"Resources\Wav\Fail.wav");
            General.soundAlarm = new SoundPlayer(@"Resources\Wav\Alarm.wav");
            General.soundSuccess = new SoundPlayer(@"Resources\Wav\Success.wav");
            General.soundNotice = new SoundPlayer(@"Resources\Wav\Notice.wav");

            OffBrush.Color = Colors.Transparent;

            DialogOnBrush.Color = Colors.DodgerBlue;
            DialogOnBrush.Opacity = 0.6;

            OnBrush.Color = Colors.DodgerBlue;
            OnBrush.Opacity = 0.4;

            NgBrush.Color = Colors.HotPink;
            NgBrush.Opacity = 0.4;
        }

        public static void Show()
        {
            var T = 0.3;
            var t = 0.005;

            State.Setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
            //10msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);

            State.VmMainWindow.ThemeOpacity = 0;
            Task.Run(() =>
            {
                while (true)
                {

                    State.VmMainWindow.ThemeOpacity += State.Setting.OpacityTheme / (double)times;
                    Thread.Sleep((int)(t * 1000));
                    if (State.VmMainWindow.ThemeOpacity >= State.Setting.OpacityTheme) return;

                }
            });
        }

        public static void SetRadius(bool sw)
        {
            var T = 0.45;//アニメーションが完了するまでの時間（秒）
            var t = 0.005;//（秒）

            //5msec刻みでT秒で元のOpacityに戻す
            int times = (int)(T / t);


            Task.Run(() =>
            {
                if (sw)
                {
                    while (true)
                    {
                        State.VmMainWindow.ThemeBlurEffectRadius += 25 / (double)times;
                        Thread.Sleep((int)(t * 1000));
                        if (State.VmMainWindow.ThemeBlurEffectRadius >= 25) return;

                    }
                }
                else
                {
                    var CurrentRadius = State.VmMainWindow.ThemeBlurEffectRadius;
                    while (true)
                    {
                        CurrentRadius -= 25 / (double)times;
                        if (CurrentRadius > 0)
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = CurrentRadius;
                        }
                        else
                        {
                            State.VmMainWindow.ThemeBlurEffectRadius = 0;
                            return;
                        }
                        Thread.Sleep((int)(t * 1000));
                    }
                }

            });
        }



        public static bool SaveRetryLog()
        {
            if (State.RetryLogList.Count() == 0) return true;

            //出力用のファイルを開く appendをtrueにすると既存のファイルに追記、falseにするとファイルを新規作成する
            using (var sw = new System.IO.StreamWriter(Constants.fileName_RetryLog, true, Encoding.GetEncoding("Shift_JIS")))
            {
                try
                {
                    State.RetryLogList.ForEach(d =>
                    {
                        sw.WriteLine(d);
                    });

                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }



        private static List<string> MakePassTestData()//TODO:
        {
            var ListData = new List<string>
            {
                "AssemblyVer " + State.AssemblyInfo,
                "TestSpecVer " + State.TestSpec.TestSpecVer,
                System.DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss"),
                State.VmTestStatus.FwVer,
                State.VmTestStatus.FwSum,

                State.VmTestResults.LumLed1R,
                State.VmTestResults.LumLed2R,
                State.VmTestResults.LumLed3R,
                State.VmTestResults.LumLed4R,
                State.VmTestResults.LumLed5R,
                State.VmTestResults.LumLed6R,
                State.VmTestResults.LumLed7R,
                State.VmTestResults.LumLed8R,
                State.VmTestResults.LumLed9R,
                State.VmTestResults.LumLed10R,
                State.VmTestResults.LumLed11R,
                State.VmTestResults.LumLed12R,
                State.VmTestResults.LumLed13R,
                State.VmTestResults.LumLed14R,

                State.VmTestResults.LumLed1G,
                State.VmTestResults.LumLed2G,
                State.VmTestResults.LumLed3G,
                State.VmTestResults.LumLed4G,
                State.VmTestResults.LumLed5G,
                State.VmTestResults.LumLed6G,
                State.VmTestResults.LumLed7G,
                State.VmTestResults.LumLed8G,
                State.VmTestResults.LumLed9G,
                State.VmTestResults.LumLed10G,
                State.VmTestResults.LumLed11G,
                State.VmTestResults.LumLed12G,
                State.VmTestResults.LumLed13G,
                State.VmTestResults.LumLed14G,

                State.VmTestResults.LumLed1B,
                State.VmTestResults.LumLed2B,
                State.VmTestResults.LumLed3B,
                State.VmTestResults.LumLed4B,
                State.VmTestResults.LumLed5B,
                State.VmTestResults.LumLed6B,
                State.VmTestResults.LumLed7B,
                State.VmTestResults.LumLed8B,
                State.VmTestResults.LumLed9B,
                State.VmTestResults.LumLed10B,
                State.VmTestResults.LumLed11B,
                State.VmTestResults.LumLed12B,
                State.VmTestResults.LumLed13B,
                State.VmTestResults.LumLed14B,

            };

            return ListData;
        }

        public static bool SaveTestData()
        {
            try
            {
                var dataList = new List<string>();
                dataList = MakePassTestData();

                var fileName = System.DateTime.Now.ToString("yyyy年MM月dd日");

                var OkDataFilePath = Constants.PassDataFolderPath + fileName + ".csv";

                if (!System.IO.File.Exists(OkDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.PassDataFolderPath + "Format.csv", OkDataFilePath);
                }

                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", dataList);

                // appendをtrueにすると，既存のファイルに追記
                // falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(OkDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //**************************************************************************
        //検査データの保存　　　　
        //引数：なし
        //戻値：なし
        //**************************************************************************

        public static bool SaveNgData(List<string> dataList)
        {
            try
            {
                var fileName = System.DateTime.Now.ToString("yyyy年MM月dd日");

                var NgDataFilePath = Constants.FailDataFolderPath + fileName + ".csv";
                if (!File.Exists(NgDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.FailDataFolderPath + "FormatNg.csv", NgDataFilePath);
                }

                var stArrayData = dataList.ToArray();
                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", stArrayData);

                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(NgDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///レバーが下がっていればTrueを返す 
        /// </summary>
        /// <returns></returns>
        public static bool CheckPress()
        {
            LPC1768.SendData1768("R_PRESS", setLog: false);
            return LPC1768.RecieveData.Contains("0");
        }

        //**************************************************************************
        //EPX64のリセット
        //引数：なし
        //戻値：なし
        //**************************************************************************
        public static void ResetIo() //P7:0 P6:0 P5:1 P4:1  P3:1 P2:1 P1:1 P0:1  
        {
            //IOを初期化する処理（出力をすべてＬに落とす）
            LPC1768.SendData1768("ResetIo");
            Flags.PowOn = false;

            State.VmComm.ColorCan1 = OffBrush;
            State.VmComm.ColorCan2 = OffBrush;

        }

        public static void PowSupply(bool sw)
        {
            if (Flags.PowOn == sw) return;

            if (sw)
            {
                LPC1768.SendData1768("K3,1");
                Thread.Sleep(2000);
            }
            else
            {
                LPC1768.SendData1768("K3,0");
                State.VmComm.ColorCan1 = OffBrush;
                State.VmComm.ColorCan2 = OffBrush;
            }

            Flags.PowOn = sw;
        }

        public static async Task PowSupplyAsync(bool sw) => await Task.Run(() => { PowSupply(sw); });



        //**************************************************************************
        //WAVEファイルを再生する
        //引数：なし
        //戻値：なし
        //**************************************************************************  

        //WAVEファイルを再生する（非同期で再生）
        public static void PlaySound(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.Play();
        }
        //WAVEファイルを再生する（同期で再生）
        public static void PlaySound2(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlaySync();

        }

        public static void PlaySoundLoop(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlayLooping();
        }

        //再生されているWAVEファイルを止める
        public static void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }



        public static void ResetViewModel()//TODO:
        {
            //ViewModel OK台数、NG台数、Total台数の更新
            State.VmTestStatus.OkCount = State.Setting.TodayOkCount.ToString() + "台";
            State.VmTestStatus.NgCount = State.Setting.TodayNgCount.ToString() + "台";
            State.VmTestStatus.Message = Constants.MessSet;
            General.cam1.ImageOpacity = Constants.OpacityImgMin;
            General.cam2.ImageOpacity = Constants.OpacityImgMin;


            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Visible;

            State.VmTestStatus.TestTime = "00:00";
            State.VmTestStatus.進捗度 = 0;
            State.VmTestStatus.TestLog = "";

            State.VmTestStatus.FailInfo = "";
            State.VmTestStatus.Spec = "";
            State.VmTestStatus.MeasValue = "";


            //試験結果のクリア
            State.VmTestResults = new ViewModelTestResult();

            //通信ログのクリア
            State.VmComm.LPC1768_TX = "";
            State.VmComm.LPC1768_RX = "";
            State.VmComm.TARGET_TX = "";
            State.VmComm.TARGET_RX = "";

            State.VmMainWindow.EnableOtherButton = true;

            //各種フラグの初期化
            Flags.PowOn = false;
            Flags.ClickStopButton = false;
            Flags.Testing = false;


            //テーマ透過度を元に戻す
            General.SetRadius(false);

            State.VmTestStatus.RetryLabelVis = System.Windows.Visibility.Hidden;
            State.VmTestStatus.TestSettingEnable = true;

        }


        public static void CheckAll周辺機器フラグ()
        {
            Flags.AllOk周辺機器接続 = (Flags.State1768 && General.cam1.CamState && General.cam2.CamState);
        }


        public static void Init周辺機器()//TODO:
        {
            Flags.Initializing周辺機器 = true;

            //LPC1768の初期化
            bool Stop1768 = false;
            Task.Run(() =>
            {
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                    {
                        break;
                    }

                    Flags.State1768 = LPC1768.Init();
                    if (Flags.State1768)
                    {
                        //IOボードのリセット（出力をすべてLする）
                        ResetIo();
                        break;
                    }

                    Thread.Sleep(500);
                }
                Stop1768 = true;
            });


            //カメラ1（CMS_V37BK）の初期化
            bool StopCAMERA1 = false;
            Task.Run(() =>
            {
                cam1 = new Camera(State.cam1Prop.CamNumber, Constants.filePath_Cam1CalFilePath, 640, 360);
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                        break;

                    if (!Flags.State1768) continue;//他のアイテムの試験機が接続されていたらカメラのイニシャライズは行わない

                    cam1.InitCamera();
                    if (Flags.StateCam1 = cam1.CamState)
                        break;

                    Thread.Sleep(500);
                }
                StopCAMERA1 = true;
            });

            //カメラ2（CMS_V37BK）の初期化
            bool StopCAMERA2 = false;
            Task.Run(() =>
            {
                cam2 = new Camera(State.cam2Prop.CamNumber, Constants.filePath_Cam2CalFilePath, 640, 360);
                while (true)
                {
                    if (Flags.StopInit周辺機器)
                    {
                        break;
                    }

                    if (!Flags.State1768) continue;//他のアイテムの試験機が接続されていたらカメラのイニシャライズは行わない

                    cam2.InitCamera();
                    if (Flags.StateCam2 = cam2.CamState)
                        break;

                    Thread.Sleep(500);
                }
                StopCAMERA2 = true;
            });



            Task.Run(() =>
            {
                while (true)
                {
                    CheckAll周辺機器フラグ();

                    //EPX64Sの初期化の中で、K100、K101の溶着チェックを行っているが、これがNGだとしてもInit周辺機器()は終了する
                    var IsAllStopped = Stop1768 && StopCAMERA1 && StopCAMERA2;

                    if (Flags.AllOk周辺機器接続 || IsAllStopped) break;
                    Thread.Sleep(400);

                }
                Flags.Initializing周辺機器 = false;
            });

        }

        //強制停止ボタンの設定
        public static async Task ShowStopButton(bool sw)
        {
            if (sw)
            {
                State.VmTestStatus.StopButtonEnable = true;
                await Task.Run(() =>
                {
                    foreach (var i in Enumerable.Range(1, 100))
                    {
                        State.VmTestStatus.StopButtonVis = i / 100.0;
                        Thread.Sleep(10);
                    }
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    foreach (var i in Enumerable.Range(1, 100))
                    {
                        State.VmTestStatus.StopButtonVis = (1 - (i / 100.0));
                        Thread.Sleep(10);
                    }
                });
                State.VmTestStatus.StopButtonEnable = false;
            }

        }




        public enum CAN_NAME { CN271, CN272 }
        public static void SelectCan(CAN_NAME name)
        {
            if (name == CAN_NAME.CN271)
            {
                SetK4(false);
                State.VmComm.ColorCan1 = OnBrush;
                State.VmComm.ColorCan2 = OffBrush;

            }
            else
            {
                SetK4(true);
                State.VmComm.ColorCan1 = OffBrush;
                State.VmComm.ColorCan2 = OnBrush;
            }
        }


        //試験機リレー、ソレノイドスタンプ制御
        public static void SetK1_2(bool sw) { LPC1768.SendData1768(sw ? "K1_2,1" : "K1_2,0"); }
        public static void SetK3(bool sw) { LPC1768.SendData1768(sw ? "K3,1" : "K3,0"); }
        public static void SetK4(bool sw) { LPC1768.SendData1768(sw ? "K4,1" : "K4,0"); }
        public static void SetRL1(bool sw) { LPC1768.SendData1768(sw ? "RL1,1" : "RL1,0"); }
        public static void StampOn() { LPC1768.SendData1768("STAMP"); }



    }

}

