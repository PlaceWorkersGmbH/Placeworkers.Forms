using System;
using Placeworkers.Forms;
using Placeworkers.Forms.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
[assembly: ExportRenderer(typeof(NavigationButton), typeof(NavigationButtonRenderer))]
namespace Placeworkers.Forms.Renderer
{
    public class NavigationButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(Control != null){
                Control.Gravity = Android.Views.GravityFlags.Left | Android.Views.GravityFlags.CenterVertical;
                var compound = Control.GetCompoundDrawables();
                Control.SetCompoundDrawables(null, null, compound[0], null);
            }
        }
    }
}
