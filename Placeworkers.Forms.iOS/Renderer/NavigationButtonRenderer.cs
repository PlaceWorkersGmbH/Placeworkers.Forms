﻿using System;
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
                Control.HorizontalAlignment = UIKit.UIControlContentHorizontalAlignment.Left;
                Control.VerticalAlignment = UIKit.UIControlContentVerticalAlignment.Center;
                if (Control.ImageView.Image == null)
                {
                    Control.ContentEdgeInsets = new UIKit.UIEdgeInsets(0, 15, 0, 0);
                }
                else
                {
                    Control.ContentEdgeInsets = new UIKit.UIEdgeInsets(0, 0, 0, 0);
                    Control.TitleEdgeInsets = new UIKit.UIEdgeInsets(0, 0, 0, 0);
                    Control.ImageView.TrailingAnchor.ConstraintEqualTo(this.TrailingAnchor, -15).Active = true;
                    Control.ImageView.CenterYAnchor.ConstraintEqualTo(Control.CenterYAnchor, 0).Active = true;
                    Control.ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
                }
            }
        }
    }
}