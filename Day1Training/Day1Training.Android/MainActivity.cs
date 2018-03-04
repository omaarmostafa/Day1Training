using Android.App;
using Android.Content.PM;
using Android.OS;
using Day1Training.Droid.PlatformServices;
using Day1Training.Services;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Day1Training.Droid
{
    [Activity(Label = "Day1Training", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static TextToSpeechImplementation textToSpeechImplementation = new TextToSpeechImplementation();
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {
                container.RegisterInstance<ITextToSpeech>(textToSpeechImplementation, new ExternallyControlledLifetimeManager());
            }
        }
    }

   
}

