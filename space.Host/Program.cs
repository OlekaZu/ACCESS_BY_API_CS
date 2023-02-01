using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using space.Nasa;
using space.Nasa.Apod;
using space.Nasa.Apod.Models;

ApiKey apiKey = new();
string? apiKeyJson = JsonConvert.SerializeObject(apiKey, Formatting.Indented);

Console.WriteLine("Input the number of photos for loading:");
string? input = Console.ReadLine();
if (!string.IsNullOrEmpty(input) && int.TryParse(input, out var inputNum) && inputNum <= 100 && inputNum >= 0)
{
    try
    {
        INasaClient<int, Task<MediaOfToday[]>> respond = new ApodClient(apiKey.ApiKeyValue);
        if (respond == null) return;
        var resultTask = respond.GetAsync(inputNum);
        var result = resultTask.Result;
        foreach (var item in result)
            Console.WriteLine(item);
    }
    catch
    {
        throw new Exception();
    }
}
else
{
    Console.WriteLine("Error input.Try again.");
}

// load configuration
internal class ApiKey
{
    public string ApiKeyValue { get; private set; }
    public ApiKey()
    {
        ConfigurationBuilder configurationBuilder = new();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        var configuration = configurationBuilder.Build();
        ApiKeyValue = configuration["ApiKey"];
    }

};