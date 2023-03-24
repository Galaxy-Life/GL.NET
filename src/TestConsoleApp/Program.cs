﻿using GL.NET;

var creds = Environment.GetEnvironmentVariable("PhoenixApiCred").Split(';');
var client = new GLClient(creds[0], creds[1]);

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

Console.WriteLine("Done");
