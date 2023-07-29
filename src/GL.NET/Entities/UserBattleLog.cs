namespace GL.NET.Entities;

public class UserBattleLog
{
    public string Id { get; set; }

    public List<BattleLog> BattleLogs { get; set; } = new List<BattleLog>();
}

public class BattleLog
{
    public bool IsDefense { get; set; }

    public string OpponentId { get; set; }

    public string PlanetId { get; set; }

    public long CoinsLooted { get; set; }

    public long MineralsLooted { get; set; }

    public long ScoreGained { get; set; }

    public BattleType BattleType { get; set; }

    public DateTime Date { get; set; }
}

public enum BattleType
{
    Attack = 0,

    Rival = 1,

    RandomTarget = 2,

    RandomTargetBot = 3,
}