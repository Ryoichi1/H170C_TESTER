
namespace H170C_Tester
{
    public class TestSpec
    {
        //テストスペックVER
        public string TestSpecVer { get; set; }

        //ファームウェア
        public string FwVer { get; set; }
        public string FwSum { get; set; }


        //LED 色相
        public int RedHueMax { get; set; }
        public int RedHueMin { get; set; }

        public int GreenHueMax { get; set; }
        public int GreenHueMin { get; set; }

        public int BlueHueMax { get; set; }
        public int BlueHueMin { get; set; }

        //輝度公差
        public double ErrLum { get; set; }

    }
}
