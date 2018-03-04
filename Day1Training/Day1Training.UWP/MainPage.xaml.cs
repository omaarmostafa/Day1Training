using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Day1Training.Services;
using Day1Training.UWP.PlatformServices;
using Syncfusion.ListView.XForms.UWP;

namespace Day1Training.UWP
{
    public sealed partial class MainPage
    {
       public static TextToSpeechImplementation textToSpeechImplementation = new TextToSpeechImplementation();
        public MainPage()
        {
            this.InitializeComponent();
            SfListViewRenderer.Init();
            LoadApplication(new Day1Training.App(new UwpInitializer()));
        }
        public class UwpInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {
                container.RegisterInstance<ITextToSpeech>(textToSpeechImplementation, new ExternallyControlledLifetimeManager());
            }
        }
    }

    
}
