using Newtonsoft.Json;

namespace GL.NET.Entities;

public class WarSummary
{
    public WarSummary() { }

    public WarSummary(string enemyId, Emblem enemyLogo, string enemyName, int enemyScore, int selfScore, long startTime, long endTime, string winnerAllianceId, bool knockout)
    {
        EnemyAllianceId = enemyId;
        EnemyAllianceLogo = enemyLogo.ToString();
        EnemyAllianceName = enemyName;
        EnemyAllianceWarScore = enemyScore;
        SelfAllianceWarScore = selfScore;
        WarStartTime = startTime;
        WarEndTime = endTime;
        WinnerId = winnerAllianceId;
        OnKnockout = knockout;
    }

    [JsonProperty("enemyAllianceId")]
    public string EnemyAllianceId { get; set; }

    [JsonProperty("enemyAllianceLogo")]
    public string EnemyAllianceLogo { get; set; }

    [JsonProperty("enemyAllianceName")]
    public string EnemyAllianceName { get; set; }

    [JsonProperty("enemyAllianceWarScore")]
    public int EnemyAllianceWarScore { get; set; }

    [JsonProperty("myAllianceWarScore")]
    public int SelfAllianceWarScore { get; set; }

    [JsonProperty("warStartTime")]
    public long WarStartTime { get; set; }

    [JsonProperty("warEndTime")]
    public long WarEndTime { get; set; }

    [JsonProperty("onKnockout")]
    public bool OnKnockout { get; set; }

    [JsonProperty("winnerId")]
    public string WinnerId { get; set; }
}
