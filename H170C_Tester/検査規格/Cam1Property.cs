

namespace H170C_Tester
{
    public class Cam1Property
    {
        //カメラナンバー
        public int CamNumber { get; set; }

        public int BinLevel { get; set; }
        public bool Opening { get; set; }//オープニング処理 or クロージング処理
        public int OpenCnt { get; set; }//クロージング処理時の拡張回数
        public int CloseCnt { get; set; }//クロージング処理時の収縮回数


        //カメラプロパティ
        public double Brightness { get; set; }
        public double Contrast { get; set; }
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Sharpness { get; set; }
        public double Gamma { get; set; }
        public double Gain { get; set; }
        public double Exposure { get; set; }
        public double Theta { get; set; }

        //7セグの座標
        public string LED1 { get; set; }
        public string LED2 { get; set; }
        public string LED3 { get; set; }
        public string LED4 { get; set; }
        public string LED5 { get; set; }
        public string LED6 { get; set; }
        public string LED7 { get; set; }

        public double LumRedLed1 { get; set; }
        public double LumRedLed2 { get; set; }
        public double LumRedLed3 { get; set; }
        public double LumRedLed4 { get; set; }
        public double LumRedLed5 { get; set; }
        public double LumRedLed6 { get; set; }
        public double LumRedLed7 { get; set; }

        public double LumBlueLed1 { get; set; }
        public double LumBlueLed2 { get; set; }
        public double LumBlueLed3 { get; set; }
        public double LumBlueLed4 { get; set; }
        public double LumBlueLed5 { get; set; }
        public double LumBlueLed6 { get; set; }
        public double LumBlueLed7 { get; set; }

        public double LumGreenLed1 { get; set; }
        public double LumGreenLed2 { get; set; }
        public double LumGreenLed3 { get; set; }
        public double LumGreenLed4 { get; set; }
        public double LumGreenLed5 { get; set; }
        public double LumGreenLed6 { get; set; }
        public double LumGreenLed7 { get; set; }

    }
}
