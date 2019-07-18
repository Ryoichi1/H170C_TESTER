﻿using System;
using System.Windows;
using System.Windows.Navigation;

namespace H170C_Tester
{
    /// <summary>
    /// Config.xaml の相互作用ロジック
    /// </summary>
    public partial class Conf
    {
        private NavigationService naviTheme;
        private NavigationService naviMente;
        private NavigationService naviCamera1;
        private NavigationService naviCamera2;
        Uri uriThemePage = new Uri("Page/Config/Theme.xaml", UriKind.Relative);
        Uri uriMentePage = new Uri("Page/Config/Mainte.xaml", UriKind.Relative);
        Uri uriCamera1Page = new Uri("Page/Config/Camera1Conf.xaml", UriKind.Relative);
        Uri uriCamera2Page = new Uri("Page/Config/Camera2Conf.xaml", UriKind.Relative);

        public Conf()
        {
            InitializeComponent();
            naviTheme = FrameTheme.NavigationService;
            naviMente = FrameMente.NavigationService;

            naviCamera1 = FrameCamera1.NavigationService;
            naviCamera2 = FrameCamera2.NavigationService;

            FrameTheme.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameMente.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            FrameCamera1.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameCamera2.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            TabMenu.SelectedIndex = 0;

            // オブジェクト作成に必要なコードをこの下に挿入します。
        }
        private void TabMente_Loaded(object sender, RoutedEventArgs e)
        {
            naviMente.Navigate(uriMentePage);
        }



        private void TabTheme_Loaded(object sender, RoutedEventArgs e)
        {
            naviTheme.Navigate(uriThemePage);
        }

        private void TabCamera1_Loaded(object sender, RoutedEventArgs e)
        {
            naviCamera1.Navigate(uriCamera1Page);
        }

        private void TabCamera2_Loaded(object sender, RoutedEventArgs e)
        {
            naviCamera2.Navigate(uriCamera2Page);
        }


    }
}
