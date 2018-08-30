using Android.Content;
using Placeworkers.Forms;
using Placeworkers.Forms.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationButton), typeof(NavigationButtonRenderer))]
namespace Placeworkers.Forms.Renderer
{
    public class NavigationButtonRenderer : ButtonRenderer
    {
        NavigationButton Button => Element as NavigationButton;

        public NavigationButtonRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Element != null && Control != null)
            {
                Control.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
                Control.SetSingleLine(true);
                Control.Gravity = Android.Views.GravityFlags.Left | Android.Views.GravityFlags.CenterVertical;
                var compound = Control.GetCompoundDrawables();
                Control.SetCompoundDrawables(null, null, compound[0], null);
            }
        }
    }
}
