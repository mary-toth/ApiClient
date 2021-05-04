using System;
using ApiClient.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace ApiClient
{
    class Program
    {
        class Item
        {
            public int id { get; set; }
            public string obdb_id { get; set; }
            public string name { get; set; }
            public string brewery_type { get; set; }
            public string street { get; set; }
            public string address_2 { get; set; }
            public string address_3 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string county_province { get; set; }
            public string postal_code { get; set; }
            public string country { get; set; }
            public string longitude { get; set; }
            public string latitude { get; set; }
            public string phone { get; set; }
            public string website_url { get; set; }
            public string updated_at { get; set; }
            public string created_at { get; set; }
        }
        static async Task Main(string[] args)
        {

            var keepGoing = true;

            while (keepGoing)
            {
                var client = new HttpClient();

                var token = "";

                if (args.Length == 0)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.Write("Type a state to show that state's breweries: ");
                    token = Console.ReadLine();
                    Console.WriteLine("-----------------------------------");
                }
                else
                {
                    token = args[0];
                }

                var url = $"https://api.openbrewerydb.org/breweries?by_state={token}";

                var responseAsStream = await client.GetStreamAsync(url);

                var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.name} - {item.city}, {item.state}");
                }

            }
        }
    }
}

