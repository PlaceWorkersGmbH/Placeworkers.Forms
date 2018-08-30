using System;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
    public static class GridExtension
    {
        public static void AddChild(this Grid grid, View view, int row, int column, int rowspan = 1, int columnspan = 1)
        {
            if (row < 0)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column < 0)
                throw new ArgumentOutOfRangeException(nameof(column));
            if (rowspan <= 0)
                throw new ArgumentOutOfRangeException(nameof(rowspan));
            if (columnspan <= 0)
                throw new ArgumentOutOfRangeException(nameof(columnspan));
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            Grid.SetRow(view, row);
            Grid.SetRowSpan(view, rowspan);
            Grid.SetColumn(view, column);
            Grid.SetColumnSpan(view, columnspan);
            grid.Children.Add(view);
        }
    }
}