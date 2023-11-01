namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public abstract class FormatMapper<T>
    where T : class
{
    public abstract bool CanMap(string data);
    public abstract T? Map(string data);

    public static FormatMapper<T>? GetMapperFromType(string type)
    {
        return type.Trim().ToLower() switch
        {
            "json" => new JsonFormatMapper<T>(),
            "xml" => new XmlFormatMapper<T>(),
            "csv" => new CsvFormatMapper<T>(),
            "custom" => new CustomFormatMapper<T>(),
            _ => null
        };
    }
}
