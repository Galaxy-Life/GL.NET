namespace GL.NET.Entities;

public class UserLogins
{
    public string Id { get; set; }

    public List<Login> Logins { get; set; }
}

public class Login
{
    public ulong CommandsSinceLastLogin { get; set; }

    public DateTime Time { get; set; }
}
