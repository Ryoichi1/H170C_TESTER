using System.Threading.Tasks;

namespace H170C_Tester
{
    public static class TestHarness
    {
        public enum NAME { GND1, GND2 }
        public static async Task<bool> CheckGnd(NAME name)
        {
            bool result = false;

            return await Task<bool>.Run(() =>
            {
                try
                {
                    if (name == NAME.GND1)
                    {
                        if (!LPC1768.SendData1768("R_GND1")) return false;
                        return result = LPC1768.RecieveData == "0";
                    }
                    else
                    {
                        if (!LPC1768.SendData1768("R_GND2")) return false;
                        return result = LPC1768.RecieveData == "0";
                    }
                }
                catch
                {
                    return result = false;
                }
                finally
                {
                    if (!result)
                    {
                        State.VmTestStatus.Spec = "規格値 : ";
                        State.VmTestStatus.MeasValue = "計測値 : 未半田 or 誤配線DEATH!!!";
                    }

                }

            });


        }



    }
}
