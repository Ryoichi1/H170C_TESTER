using OpenCvSharp;
using OpenCvSharp.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace H170C_Tester
{

    public static class TestLed
    {
        public enum NAME1
        {
            LED1, LED2, LED3, LED4, LED5, LED6, LED7,
        }
        public enum NAME2
        {
            LED8, LED9, LED10, LED11, LED12, LED13, LED14,
        }

        public enum COLOR
        {
            RED, GREEN, BLUE,
        }

        public enum SECTION { Section1, Section2 }//Section1:LED1～7 Section2:LED8～14

        const int WIDTH = 640;
        const int HEIGHT = 360;

        private static IplImage source = new IplImage(WIDTH, HEIGHT, BitDepth.U8, 3);

        public static List<LedSpec1> ListLedSpec1;
        public static List<LedSpec2> ListLedSpec2;


        public class LedSpec1
        {
            public NAME1 name;
            public bool resultArea;
            public bool resultHue;
        }

        public class LedSpec2
        {
            public NAME2 name;
            public bool resultArea;
            public bool resultHue;
        }

        private static void InitList()
        {
            ListLedSpec1 = new List<LedSpec1>();
            foreach (var n in Enum.GetValues(typeof(NAME1)))
            {
                ListLedSpec1.Add(new LedSpec1 { name = (NAME1)n });
            }

            ListLedSpec2 = new List<LedSpec2>();
            foreach (var n in Enum.GetValues(typeof(NAME2)))
            {
                ListLedSpec2.Add(new LedSpec2 { name = (NAME2)n });
            }
        }

        private static void SetRed()
        {
            //赤全点灯させる処理  ※ここだけCN272経由で通信を行う
            LPC1768.SendDataTarget(Data: "WP3101", canName: General.CAN_NAME.CN272);//LED1,2の赤
            LPC1768.SendDataTarget(Data: "WP1201", canName: General.CAN_NAME.CN272);//LED3,4の赤
            LPC1768.SendDataTarget(Data: "WP1701", canName: General.CAN_NAME.CN272);//LED5,6の赤
            LPC1768.SendDataTarget(Data: "WP2201", canName: General.CAN_NAME.CN272);//LED7,8の赤
            LPC1768.SendDataTarget(Data: "WP2501", canName: General.CAN_NAME.CN272);//LED9,10の赤
            LPC1768.SendDataTarget(Data: "WP3301", canName: General.CAN_NAME.CN272);//LED11,12の赤
            LPC1768.SendDataTarget(Data: "WP3701", canName: General.CAN_NAME.CN272);//LED13,14の赤
        }

        private static void SetGreen()
        {
            LPC1768.SendDataTarget("WP1001");//LED1,2の緑
            LPC1768.SendDataTarget("WP1301");//LED3,4の緑
            LPC1768.SendDataTarget("WP2001");//LED5,6の緑
            LPC1768.SendDataTarget("WP2301");//LED7,8の緑
            LPC1768.SendDataTarget("WP2601");//LED9,10の緑
            LPC1768.SendDataTarget("WP3401");//LED11,12の緑
            LPC1768.SendDataTarget("WP0001");//LED13,14の緑
        }

        private static void SetBlue()
        {
            LPC1768.SendDataTarget("WP3001");//LED1,2の青
            LPC1768.SendDataTarget("WP1101");//LED3,4の青
            LPC1768.SendDataTarget("WP1601");//LED5,6の青
            LPC1768.SendDataTarget("WP2101");//LED7,8の青
            LPC1768.SendDataTarget("WP2401");//LED9,10の青
            LPC1768.SendDataTarget("WP2701");//LED11,12の青
            LPC1768.SendDataTarget("WP3501");//LED13,14の青

        }

        private static async Task<bool> CheckLum1(COLOR col)
        {
            bool allResult = false;
            int X = 0;
            int Y = 0;
            double refLum = 0;
            double errLum = 25;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    //テストログの更新
                    State.VmTestStatus.TestLog += "輝度チェック";

                    General.cam1.ResetFlag();//カメラのフラグを初期化 リトライ時にフラグが初期化できてないとだめ
                                             //例 ＮＧリトライ時は、General.cam.FlagFrame = trueになっていてNGフレーム表示の無限ループにいる

                    General.cam1.FlagLabeling = true;
                    Thread.Sleep(1000);
                    var blobInfo = General.cam1.blobs.Clone();

                    var blob = blobInfo.OrderByDescending(b => b.Value.Centroid.X).ToList();

                    ListLedSpec1.ForEach(l =>
                    {
                        switch (l.name)
                        {
                            case NAME1.LED1:
                                X = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed1;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed1;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed1;
                                        break;
                                }
                                break;

                            case NAME1.LED2:
                                X = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed2;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed2;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed2;
                                        break;
                                }
                                break;

                            case NAME1.LED3:
                                X = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed3;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed3;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed3;
                                        break;
                                }
                                break;

                            case NAME1.LED4:
                                X = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed4;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed4;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed4;
                                        break;
                                }
                                break;

                            case NAME1.LED5:
                                X = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed5;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed5;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed5;
                                        break;
                                }
                                break;

                            case NAME1.LED6:
                                X = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed6;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed6;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed6;
                                        break;
                                }
                                break;

                            case NAME1.LED7:
                                X = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam1Prop.LumRedLed7;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam1Prop.LumGreenLed7;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam1Prop.LumBlueLed7;
                                        break;
                                }
                                break;
                        }

                        var match = blob.FirstOrDefault(b =>
                        {
                            var pointX = b.Value.Centroid.X;
                            var pointY = b.Value.Centroid.Y;
                            //X座標の確認
                            if ((int)pointX < X - 10 || (int)pointX > X + 10) return false;

                            //Y座標の確認
                            if ((int)pointY < Y - 10 || (int)pointY > Y + 10) return false;

                            return true;
                        });

                        var area = 0;
                        if (!match.Equals(default(KeyValuePair<int, CvBlob>)))
                        {
                            area = match.Value.Area;
                            //面積の計算
                            l.resultArea = area >= refLum * (1 - (errLum / 100.0)) && area <= refLum * (1 + (errLum / 100.0));
                        }


                        switch (l.name)
                        {
                            case NAME1.LED1:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed1R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed1R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed1G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed1G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed1B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed1B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED2:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed2R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed2R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed2G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed2G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed2B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed2B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED3:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed3R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed3R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed3G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed3G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed3B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed3B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED4:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed4R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed4R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed4G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed4G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed4B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed4B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED5:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed5R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed5R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed5G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed5G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed5B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed5B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED6:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed6R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed6R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed6G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed6G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed6B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed6B = General.NgBrush;
                                        break;
                                }
                                break;
                            case NAME1.LED7:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed7R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed7R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed7G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed7G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed7B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed7B = General.NgBrush;
                                        break;
                                }
                                break;
                        }

                    });

                    allResult = ListLedSpec1.All(l => l.resultArea);
                    if (allResult)
                    {
                        State.VmTestStatus.TestLog += "---PASS\r\n";
                        return true;
                    }
                    else
                    {
                        State.VmTestStatus.TestLog += "---FAIL\r\n";
                        return false;
                    }

                });
            }
            finally
            {
            }




        }

        private static async Task<bool> CheckLum2(COLOR col)
        {
            bool allResult = false;
            int X = 0;
            int Y = 0;
            double refLum = 0;
            double errLum = 25;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    //テストログの更新
                    State.VmTestStatus.TestLog += "輝度チェック";

                    General.cam2.ResetFlag();//カメラのフラグを初期化 リトライ時にフラグが初期化できてないとだめ
                                             //例 ＮＧリトライ時は、General.cam.FlagFrame = trueになっていてNGフレーム表示の無限ループにいる

                    General.cam2.FlagLabeling = true;
                    Thread.Sleep(1000);
                    var blobInfo = General.cam2.blobs.Clone();

                    var blob = blobInfo.OrderByDescending(b => b.Value.Centroid.X).ToList();

                    ListLedSpec2.ForEach(l =>
                    {
                        switch (l.name)
                        {
                            case NAME2.LED8:
                                X = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed8;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed8;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed8;
                                        break;
                                }
                                break;

                            case NAME2.LED9:
                                X = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed9;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed9;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed9;
                                        break;
                                }
                                break;

                            case NAME2.LED10:
                                X = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed10;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed10;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed10;
                                        break;
                                }
                                break;

                            case NAME2.LED11:
                                X = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed11;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed11;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed11;
                                        break;
                                }
                                break;

                            case NAME2.LED12:
                                X = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed12;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed12;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed12;
                                        break;
                                }
                                break;

                            case NAME2.LED13:
                                X = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed13;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed13;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed13;
                                        break;
                                }
                                break;

                            case NAME2.LED14:
                                X = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[0]);
                                Y = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[1]);
                                switch (col)
                                {
                                    case COLOR.RED:
                                        refLum = State.cam2Prop.LumRedLed14;
                                        break;

                                    case COLOR.GREEN:
                                        refLum = State.cam2Prop.LumGreenLed14;
                                        break;

                                    case COLOR.BLUE:
                                        refLum = State.cam2Prop.LumBlueLed14;
                                        break;
                                }
                                break;


                        }

                        var match = blob.FirstOrDefault(b =>
                        {
                            var pointX = b.Value.Centroid.X;
                            var pointY = b.Value.Centroid.Y;
                            //X座標の確認
                            if ((int)pointX < X - 10 || (int)pointX > X + 10) return false;

                            //Y座標の確認
                            if ((int)pointY < Y - 10 || (int)pointY > Y + 10) return false;

                            return true;
                        });

                        var area = 0;
                        if (!match.Equals(default(KeyValuePair<int, CvBlob>)))
                        {
                            area = match.Value.Area;
                            //面積の計算
                            l.resultArea = area >= refLum * (1 - (errLum / 100.0)) && area <= refLum * (1 + (errLum / 100.0));
                        }


                        switch (l.name)
                        {
                            case NAME2.LED8:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed8R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed8R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed8G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed8G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed8B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed8B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED9:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed9R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed9R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed9G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed9G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed9B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed9B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED10:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed10R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed10R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed10G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed10G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed10B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed10B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED11:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed11R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed11R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed11G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed11G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed11B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed11B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED12:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed12R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed12R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed12G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed12G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed12B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed12B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED13:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed13R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed13R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed13G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed13G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed13B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed13B = General.NgBrush;
                                        break;
                                }
                                break;

                            case NAME2.LED14:
                                switch (col)
                                {
                                    case COLOR.RED:
                                        State.VmTestResults.LumLed14R = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed14R = General.NgBrush;
                                        break;
                                    case COLOR.GREEN:
                                        State.VmTestResults.LumLed14G = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed14G = General.NgBrush;
                                        break;
                                    case COLOR.BLUE:
                                        State.VmTestResults.LumLed14B = area.ToString();
                                        if (!l.resultArea) State.VmTestResults.ColLumLed14B = General.NgBrush;
                                        break;
                                }
                                break;
                        }

                    });

                    allResult = ListLedSpec2.All(l => l.resultArea);
                    if (allResult)
                    {
                        State.VmTestStatus.TestLog += "---PASS\r\n";
                        return true;
                    }
                    else
                    {
                        State.VmTestStatus.TestLog += "---FAIL\r\n";
                        return false;
                    }

                });
            }
            finally
            {
            }

        }


        private static async Task<bool> CheckColor1(COLOR col)
        {
            var side = 50;
            var X = 0;
            var Y = 0;
            var refHueMax = 0;
            var refHueMin = 0;

            return await Task<bool>.Run(() =>
            {
                State.VmTestStatus.TestLog += "色相チェック";
                var Result = false;
                try
                {
                    InitList();

                    switch (col)
                    {
                        case COLOR.RED:
                            refHueMax = State.TestSpec.RedHueMax;
                            refHueMin = State.TestSpec.RedHueMin;
                            State.VmTestStatus.Spec = "規格値 : 赤 " + State.TestSpec.RedHueMin.ToString() + "-" + State.TestSpec.RedHueMax.ToString();
                            break;

                        case COLOR.GREEN:
                            refHueMax = State.TestSpec.GreenHueMax;
                            refHueMin = State.TestSpec.GreenHueMin;
                            State.VmTestStatus.Spec = "規格値 : 緑 " + State.TestSpec.GreenHueMin.ToString() + "-" + State.TestSpec.GreenHueMax.ToString();
                            break;

                        case COLOR.BLUE:
                            refHueMax = State.TestSpec.BlueHueMax;
                            refHueMin = State.TestSpec.BlueHueMin;
                            State.VmTestStatus.Spec = "規格値 : 青 " + State.TestSpec.BlueHueMin.ToString() + "-" + State.TestSpec.BlueHueMax.ToString();
                            break;
                    }

                    Thread.Sleep(1000);

                    //cam1の画像を取得する処理
                    General.cam1.FlagTestPic = true;
                    while (General.cam1.FlagTestPic) ;
                    source = General.cam1.imageForTest;
                    //source.SaveImage(@"C:\Users\TSDP00059\Desktop\src.jpg");
                    using (IplImage hsv = new IplImage(640, 360, BitDepth.U8, 3)) // グレースケール画像格納用の変数
                    {
                        try
                        {
                            //RGBからHSVに変換
                            Cv.CvtColor(source, hsv, ColorConversion.BgrToHsv);
                            OpenCvSharp.CPlusPlus.Mat mat = new OpenCvSharp.CPlusPlus.Mat(hsv, true);

                            ListLedSpec1.ForEach(l =>
                            {

                                switch (l.name)
                                {
                                    case NAME1.LED1:
                                        X = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED2:
                                        X = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED3:
                                        X = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED4:
                                        X = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED5:
                                        X = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED6:
                                        X = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[1]);
                                        break;

                                    case NAME1.LED7:
                                        X = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[1]);
                                        break;
                                }

                                var ListH = new List<int>();
                                var ListS = new List<int>();
                                var ListV = new List<int>();

                                foreach (var i in Enumerable.Range(0, side))
                                {
                                    foreach (var j in Enumerable.Range(0, side))
                                    {
                                        var re = mat.At<OpenCvSharp.CPlusPlus.Vec3b>(Y - (side / 2) + i, X - (side / 2) + j);
                                        if (re[0] != 0 && re[1] > 200 && re[2] > 200)
                                        {
                                            ListH.Add(re[0]);
                                            ListS.Add(re[1]);
                                            ListV.Add(re[2]);
                                        }

                                    }
                                }
                                var Hue = (ListH.Count != 0) ? ListH.Average() : 0;
                                var Sat = (ListS.Count != 0) ? ListS.Average() : 0;
                                var Val = (ListV.Count != 0) ? ListV.Average() : 0;

                                l.resultHue = (Hue >= refHueMin) && (Hue <= refHueMax);

                                //ビューモデルの更新
                                string hsvValue = Hue.ToString("F0");
                                ColorHSV CurrentHsv = new ColorHSV((float)Hue / 180, (float)Sat / 255, (float)Val / 255); //正規化
                                var rgb = ColorConv.HSV2RGB(CurrentHsv);
                                var color = new SolidColorBrush(Color.FromRgb(rgb.R, rgb.G, rgb.B));
                                color.Opacity = 0.5;
                                color.Freeze();//これ重要！！！  

                                switch (l.name)
                                {
                                    case NAME1.LED1:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed1R = hsvValue;
                                                State.VmTestResults.ColLed1R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed1G = hsvValue;
                                                State.VmTestResults.ColLed1G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed1B = hsvValue;
                                                State.VmTestResults.ColLed1B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED2:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed2R = hsvValue;
                                                State.VmTestResults.ColLed2R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed2G = hsvValue;
                                                State.VmTestResults.ColLed2G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed2B = hsvValue;
                                                State.VmTestResults.ColLed2B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED3:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed3R = hsvValue;
                                                State.VmTestResults.ColLed3R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed3G = hsvValue;
                                                State.VmTestResults.ColLed3G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed3B = hsvValue;
                                                State.VmTestResults.ColLed3B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED4:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed4R = hsvValue;
                                                State.VmTestResults.ColLed4R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed4G = hsvValue;
                                                State.VmTestResults.ColLed4G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed4B = hsvValue;
                                                State.VmTestResults.ColLed4B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED5:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed5R = hsvValue;
                                                State.VmTestResults.ColLed5R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed5G = hsvValue;
                                                State.VmTestResults.ColLed5G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed5B = hsvValue;
                                                State.VmTestResults.ColLed5B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED6:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed6R = hsvValue;
                                                State.VmTestResults.ColLed6R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed6G = hsvValue;
                                                State.VmTestResults.ColLed6G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed6B = hsvValue;
                                                State.VmTestResults.ColLed6B = color;
                                                break;
                                        }
                                        break;

                                    case NAME1.LED7:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed7R = hsvValue;
                                                State.VmTestResults.ColLed7R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed7G = hsvValue;
                                                State.VmTestResults.ColLed7G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed7B = hsvValue;
                                                State.VmTestResults.ColLed7B = color;
                                                break;
                                        }
                                        break;
                                }


                            });
                        }
                        catch
                        {
                            return Result = false;
                        }
                    }

                    return Result = ListLedSpec1.All(l => l.resultHue);

                }
                finally
                {
                    if (Result)
                    {
                        State.VmTestStatus.TestLog += "---PASS\r\n";
                    }
                    else
                    {
                        State.VmTestStatus.TestLog += "---FAIL\r\n";
                    }


                    //if (!Result)
                    //{
                    //    General.cam1.MakeNgFrame = (img) =>
                    //    {
                    //        //リストからNGの座標を抽出する
                    //        var NgList = ListLedSpec1.Where(l => !l.resultHue).ToList();
                    //        NgList.ForEach(n =>
                    //        {
                    //            int x = 0;
                    //            int y = 0;
                    //            switch (n.name)
                    //            {
                    //                case NAME1.LED1:
                    //                    x = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED1.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED2:
                    //                    x = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED2.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED3:
                    //                    x = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED3.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED4:
                    //                    x = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED4.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED5:
                    //                    x = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED5.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED6:
                    //                    x = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED6.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME1.LED7:
                    //                    x = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam1Prop.LED7.Split('/').ToArray()[1]);
                    //                    break;
                    //            }

                    //            var length = 30;
                    //            img.Rectangle(new CvRect(x - (length / 2), y - (length / 2), length, length), CvColor.DodgerBlue, 4);
                    //        });
                    //    };
                    //    General.cam1.FlagNgFrame = true;
                    //    State.VmTestStatus.MeasValue = "計測値 : ---";
                    //}

                }
            });


        }

        private static async Task<bool> CheckColor2(COLOR col)
        {
            var side = 50;
            var X = 0;
            var Y = 0;
            var refHueMax = 0;
            var refHueMin = 0;

            return await Task<bool>.Run(() =>
            {
                State.VmTestStatus.TestLog += "色相チェック";
                var Result = false;
                try
                {
                    InitList();

                    switch (col)
                    {
                        case COLOR.RED:
                            refHueMax = State.TestSpec.RedHueMax;
                            refHueMin = State.TestSpec.RedHueMin;
                            State.VmTestStatus.Spec = "規格値 : 赤 " + State.TestSpec.RedHueMin.ToString() + "-" + State.TestSpec.RedHueMax.ToString();
                            break;

                        case COLOR.GREEN:
                            refHueMax = State.TestSpec.GreenHueMax;
                            refHueMin = State.TestSpec.GreenHueMin;
                            State.VmTestStatus.Spec = "規格値 : 緑 " + State.TestSpec.GreenHueMin.ToString() + "-" + State.TestSpec.GreenHueMax.ToString();
                            break;

                        case COLOR.BLUE:
                            refHueMax = State.TestSpec.BlueHueMax;
                            refHueMin = State.TestSpec.BlueHueMin;
                            State.VmTestStatus.Spec = "規格値 : 青 " + State.TestSpec.BlueHueMin.ToString() + "-" + State.TestSpec.BlueHueMax.ToString();
                            break;
                    }

                    Thread.Sleep(1000);

                    //cam2の画像を取得する処理
                    General.cam2.FlagTestPic = true;
                    while (General.cam2.FlagTestPic) ;
                    source = General.cam2.imageForTest;
                    //source.SaveImage(@"C:\Users\TSDP00059\Desktop\src.jpg");
                    using (IplImage hsv = new IplImage(640, 360, BitDepth.U8, 3)) // グレースケール画像格納用の変数
                    {
                        try
                        {
                            //RGBからHSVに変換
                            Cv.CvtColor(source, hsv, ColorConversion.BgrToHsv);
                            OpenCvSharp.CPlusPlus.Mat mat = new OpenCvSharp.CPlusPlus.Mat(hsv, true);

                            ListLedSpec2.ForEach(l =>
                            {

                                switch (l.name)
                                {
                                    case NAME2.LED8:
                                        X = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED9:
                                        X = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED10:
                                        X = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED11:
                                        X = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED12:
                                        X = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED13:
                                        X = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[1]);
                                        break;

                                    case NAME2.LED14:
                                        X = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[0]);
                                        Y = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[1]);
                                        break;
                                }

                                var ListH = new List<int>();
                                var ListS = new List<int>();
                                var ListV = new List<int>();

                                foreach (var i in Enumerable.Range(0, side))
                                {
                                    foreach (var j in Enumerable.Range(0, side))
                                    {
                                        var re = mat.At<OpenCvSharp.CPlusPlus.Vec3b>(Y - (side / 2) + i, X - (side / 2) + j);
                                        if (re[0] != 0 && re[1] > 200 && re[2] > 200)
                                        {
                                            ListH.Add(re[0]);
                                            ListS.Add(re[1]);
                                            ListV.Add(re[2]);
                                        }

                                    }
                                }
                                var Hue = (ListH.Count != 0) ? ListH.Average() : 0;
                                var Sat = (ListS.Count != 0) ? ListS.Average() : 0;
                                var Val = (ListV.Count != 0) ? ListV.Average() : 0;

                                l.resultHue = (Hue >= refHueMin) && (Hue <= refHueMax);

                                //ビューモデルの更新
                                string hsvValue = Hue.ToString("F0");
                                ColorHSV CurrentHsv = new ColorHSV((float)Hue / 180, (float)Sat / 255, (float)Val / 255); //正規化
                                var rgb = ColorConv.HSV2RGB(CurrentHsv);
                                var color = new SolidColorBrush(Color.FromRgb(rgb.R, rgb.G, rgb.B));
                                color.Opacity = 0.5;
                                color.Freeze();//これ重要！！！  

                                switch (l.name)
                                {
                                    case NAME2.LED8:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed8R = hsvValue;
                                                State.VmTestResults.ColLed8R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed8G = hsvValue;
                                                State.VmTestResults.ColLed8G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed8B = hsvValue;
                                                State.VmTestResults.ColLed8B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED9:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed9R = hsvValue;
                                                State.VmTestResults.ColLed9R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed9G = hsvValue;
                                                State.VmTestResults.ColLed9G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed9B = hsvValue;
                                                State.VmTestResults.ColLed9B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED10:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed10R = hsvValue;
                                                State.VmTestResults.ColLed10R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed10G = hsvValue;
                                                State.VmTestResults.ColLed10G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed10B = hsvValue;
                                                State.VmTestResults.ColLed10B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED11:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed11R = hsvValue;
                                                State.VmTestResults.ColLed11R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed11G = hsvValue;
                                                State.VmTestResults.ColLed11G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed11B = hsvValue;
                                                State.VmTestResults.ColLed11B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED12:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed12R = hsvValue;
                                                State.VmTestResults.ColLed12R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed12G = hsvValue;
                                                State.VmTestResults.ColLed12G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed12B = hsvValue;
                                                State.VmTestResults.ColLed12B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED13:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed13R = hsvValue;
                                                State.VmTestResults.ColLed13R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed13G = hsvValue;
                                                State.VmTestResults.ColLed13G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed13B = hsvValue;
                                                State.VmTestResults.ColLed13B = color;
                                                break;
                                        }
                                        break;

                                    case NAME2.LED14:
                                        switch (col)
                                        {
                                            case COLOR.RED:
                                                State.VmTestResults.HueLed14R = hsvValue;
                                                State.VmTestResults.ColLed14R = color;
                                                break;
                                            case COLOR.GREEN:
                                                State.VmTestResults.HueLed14G = hsvValue;
                                                State.VmTestResults.ColLed14G = color;
                                                break;
                                            case COLOR.BLUE:
                                                State.VmTestResults.HueLed14B = hsvValue;
                                                State.VmTestResults.ColLed14B = color;
                                                break;
                                        }
                                        break;
                                }


                            });
                        }
                        catch
                        {
                            return Result = false;
                        }
                    }

                    return Result = ListLedSpec2.All(l => l.resultHue);

                }
                finally
                {
                    if (Result)
                    {
                        State.VmTestStatus.TestLog += "---PASS\r\n";
                    }
                    else
                    {
                        State.VmTestStatus.TestLog += "---FAIL\r\n";
                    }


                    //if (!Result)
                    //{
                    //    General.cam2.MakeNgFrame = (img) =>
                    //    {
                    //        //リストからNGの座標を抽出する
                    //        var NgList = ListLedSpec2.Where(l => !l.resultHue).ToList();
                    //        NgList.ForEach(n =>
                    //        {
                    //            int x = 0;
                    //            int y = 0;
                    //            switch (n.name)
                    //            {
                    //                case NAME2.LED8:
                    //                    x = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED8.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED9:
                    //                    x = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED9.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED10:
                    //                    x = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED10.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED11:
                    //                    x = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED11.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED12:
                    //                    x = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED12.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED13:
                    //                    x = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED13.Split('/').ToArray()[1]);
                    //                    break;

                    //                case NAME2.LED14:
                    //                    x = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[0]);
                    //                    y = Int32.Parse(State.cam2Prop.LED14.Split('/').ToArray()[1]);
                    //                    break;
                    //            }

                    //            var length = 30;
                    //            img.Rectangle(new CvRect(x - (length / 2), y - (length / 2), length, length), CvColor.DodgerBlue, 4);
                    //        });
                    //    };
                    //    General.cam2.FlagNgFrame = true;
                    //    State.VmTestStatus.MeasValue = "計測値 : ---";
                    //}

                }
            });


        }


        public static async Task<bool> CheckSection1(COLOR col)
        {
            Flags.AddDecision = false;
            State.VmTestStatus.TestLog += "\r\n";

            bool allResult = false;
            try
            {
                await Task.Run(() =>
                {
                    switch (col)
                    {
                        case COLOR.RED:
                            SetRed();
                            break;

                        case COLOR.GREEN:
                            SetGreen();
                            break;

                        case COLOR.BLUE:
                            SetBlue();
                            break;
                    }

                });

                var reColor = await CheckColor1(col);
                var reLum = await CheckLum1(col);
                General.cam1.ResetFlag();
                LPC1768.SendDataTarget("C");
                return allResult = reLum && reColor;
            }
            finally
            {
            }
        }

        public static async Task<bool> CheckSection2(COLOR col)
        {
            Flags.AddDecision = false;
            State.VmTestStatus.TestLog += "\r\n";

            bool allResult = false;
            try
            {
                await Task.Run(() =>
                {
                    switch (col)
                    {
                        case COLOR.RED:
                            SetRed();
                            break;

                        case COLOR.GREEN:
                            SetGreen();
                            break;

                        case COLOR.BLUE:
                            SetBlue();
                            break;
                    }

                });

                var reColor = await CheckColor2(col);
                var reLum = await CheckLum2(col);
                General.cam2.ResetFlag();
                LPC1768.SendDataTarget("C");
                return allResult = reLum && reColor;
            }
            finally
            {
            }
        }

    }

}









