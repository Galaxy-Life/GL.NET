using System.Net.Http.Headers;
using System.Timers;
using GL.NET.Entities;
using GL.NET.Exceptions;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace GL.NET;

public class GLClient
{
    protected HttpClient _client;
    public event ErrorEventHandler? ErrorThrown;
    protected const string _baseGlUrl = "https://api.galaxylifegame.net";

    // Authorization
    private string _clientId = "";
    private string _clientSecret = "";
    private string _backendToken = "";
    private string _accessToken = "";
    private Timer _tokenTimer = new Timer(6 * 60 * 60 * 1000);

    public GLClient(string clientId, string clientSecret, string backendToken, int timeout = 30)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _backendToken = backendToken;

        _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(timeout) };
        RefreshToken().GetAwaiter().GetResult();

        Api = new ApiClient(_client);
        Phoenix = new AuthorizedGLClient(_client);
        Production = new BackendClient(_client, "https://lb.galaxylifeserver.net/api");
        Staging = new BackendClient(_client, "https://master.staging.galaxylifegame.net/api");

        _tokenTimer.Start();
        _tokenTimer.Elapsed += OnTimerElapsed;
    }

    public async Task RefreshToken()
    {
        if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
        {
            _accessToken = "";
            ErrorThrown?.Invoke(this, new ErrorEventArgs(new GLException($"Client Id and/or Client Secret cannot be empty/null!")));
            return;
        }

        try
        {
            var result = await _client.PostAsync("https://phoenixnetwork.eu.auth0.com/oauth/token",
                new StringContent($"{{\"client_id\":\"{_clientId}\",\"client_secret\":\"{_clientSecret}\",\"audience\":\"https://api.phoenixnetwork.net\",\"grant_type\":\"client_credentials\"}}",
                new MediaTypeHeaderValue("application/json")));
        
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(await result.Content.ReadAsStringAsync());

            _accessToken = tokenResponse?.AccessToken ?? "";

            _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            _client.DefaultRequestHeaders.Add("gl-auth", _backendToken);
        }
        catch (Exception e)
        {
            _accessToken = "";
            ErrorThrown?.Invoke(this, new ErrorEventArgs(e));
        }
    }

    public ApiClient Api { get; set; }

    public AuthorizedGLClient Phoenix { get; set; }

    public BackendClient Production { get; set; }

    public BackendClient Staging { get; set; }

    private async void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        await RefreshToken();
    }
}
