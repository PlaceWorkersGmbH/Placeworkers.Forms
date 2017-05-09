using System;
using Android.Graphics.Drawables;
using Android.Widget;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationCell), typeof(NavigationCellRenderer))]
namespace Placeworkers.Forms
{
	public class NavigationCellRenderer : TextCellRenderer
	{
		protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
		{
			var navCell = (NavigationCell)item;
			var cell = base.GetCellCore(item, convertView, parent, context) as BaseCellView;
			if (cell != null && navCell.Source != null) {
				AndroidImageHelper.GetBitmapFromImageSourceAsync(navCell.Source, cell.Context).ContinueWith((task) => { 
					var imageView = new ImageView(cell.Context);
					imageView.SetImageBitmap(task.Result);
					cell.SetAccessoryView(imageView);
				});
			}
			return cell;
		}
	}
}
