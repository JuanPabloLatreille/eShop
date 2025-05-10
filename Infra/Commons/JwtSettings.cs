namespace Infra.Commons;

public class JwtSettings
{
    public string Secret { get; set; } = string.Empty;

    public int ExpiracaoMinutos { get; set; }
}