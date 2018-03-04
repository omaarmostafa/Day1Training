using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Day1Training
{
    #region IGridViewProvider

    public interface IGridViewProvider
    {
        void ReloadData();

        void ScrollToItemWithIndex(int index, bool animated);
    }

    #endregion

    #region ControlScrollEventArgs

    public class ControlScrollEventArgs : EventArgs
    {
        public float Delta { get; set; }

        public float CurrentY { get; set; }

        public ControlScrollEventArgs(float delta, float currentY)
        {
            this.Delta = delta;
            this.CurrentY = currentY;
        }
    }

    #endregion

    #region IScrollAwareElement

    public interface IScrollAwareElement
    {
        event EventHandler OnStartScroll;
        event EventHandler OnStopScroll;
        event EventHandler<ControlScrollEventArgs> OnScroll;

        void RaiseOnScroll(float delta, float currentY);

        void RaiseOnStartScroll();

        void RaiseOnStopScroll();
    }

    #endregion

    #region GridView

    /// <summary>
    /// Class GridView.
    /// </summary>
    public class GridView : ListView, IScrollAwareElement
    {
        #region Fields

        int? _initialIndex;

        IGridViewProvider _gridViewProvider;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridView"/> class.
        /// </summary>
        public GridView(): base(ListViewCachingStrategy.RecycleElement)
        {
        }

		#endregion

		#region Bindable Properties
        public static readonly BindableProperty SelectionEnableProperty = BindableProperty.Create("SelectionEnabled", typeof(bool), typeof(GridView), false, BindingMode.TwoWay, null, null, null, null);
        public static readonly BindableProperty ScrollEnableProperty = BindableProperty.Create("ScrollEnabled", typeof(bool), typeof(GridView), true, BindingMode.TwoWay, null, null, null, null);

		public static readonly BindableProperty PaddingProperty = BindableProperty.Create<GridView, Thickness>(view => view.Padding, new Thickness(0), BindingMode.OneWay);

        /// <summary>
        /// The row spacing property
        /// </summary>
        public static readonly BindableProperty RowSpacingProperty = BindableProperty.Create("RowSpacing", typeof(double), typeof(GridView), 0.0, BindingMode.OneWay, null, null, null, null);

        /// <summary>
        /// The column spacing property
        /// </summary>
        public static readonly BindableProperty ColumnSpacingProperty = BindableProperty.Create("ColumnSpacing", typeof(double), typeof(GridView), 0.0, BindingMode.OneWay, null, null, null, null);

        /// <summary>
        /// The item width property
        /// </summary>
        public static readonly BindableProperty ItemWidthProperty = BindableProperty.Create("ItemWidth", typeof(double), typeof(GridView), 100.0, BindingMode.OneWay, null, null, null, null);

        /// <summary>
        /// The item height property
        /// </summary>
        public static readonly BindableProperty ItemHeightProperty = BindableProperty.Create("ItemHeight", typeof(double), typeof(GridView), 100.0, BindingMode.OneWay, null, null, null, null);

        public static readonly BindableProperty IsHorizontalProperty = BindableProperty.Create("IsHorizontal", typeof(bool), typeof(GridView), false, BindingMode.OneWay, null, null, null, null);


		public static readonly BindableProperty TappedCommandProperty =
          BindableProperty.CreateAttached(
              "TappedCommand",
              typeof(ICommand),
              typeof(GridView),
              null,
              propertyChanged: OnTappedCommandPropertyChanged);

        public static ICommand GetTappedCommand(BindableObject view)
        {
            return (ICommand)view.GetValue(TappedCommandProperty);
        }

        public static void SetTappedCommand(BindableObject view, bool value)
        {
            view.SetValue(TappedCommandProperty, value);
        }

        /// <summary>
        /// The item width property
        /// </summary>
        public static readonly BindableProperty MinItemWidthProperty =
            BindableProperty.Create(
                "MinItemWidth",
                typeof(double),
                typeof(GridView),
                (double)100D);

        public static double GetMinItemWidth(BindableObject view)
        {
            return (double)view.GetValue(MinItemWidthProperty);
        }

        public static void SetMinItemWidth(BindableObject view, bool value)
        {
            view.SetValue(MinItemWidthProperty, value);
        }


        ///// <summary>
        ///// The item width property
        ///// </summary>
        //public static readonly BindableProperty IsItemsSourceGroupedProperty =
        //    BindableProperty.Create(
        //        "IsItemsSourceGrouped",
        //        typeof(bool),
        //        typeof(GridView),
        //        false);

        //public static double GetIsItemsSourceGrouped(BindableObject view)
        //{
        //    return (double)view.GetValue(IsItemsSourceGroupedProperty);
        //}

        //public static void SetIsItemsSourceGrouped(BindableObject view, bool value)
        //{
        //    view.SetValue(IsItemsSourceGroupedProperty, value);
        //}

        #endregion

        #region CLR Accessors

        /// <summary>
        /// Gets or sets the tapped command.
        /// </summary>
        public ICommand TappedCommand
        {
            get
            {
                return (ICommand)GetValue(TappedCommandProperty);
            }
            set
            {
                SetValue(TappedCommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the grid view provider.
        /// </summary>
		public IGridViewProvider GridViewProvider
        {
            get { return _gridViewProvider; }
            set
            {
                _gridViewProvider = value;
                if (_initialIndex.HasValue)
                {
                    GridViewProvider.ScrollToItemWithIndex(_initialIndex.Value, false);
                    _initialIndex = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the item.
        /// </summary>
        /// <value>The width of the item.</value>
        public double MinItemWidth
        {
            get
            {
                return (double)base.GetValue(GridView.MinItemWidthProperty);
            }
            set
            {
                base.SetValue(GridView.MinItemWidthProperty, value);
            }
        }


        public bool SelectionEnabled
        {
            get
            {
                return (bool)base.GetValue(GridView.SelectionEnableProperty);

			}
            set
            {
				base.SetValue(GridView.SelectionEnableProperty, value);
			}
        }
		public bool ScrollEnabled
		{
			get
			{
				return (bool)base.GetValue(GridView.ScrollEnableProperty);

			}
			set
			{
				base.SetValue(GridView.ScrollEnableProperty, value);
			}
		}
        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        /// <value>The padding.</value>
        public Thickness Padding
        {
            get
            {
                return (Thickness)base.GetValue(PaddingProperty);
            }
            set
            {
                base.SetValue(PaddingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the row spacing.
        /// </summary>
        /// <value>The row spacing.</value>
        public double RowSpacing
        {
            get
            {
                return (double)base.GetValue(GridView.RowSpacingProperty);
            }
            set
            {
                base.SetValue(GridView.RowSpacingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the column spacing.
        /// </summary>
        /// <value>The column spacing.</value>
        public double ColumnSpacing
        {
            get
            {
                return (double)base.GetValue(GridView.ColumnSpacingProperty);
            }
            set
            {
                base.SetValue(GridView.ColumnSpacingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the item.
        /// </summary>
        /// <value>The width of the item.</value>
        public double ItemWidth
        {
            get
            {
                return (double)base.GetValue(GridView.ItemWidthProperty);
            }
            set
            {
                base.SetValue(GridView.ItemWidthProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        public double ItemHeight
        {
            get
            {
                return (double)base.GetValue(GridView.ItemHeightProperty);
            }
            set
            {
                base.SetValue(GridView.ItemHeightProperty, value);
            }
        }

		public bool IsHorizontal
		{
			get
			{
				return (bool)base.GetValue(GridView.IsHorizontalProperty);
			}
			set
			{
				base.SetValue(GridView.IsHorizontalProperty, value);
			}
		}


		#endregion

		#region Methods

		/// <summary>
		/// Attach handling for list item tapped event.
		/// </summary>
		/// <param name="view">The source of the property change.</param>
		/// <param name="oldValue">The original value of the property.</param>
		/// <param name="newValue">The new value of the property.</param>
		private static void OnTappedCommandPropertyChanged(BindableObject view, object oldValue, object newValue)
        {
            var list = view as ListView;

            if (list != null)
            {
                list.ItemTapped -= List_ItemTapped;
                list.ItemTapped += List_ItemTapped;
            }
        }

        /// <summary>
        /// Callback when an item in the list view is tapped.
        /// </summary>
        /// <param name="sender">System.Object repersenting the source of the event.</param>
        /// <param name="e">The arguments for the event.</param>
        static void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Get object
            var listView = (sender as ListView);

            // Get command
            ICommand command = GetTappedCommand(listView);

            // Execute command
            command.Execute(e.Item);
        }

        /// <summary>
        /// Invokes the item selected event.
        /// </summary>
        /// <param name="sender">System.Object repersenting the source of the event.</param>
        /// <param name="item">The arguments for the event.</param>
        public void InvokeItemSelectedEvent(object sender, object item)
        {
            //If this is not already the selected item.
            if (SelectedItem != item)
            {
                //Set the selected item property.
                SelectedItem = item;
            }

            //Fire the command
            TappedCommand?.Execute(item);
        }

        /// <summary>
        /// 
        /// </summary>
		public void ReloadData()
        {
            if (GridViewProvider != null)
            {
                GridViewProvider.ReloadData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="animated"></param>
		public void ScrollToItemWithIndex(int index, bool animated)
        {
            if (GridViewProvider != null)
            {
                GridViewProvider.ScrollToItemWithIndex(index, animated);
            }
            else
            {
                _initialIndex = index;
            }
        }

        #endregion

        #region ISCrollAwareElement

        public event EventHandler OnStartScroll;
        public event EventHandler OnStopScroll;
        public event EventHandler<ControlScrollEventArgs> OnScroll;

        public void RaiseOnScroll(float delta, float currentY)
        {
            var args = new ControlScrollEventArgs(delta, currentY);
            if (OnScroll != null)
            {
                OnScroll(this, args);
            }
        }

        public void RaiseOnStartScroll()
        {
            if (OnStartScroll != null)
            {
                OnStartScroll(this, new EventArgs());
            }
        }

        public void RaiseOnStopScroll()
        {
            if (OnStopScroll != null)
            {
                OnStopScroll(this, new EventArgs());
            }
        }

        #endregion
    }

    #endregion
}