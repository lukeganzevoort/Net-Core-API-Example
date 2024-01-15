using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

[ApiController]
[Route("[controller]")]
public class StarshipsController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public StarshipsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("pilots/{starshipName}")]
    public async Task<ActionResult<IEnumerable<string>>> GetStarshipPilots(string starshipName)
    {
        // Replace this URL with the actual URL of the SWAPI
        string starshipsApiUrl = $"https://swapi.dev/api/starships/?search={starshipName}";

        var response = await _httpClient.GetAsync(starshipsApiUrl);
        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        string content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);

        var starship = json["results"]?.First;
        if (starship == null)
        {
            return NotFound();
        }

        var pilotUrls = starship["pilots"]?.ToObject<List<string>>();
        if (pilotUrls == null || pilotUrls.Count == 0)
        {
            return Ok(new List<string>()); // No pilots found
        }

        List<string> pilotNames = new List<string>();
        foreach (var url in pilotUrls)
        {
            var pilotResponse = await _httpClient.GetAsync(url);
            if (pilotResponse.IsSuccessStatusCode)
            {
                var pilotContent = await pilotResponse.Content.ReadAsStringAsync();
                var pilotJson = JObject.Parse(pilotContent);
                pilotNames.Add(pilotJson["name"]?.ToString());
            }
        }

        return Ok(pilotNames);
    }
}





