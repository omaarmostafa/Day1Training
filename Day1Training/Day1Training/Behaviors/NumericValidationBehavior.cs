using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Day1Training.Behaviors
{
  public class NumericValidationBehavior :Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry Entry)
        {
            Entry.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(Entry);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool IsValid = Double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry Entry)
        {
            Entry.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(Entry);
        }
    }
}
