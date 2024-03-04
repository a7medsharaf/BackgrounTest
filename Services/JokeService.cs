using BackgrounTest.Interfaces;
using BackgrounTest.Models;
using Newtonsoft.Json;
using System;

namespace BackgrounTest.Services
{
    public class JokeService : IJokeService
    {
        public JokeService()
        {

        }

        public List<JokeModel> GetJokes()
        {
            string json = System.IO.File.ReadAllText(@"./Resources/Jokes.json");
            var myJokes = JsonConvert.DeserializeObject<List<JokeModel>>(json);

            return myJokes;
        }

        public async void UpdateJokes()
        {
            var client = new HttpClient();
            JokeModel J = new JokeModel();
            List<JokeModel> myList;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://official-joke-api.appspot.com/random_joke"),
                Headers =
                      {
                        { "User-Agent", "insomnia/8.5.1" },
                      },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                J= JsonConvert.DeserializeObject<JokeModel>(body);
                myList = GetJokes();
                myList.Add(J);
                using (StreamWriter file = File.CreateText(@"./Resources/Jokes.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, myList);
                }
               
            }


        }
    }
}
