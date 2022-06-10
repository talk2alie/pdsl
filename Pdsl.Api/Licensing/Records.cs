namespace Pdsl.Api.Licensing
{
    public record UserName(string? Text);

    public record Organization(string? Name);

    public record Email(string? Text);

    public record Secret(string? Text);

    public record Code(string? Text);

    public record CryptoCode(Secret Secret, Code Code);
}
