# PROJECT_ACCESS_NASA_API_CS
Solution for access to the [NASA API methods](<https://api.nasa.gov/>), get data about space photos and output them in the required format.

### Structure of the Project
```
 space.Nasa/
       Apod/
            Models/
                  MediaOfToday.cs
            ApodClient.cs
       INasaClient.cs
 space.Host/
       Program.cs
       appsettings.json
```

There are 2 projects: the ***space.Nasa*** is the library class, which is responsible for the logic of receiving ***"APOD (Astronomy Picture of the Day)"*** data, and the ***space.Host*** is console application, which receives data and output them.

***"APOD (Astronomy Picture of the Day)"*** is a resource that returns a collection of space photos (or videos) of the day, one of the most popular NASA resources.

The structure of output data:
```
{MediaOfToday.Date}
‘{MediaOfToday.Title}’ by {MediaOfToday.Copyright}
{MediaOfToday.Explanation}
{MediaOfToday.Url}
```

### How to Run Project
```bash
cd space.Host
dotnet run
```

**Don't forget to input your own generated API key in appsettings.json file.**

### Example of Output
![Alt text](/screenshots/output.jpg "Output example")

Photos are chosen randomly.
