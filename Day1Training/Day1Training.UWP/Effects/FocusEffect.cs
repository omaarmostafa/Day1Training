using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Day1Training.UWP;
using Xamarin.Forms.Platform.UWP;
[assembly: ResolutionGroupName("Asgatech")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace Day1Training.UWP
{
    public class FocusEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                (Control as Windows.UI.Xaml.Controls.Control).Background = new SolidColorBrush(Colors.Red);
                (Control as Windows.UI.Xaml.Controls.Control).Foreground = new SolidColorBrush(Colors.Green);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if(args.PropertyName== "IsFocused")
            {
                (Control as Windows.UI.Xaml.Controls.Control).Background= new SolidColorBrush(Colors.Brown);
            }
        }

        protected override void OnDetached()
        {
         
        }
    }
}
