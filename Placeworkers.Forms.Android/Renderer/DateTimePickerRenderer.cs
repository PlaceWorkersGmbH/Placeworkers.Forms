using System;
using System.ComponentModel;
using Android.App;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text.Format;
using ATimePicker = Android.Widget.TimePicker;

[assembly: ExportRenderer(typeof(DateTimePicker), typeof(DateTimePickerRenderer))]
namespace Placeworkers.Forms
{
    public class DateTimePickerRenderer : DatePickerRenderer, TimePickerDialog.IOnTimeSetListener
    {
        AlertDialog _dialog;
        IElementController ElementController => Element as IElementController;
        DateTime CurrentDateTime => (Element as DateTimePicker).Date;

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            Control.Text = CurrentDateTime.ToString(Element.Format);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsFocused") && !Element.IsFocused)
            {
                HandleTimePicker();
            }
            base.OnElementPropertyChanged(sender, e);
        }

        private void HandleTimePicker()
        {
            var dt = CurrentDateTime;
            bool is24HourFormat = DateFormat.Is24HourFormat(Context);
            _dialog = new TimePickerDialog(Context, this, dt.Hour, dt.Minute, is24HourFormat);
            if (HasCancelEvent())
            {
                _dialog.CancelEvent += OnDialogCancel;
            }
            _dialog.Show();
        }

        void TimePickerDialog.IOnTimeSetListener.OnTimeSet(ATimePicker view, int hourOfDay, int minute)
        {
            var dt = Element.Date;
            var newDT = new DateTime(dt.Year, dt.Month, dt.Day, hourOfDay, minute, 0, DateTimeKind.Utc);
            HandleDateChange(newDT);
        }

        void OnDialogCancel(object sender, EventArgs e)
        {
            var dtFromDatePicker = Element.Date;
            var dt = new DateTime(dtFromDatePicker.Year, dtFromDatePicker.Month, dtFromDatePicker.Day, CurrentDateTime.Hour, CurrentDateTime.Minute, 0);
            HandleDateChange(dt);
        }

        private void HandleDateChange(DateTime dateTime)
        {
            ElementController.SetValueFromRenderer(DateTimePicker.DateProperty, dateTime);
            Control.Text = dateTime.ToString(Element.Format);
            if (HasCancelEvent())
            {
                _dialog.CancelEvent -= OnDialogCancel;
            }
            _dialog = null;
        }

        private bool HasCancelEvent()
        {
            return Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop;
        }
    }
}
