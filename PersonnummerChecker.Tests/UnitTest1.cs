using Xunit;

namespace PersonnummerChecker.Tests;

public class MonthTests
{
    [Theory]

    // Giltiga månader (01–12)
    [InlineData("19900101-1234", true)]   // Januari
    [InlineData("19901201-1234", true)]   // December

    // Ogiltiga månader
    [InlineData("19900001-1234", false)]  // Månad 00 finns inte
    [InlineData("19901301-1234", false)]  // Månad 13 finns inte

    public void Validate_Month_IsCorrect(string personnummer, bool expected)
    {
        // Anropa huvudmetoden som validerar personnummer
        var result = PersonnummerValidator.IsValid(personnummer);

        // Kontrollera att resultatet stämmer med förväntat värde
        Assert.Equal(expected, result);
    }
}
