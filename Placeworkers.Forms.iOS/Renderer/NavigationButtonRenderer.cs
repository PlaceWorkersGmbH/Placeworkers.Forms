using System.ComponentModel;
using Placeworkers.Forms;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationButton), typeof(NavigationButtonRenderer))]
namespace Placeworkers.Forms
{
    public class NavigationButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Element != null && Control != null)
                UpdateSubViews();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Button.PaddingProperty.PropertyName || e.PropertyName == Button.ImageProperty.PropertyName)
                UpdateSubViews();
        }

        void UpdateSubViews()
        {
            Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            Control.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            Control.LineBreakMode = UILineBreakMode.TailTruncation;

            Control.ContentEdgeInsets = new UIEdgeInsets(
                (float)(Element.Padding.Top),
                (float)(Element.Padding.Left),
                (float)(Element.Padding.Bottom),
                (float)(Element.Padding.Right)
            );
            Control.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);

            Control.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
            Control.ImageView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor, -(float)(Element.Padding.Right)).Active = true;
            Control.ImageView.CenterYAnchor.ConstraintEqualTo(this.CenterYAnchor, 0).Active = true;
            Control.TitleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            Control.ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
        }
    }
}