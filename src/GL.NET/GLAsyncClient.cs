using GL.NET.Entities;
using Newtonsoft.Json;

namespace GL.NET;

public class GLAsyncClient
{
    private HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) };
    private const string _baseUrl = "https://api.galaxylifegame.net";
    
    public async Task<List<ServerStatus>> GetServerStatus()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/status");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ServerStatus>>(content);
        }
        catch (Exception)
        {
            return new List<ServerStatus>() { new ServerStatus("Api Server", false, 0) };
        }
    }

    public async Task<User> GetUserById(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/get?id={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<User> GetUserByName(string name)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/name?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<User>> SearchUserByName(string name)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/search?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<User>>(content);
        }
        catch (Exception)
        {
            return new List<User>();
        }
    }

    public async Task<User> GetUserBySteamId(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/steam?steamId={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<UserStats> GetUserStats(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/stats?id={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserStats>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Alliance> GetAlliance(string name)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/alliances/get?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Alliance>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
