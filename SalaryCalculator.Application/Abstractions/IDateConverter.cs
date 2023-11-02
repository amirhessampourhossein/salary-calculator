namespace SalaryCalculator.Application.Abstractions;

public interface IDateConverter
{
    DateTime ConvertToGregorianDate(string persianDate);
    string ConvertToPersianDate(DateTime dateTime);
}
