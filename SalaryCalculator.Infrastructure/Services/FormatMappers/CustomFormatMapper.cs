using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class CustomFormatMapper : FormatMapper
{
    protected override T? Map<T>(string data) where T : class
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "/"
        };

        using var reader = new StringReader(data);
        using var csvReader = new CsvReader(reader, configuration);
        csvReader.Read();
        return csvReader.GetRecord<T>();
    }
}