using Microsoft.Practices.Prism.Mvvm;

namespace H170C_Tester
{
    public class ViewModelCamera1 : BindableBase
    {

        //LED座標
        private string _LED1;
        public string LED1 { get { return _LED1; } set { SetProperty(ref _LED1, value); } }

        private string _LED2;
        public string LED2 { get { return _LED2; } set { SetProperty(ref _LED2, value); } }

        private string _LED3;
        public string LED3 { get { return _LED3; } set { SetProperty(ref _LED3, value); } }

        private string _LED4;
        public string LED4 { get { return _LED4; } set { SetProperty(ref _LED4, value); } }

        private string _LED5;
        public string LED5 { get { return _LED5; } set { SetProperty(ref _LED5, value); } }

        private string _LED6;
        public string LED6 { get { return _LED6; } set { SetProperty(ref _LED6, value); } }

        private string _LED7;
        public string LED7 { get { return _LED7; } set { SetProperty(ref _LED7, value); } }

        //LED輝度
        private string _LED1Lum;
        public string LED1Lum { get { return _LED1Lum; } set { SetProperty(ref _LED1Lum, value); } }

        private string _LED2Lum;
        public string LED2Lum { get { return _LED2Lum; } set { SetProperty(ref _LED2Lum, value); } }

        private string _LED3Lum;
        public string LED3Lum { get { return _LED3Lum; } set { SetProperty(ref _LED3Lum, value); } }

        private string _LED4Lum;
        public string LED4Lum { get { return _LED4Lum; } set { SetProperty(ref _LED4Lum, value); } }

        private string _LED5Lum;
        public string LED5Lum { get { return _LED5Lum; } set { SetProperty(ref _LED5Lum, value); } }

        private string _LED6Lum;
        public string LED6Lum { get { return _LED6Lum; } set { SetProperty(ref _LED6Lum, value); } }

        private string _LED7Lum;
        public string LED7Lum { get { return _LED7Lum; } set { SetProperty(ref _LED7Lum, value); } }

    }
}
