namespace SalaryCalculator.Application.Abstractions;

public interface IDateConverter
{
    DateTime ConvertToGregorianDateTime(string persianDate);
    string ConvertToPersianDateTime(DateTime dateTime);
}
