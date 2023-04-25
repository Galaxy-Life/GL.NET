namespace GL.NET;

public partial class AuthorizedGLClient
{
    private const string _stagingUrl = "https://master.staging.galaxylifegame.net/api";

    public async Task<bool> ReloadStagingRules()
    {
        try
        {
            var response = await _client.PostAsync($"{_stagingUrl}/Tasks/reloadRules", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }
}
