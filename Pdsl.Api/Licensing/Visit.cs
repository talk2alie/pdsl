namespace Pdsl.Api.Licensing
{
    public record Visit(Activity Activity)
    {
        public DateTime UtcDateTime { get; init; } = DateTime.UtcNow;

        public override string ToString()
        {
            return UtcDateTime.ToString();
        }
    }
}
