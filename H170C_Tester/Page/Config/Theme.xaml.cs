﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H170C_Tester
{
    /// <summary>
    /// Theme.xaml の相互作用ロジック
    /// </summary>
    public partial class Theme
    {
        Storyboard storyboard = new Storyboard();
        DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();

        public Theme()
        {
            InitializeComponent();
            this.DataContext = State.VmMainWindow;
            SliderOpacity.Value = State.Setting.OpacityTheme;

        }

        private void Pic1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/chri1.jpg";
            General.Show();
        }

        private void Pic2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/chri2.jpg";
            General.Show();
        }

        private void Pic3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/taki.jpg";
            General.Show();
        }

        private void Pic4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            State.VmMainWindow.Theme = "Resources/Pic/baby7.jpg";
            General.Show();
        }

        private void Pic5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/baby5.jpg";
            General.Show();
        }

        private void Pic6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/baby3.jpg";
            General.Show();
        }

        private void Pic7_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/Pic/baby1.jpg";
            General.Show();
        }

        private void SliderOpacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            State.Setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
        }

        private void SliderBlurEffectRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //State.Setting.OpacityTheme = State.VmMainWindow.ThemeOpacity;
        }
    }
}