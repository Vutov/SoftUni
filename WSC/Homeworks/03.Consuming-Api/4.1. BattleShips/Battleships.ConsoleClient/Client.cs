namespace Battleships.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Models;

    public class Client
    {
        private static string loginToken = string.Empty;

        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            while (line != "end")
            {
                var tokens = line.Trim().Split(' ');
                var command = tokens[1];
                switch (command)
                {
                    case "register":
                        Register(tokens);
                        break;
                    case "login":
                        Login(tokens);
                        break;
                    case "create-game":
                        CreateGame();
                        break;
                    case "join-game":
                        JoinGame(tokens);
                        break;
                    case "play":
                        Play(tokens);
                        break;
                    default:
                        Console.WriteLine("Invalid command " + command);
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static async void Register(params string[] tokens)
        {
            if (loginToken != string.Empty)
            {
                Console.WriteLine("Already logged!");
                return;
            }

            var emails = tokens[2];
            var password = tokens[3];
            var confrimPassword = tokens[4];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", emails),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmpassword", confrimPassword),  
                });
                var request = await httpClient.PostAsync("http://localhost:62858/api/account/register", content);
                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                }
                else
                {
                    Console.WriteLine("Registration successful!");
                }
            }
        }

        private static async void Login(params string[] tokens)
        {
            if (loginToken != string.Empty)
            {
                Console.WriteLine("Already logged!");
                return;
            }

            var emails = tokens[2];
            var password = tokens[3];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", emails),
                    new KeyValuePair<string, string>("password", password), 
                    new KeyValuePair<string, string>("grant_type", "password"), 
                });
                var request = await httpClient.PostAsync("http://localhost:62858/token", content);
                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                }
                else
                {
                    var response = request.Content.ReadAsAsync<LoginInfo>().Result;
                    loginToken = response.Access_token;
                    Console.WriteLine("Logic successful!");
                }
            }
        }

        private static async void CreateGame()
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("", ""), 
                });
                var request = await httpClient.PostAsync("http://localhost:62858/api/Games/create", content);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                }
                else
                {
                    var gameid = request.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Created game with id: " + gameid);
                }
            }
        }

        private static async void JoinGame(string[] tokens)
        {
            var gameId = tokens[2];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId), 
                });
                var request = await httpClient.PostAsync("http://localhost:62858/api/Games/join", content);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                }
                else
                {
                    var gameid = request.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Joined game with id: " + gameid);
                }
            }
        }

        private static async void Play(string[] tokens)
        {
            var gameId = tokens[2];
            var x = tokens[3];
            var y = tokens[4];
            var httpClient = new HttpClient();

            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToken);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId), 
                    new KeyValuePair<string, string>("PositionX", x), 
                    new KeyValuePair<string, string>("PositionY", y), 
                });
                var request = await httpClient.PostAsync("http://localhost:62858/api/Games/play", content);

                if (!request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsAsync<ErrorInfo>().Result;
                    Console.WriteLine(response.Message + " " + response.Error_description);
                }
                else
                {
                    var gameid = request.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Joined game with id: " + gameid);
                }
            }
        }
    }
}
