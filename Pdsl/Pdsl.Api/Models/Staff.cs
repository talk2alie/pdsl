namespace Pdsl.Api.Models
{
    public class Staff
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Suffix { get; set; }

        public Staff() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public Staff(string id, string title, string firstName, string lastName)
        {
            Id = id;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
