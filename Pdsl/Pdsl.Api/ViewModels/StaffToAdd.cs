namespace Pdsl.Api.ViewModels
{
    public class StaffToAdd
    {
        public string? Id { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Suffix { get; set; }

        public StaffToAdd()
        {
            Id = $"{Guid.NewGuid()}";
            Position = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
