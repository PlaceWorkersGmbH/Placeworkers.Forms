using System;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
	public class NavigationCell : TextCell
	{
		public static readonly BindableProperty UseIOSAccessoryProperty = BindableProperty.Create(nameof(UseIOSAccessory), typeof(bool), typeof(NavigationCell), true);

		public bool UseIOSAccessory
		{
			get { return (bool)GetValue(UseIOSAccessoryProperty); }
			set { SetValue(UseIOSAccessoryProperty, value); }
		}

		public static readonly BindableProperty UseAndroidAccessoryProperty = BindableProperty.Create(nameof(UseAndroidAccessory), typeof(bool), typeof(NavigationCell), false);

		public bool UseAndroidAccessory
		{
			get { return (bool)GetValue(UseAndroidAccessoryProperty); }
			set { SetValue(UseAndroidAccessoryProperty, value); }
		}
	}
}
