using Placeworkers.Forms;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationCell), typeof(NavigationCellRenderer))]
namespace Placeworkers.Forms
{
	public class NavigationCellRenderer : TextCellRenderer
	{
		public override UIKit.UITableViewCell GetCell(Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var navCell = (NavigationCell)item;
			var cell = base.GetCell(item, reusableCell, tv);
			if (cell != null && navCell.UseIOSAccessory) {
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			}
			return cell;
		}
	}
}
