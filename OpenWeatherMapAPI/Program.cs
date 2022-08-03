using System.Net.Http;
using Newtonsoft.Json.Linq;

var client = new HttpClient();  

Console.WriteLine("Enter your City Name");
var cityName = Console.ReadLine();
Console.WriteLine();

Console.Write("Enter Api Key: ");
var apiKey = Console.ReadLine();
Console.WriteLine();

var weatherApi = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";


var cityWeather = client.GetStringAsync(weatherApi).Result;

var currentCityWeather = JObject.Parse(cityWeather).GetValue("main");

Console.WriteLine($"The Weather of your City is :\n" +
    $"Temp: {currentCityWeather["temp"]} \n" +
    $"Feels Like: {currentCityWeather["feels_like"]} \n" +
    $"Min Temp: {currentCityWeather["temp_min"]} \n" +
    $"Max Temp: {currentCityWeather["temp_max"]} \n" +
    $"Pressure: {currentCityWeather["pressure"]} \n" +
    $"Humidity: {currentCityWeather["humidity"]}");
    



