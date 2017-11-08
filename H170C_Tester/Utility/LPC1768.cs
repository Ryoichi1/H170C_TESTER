using System.IO.Ports;
using System.Threading;

namespace H170C_Tester
{
    public static class LPC1768
    {
        private const string ID_LPC1768 = "H170C_CHECKER_V";
        private const string ComName = "mbed Serial Port";
        //変数の宣言（インスタンスメンバーになります）
        private static SerialPort port;
        public static string RecieveData { get; set; }//LPC1768から受信した生データ


        //コンストラクタ
        static LPC1768()
        {
            port = new SerialPort();
        }


        //**************************************************************************
        //LPC1768の初期化
        //**************************************************************************
        public static bool Init()
        {
            var result = false;
            try
            {
                var comNum = FindSerialPort.GetComNo(ComName);
                if (comNum == null) return false;

                if (!port.IsOpen)
                {
                    //Agilent34401A用のシリアルポート設定
                    port.PortName = comNum; //この時点で既にポートが開いている場合COM番号は設定できず例外となる（イニシャライズは１回のみ有効）
                    port.BaudRate = 115200;
                    port.DataBits = 8;
                    port.Parity = System.IO.Ports.Parity.None;
                    port.StopBits = System.IO.Ports.StopBits.One;
                    //port.DtrEnable = true;//これ設定しないとコマンド送るたびにErrorになります！
                    port.NewLine = ("\r\n");
                    port.Open();
                }


                //クエリ送信
                if (!SendData1768("*IDN?")) return false;
                return result = RecieveData.Contains(ID_LPC1768);


            }
            catch
            {
                return result = false;
            }
            finally
            {
                if (!result)
                {
                    ClosePort();
                }
            }
        }

        //**************************************************************************
        //LPC1768を制御する 
        //**************************************************************************
        public static bool SendData1768(string Data, int Wait = 1000, bool setLog = true)
        {
            //送信処理
            try
            {
                State.VmComm.LPC1768_TX = "";
                State.VmComm.LPC1768_RX = "";

                ClearBuff();//受信バッファのクリア

                port.WriteLine(Data);// \r\n は自動的に付加されます
                if(setLog) State.VmComm.LPC1768_TX = Data;

            }
            catch
            {
                State.VmComm.LPC1768_TX = "TX_Error";
                return false;
            }

            //受信処理
            try
            {
                RecieveData = "";//初期化
                port.ReadTimeout = Wait;
                RecieveData = port.ReadLine();
                if(setLog) State.VmComm.LPC1768_RX = RecieveData;
                return true;
            }
            catch
            {
                State.VmComm.LPC1768_RX = "TimeoutErr";
                return false;
            }
        }


        //**************************************************************************
        //ターゲット(H170C)にコマンドを送る 
        //**************************************************************************
        public static bool SendDataTarget(string Data, General.CAN_NAME canName = General.CAN_NAME.CN271, int Wait = 1000, bool setLog = true)
        {
            //送信処理
            try
            {
                //通信経路の選択
                General.SelectCan(canName);

                State.VmComm.TARGET_TX = "";
                State.VmComm.TARGET_RX = "";

                ClearBuff();//受信バッファのクリア

                port.WriteLine(Data);// \r\n は自動的に付加されます
                if (setLog) State.VmComm.TARGET_TX = $"[STX]{Data}[ETX]";

            }
            catch
            {
                State.VmComm.TARGET_TX = "TX_Error";
                return false;
            }

            //受信処理
            try
            {
                RecieveData = "";//初期化
                port.ReadTimeout = Wait;
                var RxData = port.ReadLine();
                return AnalysisData(RxData);
            }
            catch
            {
                if (setLog) State.VmComm.TARGET_RX = "TimeoutErr";
                return false;
            }

            //ローカル関数の定義
            bool AnalysisData(string data)
            {
                var result = false;

                try
                {
                    //受信データのフレームが正しいかチェックする（先頭STX）
                    if (!data.StartsWith("[STX]") || !data.EndsWith("[ETX]"))
                    {
                        RecieveData = "FrameError";
                        return result = false;
                    }

                    //先頭の[STX],末尾の[ETX]を取り除く
                    RecieveData = data.Replace("[STX]", "").Replace("[ETX]", "");
                    return result = true;
                }
                catch
                {
                    RecieveData = "Error例外";
                    return result = false;
                }
                finally
                {
                    if (!result)
                    {   //TODO：
                        //ラベルの色を赤くするなどの処理を追加する
                    }
                    //先頭の[STX],末尾の[ETX]はログにそのまま表示する
                    if (setLog) State.VmComm.TARGET_RX = data; Thread.Sleep(40);
                }
            }

        }



        //**************************************************************************
        //受信バッファをクリアする
        //**************************************************************************
        private static void ClearBuff()
        {
            if (port.IsOpen)
                port.DiscardInBuffer();
        }


        //**************************************************************************
        //COMポートを閉じる
        //引数：なし
        //戻値：bool
        //**************************************************************************   
        public static bool ClosePort()
        {
            try
            {
                //ポートが開いているかどうかの判定
                if (port.IsOpen)
                {
                    SendData1768("ResetIo");//製品を初期化して終了
                    port.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }





    }

}

