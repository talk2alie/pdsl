namespace Pdsl.Api.Licensing
{
    public record Name(string Text)
    {
        public override string ToString()
        {
            return Text!;
        }
    }

    public record Organization(string Name)
    {
        public override string ToString()
        {
            return Name!;
        }
    }

    public record Email(string Text)
    {
        public override string ToString()
        {
            return Text!;
        }
    }

    public record Secret(string Text)
    {
        public override string ToString()
        {
            return Text!;
        }
    }

    public record Code(string Text)
    {
        public override string ToString()
        {
            return Text!;
        }
    }

    public record CryptoCode(Secret Secret, Code Code);
}
