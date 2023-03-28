using GL.NET;
using GL.NET.Entities;

var creds = Environment.GetEnvironmentVariable("PhoenixApiCred").Split(';');
var client = new AuthorizedGLClient(creds[0], creds[1], creds[2]);

client.ErrorThrown += OnErrorThrown;

void OnErrorThrown(object sender, ErrorEventArgs e)
{
    var ex = e.GetException();
    System.Console.WriteLine(ex.Message);
}

// Galaxy Life Endpoints
var a = await client.GetServerStatus();

var b = await client.GetUserById("36271");
var c = await client.GetUserByName("svr333");
var d = await client.SearchUserByName("svr");
var e = await client.GetUserBySteamId("76561198240675026");
var f = await client.GetUserStats("36271");

var g = await client.GetAlliance("covenant imperium");

var h = await client.GetXpLeaderboard();
var i = await client.GetXpFromAttackLeaderboard();
var j = await client.GetRivalsWonLeaderboard();

// Phoenix Endpoints
var one = await client.GetPhoenixUserAsync(36271);
var two = await client.GetPhoenixUserByNameAsync("svr333");

// Auth Phoenix Endpoints
var three = await client.GetFullPhoenixUserAsync(36271);
var four = await client.RemoveGlBeta(36271);
var five = await client.AddGlBeta(36271);
var six = await client.GiveRoleAsync(36271, PhoenixRole.Staff);

// Backend endpoints
var seven = await client.GetChipsBoughtAsync("36271");
var eight = await client.TryAddChipsToUserAsync("36271", 1);
var nine = await client.TryAddItemToUserAsync("36271", "7000", 1);

Console.WriteLine("Done");
