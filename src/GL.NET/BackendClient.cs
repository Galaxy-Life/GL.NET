using Newtonsoft.Json;

namespace GL.NET;

public partial class AuthorizedGLClient
{
    private const string _baseBackendUrl = "https://lb.galaxylifeserver.net/api";

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

    public async Task<bool> TryAddChipsToUserAsync(string userId, int amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseBackendUrl}/Tasks/addChipsFallback?id={userId}&amount={amount}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryAddItemToUserAsync(string userId, string itemSku, int amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseBackendUrl}/Tasks/addItemFallback?id={userId}&itemSku={itemSku}&amount={amount}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryKickUserOfflineAsync(string userId)
    {
        // if you send request with empty userid, backend will run this for everyone
        if (string.IsNullOrEmpty(userId))
        {
            return false;
        }

        try
        {
            var response = await _client.PostAsync($"{_baseBackendUrl}/Tasks/kick?id={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> TryResetUserAsync(string userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseBackendUrl}/Tasks/reset?id={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }

    public async Task<bool> RenameAllianceAsync(string allianceId, string newName)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseBackendUrl}/Tasks/renameAlliance?allianceId={allianceId}&newName={newName}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ThrowError(e);
            return false;
        }
    }
}