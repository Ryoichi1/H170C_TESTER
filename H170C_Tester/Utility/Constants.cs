
namespace H170C_Tester
{
    public static class Constants
    {
        //スタートボタンの表示
        public const string 開始 = "検査開始";
        public const string 停止 = "強制停止";
        public const string 確認 = "確認";

        //作業者へのメッセージ
        public const string MessOpecode = "工番を入力してください";
        public const string MessOperator = "作業者名を選択してください";
        public const string MessSet = "製品をセットしてレバーを下げてください";
        public const string MessRemove = "製品を取り外してください";

        public const string MessWait = "検査中！　しばらくお待ちください・・・";
        public const string MessCheckConnectMachine = "周辺機器の接続を確認してください！";

        public static readonly string filePath_TestSpec = @"C:\H170C\ConfigData\TestSpec.config";
        public static readonly string filePath_Configuration = @"C:\H170C\ConfigData\Configuration.config";
        public static readonly string filePath_Camera1Property = @"C:\H170C\ConfigData\Camera1Property.config";
        public static readonly string filePath_Camera2Property = @"C:\H170C\ConfigData\Camera2Property.config";

        public static readonly string filePath_Cam1CalFilePath = @"C:\H170C\ConfigData\AN170600068.xml";
        public static readonly string filePath_Cam2CalFilePath = @"C:\H170C\ConfigData\AN170600009.xml";

        public static readonly string RwsPath_Test = @"C:\H170C\FW_WRITE\ForTest\H170C_Write\H170C_Write.AWS";
        public static readonly string RwsPath_Product = @"C:\H170C\FW_WRITE\ForProduct\H170C_Write\H170C_Write.AWS";

        public static readonly string Path_Manual = @"C:\H170C\Manual.pdf";

        //検査データフォルダのパス
        public static readonly string PassDataFolderPath = @"C:\H170C\検査データ\合格品データ\";
        public static readonly string FailDataFolderPath = @"C:\H170C\検査データ\不良品データ\";
        public static readonly string fileName_RetryLog  = @"C:\H170C\検査データ\不良品データ\" + "リトライ履歴.txt";

        //Imageの透明度
        public const double OpacityImgMin = 0.0;

        //リトライ回数
        public static readonly int RetryCount = 0;












    }
}
