using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SalaryCalculator.Infrastructure.Services.FormatMappers;

public class JsonFormatMapper<T> : FormatMapper<T> where T : class
{
    public override bool CanMap(string data)
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

    public override T? Map(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}
