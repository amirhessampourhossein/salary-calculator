using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class CsvFormatMapper : FormatMapper
{
    protected override T? TryMap<T>(string data) where T : class
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
        using var reader = new StreamReader(stream);
        using var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        });
        csvReader.Read();
        return csvReader.GetRecord<T>();
    }
}
