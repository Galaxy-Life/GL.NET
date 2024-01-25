using GL.NET.Entities;
using Newtonsoft.Json;

namespace GL.NET;

public class ApiClient
{
    protected HttpClient _client;
    protected const string _baseGlUrl = "https://api.galaxylifegame.net";
    protected const string _baseTelemetryUrl = "https://api.telemetry.galaxylifegame.net/api";

    public ApiClient(HttpClient client)
    {
        _client = client;
    }

    public event ErrorEventHandler? ErrorThrown;
    
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

    public async Task<List<WarpointLeaderboardUser>> GetWarpointLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/warpoints");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<WarpointLeaderboardUser>>(content) ?? new List<WarpointLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<WarpointLeaderboardUser>();
        }
    }

    public async Task<List<MinimalAlliance>> GetAllianceWarpointLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Alliances/warpointLb");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<MinimalAlliance>>(content) ?? new List<MinimalAlliance>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<MinimalAlliance>();
        }
    }

    public async Task<List<ChipsLeaderboardUser>> GetChipsLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/chips");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ChipsLeaderboardUser>>(content) ?? new List<ChipsLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<ChipsLeaderboardUser>();
        }
    }

    public async Task<List<ChipsSpentLeaderboardUser>> GetChipsSpentLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/chipsSpent");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ChipsSpentLeaderboardUser>>(content) ?? new List<ChipsSpentLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<ChipsSpentLeaderboardUser>();
        }
    }

    public async Task<List<FriendsHelpedLeaderboardUser>> GetFriendsHelpedLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/friendsHelped");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<FriendsHelpedLeaderboardUser>>(content) ?? new List<FriendsHelpedLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<FriendsHelpedLeaderboardUser>();
        }
    }

    public async Task<List<GiftsReceivedLeaderboardUser>> GetGiftsReceivedLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/giftsReceived");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GiftsReceivedLeaderboardUser>>(content) ?? new List<GiftsReceivedLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<GiftsReceivedLeaderboardUser>();
        }
    }

    public async Task<List<GiftsSentLeaderboardUser>> GetGiftsSentLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/giftsSent");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<GiftsSentLeaderboardUser>>(content) ?? new List<GiftsSentLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<GiftsSentLeaderboardUser>();
        }
    }

    public async Task<List<StarsVisitedLeaderboardUser>> GetStarsVisitedLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/starsVisited");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<StarsVisitedLeaderboardUser>>(content) ?? new List<StarsVisitedLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<StarsVisitedLeaderboardUser>();
        }
    }

    public async Task<List<ObstaclesRecycledLeaderboardUser>> GetObstaclesRecycledLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/obstaclesRecycled");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ObstaclesRecycledLeaderboardUser>>(content) ?? new List<ObstaclesRecycledLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<ObstaclesRecycledLeaderboardUser>();
        }
    }

    public async Task<List<UtilityUsedLeaderboardUser>> GetUtilityUsedLeaderboard()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/utilityUsed");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UtilityUsedLeaderboardUser>>(content) ?? new List<UtilityUsedLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<UtilityUsedLeaderboardUser>();
        }
    }

    public async Task<List<SocialItemLeaderboardUser>> GetItemLeaderboard(string sku)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/item?sku={sku}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<SocialItemLeaderboardUser>>(content) ?? new List<SocialItemLeaderboardUser>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<SocialItemLeaderboardUser>();
        }
    }

    public async Task<List<AdvancedChipsLeaderboardUser>> GetAdvancedChipsLb()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Leaderboard/advChips");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<AdvancedChipsLeaderboardUser>>(content) ?? new List<AdvancedChipsLeaderboardUser>();
        }
        catch (Exception e)
        {
            return new List<AdvancedChipsLeaderboardUser>();
        }
    }

    public async Task<bool> MakeUserOwnerInAllianceAsync(string allianceId, string userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseGlUrl}/Alliances/makeUserOwnerInAlliance?allianceId={allianceId}&userId={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> KickUserFromAllianceAsync(string allianceId, string userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseGlUrl}/Alliances/removeUserFromAlliance?allianceId={allianceId}&userId={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<List<WarSummary>> GetAllianceWarlogs(string allianceId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/Alliances/getWarlogs?name={allianceId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<WarSummary>>(content) ?? new List<WarSummary>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<WarSummary>();
        }
    }

    public async Task<int> GetChipsBoughtAsync(string userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/getChipsBought?id={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return 0;
        }
    }

    public async Task<int> GetChipsSpentAsync(string userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/users/getChipsSpent?id={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(content);
        }
        catch (Exception e)
        {
            ThrowError(e);
            return 0;
        }
    }

    public async Task<List<BattleLog>> GetBattlelogTelemetry(string userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/telemetry/battlelogs?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<BattleLog>>(content) ?? new List<BattleLog>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<BattleLog>();
        }
    }

    public async Task<List<Gift>> GetGiftsTelemetry(string userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/telemetry/gifts?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Gift>>(content) ?? new List<Gift>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<Gift>();
        }
    }

    public async Task<List<Login>> GetLoginsTelemetry(string userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_baseGlUrl}/telemetry/logins?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Login>>(content) ?? new List<Login>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new List<Login>();
        }
    }

    public async Task<Dictionary<string, Dictionary<string, Fingerprint>>> GetFingerprint(string userId)
    {
        try
        {
            var token = _client.DefaultRequestHeaders.GetValues("gl-auth").FirstOrDefault();
            var response = await _client.GetAsync($"{_baseTelemetryUrl}/fingerprint/visits?userId={userId}&key={token}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Fingerprint>>>(content) ?? new Dictionary<string, Dictionary<string, Fingerprint>>();
        }
        catch (Exception e)
        {
            ThrowError(e);
            return new Dictionary<string, Dictionary<string, Fingerprint>>();
        }
    }

    private void ThrowError(Exception e)
    {
        ErrorThrown?.Invoke(this, new ErrorEventArgs(e));
    }
}
