using System;
using Placeworkers.Forms;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(NavigationButton), typeof(NavigationButtonRenderer))]
namespace Placeworkers.Forms
{
    public class NavigationButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Element != null && Control != null)
            {
                var navButton = Element as NavigationButton;
                Control.HorizontalAlignment = UIKit.UIControlContentHorizontalAlignment.Left;
                Control.VerticalAlignment = UIKit.UIControlContentVerticalAlignment.Center;
                Control.LineBreakMode = UILineBreakMode.TailTruncation;
                if (Control.ImageView.Image == null)
                {
                    Control.ContentEdgeInsets = new UIKit.UIEdgeInsets(0, navButton.TextPaddingLeft, 0, 0);
                }
                else
                {
                    Control.ContentEdgeInsets = new UIKit.UIEdgeInsets(0, navButton.TextPaddingLeft -10, 0, 25);
                    Control.TitleEdgeInsets = new UIKit.UIEdgeInsets(0, 0, 0, 0);
                    Control.ImageView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor, -15).Active = true;
                    Control.ImageView.CenterYAnchor.ConstraintEqualTo(Control.CenterYAnchor, 0).Active = true;
                    Control.ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
                }
            }
        }
    }
}
