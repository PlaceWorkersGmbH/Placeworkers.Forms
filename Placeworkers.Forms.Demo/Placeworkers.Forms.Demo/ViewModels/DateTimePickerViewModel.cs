using System;
namespace Placeworkers.Forms.Demo.ViewModels
{
    public class DateTimePickerViewModel
    {
		DateTime _date = new DateTime(2017, 11, 24, 15, 30, 0, DateTimeKind.Utc);
		public DateTime Date
		{
			get { return _date; }
			set
			{
				_date = value;
			}
		}
    }
}
