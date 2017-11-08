using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;


namespace H170C_Tester
{
    public class ViewModelTestResult : BindableBase
    {
        //赤色チェック
        private string _HueLed1R;
        public string HueLed1R { get { return _HueLed1R; } set { SetProperty(ref _HueLed1R, value); } }

        private Brush _ColLed1R;
        public Brush ColLed1R { get { return _ColLed1R; } set { SetProperty(ref _ColLed1R, value); } }

        private string _LumLed1R;
        public string LumLed1R { get { return _LumLed1R; } set { SetProperty(ref _LumLed1R, value); } }

        private Brush _ColLumLed1R;
        public Brush ColLumLed1R { get { return _ColLumLed1R; } set { SetProperty(ref _ColLumLed1R, value); } }

        private string _HueLed2R;
        public string HueLed2R { get { return _HueLed2R; } set { SetProperty(ref _HueLed2R, value); } }

        private Brush _ColLed2R;
        public Brush ColLed2R { get { return _ColLed2R; } set { SetProperty(ref _ColLed2R, value); } }

        private string _LumLed2R;
        public string LumLed2R { get { return _LumLed2R; } set { SetProperty(ref _LumLed2R, value); } }

        private Brush _ColLumLed2R;
        public Brush ColLumLed2R { get { return _ColLumLed2R; } set { SetProperty(ref _ColLumLed2R, value); } }

        private string _HueLed3R;
        public string HueLed3R { get { return _HueLed3R; } set { SetProperty(ref _HueLed3R, value); } }

        private Brush _ColLed3R;
        public Brush ColLed3R { get { return _ColLed3R; } set { SetProperty(ref _ColLed3R, value); } }

        private string _LumLed3R;
        public string LumLed3R { get { return _LumLed3R; } set { SetProperty(ref _LumLed3R, value); } }

        private Brush _ColLumLed3R;
        public Brush ColLumLed3R { get { return _ColLumLed3R; } set { SetProperty(ref _ColLumLed3R, value); } }

        private string _HueLed4R;
        public string HueLed4R { get { return _HueLed4R; } set { SetProperty(ref _HueLed4R, value); } }

        private Brush _ColLed4R;
        public Brush ColLed4R { get { return _ColLed4R; } set { SetProperty(ref _ColLed4R, value); } }

        private string _LumLed4R;
        public string LumLed4R { get { return _LumLed4R; } set { SetProperty(ref _LumLed4R, value); } }

        private Brush _ColLumLed4R;
        public Brush ColLumLed4R { get { return _ColLumLed4R; } set { SetProperty(ref _ColLumLed4R, value); } }

        private string _HueLed5R;
        public string HueLed5R { get { return _HueLed5R; } set { SetProperty(ref _HueLed5R, value); } }

        private Brush _ColLed5R;
        public Brush ColLed5R { get { return _ColLed5R; } set { SetProperty(ref _ColLed5R, value); } }

        private string _LumLed5R;
        public string LumLed5R { get { return _LumLed5R; } set { SetProperty(ref _LumLed5R, value); } }

        private Brush _ColLumLed5R;
        public Brush ColLumLed5R { get { return _ColLumLed5R; } set { SetProperty(ref _ColLumLed5R, value); } }

        private string _HueLed6R;
        public string HueLed6R { get { return _HueLed6R; } set { SetProperty(ref _HueLed6R, value); } }

        private Brush _ColLed6R;
        public Brush ColLed6R { get { return _ColLed6R; } set { SetProperty(ref _ColLed6R, value); } }

        private string _LumLed6R;
        public string LumLed6R { get { return _LumLed6R; } set { SetProperty(ref _LumLed6R, value); } }

        private Brush _ColLumLed6R;
        public Brush ColLumLed6R { get { return _ColLumLed6R; } set { SetProperty(ref _ColLumLed6R, value); } }

        private string _HueLed7R;
        public string HueLed7R { get { return _HueLed7R; } set { SetProperty(ref _HueLed7R, value); } }

        private Brush _ColLed7R;
        public Brush ColLed7R { get { return _ColLed7R; } set { SetProperty(ref _ColLed7R, value); } }

        private string _LumLed7R;
        public string LumLed7R { get { return _LumLed7R; } set { SetProperty(ref _LumLed7R, value); } }

        private Brush _ColLumLed7R;
        public Brush ColLumLed7R { get { return _ColLumLed7R; } set { SetProperty(ref _ColLumLed7R, value); } }

        private string _HueLed8R;
        public string HueLed8R { get { return _HueLed8R; } set { SetProperty(ref _HueLed8R, value); } }

        private Brush _ColLed8R;
        public Brush ColLed8R { get { return _ColLed8R; } set { SetProperty(ref _ColLed8R, value); } }

        private string _LumLed8R;
        public string LumLed8R { get { return _LumLed8R; } set { SetProperty(ref _LumLed8R, value); } }

        private Brush _ColLumLed8R;
        public Brush ColLumLed8R { get { return _ColLumLed8R; } set { SetProperty(ref _ColLumLed8R, value); } }

        private string _HueLed9R;
        public string HueLed9R { get { return _HueLed9R; } set { SetProperty(ref _HueLed9R, value); } }

        private Brush _ColLed9R;
        public Brush ColLed9R { get { return _ColLed9R; } set { SetProperty(ref _ColLed9R, value); } }

        private string _LumLed9R;
        public string LumLed9R { get { return _LumLed9R; } set { SetProperty(ref _LumLed9R, value); } }

        private Brush _ColLumLed9R;
        public Brush ColLumLed9R { get { return _ColLumLed9R; } set { SetProperty(ref _ColLumLed9R, value); } }

        private string _HueLed10R;
        public string HueLed10R { get { return _HueLed10R; } set { SetProperty(ref _HueLed10R, value); } }

        private Brush _ColLed10R;
        public Brush ColLed10R { get { return _ColLed10R; } set { SetProperty(ref _ColLed10R, value); } }

        private string _LumLed10R;
        public string LumLed10R { get { return _LumLed10R; } set { SetProperty(ref _LumLed10R, value); } }

        private Brush _ColLumLed10R;
        public Brush ColLumLed10R { get { return _ColLumLed10R; } set { SetProperty(ref _ColLumLed10R, value); } }

        private string _HueLed11R;
        public string HueLed11R { get { return _HueLed11R; } set { SetProperty(ref _HueLed11R, value); } }

        private Brush _ColLed11R;
        public Brush ColLed11R { get { return _ColLed11R; } set { SetProperty(ref _ColLed11R, value); } }

        private string _LumLed11R;
        public string LumLed11R { get { return _LumLed11R; } set { SetProperty(ref _LumLed11R, value); } }

        private Brush _ColLumLed11R;
        public Brush ColLumLed11R { get { return _ColLumLed11R; } set { SetProperty(ref _ColLumLed11R, value); } }

        private string _HueLed12R;
        public string HueLed12R { get { return _HueLed12R; } set { SetProperty(ref _HueLed12R, value); } }

        private Brush _ColLed12R;
        public Brush ColLed12R { get { return _ColLed12R; } set { SetProperty(ref _ColLed12R, value); } }

        private string _LumLed12R;
        public string LumLed12R { get { return _LumLed12R; } set { SetProperty(ref _LumLed12R, value); } }

        private Brush _ColLumLed12R;
        public Brush ColLumLed12R { get { return _ColLumLed12R; } set { SetProperty(ref _ColLumLed12R, value); } }

        private string _HueLed13R;
        public string HueLed13R { get { return _HueLed13R; } set { SetProperty(ref _HueLed13R, value); } }

        private Brush _ColLed13R;
        public Brush ColLed13R { get { return _ColLed13R; } set { SetProperty(ref _ColLed13R, value); } }

        private string _LumLed13R;
        public string LumLed13R { get { return _LumLed13R; } set { SetProperty(ref _LumLed13R, value); } }

        private Brush _ColLumLed13R;
        public Brush ColLumLed13R { get { return _ColLumLed13R; } set { SetProperty(ref _ColLumLed13R, value); } }

        private string _HueLed14R;
        public string HueLed14R { get { return _HueLed14R; } set { SetProperty(ref _HueLed14R, value); } }

        private Brush _ColLed14R;
        public Brush ColLed14R { get { return _ColLed14R; } set { SetProperty(ref _ColLed14R, value); } }

        private string _LumLed14R;
        public string LumLed14R { get { return _LumLed14R; } set { SetProperty(ref _LumLed14R, value); } }

        private Brush _ColLumLed14R;
        public Brush ColLumLed14R { get { return _ColLumLed14R; } set { SetProperty(ref _ColLumLed14R, value); } }
        
        //緑色チェック
        private string _HueLed1G;
        public string HueLed1G { get { return _HueLed1G; } set { SetProperty(ref _HueLed1G, value); } }

        private Brush _ColLed1G;
        public Brush ColLed1G { get { return _ColLed1G; } set { SetProperty(ref _ColLed1G, value); } }

        private string _LumLed1G;
        public string LumLed1G { get { return _LumLed1G; } set { SetProperty(ref _LumLed1G, value); } }

        private Brush _ColLumLed1G;
        public Brush ColLumLed1G { get { return _ColLumLed1G; } set { SetProperty(ref _ColLumLed1G, value); } }

        private string _HueLed2G;
        public string HueLed2G { get { return _HueLed2G; } set { SetProperty(ref _HueLed2G, value); } }

        private Brush _ColLed2G;
        public Brush ColLed2G { get { return _ColLed2G; } set { SetProperty(ref _ColLed2G, value); } }

        private string _LumLed2G;
        public string LumLed2G { get { return _LumLed2G; } set { SetProperty(ref _LumLed2G, value); } }

        private Brush _ColLumLed2G;
        public Brush ColLumLed2G { get { return _ColLumLed2G; } set { SetProperty(ref _ColLumLed2G, value); } }

        private string _HueLed3G;
        public string HueLed3G { get { return _HueLed3G; } set { SetProperty(ref _HueLed3G, value); } }

        private Brush _ColLed3G;
        public Brush ColLed3G { get { return _ColLed3G; } set { SetProperty(ref _ColLed3G, value); } }

        private string _LumLed3G;
        public string LumLed3G { get { return _LumLed3G; } set { SetProperty(ref _LumLed3G, value); } }

        private Brush _ColLumLed3G;
        public Brush ColLumLed3G { get { return _ColLumLed3G; } set { SetProperty(ref _ColLumLed3G, value); } }

        private string _HueLed4G;
        public string HueLed4G { get { return _HueLed4G; } set { SetProperty(ref _HueLed4G, value); } }

        private Brush _ColLed4G;
        public Brush ColLed4G { get { return _ColLed4G; } set { SetProperty(ref _ColLed4G, value); } }

        private string _LumLed4G;
        public string LumLed4G { get { return _LumLed4G; } set { SetProperty(ref _LumLed4G, value); } }

        private Brush _ColLumLed4G;
        public Brush ColLumLed4G { get { return _ColLumLed4G; } set { SetProperty(ref _ColLumLed4G, value); } }

        private string _HueLed5G;
        public string HueLed5G { get { return _HueLed5G; } set { SetProperty(ref _HueLed5G, value); } }

        private Brush _ColLed5G;
        public Brush ColLed5G { get { return _ColLed5G; } set { SetProperty(ref _ColLed5G, value); } }

        private string _LumLed5G;
        public string LumLed5G { get { return _LumLed5G; } set { SetProperty(ref _LumLed5G, value); } }

        private Brush _ColLumLed5G;
        public Brush ColLumLed5G { get { return _ColLumLed5G; } set { SetProperty(ref _ColLumLed5G, value); } }

        private string _HueLed6G;
        public string HueLed6G { get { return _HueLed6G; } set { SetProperty(ref _HueLed6G, value); } }

        private Brush _ColLed6G;
        public Brush ColLed6G { get { return _ColLed6G; } set { SetProperty(ref _ColLed6G, value); } }

        private string _LumLed6G;
        public string LumLed6G { get { return _LumLed6G; } set { SetProperty(ref _LumLed6G, value); } }

        private Brush _ColLumLed6G;
        public Brush ColLumLed6G { get { return _ColLumLed6G; } set { SetProperty(ref _ColLumLed6G, value); } }

        private string _HueLed7G;
        public string HueLed7G { get { return _HueLed7G; } set { SetProperty(ref _HueLed7G, value); } }

        private Brush _ColLed7G;
        public Brush ColLed7G { get { return _ColLed7G; } set { SetProperty(ref _ColLed7G, value); } }

        private string _LumLed7G;
        public string LumLed7G { get { return _LumLed7G; } set { SetProperty(ref _LumLed7G, value); } }

        private Brush _ColLumLed7G;
        public Brush ColLumLed7G { get { return _ColLumLed7G; } set { SetProperty(ref _ColLumLed7G, value); } }

        private string _HueLed8G;
        public string HueLed8G { get { return _HueLed8G; } set { SetProperty(ref _HueLed8G, value); } }

        private Brush _ColLed8G;
        public Brush ColLed8G { get { return _ColLed8G; } set { SetProperty(ref _ColLed8G, value); } }

        private string _LumLed8G;
        public string LumLed8G { get { return _LumLed8G; } set { SetProperty(ref _LumLed8G, value); } }

        private Brush _ColLumLed8G;
        public Brush ColLumLed8G { get { return _ColLumLed8G; } set { SetProperty(ref _ColLumLed8G, value); } }

        private string _HueLed9G;
        public string HueLed9G { get { return _HueLed9G; } set { SetProperty(ref _HueLed9G, value); } }

        private Brush _ColLed9G;
        public Brush ColLed9G { get { return _ColLed9G; } set { SetProperty(ref _ColLed9G, value); } }

        private string _LumLed9G;
        public string LumLed9G { get { return _LumLed9G; } set { SetProperty(ref _LumLed9G, value); } }

        private Brush _ColLumLed9G;
        public Brush ColLumLed9G { get { return _ColLumLed9G; } set { SetProperty(ref _ColLumLed9G, value); } }

        private string _HueLed10G;
        public string HueLed10G { get { return _HueLed10G; } set { SetProperty(ref _HueLed10G, value); } }

        private Brush _ColLed10G;
        public Brush ColLed10G { get { return _ColLed10G; } set { SetProperty(ref _ColLed10G, value); } }

        private string _LumLed10G;
        public string LumLed10G { get { return _LumLed10G; } set { SetProperty(ref _LumLed10G, value); } }

        private Brush _ColLumLed10G;
        public Brush ColLumLed10G { get { return _ColLumLed10G; } set { SetProperty(ref _ColLumLed10G, value); } }

        private string _HueLed11G;
        public string HueLed11G { get { return _HueLed11G; } set { SetProperty(ref _HueLed11G, value); } }

        private Brush _ColLed11G;
        public Brush ColLed11G { get { return _ColLed11G; } set { SetProperty(ref _ColLed11G, value); } }

        private string _LumLed11G;
        public string LumLed11G { get { return _LumLed11G; } set { SetProperty(ref _LumLed11G, value); } }

        private Brush _ColLumLed11G;
        public Brush ColLumLed11G { get { return _ColLumLed11G; } set { SetProperty(ref _ColLumLed11G, value); } }

        private string _HueLed12G;
        public string HueLed12G { get { return _HueLed12G; } set { SetProperty(ref _HueLed12G, value); } }

        private Brush _ColLed12G;
        public Brush ColLed12G { get { return _ColLed12G; } set { SetProperty(ref _ColLed12G, value); } }

        private string _LumLed12G;
        public string LumLed12G { get { return _LumLed12G; } set { SetProperty(ref _LumLed12G, value); } }

        private Brush _ColLumLed12G;
        public Brush ColLumLed12G { get { return _ColLumLed12G; } set { SetProperty(ref _ColLumLed12G, value); } }

        private string _HueLed13G;
        public string HueLed13G { get { return _HueLed13G; } set { SetProperty(ref _HueLed13G, value); } }

        private Brush _ColLed13G;
        public Brush ColLed13G { get { return _ColLed13G; } set { SetProperty(ref _ColLed13G, value); } }

        private string _LumLed13G;
        public string LumLed13G { get { return _LumLed13G; } set { SetProperty(ref _LumLed13G, value); } }

        private Brush _ColLumLed13G;
        public Brush ColLumLed13G { get { return _ColLumLed13G; } set { SetProperty(ref _ColLumLed13G, value); } }

        private string _HueLed14G;
        public string HueLed14G { get { return _HueLed14G; } set { SetProperty(ref _HueLed14G, value); } }

        private Brush _ColLed14G;
        public Brush ColLed14G { get { return _ColLed14G; } set { SetProperty(ref _ColLed14G, value); } }

        private string _LumLed14G;
        public string LumLed14G { get { return _LumLed14G; } set { SetProperty(ref _LumLed14G, value); } }

        private Brush _ColLumLed14G;
        public Brush ColLumLed14G { get { return _ColLumLed14G; } set { SetProperty(ref _ColLumLed14G, value); } }


        //青色チェック
        private string _HueLed1B;
        public string HueLed1B { get { return _HueLed1B; } set { SetProperty(ref _HueLed1B, value); } }

        private Brush _ColLed1B;
        public Brush ColLed1B { get { return _ColLed1B; } set { SetProperty(ref _ColLed1B, value); } }

        private string _LumLed1B;
        public string LumLed1B { get { return _LumLed1B; } set { SetProperty(ref _LumLed1B, value); } }

        private Brush _ColLumLed1B;
        public Brush ColLumLed1B { get { return _ColLumLed1B; } set { SetProperty(ref _ColLumLed1B, value); } }

        private string _HueLed2B;
        public string HueLed2B { get { return _HueLed2B; } set { SetProperty(ref _HueLed2B, value); } }

        private Brush _ColLed2B;
        public Brush ColLed2B { get { return _ColLed2B; } set { SetProperty(ref _ColLed2B, value); } }

        private string _LumLed2B;
        public string LumLed2B { get { return _LumLed2B; } set { SetProperty(ref _LumLed2B, value); } }

        private Brush _ColLumLed2B;
        public Brush ColLumLed2B { get { return _ColLumLed2B; } set { SetProperty(ref _ColLumLed2B, value); } }

        private string _HueLed3B;
        public string HueLed3B { get { return _HueLed3B; } set { SetProperty(ref _HueLed3B, value); } }

        private Brush _ColLed3B;
        public Brush ColLed3B { get { return _ColLed3B; } set { SetProperty(ref _ColLed3B, value); } }

        private string _LumLed3B;
        public string LumLed3B { get { return _LumLed3B; } set { SetProperty(ref _LumLed3B, value); } }

        private Brush _ColLumLed3B;
        public Brush ColLumLed3B { get { return _ColLumLed3B; } set { SetProperty(ref _ColLumLed3B, value); } }

        private string _HueLed4B;
        public string HueLed4B { get { return _HueLed4B; } set { SetProperty(ref _HueLed4B, value); } }

        private Brush _ColLed4B;
        public Brush ColLed4B { get { return _ColLed4B; } set { SetProperty(ref _ColLed4B, value); } }

        private string _LumLed4B;
        public string LumLed4B { get { return _LumLed4B; } set { SetProperty(ref _LumLed4B, value); } }

        private Brush _ColLumLed4B;
        public Brush ColLumLed4B { get { return _ColLumLed4B; } set { SetProperty(ref _ColLumLed4B, value); } }

        private string _HueLed5B;
        public string HueLed5B { get { return _HueLed5B; } set { SetProperty(ref _HueLed5B, value); } }

        private Brush _ColLed5B;
        public Brush ColLed5B { get { return _ColLed5B; } set { SetProperty(ref _ColLed5B, value); } }

        private string _LumLed5B;
        public string LumLed5B { get { return _LumLed5B; } set { SetProperty(ref _LumLed5B, value); } }

        private Brush _ColLumLed5B;
        public Brush ColLumLed5B { get { return _ColLumLed5B; } set { SetProperty(ref _ColLumLed5B, value); } }

        private string _HueLed6B;
        public string HueLed6B { get { return _HueLed6B; } set { SetProperty(ref _HueLed6B, value); } }

        private Brush _ColLed6B;
        public Brush ColLed6B { get { return _ColLed6B; } set { SetProperty(ref _ColLed6B, value); } }

        private string _LumLed6B;
        public string LumLed6B { get { return _LumLed6B; } set { SetProperty(ref _LumLed6B, value); } }

        private Brush _ColLumLed6B;
        public Brush ColLumLed6B { get { return _ColLumLed6B; } set { SetProperty(ref _ColLumLed6B, value); } }

        private string _HueLed7B;
        public string HueLed7B { get { return _HueLed7B; } set { SetProperty(ref _HueLed7B, value); } }

        private Brush _ColLed7B;
        public Brush ColLed7B { get { return _ColLed7B; } set { SetProperty(ref _ColLed7B, value); } }

        private string _LumLed7B;
        public string LumLed7B { get { return _LumLed7B; } set { SetProperty(ref _LumLed7B, value); } }

        private Brush _ColLumLed7B;
        public Brush ColLumLed7B { get { return _ColLumLed7B; } set { SetProperty(ref _ColLumLed7B, value); } }

        private string _HueLed8B;
        public string HueLed8B { get { return _HueLed8B; } set { SetProperty(ref _HueLed8B, value); } }

        private Brush _ColLed8B;
        public Brush ColLed8B { get { return _ColLed8B; } set { SetProperty(ref _ColLed8B, value); } }

        private string _LumLed8B;
        public string LumLed8B { get { return _LumLed8B; } set { SetProperty(ref _LumLed8B, value); } }

        private Brush _ColLumLed8B;
        public Brush ColLumLed8B { get { return _ColLumLed8B; } set { SetProperty(ref _ColLumLed8B, value); } }

        private string _HueLed9B;
        public string HueLed9B { get { return _HueLed9B; } set { SetProperty(ref _HueLed9B, value); } }

        private Brush _ColLed9B;
        public Brush ColLed9B { get { return _ColLed9B; } set { SetProperty(ref _ColLed9B, value); } }

        private string _LumLed9B;
        public string LumLed9B { get { return _LumLed9B; } set { SetProperty(ref _LumLed9B, value); } }

        private Brush _ColLumLed9B;
        public Brush ColLumLed9B { get { return _ColLumLed9B; } set { SetProperty(ref _ColLumLed9B, value); } }

        private string _HueLed10B;
        public string HueLed10B { get { return _HueLed10B; } set { SetProperty(ref _HueLed10B, value); } }

        private Brush _ColLed10B;
        public Brush ColLed10B { get { return _ColLed10B; } set { SetProperty(ref _ColLed10B, value); } }

        private string _LumLed10B;
        public string LumLed10B { get { return _LumLed10B; } set { SetProperty(ref _LumLed10B, value); } }

        private Brush _ColLumLed10B;
        public Brush ColLumLed10B { get { return _ColLumLed10B; } set { SetProperty(ref _ColLumLed10B, value); } }

        private string _HueLed11B;
        public string HueLed11B { get { return _HueLed11B; } set { SetProperty(ref _HueLed11B, value); } }

        private Brush _ColLed11B;
        public Brush ColLed11B { get { return _ColLed11B; } set { SetProperty(ref _ColLed11B, value); } }

        private string _LumLed11B;
        public string LumLed11B { get { return _LumLed11B; } set { SetProperty(ref _LumLed11B, value); } }

        private Brush _ColLumLed11B;
        public Brush ColLumLed11B { get { return _ColLumLed11B; } set { SetProperty(ref _ColLumLed11B, value); } }

        private string _HueLed12B;
        public string HueLed12B { get { return _HueLed12B; } set { SetProperty(ref _HueLed12B, value); } }

        private Brush _ColLed12B;
        public Brush ColLed12B { get { return _ColLed12B; } set { SetProperty(ref _ColLed12B, value); } }

        private string _LumLed12B;
        public string LumLed12B { get { return _LumLed12B; } set { SetProperty(ref _LumLed12B, value); } }

        private Brush _ColLumLed12B;
        public Brush ColLumLed12B { get { return _ColLumLed12B; } set { SetProperty(ref _ColLumLed12B, value); } }

        private string _HueLed13B;
        public string HueLed13B { get { return _HueLed13B; } set { SetProperty(ref _HueLed13B, value); } }

        private Brush _ColLed13B;
        public Brush ColLed13B { get { return _ColLed13B; } set { SetProperty(ref _ColLed13B, value); } }

        private string _LumLed13B;
        public string LumLed13B { get { return _LumLed13B; } set { SetProperty(ref _LumLed13B, value); } }

        private Brush _ColLumLed13B;
        public Brush ColLumLed13B { get { return _ColLumLed13B; } set { SetProperty(ref _ColLumLed13B, value); } }

        private string _HueLed14B;
        public string HueLed14B { get { return _HueLed14B; } set { SetProperty(ref _HueLed14B, value); } }

        private Brush _ColLed14B;
        public Brush ColLed14B { get { return _ColLed14B; } set { SetProperty(ref _ColLed14B, value); } }

        private string _LumLed14B;
        public string LumLed14B { get { return _LumLed14B; } set { SetProperty(ref _LumLed14B, value); } }

        private Brush _ColLumLed14B;
        public Brush ColLumLed14B { get { return _ColLumLed14B; } set { SetProperty(ref _ColLumLed14B, value); } }








































        private Brush _ColLumLed1;
        public Brush ColLumLed1 { get { return _ColLumLed1; } set { SetProperty(ref _ColLumLed1, value); } }

        private Brush _ColLumLed2;
        public Brush ColLumLed2 { get { return _ColLumLed2; } set { SetProperty(ref _ColLumLed2, value); } }

        private Brush _ColLumLed3;
        public Brush ColLumLed3 { get { return _ColLumLed3; } set { SetProperty(ref _ColLumLed3, value); } }

        private Brush _ColLumLed4;
        public Brush ColLumLed4 { get { return _ColLumLed4; } set { SetProperty(ref _ColLumLed4, value); } }

        private Brush _ColLumLed5;
        public Brush ColLumLed5 { get { return _ColLumLed5; } set { SetProperty(ref _ColLumLed5, value); } }

        private Brush _ColLumLed6;
        public Brush ColLumLed6 { get { return _ColLumLed6; } set { SetProperty(ref _ColLumLed6, value); } }

        private Brush _ColLumLed7;
        public Brush ColLumLed7 { get { return _ColLumLed7; } set { SetProperty(ref _ColLumLed7, value); } }


        private Brush _ColSw1_1;
        public Brush ColSw1_1 { get { return _ColSw1_1; } set { SetProperty(ref _ColSw1_1, value); } }

        private Brush _ColSw1_2;
        public Brush ColSw1_2 { get { return _ColSw1_2; } set { SetProperty(ref _ColSw1_2, value); } }

        private Brush _ColSw1_3;
        public Brush ColSw1_3 { get { return _ColSw1_3; } set { SetProperty(ref _ColSw1_3, value); } }

        private Brush _ColSw1_4;
        public Brush ColSw1_4 { get { return _ColSw1_4; } set { SetProperty(ref _ColSw1_4, value); } }

        private Brush _ColSw1_1Exp;
        public Brush ColSw1_1Exp { get { return _ColSw1_1Exp; } set { SetProperty(ref _ColSw1_1Exp, value); } }

        private Brush _ColSw1_2Exp;
        public Brush ColSw1_2Exp { get { return _ColSw1_2Exp; } set { SetProperty(ref _ColSw1_2Exp, value); } }

        private Brush _ColSw1_3Exp;
        public Brush ColSw1_3Exp { get { return _ColSw1_3Exp; } set { SetProperty(ref _ColSw1_3Exp, value); } }

        private Brush _ColSw1_4Exp;
        public Brush ColSw1_4Exp { get { return _ColSw1_4Exp; } set { SetProperty(ref _ColSw1_4Exp, value); } }

    }

}








