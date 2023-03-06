using GL.NET;

var client = new GLAsyncClient();

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

Console.WriteLine("Done");
