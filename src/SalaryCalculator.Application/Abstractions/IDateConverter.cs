namespace SalaryCalculator.Application.Abstractions;

public interface IDateConverter
{
    DateOnly ConvertToGregorianDate(string persianDate);
    string ConvertToPersianDate(DateOnly dateTime);
}
