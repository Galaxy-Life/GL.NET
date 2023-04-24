namespace GL.NET.Entities;

public class Alliance
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Emblem Emblem { get; set; }

    public int AllianceLevel { get; set; }

    public int WarPoints { get; set; }

    public int WarsWon { get; set; }

    public int WarsLost { get; set; }

    public bool InWar { get; set; }

    public string OpponentAllianceId { get; set; }

    public AllianceUser[] Members { get; set; }
}

public class MinimalAlliance
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Warpoints { get; set; }
    public int MemberCount { get; set; }
}
