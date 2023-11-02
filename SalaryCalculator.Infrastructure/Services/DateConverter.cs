using SalaryCalculator.Application.Abstractions;
using System.Globalization;

namespace SalaryCalculator.Infrastructure.Services;

public class DateConverter : IDateConverter
{
    private readonly PersianCalendar _persianCalendar;

    public DateConverter(PersianCalendar persianCalendar)
    {
        _persianCalendar = persianCalendar;
    }

    public DateTime ConvertToGregorianDate(string persianDate)
    {
        if (persianDate.Contains('/'))
            persianDate = persianDate.Replace("/", "");

        var year = int.Parse(persianDate[0..4]);
        var month = int.Parse(persianDate[4..6]);
        var day = int.Parse(persianDate[6..8]);

        return _persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
    }

    public string ConvertToPersianDate(DateTime dateTime)
    {
        var year = _persianCalendar.GetYear(dateTime).ToString("0000");
        var month = _persianCalendar.GetMonth(dateTime).ToString("00");
        var day = _persianCalendar.GetDayOfMonth(dateTime).ToString("00");

        return $"{year}/{month}/{day}";
    }
}
