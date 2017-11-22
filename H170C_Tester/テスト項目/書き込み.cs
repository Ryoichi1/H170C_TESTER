﻿using System.Threading.Tasks;

namespace H170C_Tester
{
    public static class 書き込み
    {
        public enum WriteMode { TEST, PRODUCT }

        public static async Task<bool> WriteFw(WriteMode mode)
        {
            bool result = false;
            try
            {
                string Path = "";
                if (mode == WriteMode.TEST)
                {
                    Path = Constants.RwsPath_Test;
                }
                else
                {
                    Path = Constants.RwsPath_Product;
                }

                General.SetK1_2(true);

                await Task.Delay(400);

                if (!await FDT.WriteFirmware(Constants.RwsPath_Test)) return false;

                if (mode == WriteMode.TEST)
                {
                    return result = true;
                }
                else
                {
                    return result = FDT.CheckSum(State.TestSpec.FwSum);
                }
            }
            catch
            {
                return result = false;
            }
            finally
            {
                General.SetK1_2(false);

                if (!result)
                {
                    State.VmTestStatus.Spec = "規格値 : チェックサム " + State.TestSpec.FwSum;
                    State.VmTestStatus.MeasValue = "計測値 : チェックサム " + FDT.FlashCheckSum;
                }
            }


        }



    }
}
