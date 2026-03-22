using System.Text.Json;
using WebApiLab.Console.Models;

HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5070");
HttpResponseMessage response = await client.GetAsync("/api/people");

if (response.IsSuccessStatusCode)
{
    string jsonResponse = await response.Content.ReadAsStringAsync();

    var people = JsonSerializer.Deserialize<List<Person>>(
        jsonResponse,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    
    if (people != null)
    {
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} speaks {person.Language}");
        }
    }
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
    Console.WriteLine(await response.Content.ReadAsStringAsync());
}

HttpResponseMessage singleResponse = await client.GetAsync("/api/People/V590F92YF627HFY0");

if (response.IsSuccessStatusCode)
{
    string jsonResponse = await singleResponse.Content.ReadAsStringAsync();

    var person = JsonSerializer.Deserialize<Person>(
        jsonResponse,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    Console.WriteLine($"{person.Name} speaks {person.Language}");
}
else
{
    Console.WriteLine($"Error: {singleResponse.StatusCode}");
    Console.WriteLine(await singleResponse.Content.ReadAsStringAsync());
}