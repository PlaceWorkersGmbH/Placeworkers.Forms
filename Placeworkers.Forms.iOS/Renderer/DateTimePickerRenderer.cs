using System;
using System.ComponentModel;
using Foundation;
using UIKit;
using RectangleF = CoreGraphics.CGRect;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Placeworkers.Forms;

[assembly: ExportRenderer(typeof(DateTimePicker), typeof(DateTimePickerRenderer))]
namespace Placeworkers.Forms
{
	internal class NoCaretField : UITextField
	{
		public NoCaretField() : base(new RectangleF())
		{
		}

		public override RectangleF GetCaretRectForPosition(UITextPosition position)
		{
			return new RectangleF();
		}
	}

	public class DateTimePickerRenderer : ViewRenderer<DateTimePicker, UITextField>
	{
		UIDatePicker _picker;
		UIColor _defaultTextColor;
		bool _disposed;

		IElementController ElementController => Element as IElementController;

		protected override void OnElementChanged(ElementChangedEventArgs<DateTimePicker> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
				return;

			if (Control == null)
			{
				var entry = new NoCaretField { BorderStyle = UITextBorderStyle.RoundedRect };

				entry.EditingDidBegin += OnStarted;
				entry.EditingDidEnd += OnEnded;

				_picker = new UIDatePicker { Mode = UIDatePickerMode.DateAndTime, TimeZone = new NSTimeZone("UTC") };

				_picker.ValueChanged += HandleValueChanged;

				var width = UIScreen.MainScreen.Bounds.Width;
				var toolbar = new UIToolbar(new RectangleF(0, 0, width, 44)) { BarStyle = UIBarStyle.Default, Translucent = true };
				var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
				var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (o, a) => entry.ResignFirstResponder());

				toolbar.SetItems(new[] { spacer, doneButton }, false);

				entry.InputView = _picker;
				entry.InputAccessoryView = toolbar;

				_defaultTextColor = entry.TextColor;

				SetNativeControl(entry);
			}

			UpdateDateFromModel(false);
			UpdateMaximumDate();
			UpdateMinimumDate();
			UpdateTextColor();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == DateTimePicker.DateProperty.PropertyName || e.PropertyName == DatePicker.FormatProperty.PropertyName)
				UpdateDateFromModel(true);
			else if (e.PropertyName == DatePicker.MinimumDateProperty.PropertyName)
				UpdateMinimumDate();
			else if (e.PropertyName == DatePicker.MaximumDateProperty.PropertyName)
				UpdateMaximumDate();
			else if (e.PropertyName == DatePicker.TextColorProperty.PropertyName || e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
				UpdateTextColor();
		}

		void HandleValueChanged(object sender, EventArgs e)
		{
			var dt = _picker.Date.ToDateTime();
			ElementController?.SetValueFromRenderer(DateTimePicker.DateProperty, dt);
		}

		void OnEnded(object sender, EventArgs eventArgs)
		{
			var key = Element.GetInternalPropertyKey("IsFocusedPropertyKey");
			ElementController.SetValueFromRenderer(key, false);
		}

		void OnStarted(object sender, EventArgs eventArgs)
		{
			var key = Element.GetInternalPropertyKey("IsFocusedPropertyKey");
			ElementController.SetValueFromRenderer(key, true);
		}

		void UpdateDateFromModel(bool animate)
		{
			if (_picker.Date.ToDateTime() != Element.Date)
				_picker.SetDate(Element.Date.ToNSDate(), animate);
			
			Control.Text = Element.Date.ToString(Element.Format);
		}

		void UpdateMaximumDate()
		{
			_picker.MaximumDate = Element.MaximumDate.ToNSDate();
		}

		void UpdateMinimumDate()
		{
			_picker.MinimumDate = Element.MinimumDate.ToNSDate();
		}

		void UpdateTextColor()
		{
			var textColor = Element.TextColor;

			if (textColor.IsDefault() || !Element.IsEnabled)
				Control.TextColor = _defaultTextColor;
			else
				Control.TextColor = textColor.ToUIColor();
		}

		protected override void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			_disposed = true;

			if (disposing)
			{
				_defaultTextColor = null;

				if (_picker != null)
				{
					_picker.RemoveFromSuperview();
					_picker.ValueChanged -= HandleValueChanged;
					_picker.Dispose();
					_picker = null;
				}

				if (Control != null)
				{
					Control.EditingDidBegin -= OnStarted;
					Control.EditingDidEnd -= OnEnded;
				}
			}

			base.Dispose(disposing);
		}
	}
}
