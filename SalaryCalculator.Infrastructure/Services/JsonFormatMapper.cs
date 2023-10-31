using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SalaryCalculator.Application.Abstractions;

namespace SalaryCalculator.Infrastructure.Services;

public class JsonFormatMapper<T> : IFormatMapper<T>
    where T : class
{
    public bool CanMap(string data)
    {
        try
        {
            JToken.Parse(data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public T? Map(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}
