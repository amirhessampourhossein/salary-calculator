using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class CustomFormatMapper : FormatMapper
{
    protected override T? TryMap<T>(string data) where T : class
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "/"
        };

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
        using var reader = new StreamReader(stream);
        using var csvReader = new CsvReader(reader, configuration);
        csvReader.Read();
        return csvReader.GetRecord<T>();
    }
}