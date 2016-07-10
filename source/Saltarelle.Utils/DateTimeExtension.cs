using System;

namespace Saltarelle.Utils
{
	public static class DateTimeExtension
	{
		/// <summary>
		/// Adds passed numer of days.
		/// In case of daylight saving the resulting date time has the same time as before.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="days"></param>
		/// <returns></returns>
		public static DateTime AddDaysSafe(this DateTime date, int days)
		{
			// due to summer time change !!
			DateTime newDate;
			if (days > 0)
				newDate = date.Date.AddHours(days * 24 +1).Date;
			else if ( days < 0)
				newDate = date.Date.AddHours(days * 24).Date;
			else
				newDate = date.Date;

			return new DateTime(newDate.Year, newDate.Month, newDate.Day, date.Hour, date.Minute, date.Second);
		}
	}
}
