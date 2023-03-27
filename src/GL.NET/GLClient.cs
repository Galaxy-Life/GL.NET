using GL.NET.Entities;
using Newtonsoft.Json;

namespace GL.NET;

public partial class GLClient
{
    protected HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) };
    protected const string _baseGlUrl = "https://api.galaxylifegame.net";

    public GLClient() { }

    public event ErrorEventHandler? ErrorThrown;

    public virtual void ThrowError(Exception e)
    {
        ErrorThrown?.Invoke(this, new ErrorEventArgs(e));
    }
    
    public async Task<List<ServerStatus>> GetServerStatus()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/status");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ServerStatus>>(content)
                ?? new List<ServerStatus>() { new ServerStatus("Api Server", false, 0) };;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<ServerStatus>() { new ServerStatus("Api Server", false, 0) };
        }
    }

    public async Task<User?> GetUserById(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/get?id={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<User?> GetUserByName(string name)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/name?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<List<User>> SearchUserByName(string name)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/search?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<User>>(content) ?? new List<User>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<User>();
        }
    }

    public async Task<User?> GetUserBySteamId(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/steam?steamId={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<string?> GetSteamIdByUserId(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/platformId?userId={id}");
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<UserStats?> GetUserStats(string id)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/stats?id={id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserStats>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<Alliance?> GetAlliance(string name)
    {
        try
        {
            name = name.ToLower().Trim();
            var response = await _client.GetAsync($"{_baseGlUrl}/alliances/get?name={name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Alliance>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<List<ExperienceLeaderboardUser>> GetXpLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/xp");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ExperienceLeaderboardUser>>(content) ?? new List<ExperienceLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<ExperienceLeaderboardUser>();
        }
    }

    public async Task<List<XpFromAttackLeaderboardUser>> GetXpFromAttackLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/xpFromAttack");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<XpFromAttackLeaderboardUser>>(content) ?? new List<XpFromAttackLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<XpFromAttackLeaderboardUser>();
        }
    }

    public async Task<List<RivalsWonLeaderboardUser>> GetRivalsWonLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/rivalsWon");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<RivalsWonLeaderboardUser>>(content) ?? new List<RivalsWonLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<RivalsWonLeaderboardUser>();
        }
    }
}
