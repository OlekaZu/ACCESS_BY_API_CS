using space.Nasa.Apod.Models;
using System.Text.Json;

namespace space.Nasa.Apod
{
    public class ApodClient : INasaClient<int, Task<MediaOfToday[]>>
    {
        private string _apiKey;
        static HttpClient httpClient = new HttpClient();
        public ApodClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<MediaOfToday[]> GetAsync(int numPhotos)
        {
            string apiURL = string.Format($"https://api.nasa.gov/planetary/apod?api_key={_apiKey}&count={numPhotos}");
            using HttpResponseMessage response = await httpClient.GetAsync(apiURL);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                string error = $"\nGET\n\"{apiURL}\" returned {response.StatusCode}:\n{responseBody}\n";
                Console.WriteLine(error);
                throw new HttpRequestException(error);
            }
            string content = await response.Content.ReadAsStringAsync();
            MediaOfToday[]? photos = JsonDocument.Parse(content).Deserialize<MediaOfToday[]>();
            if (photos == null) throw new Exception("");
            return photos;
        }
    }
}

