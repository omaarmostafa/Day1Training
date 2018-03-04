using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Day1Training.Triggers
{ 
    public class BackgroundEventColorTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            sender.BackgroundColor = Color.Yellow;
        }
    }
}
