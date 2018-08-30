using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Placeworkers.Forms.Demo.ViewModels;
using Xamarin.Forms;

namespace Placeworkers.Forms.Demo.Views
{
    public partial class DateTimePickerView : ContentPage
    {
        public DateTimePickerView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(() => {
                Task.Delay(TimeSpan.FromSeconds(2));
                ((DateTimePickerViewModel)BindingContext).Date = new DateTime(2017, 9, 1, 13, 21, 4, DateTimeKind.Utc);
                ((DateTimePickerViewModel)BindingContext).Minimum = new DateTime(2017, 8, 1, 13, 21, 4, DateTimeKind.Utc);
                ((DateTimePickerViewModel)BindingContext).Maximum = new DateTime(2017, 10, 1, 13, 21, 4, DateTimeKind.Utc);
            });
        }
    }
}
