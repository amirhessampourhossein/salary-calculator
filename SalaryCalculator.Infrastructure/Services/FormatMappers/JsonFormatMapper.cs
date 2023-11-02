using Newtonsoft.Json;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class JsonFormatMapper : FormatMapper
{
    protected override T? TryMap<T>(string data) where T : class
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}
