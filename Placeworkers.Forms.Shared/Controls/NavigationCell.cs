using System;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
	public class NavigationCell : TextCell
	{
		public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(NavigationCell));

		/// <summary>
		/// Gets or sets the ImageSource to use with the control.
		/// </summary>
		/// <value>
		/// The Source property gets/sets the value of the backing field, SourceProperty.
		/// </value>
		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource Source
		{
			get { return (ImageSource)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}

		public static readonly BindableProperty UseIOSAccessoryProperty = BindableProperty.Create(nameof(UseIOSAccessory), typeof(bool), typeof(NavigationCell), true);

		public bool UseIOSAccessory
		{
			get { return (bool)GetValue(UseIOSAccessoryProperty); }
			set { SetValue(UseIOSAccessoryProperty, value); }
		}
	}
}
