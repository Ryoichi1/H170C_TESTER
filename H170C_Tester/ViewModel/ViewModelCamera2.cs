using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;

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

        //LED輝度 赤
        private string _LED8LumR;
        public string LED8LumR { get { return _LED8LumR; } set { SetProperty(ref _LED8LumR, value); } }

        private string _LED9LumR;
        public string LED9LumR { get { return _LED9LumR; } set { SetProperty(ref _LED9LumR, value); } }

        private string _LED10LumR;
        public string LED10LumR { get { return _LED10LumR; } set { SetProperty(ref _LED10LumR, value); } }

        private string _LED11LumR;
        public string LED11LumR { get { return _LED11LumR; } set { SetProperty(ref _LED11LumR, value); } }

        private string _LED12LumR;
        public string LED12LumR { get { return _LED12LumR; } set { SetProperty(ref _LED12LumR, value); } }

        private string _LED13LumR;
        public string LED13LumR { get { return _LED13LumR; } set { SetProperty(ref _LED13LumR, value); } }

        private string _LED14LumR;
        public string LED14LumR { get { return _LED14LumR; } set { SetProperty(ref _LED14LumR, value); } }

        //LED輝度 緑
        private string _LED8LumG;
        public string LED8LumG { get { return _LED8LumG; } set { SetProperty(ref _LED8LumG, value); } }

        private string _LED9LumG;
        public string LED9LumG { get { return _LED9LumG; } set { SetProperty(ref _LED9LumG, value); } }

        private string _LED10LumG;
        public string LED10LumG { get { return _LED10LumG; } set { SetProperty(ref _LED10LumG, value); } }

        private string _LED11LumG;
        public string LED11LumG { get { return _LED11LumG; } set { SetProperty(ref _LED11LumG, value); } }

        private string _LED12LumG;
        public string LED12LumG { get { return _LED12LumG; } set { SetProperty(ref _LED12LumG, value); } }

        private string _LED13LumG;
        public string LED13LumG { get { return _LED13LumG; } set { SetProperty(ref _LED13LumG, value); } }

        private string _LED14LumG;
        public string LED14LumG { get { return _LED14LumG; } set { SetProperty(ref _LED14LumG, value); } }

        //LED輝度 青
        private string _LED8LumB;
        public string LED8LumB { get { return _LED8LumB; } set { SetProperty(ref _LED8LumB, value); } }

        private string _LED9LumB;
        public string LED9LumB { get { return _LED9LumB; } set { SetProperty(ref _LED9LumB, value); } }

        private string _LED10LumB;
        public string LED10LumB { get { return _LED10LumB; } set { SetProperty(ref _LED10LumB, value); } }

        private string _LED11LumB;
        public string LED11LumB { get { return _LED11LumB; } set { SetProperty(ref _LED11LumB, value); } }

        private string _LED12LumB;
        public string LED12LumB { get { return _LED12LumB; } set { SetProperty(ref _LED12LumB, value); } }

        private string _LED13LumB;
        public string LED13LumB { get { return _LED13LumB; } set { SetProperty(ref _LED13LumB, value); } }

        private string _LED14LumB;
        public string LED14LumB { get { return _LED14LumB; } set { SetProperty(ref _LED14LumB, value); } }




        //色相赤
        private string _HueLed8R;
        public string HueLed8R { get { return _HueLed8R; } set { SetProperty(ref _HueLed8R, value); } }

        private Brush _ColLed8R;
        public Brush ColLed8R { get { return _ColLed8R; } set { SetProperty(ref _ColLed8R, value); } }

        private string _HueLed9R;
        public string HueLed9R { get { return _HueLed9R; } set { SetProperty(ref _HueLed9R, value); } }

        private Brush _ColLed9R;
        public Brush ColLed9R { get { return _ColLed9R; } set { SetProperty(ref _ColLed9R, value); } }

        private string _HueLed10R;
        public string HueLed10R { get { return _HueLed10R; } set { SetProperty(ref _HueLed10R, value); } }

        private Brush _ColLed10R;
        public Brush ColLed10R { get { return _ColLed10R; } set { SetProperty(ref _ColLed10R, value); } }

        private string _HueLed11R;
        public string HueLed11R { get { return _HueLed11R; } set { SetProperty(ref _HueLed11R, value); } }

        private Brush _ColLed11R;
        public Brush ColLed11R { get { return _ColLed11R; } set { SetProperty(ref _ColLed11R, value); } }

        private string _HueLed12R;
        public string HueLed12R { get { return _HueLed12R; } set { SetProperty(ref _HueLed12R, value); } }

        private Brush _ColLed12R;
        public Brush ColLed12R { get { return _ColLed12R; } set { SetProperty(ref _ColLed12R, value); } }

        private string _HueLed13R;
        public string HueLed13R { get { return _HueLed13R; } set { SetProperty(ref _HueLed13R, value); } }

        private Brush _ColLed13R;
        public Brush ColLed13R { get { return _ColLed13R; } set { SetProperty(ref _ColLed13R, value); } }

        private string _HueLed14R;
        public string HueLed14R { get { return _HueLed14R; } set { SetProperty(ref _HueLed14R, value); } }

        private Brush _ColLed14R;
        public Brush ColLed14R { get { return _ColLed14R; } set { SetProperty(ref _ColLed14R, value); } }


        //色相緑
        private string _HueLed8G;
        public string HueLed8G { get { return _HueLed8G; } set { SetProperty(ref _HueLed8G, value); } }

        private Brush _ColLed8G;
        public Brush ColLed8G { get { return _ColLed8G; } set { SetProperty(ref _ColLed8G, value); } }

        private string _HueLed9G;
        public string HueLed9G { get { return _HueLed9G; } set { SetProperty(ref _HueLed9G, value); } }

        private Brush _ColLed9G;
        public Brush ColLed9G { get { return _ColLed9G; } set { SetProperty(ref _ColLed9G, value); } }

        private string _HueLed10G;
        public string HueLed10G { get { return _HueLed10G; } set { SetProperty(ref _HueLed10G, value); } }

        private Brush _ColLed10G;
        public Brush ColLed10G { get { return _ColLed10G; } set { SetProperty(ref _ColLed10G, value); } }

        private string _HueLed11G;
        public string HueLed11G { get { return _HueLed11G; } set { SetProperty(ref _HueLed11G, value); } }

        private Brush _ColLed11G;
        public Brush ColLed11G { get { return _ColLed11G; } set { SetProperty(ref _ColLed11G, value); } }

        private string _HueLed12G;
        public string HueLed12G { get { return _HueLed12G; } set { SetProperty(ref _HueLed12G, value); } }

        private Brush _ColLed12G;
        public Brush ColLed12G { get { return _ColLed12G; } set { SetProperty(ref _ColLed12G, value); } }

        private string _HueLed13G;
        public string HueLed13G { get { return _HueLed13G; } set { SetProperty(ref _HueLed13G, value); } }

        private Brush _ColLed13G;
        public Brush ColLed13G { get { return _ColLed13G; } set { SetProperty(ref _ColLed13G, value); } }

        private string _HueLed14G;
        public string HueLed14G { get { return _HueLed14G; } set { SetProperty(ref _HueLed14G, value); } }

        private Brush _ColLed14G;
        public Brush ColLed14G { get { return _ColLed14G; } set { SetProperty(ref _ColLed14G, value); } }


        //色相青
        private string _HueLed8B;
        public string HueLed8B { get { return _HueLed8B; } set { SetProperty(ref _HueLed8B, value); } }

        private Brush _ColLed8B;
        public Brush ColLed8B { get { return _ColLed8B; } set { SetProperty(ref _ColLed8B, value); } }

        private string _HueLed9B;
        public string HueLed9B { get { return _HueLed9B; } set { SetProperty(ref _HueLed9B, value); } }

        private Brush _ColLed9B;
        public Brush ColLed9B { get { return _ColLed9B; } set { SetProperty(ref _ColLed9B, value); } }

        private string _HueLed10B;
        public string HueLed10B { get { return _HueLed10B; } set { SetProperty(ref _HueLed10B, value); } }

        private Brush _ColLed10B;
        public Brush ColLed10B { get { return _ColLed10B; } set { SetProperty(ref _ColLed10B, value); } }

        private string _HueLed11B;
        public string HueLed11B { get { return _HueLed11B; } set { SetProperty(ref _HueLed11B, value); } }

        private Brush _ColLed11B;
        public Brush ColLed11B { get { return _ColLed11B; } set { SetProperty(ref _ColLed11B, value); } }

        private string _HueLed12B;
        public string HueLed12B { get { return _HueLed12B; } set { SetProperty(ref _HueLed12B, value); } }

        private Brush _ColLed12B;
        public Brush ColLed12B { get { return _ColLed12B; } set { SetProperty(ref _ColLed12B, value); } }

        private string _HueLed13B;
        public string HueLed13B { get { return _HueLed13B; } set { SetProperty(ref _HueLed13B, value); } }

        private Brush _ColLed13B;
        public Brush ColLed13B { get { return _ColLed13B; } set { SetProperty(ref _ColLed13B, value); } }

        private string _HueLed14B;
        public string HueLed14B { get { return _HueLed14B; } set { SetProperty(ref _HueLed14B, value); } }

        private Brush _ColLed14B;
        public Brush ColLed14B { get { return _ColLed14B; } set { SetProperty(ref _ColLed14B, value); } }

















    }
}
