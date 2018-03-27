using Xamarin.Forms;

namespace Placeworkers.Forms
{
	public class NavigationButton : Button
	{
		public static readonly BindableProperty TextPaddingLeftProperty = BindableProperty.Create(nameof(TextPaddingLeft), typeof(int), typeof(NavigationButton), 15, BindingMode.TwoWay);
		public int TextPaddingLeft
		{
			get => (int)GetValue(TextPaddingLeftProperty);
			set => SetValue(TextPaddingLeftProperty, value);
		}
	}
}
