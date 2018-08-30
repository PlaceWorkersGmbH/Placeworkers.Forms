using System;
using Prism.Mvvm;

namespace Placeworkers.Forms.Demo.ViewModels
{
    public class DateTimePickerViewModel : BindableBase
    {
		DateTime _date = new DateTime(2017, 11, 24, 15, 30, 0, DateTimeKind.Utc);
        DateTime _minmum = new DateTime(2017, 9, 1, 12, 42, 4, DateTimeKind.Utc);
        DateTime _maximum = new DateTime(2017, 12, 1, 16, 42, 4, DateTimeKind.Utc);
        public DateTime Minimum {
            get => _minmum;
            set { _minmum = value; RaisePropertyChanged(nameof(Minimum)); }
        }
        public DateTime Maximum {
            get => _maximum;
            set { _maximum = value; RaisePropertyChanged(nameof(Maximum)); }
        }
		public DateTime Date
		{
			get => _date;
			set { _date = value; RaisePropertyChanged(nameof(Date)); }
		}
    }
}
