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

            return JsonConvert.DeserializeObject<List<ServerStatus>>(content)
                ?? new List<ServerStatus>() { new ServerStatus("Api Server", false, 0) };;
        }
        catch (Exception)
        {
            return new List<ServerStatus>() { new ServerStatus("Api Server", false, 0) };
        }
    }

    public async Task<User?> GetUserById(string id)
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

    public async Task<User?> GetUserByName(string name)
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

            return JsonConvert.DeserializeObject<List<User>>(content) ?? new List<User>();
        }
        catch (Exception)
        {
            return new List<User>();
        }
    }

    public async Task<User?> GetUserBySteamId(string id)
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

    public async Task<string?> GetSteamIdByUserId(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/users/platformId?userId={id}");
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<UserStats?> GetUserStats(string id)
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

    public async Task<Alliance?> GetAlliance(string name)
    {
        try
        {
            name = name.ToLower().Trim();
            var response = await _client.GetAsync($"{_baseUrl}/alliances/get?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Alliance>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<ExperienceLeaderboardUser>> GetXpLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/Leaderboard/xp");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ExperienceLeaderboardUser>>(content) ?? new List<ExperienceLeaderboardUser>();
        }
        catch (Exception)
        {
            return new List<ExperienceLeaderboardUser>();
        }
    }

    public async Task<List<XpFromAttackLeaderboardUser>> GetXpFromAttackLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/Leaderboard/xpFromAttack");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<XpFromAttackLeaderboardUser>>(content) ?? new List<XpFromAttackLeaderboardUser>();
        }
        catch (Exception)
        {
            return new List<XpFromAttackLeaderboardUser>();
        }
    }

    public async Task<List<RivalsWonLeaderboardUser>> GetRivalsWonLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/Leaderboard/rivalsWon");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<RivalsWonLeaderboardUser>>(content) ?? new List<RivalsWonLeaderboardUser>();
        }
        catch (Exception)
        {
            return new List<RivalsWonLeaderboardUser>();
        }
    }
}
