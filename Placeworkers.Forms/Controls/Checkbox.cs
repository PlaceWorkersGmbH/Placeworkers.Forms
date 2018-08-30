using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Placeworkers.Forms
{
    public class Checkbox : StackLayout
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(Checkbox), true, BindingMode.TwoWay);
        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set => SetValue(CheckedProperty, value);
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
        readonly Label _checkboxLabel;

        public Checkbox()
        {
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
                Margin = new Thickness(0, 0, 0, 0)
            };
            _checkboxImage.SetBinding(Image.SourceProperty, new Binding(nameof(Checked), source: this, converter: new CheckedConverter(this)));
            _checkboxLabel = new Label
            {
                VerticalOptions = new LayoutOptions
                {
                    Alignment = LayoutAlignment.Fill,
                    Expands = true
                },
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(8, 0, 0, 0)
            };
            _checkboxLabel.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
            _checkboxLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));
            Children.Add(_checkboxImage);
            Children.Add(_checkboxLabel);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Checked = !Checked;
            };
            _checkboxLabel.GestureRecognizers.Add(tapGestureRecognizer);
            _checkboxImage.GestureRecognizers.Add(tapGestureRecognizer);
            OnPropertyChanged("Checked");
        }

        protected sealed override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Style")
            {
                _checkboxImage.SetBinding(Image.SourceProperty, new Binding(nameof(Checked), source: this, converter: new CheckedConverter(this)));
                OnPropertyChanged("Checked");
            }
        }

        class CheckedConverter : IValueConverter
        {
            Checkbox _checkbox;

            public CheckedConverter(Checkbox checkbox) => _checkbox = checkbox;

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value ? _checkbox.SourceSelected : _checkbox.SourceUnselected;
            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
        }
    }
}