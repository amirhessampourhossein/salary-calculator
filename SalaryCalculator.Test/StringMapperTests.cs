using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Infrastructure.Services;
using System.Globalization;
using System.Xml.Serialization;

namespace SalaryCalculator.Test;

public class StringMapperTests
{
    private static readonly EmployeeSalaryRequest TestRecord = new()
    {
        FirstName = "Test",
        LastName = "Test",
        Allowance = 1000.55m,
        BasicSalary = 1000.55m,
        Transportation = 1000.55m,
        Date = "14020812"
    };

    private readonly StringMapper _stringMapper;

    public StringMapperTests()
    {
        _stringMapper = new(new PersianDateConverter(new()));
    }

    [Fact]
    public void Map_WhenDataIsJson_ReturnsNonNull()
    {
        //Arrange
        var json = JsonConvert.SerializeObject(TestRecord);

        //Act
        var result = _stringMapper.Map(json, "json");

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Map_WhenDataIsXml_ReturnsNonNull()
    {
        //Arrange
        var serializer = new XmlSerializer(typeof(EmployeeSalaryRequest));
        using var writer = new StringWriter();
        serializer.Serialize(writer, TestRecord);
        var xml = writer.ToString();

        //Act
        var result = _stringMapper.Map(xml, "xml");

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Map_WhenDataIsCsv_ReturnsNonNull()
    {
        //Arrange
        var csv = string.Join(",", TestRecord.GetType().GetProperties().Select(p => p.GetValue(TestRecord)?.ToString()).ToArray());

        //Act
        var result = _stringMapper.Map(csv, "csv");

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Map_WhenDataIsCustom_ReturnsNonNull()
    {
        //Arrange
        string delimiter = "/";
        var properties = TestRecord.GetType().GetProperties();
        var custom = string.Join(delimiter, properties.Select(p => p.Name).ToArray());
        custom += "\r\n";
        custom += string.Join(delimiter, properties.Select(p => p.GetValue(TestRecord)?.ToString()).ToArray());

        //Act
        var result = _stringMapper.Map(custom, "custom");

        //Assert
        Assert.NotNull(result);
    }
}
