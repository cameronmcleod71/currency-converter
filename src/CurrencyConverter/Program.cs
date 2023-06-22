using System;
using CurrencyData;

namespace CurrencyConverter // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isFinished = false;
            string commandCode = "";
            Console.WriteLine("Welcome to Currency Converter made by cameronmcleod71!");
            while (!isFinished) {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - List available countries");
                Console.WriteLine("2 - Convert a currency");
                commandCode = Console.ReadLine();
                switch (commandCode) 
                {
                    case "0":
                        Console.WriteLine("Ending runtime.");
                        isFinished = true;
                        break;
                    case "1":
                        Console.WriteLine("Getting available Countries");
                        break;
                    case "2":
                        Console.WriteLine("Note: you can use the convert command with a two country codes and a 9-digit currency.");
                        Console.WriteLine("Example dotnet run CAD USD 9 // will convert 9 dollars CAD to USD");
                        break;
                    default:
                        Console.WriteLine("Please enter a 1-digit command code listed above");
                        break;
                }
                
            }
            ApiData MyData = new ApiData();
            MyData.DeserializedCountryList();

  
        }

        private Dictionary<string, string> getAvailableCountries()
        {
            return new Dictionary<string, string>{{"USD", "United States"}};
        }

        private Dictionary<bool, string> verifyCountryCode(string currencyCode, Dictionary<string, string> countries)
        {
            return new Dictionary<bool, string>{{false, "need to write func"}};
        }

        private Dictionary<bool, string> verifyCurrency(int currency) 
        {
            return new Dictionary<bool, string>{{false, "need to write func"}};
        }

        private int getConvertedCurrency(int currency)
        {
            return 0;
        }
    }
}