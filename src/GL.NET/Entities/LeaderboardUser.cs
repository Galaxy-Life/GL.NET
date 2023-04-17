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

public class ChipsLeaderboardUser : LeaderboardUser
{
    public long Chips { get; set; }
}

public class ChipsSpentLeaderboardUser : LeaderboardUser
{
    public ulong ChipsSpent { get; set; }
}

public class FriendsHelpedLeaderboardUser : LeaderboardUser
{
    public ulong FriendsHelped { get; set; }
}

public class GiftsReceivedLeaderboardUser : LeaderboardUser
{
    public ulong GiftsReceived { get; set; }
}

public class GiftsSentLeaderboardUser : LeaderboardUser
{
    public ulong GiftsSent { get; set; }
}

public class StarsVisitedLeaderboardUser : LeaderboardUser
{
    public ulong StarsVisited { get; set; }
}

public class ObstaclesRecycledLeaderboardUser : LeaderboardUser
{
    public ulong ObstaclesRecycled { get; set; }
}

public class UtilityUsedLeaderboardUser : LeaderboardUser
{
    public ulong UtilityUsed { get; set; }
}

public class SocialItemLeaderboardUser : LeaderboardUser
{
    public int Quantity { get; set; }
}
