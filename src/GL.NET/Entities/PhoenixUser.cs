namespace GL.NET.Entities;

public class PhoenixUser
{
    public uint UserId { get; set; }

    public string? SteamId { get; set; }

    public string UserName { get; set; }

    public PhoenixRole Role { get; set; }

    public DateTime? Created { get; set; }
}

public class FullPhoenixUser : PhoenixUser
{
    public string Email { get; set; }

    public string? DiscordId { get; set; }

    public string? BanReason { get; set; }
}
