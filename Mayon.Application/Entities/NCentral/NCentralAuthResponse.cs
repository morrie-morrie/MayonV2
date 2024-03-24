namespace Mayon.Application.Entities.NCentral;

public class NCentralAuthResponse
{
    public Tokens tokens { get; set; }
    public string refresh { get; set; }
    public string validate { get; set; }
}

public class Tokens
{
    public Access access { get; set; }
    public Refresh refresh { get; set; }
}

public class Access
{
    public string token { get; set; }
    public string type { get; set; }
    public int expirySeconds { get; set; }
}

public class Refresh
{
    public string token { get; set; }
    public string type { get; set; }
    public int expirySeconds { get; set; }
}