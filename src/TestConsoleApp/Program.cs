using GL.NET;
using GL.NET.Entities;

var creds = Environment.GetEnvironmentVariable("PhoenixApiCred").Split(';');
var client = new GLClient(creds[0], creds[1], creds[2]);

client.ErrorThrown += OnErrorThrown;

void OnErrorThrown(object sender, ErrorEventArgs e)
{
    var ex = e.GetException();
    System.Console.WriteLine(ex.Message);
}

// Galaxy Life Endpoints
var a = await client.Api.GetServerStatus();

var b = await client.Api.GetUserById("36271");
var c = await client.Api.GetUserByName("svr333");
var d = await client.Api.SearchUserByName("svr");
var e = await client.Api.GetUserBySteamId("76561198240675026");
var f = await client.Api.GetUserStats("36271");

var g = await client.Api.GetAlliance("covenant imperium");

var h = await client.Api.GetXpLeaderboard();
var i = await client.Api.GetXpFromAttackLeaderboard();
var j = await client.Api.GetRivalsWonLeaderboard();

var k = await client.Api.GetAllianceWarlogs("unity");
var l = await client.Api.GetChipsBoughtAsync("36271");

var m = await client.Api.GetBattlelogTelemetry("2");
var n = await client.Api.GetGiftsTelemetry("2");
var o = await client.Api.GetLoginsTelemetry("2");
var p = await client.Api.GetFingerprint("2");

// Phoenix Endpoints
var one = await client.Phoenix.GetPhoenixUserAsync(36271);
var two = await client.Phoenix.GetPhoenixUserByNameAsync("svr333");

// Auth Phoenix Endpoints
var three = await client.Phoenix.GetFullPhoenixUserAsync(36271);
var four = await client.Phoenix.RemoveGlBeta(36271);
var five = await client.Phoenix.AddGlBeta(36271);
var six = await client.Phoenix.GiveRoleAsync(36271, PhoenixRole.Staff);
//var seven = await client.Phoenix.TryBanUser(12421, "Api test ban");
//var seven2 = await client.Phoenix.TryUnbanUser(315100);
// var seven3 = await client.Phoenix.DeleteAvatarAsync(47990);

// Backend endpoints
var eight = await client.Production.TryAddChipsToUserAsync("36271", 1);
var nine = await client.Production.TryAddItemToUserAsync("36271", "7000", 1);

Console.WriteLine("Done");
