//// ***********************************************************************
//// Assembly         : XLabs.Forms.iOS
//// Author           : XLabs Team
//// Created          : 12-27-2015
//// 
//// Last Modified By : XLabs Team
//// Last Modified On : 01-04-2016
//// ***********************************************************************
//// <copyright file="GridDataSource.cs" company="XLabs Team">
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
//using Foundation;
//using Microsoft.Practices.ServiceLocation;
//using UIKit;

//namespace Day1Training.IOS
//{
//    /// <summary>
//    /// Class GridDataSource.
//    /// </summary>
//    public class GridDataSource : UICollectionViewSource
//    {
//        /// <summary>
//        /// Delegate OnGetCell
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="indexPath">The index path.</param>
//        /// <returns>UICollectionViewCell.</returns>
//        public delegate UICollectionViewCell OnGetCell(UICollectionView collectionView, NSIndexPath indexPath);

//        /// <summary>
//        /// Delegate OnRowsInSection
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="section">The section.</param>
//        /// <returns>System.Int32.</returns>
//        public delegate int OnRowsInSection(UICollectionView collectionView, nint section);

//        /// <summary>
//        /// Delegate OnItemSelected
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="indexPath">The index path.</param>
//        public delegate void OnItemSelected(UICollectionView collectionView, NSIndexPath indexPath);

//        /// <summary>
//        /// The _on get cell
//        /// </summary>
//        private readonly OnGetCell _onGetCell;
//        /// <summary>
//        /// The _on rows in section
//        /// </summary>
//        private readonly OnRowsInSection _onRowsInSection;
//        /// <summary>
//        /// The _on item selected
//        /// </summary>
//        private readonly OnItemSelected _onItemSelected;

//		/// <summary>
//		/// Initializes a new instance of the <see cref="GridDataSource"/> class.
//		/// </summary>
//		/// <param name="onGetCell">The on get cell.</param>
//		/// <param name="onRowsInSection">The on rows in section.</param>
//		/// <param name="onItemSelected">The on item selected.</param>
//		// CounterViewModel counterViewModel = ServiceLocator.Current.GetInstance<CounterViewModel>();
//		public GridDataSource(OnGetCell onGetCell, OnRowsInSection onRowsInSection, OnItemSelected onItemSelected)
//        {
//            this._onGetCell = onGetCell;
//            this._onRowsInSection = onRowsInSection;
//            this._onItemSelected = onItemSelected;
//        }

//        #region implemented abstract members of UICollectionViewDataSource

//        /// <summary>
//        /// Gets the items count.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="section">The section.</param>
//        /// <returns>System.Int32.</returns>
//        public override nint GetItemsCount (UICollectionView collectionView, nint section)
//        {
//            return this._onRowsInSection(collectionView, section);
//        }


//		public override bool CanMoveItem(UICollectionView collectionView, NSIndexPath indexPath)
//		{

//			return true;

//		}


//		public override async void MoveItem(UICollectionView collectionView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
//		{
//			// Reorder our list of items
			

//			var item = counterViewModel.FilteredCatalogItems[(int)sourceIndexPath.Item];
//			try
//			{
//				await counterViewModel.ChangeItemPosition(item, (int)destinationIndexPath.Item);
//				collectionView.ReloadData();
//			}
//			catch (Exception ex)
//			{

//			}

//		}
	

//        /// <summary>
//        /// Items the selected.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="indexPath">The index path.</param>
//        public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            this._onItemSelected (collectionView, indexPath);
//        }
//        /// <summary>
//        /// Gets the cell.
//        /// </summary>
//        /// <param name="collectionView">The collection view.</param>
//        /// <param name="indexPath">The index path.</param>
//        /// <returns>UICollectionViewCell.</returns>
//        public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
//        {
//            var cell = this._onGetCell (collectionView, indexPath);

//            if (((GridCollectionView) collectionView).SelectionEnable)
//            {
//                // todo: investigate whether this needs to be removed when cell is re-used
//                cell.AddGestureRecognizer(new UITapGestureRecognizer(v =>
//                {
//                    ItemSelected(collectionView, indexPath);
//                }));
//            }
//            else
//            {
//                if (cell !=null)
//                {
         
//					cell.SelectedBackgroundView = new UIView();
//				}
//            }

//            return cell;
//        }
//        public override void ItemHighlighted(UICollectionView collectionView, NSIndexPath indexPath)
//        {
//          var cell = this._onGetCell(collectionView, indexPath);
          
//        }

//        #endregion
//    }
//}

