namespace GL.NET.Entities;

public class LeaderboardUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}

public class ExperienceLeaderboardUser : LeaderboardUser
{
    public long Level { get; set; }
    public long Experience { get; set; }
}

public class XpFromAttackLeaderboardUser : LeaderboardUser
{
    public long Level { get; set; }
    public long Experience { get; set; }
}

public class RivalsWonLeaderboardUser : LeaderboardUser
{
    public ulong RivalsWon { get; set; }
}
