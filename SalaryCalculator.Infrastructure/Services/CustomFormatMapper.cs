using CsvHelper;
using CsvHelper.Configuration;
using SalaryCalculator.Application.Abstractions;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Infrastructure.Services;

public class CustomFormatMapper<T> : IFormatMapper<T>
    where T : class
{
    public bool CanMap(string data)
    {
        var columns = string.Join(
            "/",
            typeof(T)
            .GetProperties()
            .Select(property => property.Name)
            .ToArray());

        return data.ToLower().Contains(columns);
    }

    public T? Map(string data)
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "/"
        };

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
        using var reader = new StreamReader(stream);
        using var csvReader = new CsvReader(reader, configuration);
        return csvReader.GetRecord<T>();
    }
}