using System;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
	public class DateTimePicker : DatePicker
	{
		public static readonly new BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DatePicker), DateTime.UtcNow, BindingMode.TwoWay, coerceValue: CoerceDate,
			propertyChanged: DatePropertyChanged);

		public new DateTime Date
		{
			get { return (DateTime)GetValue(DateProperty); }
			set { SetValue(DateProperty, value); }
		}

		static object CoerceDate(BindableObject bindable, object value)
		{
			var picker = (DateTimePicker)bindable;
			DateTime dateValue = ((DateTime)value);

			if (dateValue > picker.MaximumDate)
				dateValue = picker.MaximumDate;

			if (dateValue < picker.MinimumDate)
				dateValue = picker.MinimumDate;

			return dateValue;
		}

		public new event EventHandler<DateChangedEventArgs> DateSelected;

		static void DatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var datePicker = (DateTimePicker)bindable;
			EventHandler<DateChangedEventArgs> selected = datePicker.DateSelected;

			if (selected != null)
				selected(datePicker, new DateChangedEventArgs((DateTime)oldValue, (DateTime)newValue));
		}
	}
}
