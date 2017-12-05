using System;
using Prism.Mvvm;

namespace Placeworkers.Forms.Demo.ViewModels
{
    public class DateTimePickerViewModel : BindableBase
    {
		DateTime _date = new DateTime(2017, 11, 24, 15, 30, 0, DateTimeKind.Utc);
        public DateTime Minimum { get; set; } = new DateTime(2017, 9, 1, 12, 42, 4, DateTimeKind.Utc);
        public DateTime Maximum { get; set; } = new DateTime(2017, 12, 1, 16, 42, 4, DateTimeKind.Utc);
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
                RaisePropertyChanged(nameof(Date));
			}
		}
    }
}
