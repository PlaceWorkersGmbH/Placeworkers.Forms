using Xamarin.Forms;

namespace Placeworkers.Forms
{
    public class ExtendedListView : ListView
    {
        public static readonly BindableProperty IsScrollableProperty = BindableProperty.Create(nameof(IsScrollable), typeof(bool), typeof(ExtendedListView), true, BindingMode.OneWay);
        public bool IsScrollable
        {
            get => (bool)this.GetValue(IsScrollableProperty);
            set => this.SetValue(IsScrollableProperty, value);
        }
    }
}