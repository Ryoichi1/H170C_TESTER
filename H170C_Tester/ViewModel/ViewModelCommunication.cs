using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;

namespace H170C_Tester
{

    public class ViewModelCommunication : BindableBase
    {
        //プロパティ
        private string _LPC1768_TX;
        public string LPC1768_TX
        {
            get { return _LPC1768_TX; }
            set { SetProperty(ref _LPC1768_TX, value); }
        }

        private string _LPC1768_RX;
        public string LPC1768_RX
        {
            get { return _LPC1768_RX; }
            set { SetProperty(ref _LPC1768_RX, value); }
        }

        //プロパティ
        private string _TARGET_TX;
        public string TARGET_TX
        {
            get { return _TARGET_TX; }
            set { SetProperty(ref _TARGET_TX, value); }
        }

        private string _TARGET_RX;
        public string TARGET_RX
        {
            get { return _TARGET_RX; }
            set { SetProperty(ref _TARGET_RX, value); }
        }

        private Brush _ColorCan1;
        public Brush ColorCan1 { get { return _ColorCan1; } set { SetProperty(ref _ColorCan1, value); } }

        private Brush _ColorCan2;
        public Brush ColorCan2 { get { return _ColorCan2; } set { SetProperty(ref _ColorCan2, value); } }


    }
}
