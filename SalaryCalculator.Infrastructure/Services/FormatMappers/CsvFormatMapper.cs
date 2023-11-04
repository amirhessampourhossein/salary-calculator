using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class CsvFormatMapper : FormatMapper
{
    protected override T? TryMap<T>(string data) where T : class
    {
        using var reader = new StringReader(data);
        using var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        });
        csvReader.Read();
        return csvReader.GetRecord<T>();
    }
}
