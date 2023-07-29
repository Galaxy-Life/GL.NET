namespace GL.NET.Entities;

public class UserGifts
{
    public string Id { get; set; }

    public List<Gift> GiftsReceived { get; set; } = new List<Gift>();
}

public class Gift
{
    public string FromUserId { get; set; }

    public string Sku { get; set; }
}