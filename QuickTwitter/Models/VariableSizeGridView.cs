using QuickTwitter.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QuickTwitter.Models
{
    class VariableSizeGridView : GridView
    { 
        private int rowVal;
        private int colVal;

        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            Tweet dataItem = item as Tweet;
            int index = -1;

            if (dataItem != null )
            {
                if (dataItem.ExtendedEntities != null)
                index = dataItem.ExtendedEntities.Media.Length;
            }

            if (index == 1)
            {
                colVal = 3;
                rowVal = 5;
            }
            else
            {
                colVal = 3;
                rowVal = 2;
            }

            if (index == 2)
            {
                colVal = 3;
                rowVal = 10;
            }

            if (index == 4 || index == 3)
            {
                colVal = 3;
                rowVal = 8;
            }

            VariableSizedWrapGrid.SetRowSpan(element as UIElement, rowVal);
            VariableSizedWrapGrid.SetColumnSpan(element as UIElement, colVal);

            base.PrepareContainerForItemOverride(element, item);

        }

    }
}
