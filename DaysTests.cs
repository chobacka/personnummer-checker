using ConsoleAppCICDgruppuppgift;
using Xunit;

namespace ConsoleAppCICDgruppuppgift.Tests 

{
    public class DaysTests
    {
        [Theory]
        // Testar giltiga dagar för olika månader
        [InlineData("19900101-2386", true)] // 1 januari
        [InlineData("19900131-2386", true)] // 31 januari
        [InlineData("19900430-2386", true)] // April, 30 dagar
        [InlineData("20200229-2386", true)] // Skottår, 29 feb
        [InlineData("20190228-2386", true)] // Vanligt år, 28 feb


        // Testar ogiltiga dagar
        [InlineData("19900100-2386", false)] // Dag 00           
        [InlineData("19900132-2386", false)]// Dag 32
        [InlineData("19900431-2386", false)] // April har 30 dagar
        [InlineData("20190229-2386", false)] // Ej skttår
        [InlineData("19900230-2386", false)] // Februari är max 29 dagar

        // Testar ogiltiga format
        [InlineData("1990AA01-2386", false)]
        [InlineData("199001AA-2386", false)]

        public void Validate_ShouldHandleDaysCorrectly(string pnr, bool expected)
        {
            // Act
            bool result = PersonnummerValidator.Validate(pnr);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

