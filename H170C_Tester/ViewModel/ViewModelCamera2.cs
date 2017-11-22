using Microsoft.Practices.Prism.Mvvm;

namespace H170C_Tester
{
    public class ViewModelCamera2 : BindableBase
    {
        //粒LED座標
        private string _LED8;
        public string LED8 { get { return _LED8; } set { SetProperty(ref _LED8, value); } }

        private string _LED9;
        public string LED9 { get { return _LED9; } set { SetProperty(ref _LED9, value); } }

        private string _LED10;
        public string LED10 { get { return _LED10; } set { SetProperty(ref _LED10, value); } }

        private string _LED11;
        public string LED11 { get { return _LED11; } set { SetProperty(ref _LED11, value); } }

        private string _LED12;
        public string LED12 { get { return _LED12; } set { SetProperty(ref _LED12, value); } }

        private string _LED13;
        public string LED13 { get { return _LED13; } set { SetProperty(ref _LED13, value); } }

        private string _LED14;
        public string LED14 { get { return _LED14; } set { SetProperty(ref _LED14, value); } }

        //LED輝度
        private string _LED8Lum;
        public string LED8Lum { get { return _LED8Lum; } set { SetProperty(ref _LED8Lum, value); } }

        private string _LED9Lum;
        public string LED9Lum { get { return _LED9Lum; } set { SetProperty(ref _LED9Lum, value); } }

        private string _LED10Lum;
        public string LED10Lum { get { return _LED10Lum; } set { SetProperty(ref _LED10Lum, value); } }

        private string _LED11Lum;
        public string LED11Lum { get { return _LED11Lum; } set { SetProperty(ref _LED11Lum, value); } }

        private string _LED12Lum;
        public string LED12Lum { get { return _LED12Lum; } set { SetProperty(ref _LED12Lum, value); } }

        private string _LED13Lum;
        public string LED13Lum { get { return _LED13Lum; } set { SetProperty(ref _LED13Lum, value); } }

        private string _LED14Lum;
        public string LED14Lum { get { return _LED14Lum; } set { SetProperty(ref _LED14Lum, value); } }

    }
}
