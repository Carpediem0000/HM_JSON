using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
namespace HM_JSON
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Currency> currencyList = new();
            try 
            {
                currencyList = await GetCurrencyList();

            } 
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }

            int choice = 0;
            float sum;
            string res;
            do
            {
                Currency.Show(currencyList);
                await Console.Out.WriteLineAsync("Чтобы закрыть программу введите 0");
                await Console.Out.WriteLineAsync("Введите номер пары:");
                choice = int.Parse(Console.ReadLine());

                Currency currency = currencyList.FirstOrDefault(c => c.ID == choice);
                if (currency != null)
                {
                    await Console.Out.WriteLineAsync("Введите сумму в грн:");
                    sum = float.Parse(Console.ReadLine());
                    res = $"{sum} UAH = {(sum / currency.rate).ToString("F2")} {currency.cc}({currency.txt})";
                    await Console.Out.WriteLineAsync(res);
                    Console.ReadKey();
                }
                else
                {
                    await Console.Out.WriteLineAsync("Неправильный выбор");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (choice != 0);
        }
        static async Task<List<Currency>> GetCurrencyList()
        {
            var currencyList = new List<Currency>();
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                currencyList = JsonConvert.DeserializeObject<List<Currency>>(responseContent);

                return currencyList;
            }
            else
            {
                await Console.Out.WriteLineAsync("Не удалось получить информацию о валюте.");
                return new List<Currency>();
            }
        }
    }
}
