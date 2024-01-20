using System.Numerics;

namespace OvertimePolicies;

public static class OvertimeMethods
{
    public static T CalculateA<T>(T basicSalary, T allowance)
        where T : INumber<T>
        => basicSalary + allowance;

    public static T CalculateB<T>(T basicSalary, T allowance)
        where T : INumber<T>
        => (basicSalary + allowance) * ConvertToGenericNumber<T>(2);

    public static T CalculateC<T>(T basicSalary, T allowance)
        where T : INumber<T>
        => (basicSalary + allowance) * ConvertToGenericNumber<T>(3);

    private static T ConvertToGenericNumber<T>(int integer)
        where T : INumber<T>
        => T.Parse(integer.ToString(), null);
}
