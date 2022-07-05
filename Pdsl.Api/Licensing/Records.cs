namespace Pdsl.Api.Licensing
{
    public record Data(string Text)
    {
        public sealed override string ToString()
        {
            return Text!;
        }
    }

    public record Name(string Text) : Data(Text);

    public record Organization(string Name)
    {
        public override string ToString()
        {
            return Name!;
        }
    }

    public record Email(string Text) : Data(Text);

    public record Secret(string Text) : Data(Text);

    public record Code(string Text) : Data(Text);

    public record CryptoCode(Secret Secret, Code Code);

    public record FindVisitorModel(Name Name, Organization Organization, Email Email);

    public record Visit(Activity Activity, DateTime UtcDateTime);
}
