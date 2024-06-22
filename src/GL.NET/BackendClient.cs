namespace GL.NET;

public class BackendClient
{
    private HttpClient _client;
    private string _baseUrl = "https://lb.galaxylifeserver.net/api";

    public BackendClient(HttpClient client, string baseUrl)
    {
        _client = client;
        _baseUrl = baseUrl;
    }

    public async Task<bool> TryAddChipsToUserAsync(string userId, int amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/addChipsFallback?id={userId}&amount={amount}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> TryAddItemToUserAsync(string userId, string itemSku, int amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/addItemFallback?id={userId}&itemSku={itemSku}&amount={amount}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> TryAddXpToUserAsync(string userId, int amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/addXpFallback?id={userId}&amount={amount}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
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
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/kick?id={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> TryResetUserAsync(string userId)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/reset?id={userId}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> RenameAllianceAsync(string allianceId, string newName)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/renameAlliance?allianceId={allianceId}&newName={newName}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> EnableMaintenance(uint minutes)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/enableMaintenance?minutes={minutes}", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> ReloadRules()
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/reloadRules", new StringContent(""));
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<long> GetMaintenanceTime()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/Tasks/getMaintenanceTimer");
            var content = await response.Content.ReadAsStringAsync();

            return long.Parse(content);
        }
        catch (Exception e)
        {
            return 0;
        }
    }

    public async Task<bool> RunKicker(string id = "")
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/kick?id={id}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> ResetPlanetHelps(string id)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/resetPlanetHelps?id={id}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> ForceWar(string a, string b)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/forceWar?a={a}&b={b}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> ForceStopWar(string a, string b)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/forceStopWar?a={a}&b={b}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> CompensateChips(uint amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/compensateChips?amount={amount}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> CompensateItems(string sku, uint amount)
    {
        try
        {
            var response = await _client.PostAsync($"{_baseUrl}/Tasks/compensateItems?sku={sku}&amount={amount}", new StringContent(""));

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> RestartServer()
    {
        try
        {
            var response = await _client.GetAsync($"{_baseUrl}/Tasks/restartStaging");

            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
