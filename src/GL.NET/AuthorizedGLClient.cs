using System.Net.Http.Headers;
using System.Timers;
using GL.NET.Entities;
using GL.NET.Exceptions;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace GL.NET;

public partial class AuthorizedGLClient : GLClient
{
    private const string _basePnUrl = "https://api.phoenixnetwork.net";
    private const string _glBetaEntitle = "galaxylife-beta";
    private string _clientId = "";
    private string _clientSecret = "";
    private string _backendToken = "";
    private string _accessToken = "";
    private Timer _tokenTimer = new Timer(6 * 60 * 60 * 1000);

    public AuthorizedGLClient(string clientId, string clientSecret, string backendToken) : base()
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _backendToken = backendToken;
        RefreshToken().GetAwaiter().GetResult();

        _tokenTimer.Start();

        _tokenTimer.Elapsed += OnTimerElapsed;
    }

    public async Task RefreshToken()
    {
        if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
        {
            _accessToken = "";
            ThrowError(new GLException($"Client Id and/or Client Secret cannot be empty/null!"));
            return;
        }

        try
        {
            var result = await _client.PostAsync("https://phoenixnetwork.eu.auth0.com/oauth/token",
                new StringContent($"{{\"client_id\":\"{_clientId}\",\"client_secret\":\"{_clientSecret}\",\"audience\":\"https://api.phoenixnetwork.net\",\"grant_type\":\"client_credentials\"}}",
                new MediaTypeHeaderValue("application/json")));
        
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await result.Content.ReadAsStringAsync());

            _accessToken = tokenResponse?.AccessToken ?? "";

            _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            _client.DefaultRequestHeaders.Add("gl-auth", _backendToken);
        }
        catch (Exception e)
        {
            _accessToken = "";
            ThrowError(e);
        }
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
        catch (Exception e)
        {
            ThrowError(e);
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
        catch (NoAuthException)
        {
            await RefreshToken();
            return null;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<FullPhoenixUser?> GetFullPhoenixUserAsync(string userId)
        => await GetFullPhoenixUserAsync(uint.Parse(userId));

    public async Task<FullPhoenixUser?> GetFullPhoenixUserAsync(uint userId)
    {
        await CheckAuth();

        try
        {
            var response = await _client.GetAsync($"{_basePnUrl}/User/getFull?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FullPhoenixUser>(content);
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return null;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return null;
        }
    }

    public async Task<bool> TryUpdateEmail(uint userId, string email)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/changeEmail?userId={userId}&email={email}", new StringContent(""));
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(content);
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryUpdateUsername(uint userId, string email)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/changeName?userId={userId}&email={email}", new StringContent(""));
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(content);
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryBanUser(string userId, string reason)
        => await TryBanUser(uint.Parse(userId), reason);

    public async Task<bool> TryBanUser(uint userId, string reason)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/banUser?userId={userId}&reason={reason}", new StringContent(""));
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(content);
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryUnbanUser(string userId)
        => await TryUnbanUser(uint.Parse(userId));

    public async Task<bool> TryUnbanUser(uint userId)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/unbanUser?userId={userId}", new StringContent(""));
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(content);
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> AddGlBeta(uint userId)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/addEntitle?userId={userId}&entitlement={_glBetaEntitle}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> RemoveGlBeta(uint userId)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/removeEntitle?userId={userId}&entitlement={_glBetaEntitle}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> GiveRoleAsync(uint userId, PhoenixRole role)
    {
        await CheckAuth();

        try
        {
            var response = await _client.PostAsync($"{_basePnUrl}/User/giveRole?userId={userId}&role={role}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (NoAuthException)
        {
            await RefreshToken();
            return false;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    private async Task CheckAuth()
    {
        if (string.IsNullOrEmpty(_accessToken))
        {
            await RefreshToken();

            // if token is empty after refresh, throw no auth
            if (string.IsNullOrEmpty(_accessToken))
            {
                throw new NoAuthException();
            }
        }
    }

    private async void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        await RefreshToken();
    }
}
