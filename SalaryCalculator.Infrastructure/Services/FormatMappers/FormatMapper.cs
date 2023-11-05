namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public abstract class FormatMapper
{
    public abstract T? Map<T>(string data) where T : class;

    public static FormatMapper? CreateMapperFromType(string type)
    {
        return type.Trim().ToLower() switch
        {
            "json" => new JsonFormatMapper(),
            "xml" => new XmlFormatMapper(),
            "csv" => new CsvFormatMapper(),
            "custom" => new CustomFormatMapper(),
            _ => null
        };
    }
}
