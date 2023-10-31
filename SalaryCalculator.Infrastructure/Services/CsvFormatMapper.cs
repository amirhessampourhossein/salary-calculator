﻿using CsvHelper;
using SalaryCalculator.Application.Abstractions;
using System.Globalization;
using System.Text;

namespace SalaryCalculator.Infrastructure.Services;

public class CsvFormatMapper<T> : IFormatMapper<T>
    where T : class
{
    public bool CanMap(string data)
    {
        var columns = string.Join(
            ",",
            typeof(T)
            .GetProperties()
            .Select(property => property.Name)
            .ToArray());

        return data.ToLower().Contains(columns);
    }

    public T? Map(string data)
    {
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
        using var reader = new StreamReader(stream);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csvReader.GetRecord<T>();
    }
}