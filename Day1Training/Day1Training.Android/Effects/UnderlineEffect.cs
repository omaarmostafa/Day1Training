using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Day1Training.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(UnderlineEffect), "UnderlineEffect")]
namespace Day1Training.Droid
{
    public class UnderlineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            SetUnderline(true);
        }

        protected override void OnDetached()
        {
            SetUnderline(false);
        }


        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if(args.PropertyName==Label.TextProperty.PropertyName|| args.PropertyName==Label.FormattedTextProperty.PropertyName)
            {
                SetUnderline(true);
            }
        }

        private void SetUnderline(bool underline)
        {
            try
            {
                var textview = (TextView)Control;
                if (underline)
                {
                    textview.PaintFlags |= Android.Graphics.PaintFlags.UnderlineText;
                }
                else
                {
                    textview.PaintFlags &= ~Android.Graphics.PaintFlags.UnderlineText;
                }

            }catch(Exception ex)
            {

            }
        }
    }
}