﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ImageCircle.Forms.Plugin.UWP;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Boora_TCC_2019.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            LoadApplication(new Boora_TCC_2019.App());
            ImageCircleRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            
        }
    }
}
