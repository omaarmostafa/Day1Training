using Day1Training.UWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportEffect(typeof(UnderlineEffect), "UnderlineEffect")]
namespace Day1Training.UWP
{
    public class UnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Setunderline(true);
        }

        protected override void OnDetached()
        {
            Setunderline(false);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if(args.PropertyName==Label.TextProperty.PropertyName|| args.PropertyName==Label.FormattedTextProperty.PropertyName)
            {
                Setunderline(true);
            }
        }

        private void Setunderline(bool underline)
        {
            var textblock = (TextBlock)Control;
            Underline ul = new Underline();
            if (underline)
            {
               
                textblock.Inlines.Add(ul);
            }
            else
            {
                textblock.Inlines.Remove(ul);
            }
        }
    }
}
