﻿using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;

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

        //LED輝度 赤
        private string _LED1LumR;
        public string LED1LumR { get { return _LED1LumR; } set { SetProperty(ref _LED1LumR, value); } }

        private string _LED2LumR;
        public string LED2LumR { get { return _LED2LumR; } set { SetProperty(ref _LED2LumR, value); } }

        private string _LED3LumR;
        public string LED3LumR { get { return _LED3LumR; } set { SetProperty(ref _LED3LumR, value); } }

        private string _LED4LumR;
        public string LED4LumR { get { return _LED4LumR; } set { SetProperty(ref _LED4LumR, value); } }

        private string _LED5LumR;
        public string LED5LumR { get { return _LED5LumR; } set { SetProperty(ref _LED5LumR, value); } }

        private string _LED6LumR;
        public string LED6LumR { get { return _LED6LumR; } set { SetProperty(ref _LED6LumR, value); } }

        private string _LED7LumR;
        public string LED7LumR { get { return _LED7LumR; } set { SetProperty(ref _LED7LumR, value); } }

        //色相赤
        private string _HueLed1R;
        public string HueLed1R { get { return _HueLed1R; } set { SetProperty(ref _HueLed1R, value); } }

        private Brush _ColLed1R;
        public Brush ColLed1R { get { return _ColLed1R; } set { SetProperty(ref _ColLed1R, value); } }

        private string _HueLed2R;
        public string HueLed2R { get { return _HueLed2R; } set { SetProperty(ref _HueLed2R, value); } }

        private Brush _ColLed2R;
        public Brush ColLed2R { get { return _ColLed2R; } set { SetProperty(ref _ColLed2R, value); } }

        private string _HueLed3R;
        public string HueLed3R { get { return _HueLed3R; } set { SetProperty(ref _HueLed3R, value); } }

        private Brush _ColLed3R;
        public Brush ColLed3R { get { return _ColLed3R; } set { SetProperty(ref _ColLed3R, value); } }

        private string _HueLed4R;
        public string HueLed4R { get { return _HueLed4R; } set { SetProperty(ref _HueLed4R, value); } }

        private Brush _ColLed4R;
        public Brush ColLed4R { get { return _ColLed4R; } set { SetProperty(ref _ColLed4R, value); } }

        private string _HueLed5R;
        public string HueLed5R { get { return _HueLed5R; } set { SetProperty(ref _HueLed5R, value); } }

        private Brush _ColLed5R;
        public Brush ColLed5R { get { return _ColLed5R; } set { SetProperty(ref _ColLed5R, value); } }

        private string _HueLed6R;
        public string HueLed6R { get { return _HueLed6R; } set { SetProperty(ref _HueLed6R, value); } }

        private Brush _ColLed6R;
        public Brush ColLed6R { get { return _ColLed6R; } set { SetProperty(ref _ColLed6R, value); } }

        private string _HueLed7R;
        public string HueLed7R { get { return _HueLed7R; } set { SetProperty(ref _HueLed7R, value); } }

        private Brush _ColLed7R;
        public Brush ColLed7R { get { return _ColLed7R; } set { SetProperty(ref _ColLed7R, value); } }





        //LED輝度 緑
        private string _LED1LumG;
        public string LED1LumG { get { return _LED1LumG; } set { SetProperty(ref _LED1LumG, value); } }

        private string _LED2LumG;
        public string LED2LumG { get { return _LED2LumG; } set { SetProperty(ref _LED2LumG, value); } }

        private string _LED3LumG;
        public string LED3LumG { get { return _LED3LumG; } set { SetProperty(ref _LED3LumG, value); } }

        private string _LED4LumG;
        public string LED4LumG { get { return _LED4LumG; } set { SetProperty(ref _LED4LumG, value); } }

        private string _LED5LumG;
        public string LED5LumG { get { return _LED5LumG; } set { SetProperty(ref _LED5LumG, value); } }

        private string _LED6LumG;
        public string LED6LumG { get { return _LED6LumG; } set { SetProperty(ref _LED6LumG, value); } }

        private string _LED7LumG;
        public string LED7LumG { get { return _LED7LumG; } set { SetProperty(ref _LED7LumG, value); } }

        //色相緑
        private string _HueLed1G;
        public string HueLed1G { get { return _HueLed1G; } set { SetProperty(ref _HueLed1G, value); } }

        private Brush _ColLed1G;
        public Brush ColLed1G { get { return _ColLed1G; } set { SetProperty(ref _ColLed1G, value); } }

        private string _HueLed2G;
        public string HueLed2G { get { return _HueLed2G; } set { SetProperty(ref _HueLed2G, value); } }

        private Brush _ColLed2G;
        public Brush ColLed2G { get { return _ColLed2G; } set { SetProperty(ref _ColLed2G, value); } }

        private string _HueLed3G;
        public string HueLed3G { get { return _HueLed3G; } set { SetProperty(ref _HueLed3G, value); } }

        private Brush _ColLed3G;
        public Brush ColLed3G { get { return _ColLed3G; } set { SetProperty(ref _ColLed3G, value); } }

        private string _HueLed4G;
        public string HueLed4G { get { return _HueLed4G; } set { SetProperty(ref _HueLed4G, value); } }

        private Brush _ColLed4G;
        public Brush ColLed4G { get { return _ColLed4G; } set { SetProperty(ref _ColLed4G, value); } }

        private string _HueLed5G;
        public string HueLed5G { get { return _HueLed5G; } set { SetProperty(ref _HueLed5G, value); } }

        private Brush _ColLed5G;
        public Brush ColLed5G { get { return _ColLed5G; } set { SetProperty(ref _ColLed5G, value); } }

        private string _HueLed6G;
        public string HueLed6G { get { return _HueLed6G; } set { SetProperty(ref _HueLed6G, value); } }

        private Brush _ColLed6G;
        public Brush ColLed6G { get { return _ColLed6G; } set { SetProperty(ref _ColLed6G, value); } }

        private string _HueLed7G;
        public string HueLed7G { get { return _HueLed7G; } set { SetProperty(ref _HueLed7G, value); } }

        private Brush _ColLed7G;
        public Brush ColLed7G { get { return _ColLed7G; } set { SetProperty(ref _ColLed7G, value); } }

        //LED輝度 青
        private string _LED1LumB;
        public string LED1LumB { get { return _LED1LumB; } set { SetProperty(ref _LED1LumB, value); } }

        private string _LED2LumB;
        public string LED2LumB { get { return _LED2LumB; } set { SetProperty(ref _LED2LumB, value); } }

        private string _LED3LumB;
        public string LED3LumB { get { return _LED3LumB; } set { SetProperty(ref _LED3LumB, value); } }

        private string _LED4LumB;
        public string LED4LumB { get { return _LED4LumB; } set { SetProperty(ref _LED4LumB, value); } }

        private string _LED5LumB;
        public string LED5LumB { get { return _LED5LumB; } set { SetProperty(ref _LED5LumB, value); } }

        private string _LED6LumB;
        public string LED6LumB { get { return _LED6LumB; } set { SetProperty(ref _LED6LumB, value); } }

        private string _LED7LumB;
        public string LED7LumB { get { return _LED7LumB; } set { SetProperty(ref _LED7LumB, value); } }

        //色相青
        private string _HueLed1B;
        public string HueLed1B { get { return _HueLed1B; } set { SetProperty(ref _HueLed1B, value); } }

        private Brush _ColLed1B;
        public Brush ColLed1B { get { return _ColLed1B; } set { SetProperty(ref _ColLed1B, value); } }

        private string _HueLed2B;
        public string HueLed2B { get { return _HueLed2B; } set { SetProperty(ref _HueLed2B, value); } }

        private Brush _ColLed2B;
        public Brush ColLed2B { get { return _ColLed2B; } set { SetProperty(ref _ColLed2B, value); } }

        private string _HueLed3B;
        public string HueLed3B { get { return _HueLed3B; } set { SetProperty(ref _HueLed3B, value); } }

        private Brush _ColLed3B;
        public Brush ColLed3B { get { return _ColLed3B; } set { SetProperty(ref _ColLed3B, value); } }

        private string _HueLed4B;
        public string HueLed4B { get { return _HueLed4B; } set { SetProperty(ref _HueLed4B, value); } }

        private Brush _ColLed4B;
        public Brush ColLed4B { get { return _ColLed4B; } set { SetProperty(ref _ColLed4B, value); } }

        private string _HueLed5B;
        public string HueLed5B { get { return _HueLed5B; } set { SetProperty(ref _HueLed5B, value); } }

        private Brush _ColLed5B;
        public Brush ColLed5B { get { return _ColLed5B; } set { SetProperty(ref _ColLed5B, value); } }

        private string _HueLed6B;
        public string HueLed6B { get { return _HueLed6B; } set { SetProperty(ref _HueLed6B, value); } }

        private Brush _ColLed6B;
        public Brush ColLed6B { get { return _ColLed6B; } set { SetProperty(ref _ColLed6B, value); } }

        private string _HueLed7B;
        public string HueLed7B { get { return _HueLed7B; } set { SetProperty(ref _HueLed7B, value); } }

        private Brush _ColLed7B;
        public Brush ColLed7B { get { return _ColLed7B; } set { SetProperty(ref _ColLed7B, value); } }

    }
}
