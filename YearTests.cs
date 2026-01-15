using ConsoleAppCICDgruppuppgift;
using Xunit;

namespace ConsoleAppCICDgruppuppgift.Tests
{
    public class YearTests
    {
        [Theory]
        //År 2027 och uppåt ska inte godkännas (Framtid)
        [InlineData("20990101-2386", false)]
        [InlineData("21000101-2384", false)]
        //Årsgräns 1900-talet (Histora)
        [InlineData("19000101-2386", true)]
        // Precis under gränsen (1899)
        [InlineData("18991231-2386", false)]
        //Gammla år
        [InlineData("17900101-2386", false)]
        //12-siffrigt format
        [InlineData("19900228-2386", true)] // Vanligt år
        [InlineData("20200229-2386", true)] // Skottår
        //10-siffrigt format
        [InlineData("900101-2386", true)]
        //Orimliga format
        [InlineData("ABCD0101-2386", false)]
        public void Validate_ShouldHandleYearsCorrectly(string pnr, bool expected)
        {
            // Act
            bool result = SocialSecurityNumberValidator.IsValidSocialSecurityNumber(pnr);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}