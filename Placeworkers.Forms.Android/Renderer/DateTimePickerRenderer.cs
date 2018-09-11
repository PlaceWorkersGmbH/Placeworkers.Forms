using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Text.Format;
using Android.Widget;
using Placeworkers.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using Object = Java.Lang.Object;

[assembly: ExportRenderer(typeof(DateTimePicker), typeof(DateTimePickerRenderer))]
namespace Placeworkers.Forms
{
    public class DateTimePickerRenderer : ViewRenderer<DateTimePicker, EditText>, TimePickerDialog.IOnTimeSetListener
    {
        DatePickerDialog _dateDialog;
        TimePickerDialog _timeDialog;
        bool _disposed;
        TextColorSwitcher _textColorSwitcher;

        public DateTimePickerRenderer(Context context) : base(context) => AutoPackage = false;

        void OnTextFieldClicked()
        {
            var view = Element;

            CreateDatePickerDialog(view.Date.Year, view.Date.Month - 1, view.Date.Day);
            CreateTimePickerDialog(view.Date.Hour, view.Date.Minute);

            UpdateMinimumDate();
            UpdateMaximumDate();

            if (HasCancelEvent())
            {
                _dateDialog.CancelEvent += OnCancelButtonClicked;
                _timeDialog.CancelEvent += OnCancelButtonClicked;
            }

            _dateDialog.Show();
        }

        void CreateDatePickerDialog(int year, int month, int day)
        {
            var view = Element;
            _dateDialog = new DatePickerDialog(Context, (o, e) =>
            {
                var oldDate = view.Date;
                var newDate = e.Date;
                view.Date = new DateTime(newDate.Year, newDate.Month, newDate.Day, oldDate.Hour, oldDate.Minute, 0, DateTimeKind.Utc);
                if (HasCancelEvent())
                {
                    _dateDialog.CancelEvent -= OnCancelButtonClicked;
                }
                _dateDialog = null;
                _timeDialog.Show();
            }, year, month, day);
        }

        void CreateTimePickerDialog(int hour, int minute)
        {
            var is24HourFormat = DateFormat.Is24HourFormat(Context);
            _timeDialog = new TimePickerDialog(Context, this, hour, minute, is24HourFormat);
        }

        protected override EditText CreateNativeControl() => new EditText(Context) { Focusable = false, Clickable = true, Tag = this };

        protected override void OnElementChanged(ElementChangedEventArgs<DateTimePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var textField = CreateNativeControl();
                textField.SetOnClickListener(TextFieldClickHandler.Instance);
                SetNativeControl(textField);
                _textColorSwitcher = new TextColorSwitcher(textField.TextColors);
            }
            SetDate(Element.Date);
            UpdateMinimumDate();
            UpdateMaximumDate();
            UpdateTextColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == DateTimePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
                SetDate(Element.Date);
            else if (e.PropertyName == Xamarin.Forms.DatePicker.MinimumDateProperty.PropertyName)
                UpdateMinimumDate();
            else if (e.PropertyName == Xamarin.Forms.DatePicker.MaximumDateProperty.PropertyName)
                UpdateMaximumDate();
            if (e.PropertyName == Xamarin.Forms.DatePicker.TextColorProperty.PropertyName)
                UpdateTextColor();
        }

        void OnCancelButtonClicked(object sender, EventArgs e) => Element.Unfocus();

        void SetDate(DateTime date) => Control.Text = date.ToString(Element.Format);

        public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
        {
            var dt = Element.Date;
            var newDT = new DateTime(dt.Year, dt.Month, dt.Day, hourOfDay, minute, 0, DateTimeKind.Utc);
            Element.Date = newDT;
            Control.ClearFocus();
            if (HasCancelEvent())
            {
                _timeDialog.CancelEvent -= OnCancelButtonClicked;
            }
            _timeDialog = null;
        }

        void UpdateMaximumDate()
        {
            if (_dateDialog != null)
            {
                _dateDialog.DatePicker.MaxDate = (long)Element.MaximumDate.ToUniversalTime().Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
            }
        }

        void UpdateMinimumDate()
        {
            if (_dateDialog != null)
            {
                _dateDialog.DatePicker.MinDate = (long)Element.MinimumDate.ToUniversalTime().Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
            }
        }

        void UpdateTextColor() => _textColorSwitcher?.UpdateTextColor(Control, Element.TextColor);

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                if (_dateDialog != null)
                {
                    if (HasCancelEvent())
                    {
                        _dateDialog.CancelEvent -= OnCancelButtonClicked;
                    }
                    _dateDialog.Hide();
                    _dateDialog.Dispose();
                    _dateDialog = null;
                }
                if (_timeDialog != null)
                {
                    if (HasCancelEvent())
                    {
                        _timeDialog.CancelEvent -= OnCancelButtonClicked;
                    }
                    _timeDialog.Hide();
                    _timeDialog.Dispose();
                    _timeDialog = null;
                }
            }
            base.Dispose(disposing);
        }

        bool HasCancelEvent() => Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop;

        class TextFieldClickHandler : Object, IOnClickListener
        {
            public static readonly TextFieldClickHandler Instance = new TextFieldClickHandler();

            public void OnClick(AView v) => ((DateTimePickerRenderer)v.Tag).OnTextFieldClicked();
        }
    }
}