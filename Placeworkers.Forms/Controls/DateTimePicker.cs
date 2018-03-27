using System;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
    public class DateTimePicker : DatePicker
    {
        public static readonly new BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DateTimePicker), DateTime.UtcNow, BindingMode.TwoWay, coerceValue: CoerceDate,
            propertyChanged: DatePropertyChanged);
        public static readonly new BindableProperty MinimumDateProperty = BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(DateTimePicker), new DateTime(1900, 1, 1),
            validateValue: ValidateMinimumDate, coerceValue: CoerceMinimumDate);
        public static readonly new BindableProperty MaximumDateProperty = BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(DateTimePicker), new DateTime(2100, 12, 31),
            validateValue: ValidateMaximumDate, coerceValue: CoerceMaximumDate);

        public new DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
        public new DateTime MaximumDate
        {
            get => (DateTime)GetValue(MaximumDateProperty);
            set => SetValue(MaximumDateProperty, value);
        }
        public new DateTime MinimumDate
        {
            get => (DateTime)GetValue(MinimumDateProperty);
            set => SetValue(MinimumDateProperty, value);
        }

        public new event EventHandler<DateChangedEventArgs> DateSelected;

        static object CoerceMaximumDate(BindableObject bindable, object value)
        {
            DateTime dateValue = (DateTime)value;
            var picker = (DateTimePicker)bindable;
            if (picker.Date > dateValue)
                picker.Date = dateValue;
            return dateValue;
        }

        static object CoerceMinimumDate(BindableObject bindable, object value)
        {
            DateTime dateValue = (DateTime)value;
            var picker = (DateTimePicker)bindable;
            if (picker.Date < dateValue)
                picker.Date = dateValue;
            return dateValue;
        }

        static object CoerceDate(BindableObject bindable, object value)
        {
            var picker = (DateTimePicker)bindable;
            DateTime dateValue = (DateTime)value;
            if (dateValue > picker.MaximumDate)
                dateValue = picker.MaximumDate;
            if (dateValue < picker.MinimumDate)
                dateValue = picker.MinimumDate;
            return dateValue;
        }

        static bool ValidateMaximumDate(BindableObject bindable, object value) => (DateTime)value >= ((DateTimePicker)bindable).MinimumDate;
        static bool ValidateMinimumDate(BindableObject bindable, object value) => (DateTime)value <= ((DateTimePicker)bindable).MaximumDate;
        static void DatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var datePicker = (DateTimePicker)bindable;
            datePicker.DateSelected?.Invoke(datePicker, new DateChangedEventArgs((DateTime)oldValue, (DateTime)newValue));
        }
    }
}
