using System.Xml.Serialization;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class XmlFormatMapper : FormatMapper
{
    public override T? Map<T>(string data) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data);
        return serializer.Deserialize(reader) as T;
    }
}
