using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleAppCICDgruppuppgift
{
  public static class SocialSecurityNumberValidator
  {
    public static bool IsValidSocialSecurityNumber(string socialSecurityNumber)
    {
      if (string.IsNullOrWhiteSpace(socialSecurityNumber))
        return false;

      // Expected format: YYMMDD-XXXX
      if (!Regex.IsMatch(socialSecurityNumber, @"^\d{6}-\d{4}$"))
        return false;

      // Remove dash
      var digits = socialSecurityNumber.Replace("-", "");

      // Validate date part
      var datePart = digits.Substring(0, 6);

      if (!DateTime.TryParseExact(
              datePart,
              "yyMMdd",
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out _))
        return false;

      // Luhn algorithm (first 9 digits)
      int sum = 0;
      for (int i = 0; i < 9; i++)
      {
        int digit = digits[i] - '0';
        int temp = digit * (i % 2 == 0 ? 2 : 1);

        if (temp > 9)
          temp -= 9;

        sum += temp;
      }

      int controlDigit = (10 - (sum % 10)) % 10;
      int lastDigit = digits[9] - '0';

      return controlDigit == lastDigit;
    }
  }
}
