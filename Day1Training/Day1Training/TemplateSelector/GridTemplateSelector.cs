using Day1Training.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Day1Training.TemplateSelector
{
    public class GridTemplateSelector : DataTemplateSelector
    {
       public DataTemplate GrayDataTemplate { get; set; }
       public DataTemplate GreenDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Student student = (Student)item;
            if(student.IsGreen)
            {
                return GreenDataTemplate;
            }
            else
            {
                return GrayDataTemplate;
            }
        }
    }
}
