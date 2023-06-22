using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyData
{
    public class Country
    {
        public string? symbol { get; set; }
        public string? name { get; set; }
        public string? symbol_native { get; set; }
        public int decimal_digits { get; set; }
        public int rounding { get; set; }
        public string? code { get; set; }
        public string? name_plural { get; set; }

    }

    public class Data
    {
        // public List<Country> country = new List<Country>();
        public Country[] country;
    }

}