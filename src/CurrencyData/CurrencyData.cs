using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace CurrencyData;
public class ApiData
{
  private string ApiKey = "CQzKEmXlvuS0YbSdHkbV2mRSLMITJY8hWUjvi6OH";
  private static readonly HttpClient client = new HttpClient();

  public string CountryListStr = "";

  public ApiData()
  {
  }

  private async Task<string> GetCountriesFromAPI()
  {
    string responseString = await client.GetStringAsync("https://api.freecurrencyapi.com/v1/currencies?apikey=CQzKEmXlvuS0YbSdHkbV2mRSLMITJY8hWUjvi6OH");
    return responseString;
  }

  public Dictionary<string, string> DeserializedCountryList()
  {
    Dictionary<string, string> DeserializedCountryList = new Dictionary<string, string>();
    Task<string> data = GetCountriesFromAPI();

    var parseResults = JObject.Parse(data.Result);
    foreach(JToken param in parseResults["data"])
    {
      DeserializedCountryList.Add((string)param.First["code"],(string)param.First["name"]);
    }
    return DeserializedCountryList;

  }
}
