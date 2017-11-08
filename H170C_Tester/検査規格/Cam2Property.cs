

namespace H170C_Tester
{
    public class Cam2Property
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

        //LEDの座標
        public string LED8 { get; set; }
        public string LED9 { get; set; }
        public string LED10 { get; set; }
        public string LED11 { get; set; }
        public string LED12 { get; set; }
        public string LED13 { get; set; }
        public string LED14 { get; set; }

        public double LumRedLed8 { get; set; }
        public double LumRedLed9 { get; set; }
        public double LumRedLed10 { get; set; }
        public double LumRedLed11 { get; set; }
        public double LumRedLed12 { get; set; }
        public double LumRedLed13 { get; set; }
        public double LumRedLed14 { get; set; }

        public double LumBlueLed8 { get; set; }
        public double LumBlueLed9 { get; set; }
        public double LumBlueLed10 { get; set; }
        public double LumBlueLed11 { get; set; }
        public double LumBlueLed12 { get; set; }
        public double LumBlueLed13 { get; set; }
        public double LumBlueLed14 { get; set; }

        public double LumGreenLed8 { get; set; }
        public double LumGreenLed9 { get; set; }
        public double LumGreenLed10 { get; set; }
        public double LumGreenLed11 { get; set; }
        public double LumGreenLed12 { get; set; }
        public double LumGreenLed13 { get; set; }
        public double LumGreenLed14 { get; set; }

    }
}
