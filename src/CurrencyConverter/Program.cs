using System;
using CurrencyData;

namespace CurrencyConverter // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApiData myData = new ApiData();
            Program p = new Program();
            Dictionary<String, String> countryList = p.GetAvailableCountries(myData);


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
                        foreach(KeyValuePair<string,string> kvp in countryList)
                        {
                            Console.WriteLine("Country: "+kvp.Value+ "Code: "+kvp.Key); 
                            Console.WriteLine();              
                        }
                        if(countryList.Count == 0)
                        {
                            Console.WriteLine("Sorry, no countries currently available.");
                        }
                        break;
                    case "2":
                        // Console.WriteLine("Note: you can use the convert command with a two country codes and a 9-digit currency.");
                        // Console.WriteLine("Example dotnet run CAD USD 9 // will convert 9 dollars CAD to USD");
                        try
                        {
                            Console.WriteLine("Please type a currency into the console:");
                            string givenCurrency = Console.ReadLine();
                            double currency = Double.Parse(givenCurrency);
                            Console.WriteLine("");
                            Console.WriteLine("Please enter the source currency code in capital letters:    Ex USD");
                            string source = Console.ReadLine();
                            KeyValuePair<bool, string> checkSource = p.VerifyCountryCode(source, countryList);
                            if(checkSource.Key == false) throw new Exception("Please enter a valid country code");
                            Console.WriteLine("");
                            Console.WriteLine("Please enter the destination currency code in capital letters:    Ex CAD");
                            string dest = Console.ReadLine();
                            KeyValuePair<bool, string> checkDest = p.VerifyCountryCode(dest, countryList);
                            if(checkSource.Key == false) throw new Exception("Please enter a valid country code");

                            double convertedCurrency = p.GetConvertedCurrency(myData, source, dest, currency);
                            if (convertedCurrency == 0) Console.WriteLine("Something went wrong during the conversion or the intitial currency was 0");
                            Console.WriteLine("Converted Currency: "+convertedCurrency);

                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a 1-digit command code listed above");
                        break;
                }
                
            }
        }

        private Dictionary<string, string> GetAvailableCountries(ApiData myData)
        {
            Dictionary<string, string> countryList = myData.DeserializedCountryList();
            return countryList;
        }

        private KeyValuePair<bool, string> VerifyCountryCode(string currencyCode, Dictionary<string, string> countryList)
        {
            if (countryList.Keys.Contains(currencyCode))
            {
                return new KeyValuePair<bool, string>(true, "Country exists");
            }
            return new KeyValuePair<bool, string>(false, "Country does not exist");
        }

        private KeyValuePair<bool, string> VerifyCurrency(int currency) 
        {
            if (currency > 999_999_999)
            {
                return new KeyValuePair<bool, string>(false, "Please use a number below 999,999,999");
            }  
            return new KeyValuePair<bool, string>(true, "Country exists");
        }

        private double GetConvertedCurrency(ApiData myData, string sourceCode, string destCode,double currency)
        {
            double newCurrency = myData.RunConversion(sourceCode, destCode, currency);
            return newCurrency;

        }
    }
}