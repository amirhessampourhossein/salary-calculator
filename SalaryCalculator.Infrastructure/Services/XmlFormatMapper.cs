using SalaryCalculator.Application.Abstractions;
using System.Xml;
using System.Xml.Serialization;

namespace SalaryCalculator.Infrastructure.Services;

public class XmlFormatMapper<T> : IFormatMapper<T>
    where T : class
{
    public bool CanMap(string data)
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

    public T? Map(string data)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(data);
        return serializer.Deserialize(reader) as T;
    }
}
