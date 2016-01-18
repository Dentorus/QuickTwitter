using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace QuickTwitter.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
            ItemListView.SizeChanged += (s, e) => SetItemsWidth();
            
        }

        private ItemsWrapGrid _wrapGrid;

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); SetItemsWidth(); }
        }

        // Using a DependencyProperty as the backing store for Columns. This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty ColumnsProperty =
        DependencyProperty.Register("Columns", typeof(int), typeof(MainView), new PropertyMetadata(1));

        private void SetItemsWidth()
        {
            if (_wrapGrid == null)
            {
                return;
            }
            _wrapGrid.ItemWidth = (int)ItemListView.ActualWidth / Columns;
        }

        private void VariableSizedWrapGrid_Loaded(object sender, RoutedEventArgs e)
        {
            _wrapGrid = sender as ItemsWrapGrid;
            SetItemsWidth();
        }
    }
}
