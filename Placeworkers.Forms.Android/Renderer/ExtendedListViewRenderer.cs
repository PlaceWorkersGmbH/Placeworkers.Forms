using Android.Content;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]
namespace Placeworkers.Forms
{
    public class ExtendedListViewRenderer : ListViewRenderer
    {
        public ExtendedListViewRenderer(Context context) : base(context) { }

        public override bool DispatchTouchEvent(Android.Views.MotionEvent e)
        {
            if (e.Action == Android.Views.MotionEventActions.Move && !((ExtendedListView)Element).IsScrollable)
                return true;
            return base.DispatchTouchEvent(e);
        }
    }
}