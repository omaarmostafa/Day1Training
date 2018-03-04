//// ***********************************************************************
//// Assembly         : XLabs.Forms.iOS
//// Author           : XLabs Team
//// Created          : 01-03-2016
//// 
//// Last Modified By : XLabs Team
//// Last Modified On : 01-04-2016
//// ***********************************************************************
//// <copyright file="GridViewRenderer.cs" company="XLabs Team">
////     Copyright (c) XLabs Team. All rights reserved.
//// </copyright>
//// <summary>
////       This project is licensed under the Apache 2.0 license
////       https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/LICENSE
////       
////       XLabs is a open source project that aims to provide a powerfull and cross 
////       platform set of controls tailored to work with Xamarin Forms.
//// </summary>
//// ***********************************************************************
//// 

//using System;
//using System.Collections;
//using System.Collections.Specialized;
//using System.Linq;
//using Foundation;
//using UIKit;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;
//using CoreGraphics;
//using Day1Training;

//[assembly: ExportRenderer(typeof(GridView), typeof(GridViewRenderer))]
//namespace Shopbox.Xamarin.IOS
//{
//    /// <summary>
//    /// Class GridViewRenderer.
//    /// </summary>
//    public class GridViewRenderer : ViewRenderer<GridView, GridCollectionView>
//    {
//        /// <summary>
//        /// The data source
//        /// </summary>
//        private GridDataSource _dataSource;

//        private NSString cellId;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="GridViewRenderer"/> class.
//        /// </summary>
//        public GridViewRenderer()
//        {
//        }

//        /// <summary>
//        /// Rowses the in section.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="section">The section.</param>
//        /// <returns>System.Int32.</returns>
//        public int RowsInSection(UICollectionView collectionView, nint section)
//        {
//            if ((ICollection)this.Element.ItemsSource != null)
//            {
//                return ((ICollection)this.Element.ItemsSource).Count;

//            }
//            return 0;
//        }

//        /// <summary>
//        /// Items the selected.
//        /// </summary>
//        /// <param name="tableView">The table view.</param>
//        /// <param name="indexPath">The index path.</param>
//        public void ItemSelected(UICollectionView tableView, NSIndexPath indexPath)
//        {
//            try
//            {
//                var item = this.Element.ItemsSource.Cast<object>().ElementAt(indexPath.Row);
//                this.Element.InvokeItemSelectedEvent(this, item);
//            }
//            catch (Exception ex)
//            {

//            }

//        }


//        /*

//*/
//        /// <summary>
//        /// Gets the cell.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="indexPath">The index path.</param>
//        /// <returns>UICollectionViewCell.</returns>
//        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            cellId = cellId ?? new NSString(GridViewCell.Key);
//            var item = this.Element.ItemsSource?.Cast<object>().ElementAt(indexPath.Row);
//            var collectionCell = collectionView.DequeueReusableCell(cellId, indexPath) as GridViewCell;

//            DataTemplate template;
//            if (this.Element.ItemTemplate is Shopbox.Forms.TemplateSelectors.SelectTableTemplate)
//            {
//                SelectTableTemplate selectTable = new SelectTableTemplate();
//                template = selectTable.selectTemplateForiOS(item);

//            }
//            else
//            {
//                template = this.Element.ItemTemplate;
//            }

//            collectionCell.RecycleCell(item, template, Element);
//            return collectionCell;

//            //var item = this.Element.ItemsSource.Cast<object>().ElementAt(indexPath.Row);
//            //         DataTemplate template;
//            //         if (this.Element.ItemTemplate is Shopbox.Forms.TemplateSelectors.SelectTableTemplate)
//            //         {
//            //             SelectTableTemplate selectTable = new SelectTableTemplate();
//            //             template = selectTable.selectTemplateForiOS(item);

//            //         }
//            //         else if (this.Element.ItemTemplate is Shopbox.Forms.TemplateSelectors.SelectCounterItemTemplate)
//            //         {
//            //             SelectCounterItemTemplate selectitem = new SelectCounterItemTemplate();
//            //             template = selectitem.selectTemplateForiOS(item);
//            //         }
//            //         else
//            //         {
//            //             template = this.Element.ItemTemplate;
//            //         }
//            //         var viewCellBinded = (template.CreateContent() as FastGridCell);
//            //         if (viewCellBinded == null) return null;

//            //         viewCellBinded.BindingContext = item;
//            //         viewCellBinded.Parent = Element;

//            //         return this.GetCell(collectionView, viewCellBinded, indexPath);

//        }

//        /// <summary>
//        /// Gets the cell.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="item">The item.</param>
//        /// <param name="indexPath">The index path.</param>
//        /// <returns>UICollectionViewCell.</returns>
//        /// 
//        protected virtual UICollectionViewCell GetCell(UICollectionView collectionView, FastGridCell item, NSIndexPath indexPath)
//        {
//            var collectionCell = collectionView.DequeueReusableCell(new NSString(GridViewCell.Key), indexPath) as GridViewCell;

//            if (collectionCell == null) return null;

//            collectionCell.ViewCell = item;

//            return collectionCell;
//        }

//        /// <summary>
//        /// Called when [element changed].
//        /// </summary>
//        /// <param name="e">The e.</param>
//        protected override void OnElementChanged(ElementChangedEventArgs<GridView> e)
//        {
//            base.OnElementChanged(e);
//            if (e.OldElement != null)
//            {
//                Unbind(e.OldElement);
//            }
//            if (e.NewElement != null)
//            {
//                if (Control == null)
//                {
//                    var collectionView = new GridCollectionView()
//                    {
//                        AllowsMultipleSelection = false,
//                        SelectionEnable = e.NewElement.SelectionEnabled,
//                        ContentInset = new UIEdgeInsets((float)this.Element.Padding.Top, (float)this.Element.Padding.Left, (float)this.Element.Padding.Bottom, (float)this.Element.Padding.Right),
//                        BackgroundColor = this.Element.BackgroundColor.ToUIColor(),
//                        ItemSize = new CoreGraphics.CGSize((float)this.Element.ItemWidth, (float)this.Element.ItemHeight),
//                        RowSpacing = this.Element.RowSpacing,
//                        ColumnSpacing = this.Element.ColumnSpacing
                                           
//                    };
//					if (!this.Element.IsHorizontal)
//                        addMovementGestureForCollectionView(collectionView);

//                    Bind(e.NewElement);

//                    collectionView.Source = this.DataSource;
//                    //collectionView.Delegate = this.GridViewDelegate;
//                    collectionView.ScrollEnabled = this.Element.ScrollEnabled;

//                    if (this.Element.IsHorizontal)
//                    {
//                        collectionView.PagingEnabled = true;

//                        UICollectionViewFlowLayout layout = new UICollectionViewFlowLayout();
//                        layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
//                        collectionView.CollectionViewLayout = layout;
//                        layout.ItemSize = new CGSize((float)this.Element.ItemWidth, (float)this.Element.ItemHeight);
//                        collectionView.ShowsHorizontalScrollIndicator = true;
//                        collectionView.ShowsVerticalScrollIndicator = true;
//                        collectionView.IndicatorStyle = UIScrollViewIndicatorStyle.White;
//                        collectionView.FlashScrollIndicators();
//                    }
//                    SetNativeControl(collectionView);
//                }
//            }


//        }

//        void addMovementGestureForCollectionView(GridCollectionView collectionView)
//        {

//            var longPressGesture = new UILongPressGestureRecognizer(gesture =>
//            {

//            // Take action based on state
//            switch (gesture.State)
//                {
//                    case UIGestureRecognizerState.Began:
//                        var selectedIndexPath = collectionView.IndexPathForItemAtPoint(gesture.LocationInView(collectionView));
//                        if (selectedIndexPath != null)
//                            collectionView.BeginInteractiveMovementForItem(selectedIndexPath);
//                        break;
//                    case UIGestureRecognizerState.Changed:
//                        collectionView.UpdateInteractiveMovement(gesture.LocationInView(collectionView));
//                        break;
//                    case UIGestureRecognizerState.Ended:
//                        collectionView.EndInteractiveMovement();
//                        break;
//                    default:
//                        collectionView.CancelInteractiveMovement();
//                        break;
//                }
//            });

//            // Add the custom recognizer to the collection view
//            collectionView.AddGestureRecognizer(longPressGesture);

//        }

//        /// <summary>
//        /// Unbinds the specified old element.
//        /// </summary>
//        /// <param name="oldElement">The old element.</param>
//        private void Unbind(GridView oldElement)
//        {
//            if (oldElement == null) return;

//            oldElement.PropertyChanging -= this.ElementPropertyChanging;
//            oldElement.PropertyChanged -= this.ElementPropertyChanged;

//            var itemsSource = oldElement.ItemsSource as INotifyCollectionChanged;
//            if (itemsSource != null)
//            {
//                itemsSource.CollectionChanged -= this.DataCollectionChanged;
//            }
//        }

//        /// <summary>
//        /// Binds the specified new element.
//        /// </summary>
//        /// <param name="newElement">The new element.</param>
//        private void Bind(GridView newElement)
//        {
//            if (newElement == null) return;

//            newElement.PropertyChanging += this.ElementPropertyChanging;
//            newElement.PropertyChanged += this.ElementPropertyChanged;

//            var source = newElement.ItemsSource as INotifyCollectionChanged;
//            if (source != null)
//            {
//                source.CollectionChanged += this.DataCollectionChanged;
//            }
//        }

//        /// <summary>
//        /// Elements the property changed.
//        /// </summary>
//        /// <param name="sender">The sender.</param>
//        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
//        private void ElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//        {
//            if (e.PropertyName == GridView.ItemsSourceProperty.PropertyName)
//            {
//                var newItemsSource = this.Element.ItemsSource as INotifyCollectionChanged;
//                if (newItemsSource != null)
//                {
//                    newItemsSource.CollectionChanged += DataCollectionChanged;
//                    this.Control.ReloadData();
//                }
//            }
//            else if (e.PropertyName == "ItemWidth" || e.PropertyName == "ItemHeight")
//            {
//                this.Control.ItemSize = new CoreGraphics.CGSize((float)this.Element.ItemWidth, (float)this.Element.ItemHeight);
//            }
//        }

//        /// <summary>
//        /// Elements the property changing.
//        /// </summary>
//        /// <param name="sender">The sender.</param>
//        /// <param name="e">The <see cref="PropertyChangingEventArgs"/> instance containing the event data.</param>
//        private void ElementPropertyChanging(object sender, PropertyChangingEventArgs e)
//        {
//            if (e.PropertyName == "ItemsSource")
//            {
//                var oldItemsSource = this.Element.ItemsSource as INotifyCollectionChanged;
//                if (oldItemsSource != null)
//                {
//                    oldItemsSource.CollectionChanged -= DataCollectionChanged;
//                }
//            }
//        }

//        /// <summary>
//        /// Datas the collection changed.
//        /// </summary>
//        /// <param name="sender">The sender.</param>
//        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
//        private void DataCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
//        {
//            InvokeOnMainThread(() =>
//            {
//                try
//                {
//                    if (this.Control == null)
//                        return;

//                    this.Control.ReloadData();

//                // TODO: try to handle add or remove operations gracefully, just reload the whole collection for other changes
//                // InsertItems, DeleteItems or ReloadItems can cause
//                // *** Assertion failure in -[XLabs_Forms_Controls_GridCollectionView _endItemAnimationsWithInvalidationContext:tentativelyForReordering:],
//                // BuildRoot/Library/Caches/com.apple.xbs/Sources/UIKit_Sim/UIKit-3512.30.14/UICollectionView.m:4324

//                //                    var indexes = new List<NSIndexPath>();
//                //                    switch (e.Action) {
//                //                        case NotifyCollectionChangedAction.Add:
//                //                            for (int i = 0; i < e.NewItems.Count; i++) {
//                //                                indexes.Add(NSIndexPath.FromRowSection((nint)(e.NewStartingIndex + i),0));
//                //                            }
//                //                            this.Control.InsertItems(indexes.ToArray());
//                //                            break;
//                //                        case NotifyCollectionChangedAction.Remove:
//                //                            for (int i = 0; i< e.OldItems.Count; i++) {
//                //                                indexes.Add(NSIndexPath.FromRowSection((nint)(e.OldStartingIndex + i),0));
//                //                            }
//                //                            this.Control.DeleteItems(indexes.ToArray());
//                //                            break;
//                //                        default:
//                //                            this.Control.ReloadData();
//                //                            break;
//                //                    }
//            }
//                catch { } // todo: determine why we are hiding a possible exception here
//            });
//        }

//        /// <summary>
//        /// Gets the data source.
//        /// </summary>
//        /// <value>The data source.</value>
//        private GridDataSource DataSource
//        {
//            get
//            {
//                return _dataSource ?? (_dataSource = new GridDataSource(GetCell, RowsInSection, ItemSelected));
//            }
//        }

//        /// <summary>
//        /// Releases unmanaged and - optionally - managed resources.
//        /// </summary>
//        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
//        protected override void Dispose(bool disposing)
//        {
//            base.Dispose(disposing);
//            if (disposing && _dataSource != null)
//            {
//                Unbind(Element);
//                _dataSource.Dispose();
//                _dataSource = null;
//            }
//        }
//    }
//}
