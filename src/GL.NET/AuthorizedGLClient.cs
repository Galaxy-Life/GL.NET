using GL.NET.Entities;
using Newtonsoft.Json;

namespace GL.NET;

public partial class AuthorizedGLClient
{
    private HttpClient _client;
    private const string _basePnUrl = "https://api.phoenixnetwork.net";
    private const string _glBetaEntitle = "galaxylife-beta";

    public AuthorizedGLClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<PhoenixUser?> GetPhoenixUserAsync(string userId)
        => await GetPhoenixUserAsync(uint.Parse(userId));

    public async Task<PhoenixUser?> GetPhoenixUserAsync(uint userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_basePnUrl}/User/get?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PhoenixUser>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<PhoenixUser?> GetPhoenixUserByNameAsync(string username)
    {
        try
        {
            var response = await _client.GetAsync($"{_basePnUrl}/User/getByName?username={username}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PhoenixUser>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<FullPhoenixUser?> GetFullPhoenixUserAsync(string userId)
        => await GetFullPhoenixUserAsync(uint.Parse(userId));

    public async Task<FullPhoenixUser?> GetFullPhoenixUserAsync(uint userId)
    {
        try
        {
            var response = await _client.GetAsync($"{_basePnUrl}/User/getFull?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FullPhoenixUser>(content);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> TryUpdateEmail(uint userId, string email)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/changeEmail?userId={userId}&email={email}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> TryUpdateUsername(uint userId, string email)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/changeName?userId={userId}&email={email}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> TryBanUser(string userId, string reason)
        => await TryBanUser(uint.Parse(userId), reason);

    public async Task<bool> TryBanUser(uint userId, string reason)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/banUser?userId={userId}&reason={reason}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> TryUnbanUser(string userId)
        => await TryUnbanUser(uint.Parse(userId));

    public async Task<bool> TryUnbanUser(uint userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/unbanUser?userId={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> AddGlBeta(uint userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/addEntitle?userId={userId}&entitlement={_glBetaEntitle}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> RemoveGlBeta(uint userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/removeEntitle?userId={userId}&entitlement={_glBetaEntitle}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> GiveRoleAsync(uint userId, PhoenixRole role)
    {
        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/giveRole?userId={userId}&role={role}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
