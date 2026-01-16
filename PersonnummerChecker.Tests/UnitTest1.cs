using Xunit;

namespace PersonnummerChecker.Tests;

public class MonthTests
{
    // Testar att giltiga månader (01–12) accepteras
    [Theory]
    [InlineData("19900101-1234")] // Januari
    [InlineData("19901201-1234")] // December
    [InlineData("9006151234")]    // Kort format, juni
    public void Valid_Month_Should_Be_Valid(string pnr)
    {
        Assert.True(PersonnummerValidator.IsValid(pnr));
    }

    // Testar att ogiltiga månader (00, 13+) nekas
    [Theory]
    [InlineData("19900001-1234")] // Månad 00
    [InlineData("19901301-1234")] // Månad 13
    [InlineData("9913991234")]    // Kort format, ogiltig månad
    public void Invalid_Month_Should_Be_Invalid(string pnr)
    {
        Assert.False(PersonnummerValidator.IsValid(pnr));
    }
}

