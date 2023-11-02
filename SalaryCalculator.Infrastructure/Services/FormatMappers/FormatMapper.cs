namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public abstract class FormatMapper
{
    public T? Map<T>(string data) where T : class
    {
        try
        {
            return TryMap<T>(data);
        }
        catch (Exception)
        {
            return null;
        }
    }

    protected abstract T? TryMap<T>(string data) where T : class;

    public static FormatMapper? GetMapperFromType(string type)
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
