using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]
namespace Placeworkers.Forms
{
	public class ExtendedListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (Control != null && Element != null)
			{
				UpdateScrollable();
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "IsScrollable":
					UpdateScrollable();
					break;
				default:
					base.OnElementPropertyChanged(sender, e);
					break;
			}

		}

		private void UpdateScrollable() { 
			Control.ScrollEnabled = ((ExtendedListView)Element).IsScrollable;
		}
	}
}
