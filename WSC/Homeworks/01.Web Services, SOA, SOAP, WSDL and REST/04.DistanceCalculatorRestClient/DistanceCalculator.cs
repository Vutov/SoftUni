namespace _04.DistanceCalculatorRestClient
{
    using System;
    using System.Net.Http;
    using System.Threading;

    public class DistanceCalculator
    {
        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:11111/api/points/");
            var query = "distance?startX=5&startY=5&endX=10&endY=10";
            PrintDistanceAsync(httpClient, query);
            Console.WriteLine("Just fooling around with async :)");
            Thread.Sleep(3000);
        }

        private async static void PrintDistanceAsync(HttpClient client, string query)
        {
            var response = await client.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
