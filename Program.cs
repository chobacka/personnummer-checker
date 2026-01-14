using System;
using System.Linq;

namespace ConsoleAppCICDgruppuppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Personnummerkontroll ===");
            Console.WriteLine("Ange personnummer (10 siffror, YYMMDDXXXX):");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Fel: Inget personnummer angavs.");
                return;
            }

            if (input.Length != 10 || !input.All(char.IsDigit))
            {
                Console.WriteLine("Fel: Personnumret måste bestå av exakt 10 siffror.");
                return;
            }

            bool isValid = PersonnummerValidator.IsValid(input);

            Console.WriteLine();
            Console.WriteLine(
                isValid
                ? "Personnumret är giltigt."
                : "Personnumret är ogiltigt."
            );
        }
    }
}