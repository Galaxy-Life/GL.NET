// See https://aka.ms/new-console-template for more information

using GL.NET;

var client = new GLAsyncClient();

var a = await client.GetServerStatus();

var b = await client.GetUserById("36271");
var c = await client.GetUserByName("svr333");
var d = await client.SearchUserByName("svr");
var e = await client.GetUserBySteamId("76561198240675026");
var f = await client.GetUserStats("36271");

var g = await client.GetAlliance("36271");
