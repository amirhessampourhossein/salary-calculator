using System.Xml;
using System.Xml.Serialization;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class XmlFormatMapper<T> : FormatMapper<T> where T : class
{
    public override bool CanMap(string data)
    {
        try
        {
            new XmlDocument().LoadXml(data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public override T? Map(string data)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data);
        return serializer.Deserialize(reader) as T;
    }
}
