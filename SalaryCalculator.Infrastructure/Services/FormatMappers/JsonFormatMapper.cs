using Newtonsoft.Json;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class JsonFormatMapper : FormatMapper
{
    public override T? Map<T>(string data) where T : class
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}
