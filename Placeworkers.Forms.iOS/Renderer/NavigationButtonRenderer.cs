using Placeworkers.Forms;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(NavigationButton), typeof(NavigationButtonRenderer))]
namespace Placeworkers.Forms
{
    public class NavigationButtonRenderer : ButtonRenderer
    {
        NavigationButton Button => Element as NavigationButton;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Element != null && Control != null)
            {
                Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                Control.VerticalAlignment = UIControlContentVerticalAlignment.Center;
                Control.LineBreakMode = UILineBreakMode.TailTruncation;
                if (Control.ImageView.Image == null)
                {
                    Control.ContentEdgeInsets = new UIEdgeInsets(0, Button.TextPaddingLeft, 0, 0);
                }
                else
                {
                    Control.ContentEdgeInsets = new UIEdgeInsets(0, Button.TextPaddingLeft -10, 0, 25);
                    Control.ImageView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor, -15).Active = true;
                    Control.ImageView.CenterYAnchor.ConstraintEqualTo(Control.CenterYAnchor, 0).Active = true;
                    Control.ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
                }
                Control.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control.ImageView.Image == null)
                Control.ContentEdgeInsets = new UIEdgeInsets(0, Button.TextPaddingLeft, 0, 0);
            else
                Control.ContentEdgeInsets = new UIEdgeInsets(0, Button.TextPaddingLeft - 10, 0, 25);
            Control.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
        }
    }
}
