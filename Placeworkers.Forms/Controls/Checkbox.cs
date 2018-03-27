using System;
using System.Globalization;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
    public class Checkbox : StackLayout
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(Checkbox), true, defaultBindingMode: BindingMode.TwoWay);
        public bool Checked
		{
			get => (bool)GetValue(CheckedProperty);
            set
            {
				_checkboxImage.WidthRequest = _checkboxImage.Width;
				_checkboxImage.HeightRequest = _checkboxImage.Height;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _checkboxImage.FadeTo(0, 100);
                    SetValue(CheckedProperty, value);
                    await _checkboxImage.FadeTo(1, 250);
                });
            }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Checkbox), string.Empty);
        public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Checkbox), Color.Black);
		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
			set => SetValue(TextColorProperty, value);
		}

		public static readonly BindableProperty SourceUnselectedProperty = BindableProperty.Create("SourceUnselected", typeof(ImageSource), typeof(Checkbox), default(ImageSource));
		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource SourceUnselected
		{
			get => (ImageSource)GetValue(SourceUnselectedProperty);
			set => SetValue(SourceUnselectedProperty, value);
		}

		public static readonly BindableProperty SourceSelectedProperty = BindableProperty.Create("SourceSelected", typeof(ImageSource), typeof(Checkbox), default(ImageSource));
		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource SourceSelected
		{
			get => (ImageSource)GetValue(SourceSelectedProperty);
			set => SetValue(SourceSelectedProperty, value);
        }

        readonly Image _checkboxImage;
        Label _checkboxLabel;

        public Checkbox(){
            Orientation = StackOrientation.Horizontal;
            Spacing = 0;
			VerticalOptions = new LayoutOptions
			{
                Alignment = LayoutAlignment.Start,
				Expands = false
			};
            _checkboxImage = new Image
			{
				VerticalOptions = new LayoutOptions
				{
					Alignment = LayoutAlignment.Center,
					Expands = false
				},
                Margin = new Thickness(8,0,0,0)
            };
            _checkboxImage.SetBinding(Image.SourceProperty, new Binding(nameof(Checked), source: this, converter: new CheckedConverter(this)));
            _checkboxLabel = new Label
            {
				VerticalOptions = new LayoutOptions
				{
                    Alignment = LayoutAlignment.Start,
					Expands = false
				},
                Margin = new Thickness(8)
            };
            _checkboxLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
            _checkboxLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));
            this.Children.Add(_checkboxImage);
            this.Children.Add(_checkboxLabel);
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
                Checked = !Checked;
			};
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }

        class CheckedConverter : IValueConverter
        {
            private Checkbox _checkbox;

            public CheckedConverter(Checkbox checkbox)
            {
                _checkbox = checkbox;
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value ? _checkbox.SourceSelected : _checkbox.SourceUnselected;
            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
        }

    }
}
