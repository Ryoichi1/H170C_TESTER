using System;
using System.Collections.Generic;

namespace H170C_Tester
{

    public class TestSpecs
    {
        public int Key;
        public string Value;
        public bool PowSw;

        public TestSpecs(int key, string value, bool powSW = true)
        {
            this.Key = key;
            this.Value = value;
            this.PowSw = powSW;

        }
    }

    public static class State
    {

        //データソース（バインディング用）
        public static ViewModelMainWindow VmMainWindow = new ViewModelMainWindow();
        public static ViewModelTestStatus VmTestStatus = new ViewModelTestStatus();
        public static ViewModelTestResult VmTestResults = new ViewModelTestResult();
        public static ViewModelCommunication VmComm = new ViewModelCommunication();
        public static TestCommand testCommand = new TestCommand();
        public static ViewModelCamera1 VmCamera1Point = new ViewModelCamera1();
        public static ViewModelCamera2 VmCamera2Point = new ViewModelCamera2();


        //パブリックメンバ
        public static Configuration Setting { get; set; }
        public static TestSpec TestSpec { get; set; }

        public static Cam1Property cam1Prop { get; set; }
        public static Cam2Property cam2Prop { get; set; }

        public static string CurrDir { get; set; }

        public static string AssemblyInfo { get; set; }

        public static double CurrentThemeOpacity { get; set; }

        public static Uri uriOtherInfoPage { get; set; }


        //リトライ履歴保存用リスト
        public static List<string> RetryLogList = new List<string>();


        public static List<TestSpecs> テスト項目 = new List<TestSpecs>()
        {
            new TestSpecs(100, "GND1 未半田チェック1", true),
            new TestSpecs(101, "GND2 未半田チェック2", true),

            new TestSpecs(200, "検査ソフト書き込み", false),

            new TestSpecs(300, "SW1検査", false),

            new TestSpecs(400, "セクション1 赤色チェック", true),
            new TestSpecs(401, "セクション1 緑色チェック", true),
            new TestSpecs(402, "セクション1 青色チェック", true),

            new TestSpecs(500, "セクション2 赤色チェック", true),
            new TestSpecs(501, "セクション2 緑色チェック", true),
            new TestSpecs(502, "セクション2 青色チェック", true),

            new TestSpecs(600, "製品ソフト書き込み", false),
        };

        //個別設定のロード
        public static void LoadConfigData()
        {
            //Configファイルのロード
            Setting = Deserialize<Configuration>(Constants.filePath_Configuration);


            VmMainWindow.ListOperator = Setting.作業者リスト;
            VmMainWindow.Theme = Setting.PathTheme;
            VmMainWindow.ThemeOpacity = Setting.OpacityTheme;

                if (Setting.日付 != DateTime.Now.ToString("yyyyMMdd"))
                {
                    Setting.日付 = DateTime.Now.ToString("yyyyMMdd");
                    Setting.TodayOkCount = 0;
                    Setting.TodayNgCount = 0;
                }

                VmTestStatus.OkCount = Setting.TodayOkCount.ToString() + "台";
                VmTestStatus.NgCount = Setting.TodayNgCount.ToString() + "台";

            //TestSpecファイルのロード
            TestSpec = Deserialize<TestSpec>(Constants.filePath_TestSpec);

            //カメラプロパティファイルのロード
            cam1Prop = Deserialize<Cam1Property>(Constants.filePath_Camera1Property);
            cam2Prop = Deserialize<Cam2Property>(Constants.filePath_Camera2Property);

        }


        //インスタンスをXMLデータに変換する
        public static bool Serialization<T>(T obj, string xmlFilePath)
        {
            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlFilePath, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
                //ファイルを閉じる
                sw.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }

        //XMLデータからインスタンスを生成する
        public static T Deserialize<T>(string xmlFilePath)
        {
            System.Xml.Serialization.XmlSerializer serializer;
            using (var sr = new System.IO.StreamReader(xmlFilePath, new System.Text.UTF8Encoding(false)))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        //********************************************************
        //個別設定データの保存
        //********************************************************
        public static bool Save個別データ()
        {
            try
            {
                //Configファイルの保存
                Setting.作業者リスト = VmMainWindow.ListOperator;
                Setting.PathTheme = VmMainWindow.Theme;
                Setting.OpacityTheme = VmMainWindow.ThemeOpacity;

                Serialization<Configuration>(Setting, Constants.filePath_Configuration);

                //Cam1プロパティの保存
                Serialization<Cam1Property>(State.cam1Prop, Constants.filePath_Camera1Property);
                Serialization<Cam2Property>(State.cam2Prop, Constants.filePath_Camera2Property);

                return true;
            }
            catch
            {
                return false;

            }

        }


        public static void SetCam1Prop()
        {
            //cam0の設定
            General.cam1.Brightness = cam1Prop.Brightness;
            General.cam1.Contrast = cam1Prop.Contrast;
            General.cam1.Hue = cam1Prop.Hue;
            General.cam1.Saturation = cam1Prop.Saturation;
            General.cam1.Sharpness = cam1Prop.Sharpness;
            General.cam1.Gamma = cam1Prop.Gamma;
            General.cam1.Gain = cam1Prop.Gain;
            General.cam1.Exposure = cam1Prop.Exposure;
            General.cam1.Theta = cam1Prop.Theta;
            General.cam1.BinLevel = cam1Prop.BinLevel;

            General.cam1.Opening = cam1Prop.Opening;
            General.cam1.openCnt = cam1Prop.OpenCnt;
            General.cam1.closeCnt = cam1Prop.CloseCnt;

            //TODO: 座標指定
            State.VmCamera1Point.LED1 = cam1Prop.LED1;
            State.VmCamera1Point.LED2 = cam1Prop.LED2;
            State.VmCamera1Point.LED3 = cam1Prop.LED3;
            State.VmCamera1Point.LED4 = cam1Prop.LED4;
            State.VmCamera1Point.LED5 = cam1Prop.LED5;
            State.VmCamera1Point.LED6 = cam1Prop.LED6;
            State.VmCamera1Point.LED7 = cam1Prop.LED7;
        }

        public static void SetCam2Prop()
        {
            //cam0の設定
            General.cam2.Brightness = cam2Prop.Brightness;
            General.cam2.Contrast = cam2Prop.Contrast;
            General.cam2.Hue = cam2Prop.Hue;
            General.cam2.Saturation = cam2Prop.Saturation;
            General.cam2.Sharpness = cam2Prop.Sharpness;
            General.cam2.Gamma = cam2Prop.Gamma;
            General.cam2.Gain = cam2Prop.Gain;
            General.cam2.Exposure = cam2Prop.Exposure;
            General.cam2.Theta = cam2Prop.Theta;
            General.cam2.BinLevel = cam2Prop.BinLevel;

            General.cam2.Opening = cam2Prop.Opening;
            General.cam2.openCnt = cam2Prop.OpenCnt;
            General.cam2.closeCnt = cam2Prop.CloseCnt;

            //TODO: 座標指定
            State.VmCamera2Point.LED8 = cam2Prop.LED8;
            State.VmCamera2Point.LED9 = cam2Prop.LED9;
            State.VmCamera2Point.LED10 = cam2Prop.LED10;
            State.VmCamera2Point.LED11 = cam2Prop.LED11;
            State.VmCamera2Point.LED12 = cam2Prop.LED12;
            State.VmCamera2Point.LED13 = cam2Prop.LED13;
            State.VmCamera2Point.LED14 = cam2Prop.LED14;

        }




    }

}
