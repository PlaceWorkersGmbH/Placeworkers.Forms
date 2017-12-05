using System.Threading.Tasks;
using Android.Support.V4.Content;
using Android.Widget;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationCell), typeof(NavigationCellRenderer))]
namespace Placeworkers.Forms
{
	public class NavigationCellRenderer : TextCellRenderer
	{
		protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
		{
			var navCell = (NavigationCell)item;
			var cell = base.GetCellCore(item, convertView, parent, context) as BaseCellView;
			if (cell != null && navCell.UseAndroidAccessory) {
				var arrow = new Android.Support.V7.Graphics.Drawable.DrawerArrowDrawable(cell.Context);
				arrow.Progress = 1.0f;
				arrow.Direction = Android.Support.V7.Graphics.Drawable.DrawerArrowDrawable.ArrowDirectionRight;
				var imageView = new ImageView(cell.Context);
				imageView.SetImageDrawable(arrow);
				cell.SetAccessoryView(imageView);
			}
			return cell;
		}
	}
}
