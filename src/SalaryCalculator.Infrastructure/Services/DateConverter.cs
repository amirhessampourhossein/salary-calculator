using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Exceptions;
using System.Globalization;

namespace SalaryCalculator.Infrastructure.Services;

public class PersianDateConverter(PersianCalendar persianCalendar)
    : IDateConverter
{
    public DateOnly ConvertToGregorianDate(string persianDate)
    {
        try
        {
            if (persianDate.Contains('/'))
                persianDate = persianDate.Replace("/", "");

            var year = int.Parse(persianDate[0..4]);
            var month = int.Parse(persianDate[4..6]);
            var day = int.Parse(persianDate[6..8]);

            var date = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

            return DateOnly.FromDateTime(date);
        }
        catch (Exception)
        {
            throw new InvalidPersianDateException();
        }
    }

    public string ConvertToPersianDate(DateOnly date)
    {
        var year = persianCalendar
            .GetYear(date.ToDateTime(TimeOnly.MinValue))
            .ToString("0000");

        var month = persianCalendar
            .GetMonth(date.ToDateTime(TimeOnly.MinValue))
            .ToString("00");

        var day = persianCalendar
            .GetDayOfMonth(date.ToDateTime(TimeOnly.MinValue))
            .ToString("00");

        return $"{year}/{month}/{day}";
    }
}
