
using System;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using System.ComponentModel;
using Xamarin.Forms;
using Day1Training.UWP;

[assembly: ExportRenderer(typeof(Day1Training.GridView), typeof(CustomListViewRenderer))]
namespace Day1Training.UWP
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            var list = e.NewElement;
          
            //if (e.OldElement != null)
            //{
            //    var baseListt = Control as ListViewBase;
            //    // Unsubscribe
            //    baseListt.SelectionChanged -= OnSelectedItemChanged;
            //}

            if (Control != null)
            {

                var baseList = Control as ListViewBase;                 //Retrieve the min item width property.
                var itemWidth = (double)list.GetValue(Day1Training.GridView.MinItemWidthProperty);

                //If the property is set.
                if (itemWidth > 0)
                {
                    //Build the new items panel template.
                    string template =
                    "<ItemsPanelTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                        "<ItemsWrapGrid VerticalAlignment = \"Top\" ItemWidth = \"" + itemWidth + "\" Orientation = \"Horizontal\"/>" +
                    "</ItemsPanelTemplate> ";
                  //  baseList.CanReorderItems = true;
                
                   // baseList.ItemTemplateSelector = new  Shopbox.Forms.TemplateSelectors.CounterTempleteSelector();
                    //var t=baseList.ItemTemplate;
                    baseList.ItemsPanel = (ItemsPanelTemplate)XamlReader.Load(template);
                   
                }
            }
        }

        //private void OnSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ((NativeListView)Element).NotifyItemSelected(listView.SelectedItem);
        //}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //If the property is width.
            if (e.PropertyName == "Width")
            {
                //Unbox the xamarin host control.
                var list = sender as Xamarin.Forms.ListView;
             
                //Get the Minimum item size.
                var itemMinSize = (double)list.GetValue(Day1Training.GridView.MinItemWidthProperty);

                //If the property is set.
                if (itemMinSize > 0)
                {
                    //Unbox the native control.
                    var itemsControl = Control as ListViewBase;

                    //itemsControl.CanReorderItems = true;
                    //Retrieve items panel.
                    ItemsWrapGrid itemsPanel = itemsControl.ItemsPanelRoot as ItemsWrapGrid;

                    //If the items panel is a wrap grid.
                    if (itemsPanel != null)
                    {
                        //Get total size (leave room for scrolling.)
                        var total = list.Width - 10;

                        //How many items can be fit whole.
                        var canBeFit = Math.Floor(total / itemMinSize);

                        //Set the items Panel item width appropriately.
                        //Note you will need your container to stretch
                        //along with the items panel or it will look 
                        //strange. 
                        itemsPanel.ItemWidth = total / canBeFit;
                    }
                }
            }
        }
    }


}