using System;
using System.Linq;


namespace ConsoleAppCICDgruppuppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Personnummerkontroll ===");
            Console.WriteLine("Ange personnummer (10 siffror, YYMMDDXXXX eller YYMMDD-XXXX):");

            string input = Console.ReadLine();

            bool isValid = SocialSecurityNumberValidator.IsValidSocialSecurityNumber(input);

            Console.WriteLine();
            Console.WriteLine(
                isValid
                ? "Personnumret är giltigt."
                : "Personnumret är ogiltigt."
            );
        }
    }
}